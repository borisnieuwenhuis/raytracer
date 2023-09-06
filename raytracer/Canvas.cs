using System;
namespace raytracer
{
	public class Canvas
	{
		

		private Color[,] values;

		public Canvas(int x, int y)
		{
            values = new Color[x, y];	
		}

		public void writePixel(int x, int y, Color color)
		{
			values[x, y] = color;
		}

        public Color pixelAt(int x, int y)
        {
            Color color = values[x, y];
			return color is null ? Color.Black : color;
        }
    }
}

