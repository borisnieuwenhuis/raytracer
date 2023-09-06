using System;
using System.Drawing;

namespace raytracer
{
	public class PPM
	{
		private readonly Canvas canvas;
        private int rowIndex = 0;

        public PPM(Canvas canvas)
        {
            this.canvas = canvas;
        }

        public string header()
		{
			return String.Format("P3\n{0} {1}\n255", this.canvas.Width, this.canvas.Height);
		}

        private double scale(double value, double scaleFactor)
        {
            if (value < 0)
            {
                return 0;
            }
            return scaleFactor * value < 255 ? Math.Ceiling(scaleFactor * value) : 255;
        }


        public String colorString(Canvas canvas, int scaleFactor = 1)
        {
            List<String> s = new List<string>();
            while (rowIndex < this.canvas.Height)
            {
                List<String> line = new List<string>();
                Color[] row = canvas.row(rowIndex);
                foreach (Color color in row)
                {
                    line.Add(String.Format("{0} {1} {2}",
                        scale(color.R, scaleFactor), scale(color.G, scaleFactor), scale(color.B, scaleFactor)));    
                }
                rowIndex += 1;
                s.Add(String.Join(" ", line));
            }
            return String.Join("\n", s);
        }

    }
}

