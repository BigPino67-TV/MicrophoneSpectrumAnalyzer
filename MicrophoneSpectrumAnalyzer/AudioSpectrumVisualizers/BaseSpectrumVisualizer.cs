
using MicrophoneSpectrumAnalyzer.AudioSpectrumVisualizers;
using System.Drawing;
using System.Windows.Forms;
using Mmosoft.Oops;

namespace MicrophoneSpectrumAnalyzer.AudioSpectrumVisualizers
{
    public abstract class BaseSpectrumVisualizer : Control
    {
        
        // bar resources
        protected Bar[] _bars;
        protected Pen _barPen;
        protected Pen _barBgPen;

        // base line
        protected Pen _baseLinePen;
        protected Rectangle _baseLineRect;

        public BaseSpectrumVisualizer()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;

            // ring pen
            _baseLinePen = new Pen(Color.White, 4);
            _baseLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            // bar pen
            _barPen = new Pen(Color.FromArgb(255, 255, 255, 255), 4);
            _barPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            // bar bg pen
            _barBgPen = new Pen(Color.FromArgb(64, Color.White), 8);
            _barBgPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        public virtual void Set(byte[] data)
        {
            // norm data
            byte[] normData = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
                normData[i] = (byte)(data[i] / 2);
            
            // transform from origin
            _bars = Transform(normData);

            // call OnPaint
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (_bars != null)
            {
                for (int i = 0; i < _bars.Length; i++)
                {
                    var bar = _bars[i];
                    g.DrawEllipse(_baseLinePen, _baseLineRect);
                    g.DrawLine(_barPen, bar.Start, bar.End);
                    g.DrawLine(_barBgPen, bar.Start, bar.End);
                }
            }
        }

        public abstract Bar[] Transform(byte[] data);
    }
}
