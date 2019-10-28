using Mmosoft.Oops;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MicrophoneSpectrumAnalyzer.AudioSpectrumVisualizers
{
    public class HorizontalSpectrumVisualizer : BaseSpectrumVisualizer
    {
        private const int BAR_PADDING = 2;

        public HorizontalSpectrumVisualizer() : base()
        {
        }

        public override void Set(byte[] data)
        {
            base.Set(data);
        }

        public override Bar[] Transform(byte[] data)
        {
            // width for bar is full width of control
            int widthForBar = this.Width - 1;
            // height for bar fully the part of control, except the bottom used base line
            // BarPadding + BaseLinePenWidth + BarPadding + BarBackgroundPenWidth/2
            int heightForBar = this.Height - 1 - (int)_baseLinePen.Width - BAR_PADDING * 2 - (int)(_barBgPen.Width / 2);
            int bottomHeightForBar = this.Height - 1 - (int)_baseLinePen.Width - BAR_PADDING * 2;

            // get max data value
            byte max = 1;
            for (int i = 0; i < data.Length; i++)
            {
                if (max < data[i])
                    max = data[i];
            }
            // scale ratio to ensure entire bar will fit available height for bar.
            float heightRatio = heightForBar * 1f / max;

            // the number of padding is greater than bar is 1
            // padding , bar , padding , bar , ... , bar, padding
            float barPaddingWidth = (widthForBar - BAR_PADDING) * 1f / data.Length;

            // cache: better for calculation
            int firstSpace = BAR_PADDING + (int)(_barPen.Width / 2);

            // init bar
            Bar[] bars = new Bar[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                int barILeft = (int)(firstSpace + barPaddingWidth * i);

                bars[i] = new Bar
                {
                    End = new Point(barILeft, bottomHeightForBar - (int)(data[i] * heightRatio)),
                    Start = new Point(barILeft, bottomHeightForBar),
                };
            }

            return bars;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int baseLineY = this.Height - 1 - (int)_baseLinePen.Width / 2;
            e.Graphics.DrawLine(_baseLinePen, 
                new Point(0, baseLineY), 
                new Point(this.Width - 1, baseLineY));
        }
    }
}
