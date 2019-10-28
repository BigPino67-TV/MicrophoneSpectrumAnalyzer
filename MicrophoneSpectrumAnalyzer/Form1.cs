using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

using NAudio.Wave;
using NAudio.CoreAudioApi;
using Mmosoft.Oops.Animation;
using MicrophoneSpectrumAnalyzer.AudioSpectrumVisualizers;
using WebcamCapturer.Controls.WinForms;
using WebcamCapturer.Core;
using AForge.Video.DirectShow;
using AForge.Video;

namespace MicrophoneSpectrumAnalyzer
{
    public partial class Form1 : Form
    {
        private Analyzer _analyzer;

        public Form1()
        {
            InitializeComponent();

            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#00b140");
            cmbBackgroundSource.SelectedIndex = 0;
            cmbSpectrumMode.SelectedIndex = 0;
            cmbSpectrumVisualizer.SelectedIndex = 0;
            horizontalSpectrumVisualizer1.Visible = false;

            _analyzer = new Analyzer(circleSpectrumVisualizer1, (SpectrumMode)cmbSpectrumMode.SelectedIndex, this.cmbRecordingSource);
            _analyzer.NumberOfLines = (int)txtNumLines.Value;
            _analyzer.ResetSpectrumData();
            

            circleSpectrumVisualizer1.InitializeEllipsePictureBox();
            //circleSpectrumVisualizer1.SetImageOrAnimatedGif("./background/BigPino67.jpg");
            circleSpectrumVisualizer1.SetImageOrAnimatedGif("./background/anim_bigpino67.gif");
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (this.cmbRecordingSource.Items.Count <= 0)
            {
                MessageBox.Show("No recording device found", "No recording device has been found, application will exit!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
            else
            {
                this.cmbRecordingSource.SelectedIndex = 0;
                this.cmbBackgroundSource.SelectedIndex = 0;
            }

        }

        private void CmbRecordingSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_analyzer != null) {
                _analyzer.StartNewRecording();
                _analyzer.ResetSpectrumData();
            }
                
        }

        private void CmbBackgroundSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilePath.Text = "";
            if (this.cmbBackgroundSource.SelectedIndex == 0 || this.cmbBackgroundSource.SelectedIndex > 2)
            {
                //this.cmbBackgroundSource.SelectedIndex > 2 means webcam
                lblFilePath.Visible = false;
                txtFilePath.Visible = false;
                btnBrowse.Visible = false;
            }
            else
            {
                lblFilePath.Visible = true;
                txtFilePath.Visible = true;
                btnBrowse.Visible = true;
            }

            if (this.cmbBackgroundSource.SelectedIndex == 0)
            {
                //None - Transparent
                circleSpectrumVisualizer1.SetImageOrAnimatedGif(null);
            }
            else if (this.cmbBackgroundSource.SelectedIndex == 1 || this.cmbBackgroundSource.SelectedIndex == 2)
            {
                //Image or video
                circleSpectrumVisualizer1.SetImageOrAnimatedGif("./background/please-select-file.jpg");
            }
            else
            {
                //webcam
            }
                
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            if (this.cmbBackgroundSource.SelectedIndex == 1)
            {
                //Image
                openFileDialog1.Title = "Select an image as background";
                openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif, *.tif, *.tiff) | *.jpg; *.jpeg; *.png; *.gif; *.tif; *.tiff";
            }
            else if (this.cmbBackgroundSource.SelectedIndex == 2)
            {
                openFileDialog1.Title = "Select a video as background";
                openFileDialog1.Filter = "Video files (*.mp4, *.mkv, *.flv, *.avi) | *.mp4; *.mkv; *.flv; *.avi";
            }

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                 txtFilePath.Text = openFileDialog1.FileName;

                if (this.cmbBackgroundSource.SelectedIndex == 1)
                    circleSpectrumVisualizer1.SetImageOrAnimatedGif(txtFilePath.Text);

                if (this.cmbBackgroundSource.SelectedIndex == 2)
                    circleSpectrumVisualizer1.SetVideo(txtFilePath.Text);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.circleSpectrumVisualizer1.StopVideo();
        }

        private void CmbSpectrumMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this._analyzer != null)
                this._analyzer.Mode = (SpectrumMode)cmbSpectrumMode.SelectedIndex;
        }

        private void TxtNumLines_ValueChanged(object sender, EventArgs e)
        {
            this._analyzer.NumberOfLines = (int)txtNumLines.Value;
            _analyzer.ResetSpectrumData();
        }

        private void CmbSpectrumVisualizer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this._analyzer != null) {
                if (cmbSpectrumVisualizer.SelectedIndex == 0)
                {
                    circleSpectrumVisualizer1.Visible = true;
                    _analyzer.SpectrumVisualizer = circleSpectrumVisualizer1;
                    _analyzer.ResetSpectrumData();

                    horizontalSpectrumVisualizer1.Visible = false;
                }
                else
                {
                    horizontalSpectrumVisualizer1.Visible = true;
                    _analyzer.SpectrumVisualizer = horizontalSpectrumVisualizer1;
                    _analyzer.ResetSpectrumData();

                    circleSpectrumVisualizer1.Visible = false;
                }
            }
        }
    }

}
