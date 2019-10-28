using AForge.Video;
using AForge.Video.DirectShow;
using MicrophoneSpectrumAnalyzer.AudioSpectrumVisualizers;
using Mmosoft.Oops;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MicrophoneSpectrumAnalyzer.AudioSpectrumVisualizers
{
    public class CircleSpectrumVisualizer : BaseSpectrumVisualizer
    {
        // the distance from original point to the ring base
        private int _padding;
        // origin point
        private Point _originLocation;
     
        // image resources
        private Image _img;
        private GraphicsPath _imgGraphicsPath;
        private Brush _overlayBr;
        private EllipsePictureBox _ellipsePB;
        private FileVideoSource _videoSource;

        /// <summary>
        /// Get or set image
        /// </summary>
        public Image Img
        {
            get
            {
                return _img;
            }
            set
            {
                _img = value;
                Invalidate();
            }
        }

        public CircleSpectrumVisualizer()
            : base()
        {
            _overlayBr = new SolidBrush(Color.FromArgb(0, 255, 255, 255));
            _padding = 100;

            _ellipsePB = new EllipsePictureBox();           
            this.Controls.Add(_ellipsePB);
        }

        public override void Set(byte[] data)
        {
            _originLocation = new Point(this.Width / 2, this.Height / 2);
            /*_baseLineRect = new Rectangle(_originLocation.X, _originLocation.Y, _padding * 2, _padding * 2)
                .MoveXY(-_padding, -_padding)
                .DecreaseSizeFromCenter(8, 8);*/
            _baseLineRect = new Rectangle(_originLocation.X, _originLocation.Y, _padding * 2, _padding * 2)
                .AdjustXY(-_padding, -_padding)
                .AdjustSizeFromCenter(-8, -8);

            if (_imgGraphicsPath != null)
                _imgGraphicsPath.Dispose();

            _imgGraphicsPath = new System.Drawing.Drawing2D.GraphicsPath();
            _imgGraphicsPath.AddEllipse(_baseLineRect);

            base.Set(data);
        }

        

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (_img != null && _imgGraphicsPath != null)
            {
                g.SetClip(_imgGraphicsPath);
                g.DrawImage(_img, _baseLineRect);
                g.FillRectangle(_overlayBr, _baseLineRect);
            }
        }

        public override Bar[] Transform(byte[] data)
        {
            return Transform(_originLocation, data, _padding);
        }

        // 
        private Bar[] Transform(Point origin, byte[] barValues, int distanceFromOrigin)
        {
            int barCount = barValues.Length;
            var bars = new Bar[barCount];
            double anglePerBar = 2 * Math.PI / barCount;
            double angle = 0;
            for (int i = 0; i < barCount; i++)
            {
                bars[i] = GetBar(origin, angle, barValues[i], distanceFromOrigin);
                angle += anglePerBar;
            }
            return bars;
        }

        private PointF GetPoint(Point origin, double angle, int distance)
        {
            float x = (float)(origin.X - distance * Math.Sin(angle));
            float y = (float)(origin.Y - distance * Math.Cos(angle));

            return new PointF
            {
                X = x,
                Y = y
            };
        }

        private Bar GetBar(Point origin, double angle, byte barValue, int distanceFromOrigin)
        {
            var start = GetPoint(origin, angle, distanceFromOrigin);
            var end = GetPoint(origin, angle, distanceFromOrigin + barValue);
            return new Bar { Start = start, End = end };
        }

        public void InitializeEllipsePictureBox()
        {
            _ellipsePB.Size = new Size(_padding * 2 - 15, _padding * 2 - 15);
            _ellipsePB.BackColor = Color.Transparent;
            _ellipsePB.Parent = this;

            var posx = _originLocation.X + (this.Width / 2);
            var posy = _originLocation.Y + (this.Height / 2);
            var pos = new Point(posx - _ellipsePB.Width / 2, posy - _ellipsePB.Height / 2);
            _ellipsePB.Location = pos;
        }

        public void SetImageOrAnimatedGif(string filepath)
        {
            if (string.IsNullOrEmpty(filepath))
            {
                _ellipsePB.Image = null;
            }
            else
            {
                Image img = Image.FromFile(filepath);
                _ellipsePB.Image = img;
                _ellipsePB.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        public void SetVideo(string filepath)
        {
            if (_videoSource != null) {
                _videoSource.SignalToStop();
                _videoSource = null;
            }
                
            _videoSource = new FileVideoSource(filepath);
            // set NewFrame event handler
            _videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
            _videoSource.PlayingFinished += new PlayingFinishedEventHandler(videoFinished);
            _videoSource.VideoSourceError += new VideoSourceErrorEventHandler(videoSource_Error);
            _videoSource.Start();
        }
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // get new frame
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            // process the frame
            _ellipsePB.Image = bitmap;
            _ellipsePB.Invalidate();
        }

        private void videoSource_Error(object sender, VideoSourceErrorEventArgs eventArgs)
        {
            MessageBox.Show(eventArgs.Description + "\r\n This application needs K-Lite", "Video source error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void videoFinished(object sender, ReasonToFinishPlaying reason)
        {
            if (reason == ReasonToFinishPlaying.EndOfStreamReached) {
                
                this.SetVideo(_videoSource.Source);
            }
        }

        public void StopVideo() {
            if (_videoSource != null)
                _videoSource.SignalToStop();
            _videoSource = null;
        }

        public void SetWebcam()
        {

        }
    }

    
}
