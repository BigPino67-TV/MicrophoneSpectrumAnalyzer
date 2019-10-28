using MicrophoneSpectrumAnalyzer.AudioSpectrumVisualizers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Threading;

using NAudio.Wave;
using NAudio.CoreAudioApi;
using Mmosoft.Oops.Animation;
using System.Linq;

namespace MicrophoneSpectrumAnalyzer
{

    internal class Analyzer
    {
        public List<byte> _spectrumdata;   //spectrum data buffer

        //
        private WaveIn _wi;
        private BufferedWaveProvider _bwp;
        
        private ComboBox _cmbRecordingDeviceList;       //device list
        
        
        private double peakAmplitudeSeen = 0;

        private char WhiteSpace = " ".ToCharArray()[0];
        private int RATE = 44100; // sample rate of the sound card
        private int BUFFERSIZE = (int)Math.Pow(2, 11); // must be a multiple of 2

        public BaseSpectrumVisualizer SpectrumVisualizer { get; set; }//spectrum dispay control
        public SpectrumMode Mode { get; set; }
        public int NumberOfLines{ get; set; }
        //ctor
        public Analyzer(BaseSpectrumVisualizer audioSpectrumVisualizer, SpectrumMode mode, ComboBox devicelist)
        {
            _spectrumdata = new List<byte>();
            SpectrumVisualizer = audioSpectrumVisualizer;
            _cmbRecordingDeviceList = devicelist;
            Mode = mode;
            Init();
        }

        // flag for enabling and disabling program functionality
        public void StartNewRecording()
        {
            string recordingSource = this._cmbRecordingDeviceList.SelectedItem.ToString();
            int newWaveInDeviceNumber = int.Parse(recordingSource.Split(this.WhiteSpace)[0].Trim());

            if (_wi != null)
            {
                _wi.StopRecording();
                _wi.Dispose();
            }

            _wi = new WaveIn();
            _wi.DeviceNumber = newWaveInDeviceNumber;
            _wi.WaveFormat = new NAudio.Wave.WaveFormat(RATE, 1);
            _wi.BufferMilliseconds = (int)((double)BUFFERSIZE / (double)RATE * 1000.0);
            _wi.DataAvailable += new EventHandler<WaveInEventArgs>(AudioDataAvailable);
            _bwp = new BufferedWaveProvider(_wi.WaveFormat);
            _bwp.BufferLength = BUFFERSIZE * 2;
            _bwp.DiscardOnBufferOverflow = true;
            try
            {
                _wi.StartRecording();
                
            }
            catch
            {
                string msg = "Could not record from audio device!\n\n";
                msg += "Is your microphone plugged in?\n";
                msg += "Is it set as your default recording device?";
                MessageBox.Show(msg, "ERROR");
            }





                
            System.Threading.Thread.Sleep(500);
        }

        public void ResetSpectrumData() {
            _spectrumdata.Clear();
            _spectrumdata = Enumerable.Repeat((byte)0.00, NumberOfLines).ToList();
        }

        // initialization
        private void Init()
        {
            int waveInDevices = WaveIn.DeviceCount;
            for (int waveInDeviceNumber = 0; waveInDeviceNumber < waveInDevices; waveInDeviceNumber++)
            {
                WaveInCapabilities deviceInfo = WaveIn.GetCapabilities(waveInDeviceNumber);
                _cmbRecordingDeviceList.Items.Add(String.Format("{0} : {1}", waveInDeviceNumber, deviceInfo.ProductName));
            }
        }

        void AudioDataAvailable(object sender, WaveInEventArgs args)
        {
            if (Mode == SpectrumMode.AMPLITUDE)
                SetDataAmplitude(args);
            else
                SetDataFFT(args);
        }

        private void SetDataFFT(WaveInEventArgs args)
        {
            int bytesPerSample = _wi.WaveFormat.BitsPerSample / 8;
            int samplesRecorded = args.BytesRecorded / bytesPerSample;
            Int16[] dataPcm = new Int16[samplesRecorded];
            for (int i = 0; i < samplesRecorded; i++)
                dataPcm[i] = BitConverter.ToInt16(args.Buffer, i * bytesPerSample);

            // the PCM size to be analyzed with FFT must be a power of 2
            int fftPoints = 2;
            while (fftPoints * 2 <= dataPcm.Length)
                fftPoints *= 2;

            // apply a Hamming window function as we load the FFT array then calculate the FFT
            NAudio.Dsp.Complex[] fftFull = new NAudio.Dsp.Complex[fftPoints];
            for (int i = 0; i < fftPoints; i++)
                fftFull[i].X = (float)(dataPcm[i] * NAudio.Dsp.FastFourierTransform.HammingWindow(i, fftPoints));
            NAudio.Dsp.FastFourierTransform.FFT(true, (int)Math.Log(fftPoints, 2.0), fftFull);

            double[] dataFft = new double[fftPoints / 2];
            byte[] data = new byte[fftPoints / 2];

            for (int i = 0; i < fftPoints / 2; i++)
            {
                double fftLeft = Math.Abs(fftFull[i].X + fftFull[i].Y);
                double fftRight = Math.Abs(fftFull[fftPoints - i - 1].X + fftFull[fftPoints - i - 1].Y);
                dataFft[i] = fftLeft + fftRight;
                data[i] = (byte)(fftLeft + fftRight);
            }

            /*if(SpectrumVisualizer.GetType().Name == "CircleSpectrumVisualizer")
                SpectrumVisualizer.Set(GetNiceCircleFFT(data));
            else
                SpectrumVisualizer.Set(data);*/

            SpectrumVisualizer.Set(GetNiceFftData(data, SpectrumVisualizer.GetType().Name == "CircleSpectrumVisualizer"));
        }

        private void SetDataAmplitude(WaveInEventArgs args) {
            int bytesPerSample = _wi.WaveFormat.BitsPerSample / 8;
            int samplesRecorded = args.BytesRecorded / bytesPerSample;
            Int16[] lastBuffer = new Int16[samplesRecorded];
            for (int i = 0; i < samplesRecorded; i++)
                lastBuffer[i] = BitConverter.ToInt16(args.Buffer, i * bytesPerSample);
            int lastBufferAmplitude = lastBuffer.Max() - lastBuffer.Min();
            double amplitude = (double)lastBufferAmplitude / Math.Pow(2, _wi.WaveFormat.BitsPerSample);
            if (amplitude > peakAmplitudeSeen)
                peakAmplitudeSeen = amplitude;
            amplitude = amplitude / peakAmplitudeSeen * 100;

            //_spectrumdata.Clear();
            if (_spectrumdata.Count >= NumberOfLines)
                _spectrumdata.RemoveAt(0);

            double regleDe3 = amplitude * 255 / 100;
            int y = Convert.ToInt32(regleDe3);
            if (y > 255) y = 255;
            if (y < 0) y = 0;
            _spectrumdata.Add((byte)y);



            SpectrumVisualizer.Set(_spectrumdata.ToArray());

        }

        public double[] FFT(double[] data)
        {
            double[] fft = new double[data.Length];
            System.Numerics.Complex[] fftComplex = new System.Numerics.Complex[data.Length];
            for (int i = 0; i < data.Length; i++)
                fftComplex[i] = new System.Numerics.Complex(data[i], 0.0);
            Accord.Math.FourierTransform.FFT(fftComplex, Accord.Math.FourierTransform.Direction.Forward);
            for (int i = 0; i < data.Length; i++)
                fft[i] = fftComplex[i].Magnitude;
            return fft;
        }

        public byte[] GetNiceFftData(byte[] data, bool circleMode)
        {
            List<byte> dataFFT_even = new List<byte>();
            List<byte> dataFFT_odd = new List<byte>();

            int lenght = Math.Min(NumberOfLines, data.Length);

            for (int i = 0; i < lenght; i++)
            {
                if (i % 2 == 0)
                    dataFFT_even.Add(data[i]);
                else
                    dataFFT_odd.Add(data[i]);
            }
            if (circleMode)
                dataFFT_odd.Reverse();
            else
                dataFFT_even.Reverse();

            List<byte> dataFFT = new List<byte>();
            dataFFT.AddRange(dataFFT_even);
            dataFFT.AddRange(dataFFT_odd);
            return dataFFT.ToArray();
        }
    }
}
