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

        public long Width => values.GetLongLength(0);
        public long Height => values.GetLongLength(1);

        public void writePixel(int x, int y, Color color)
		{
			values[x, y] = color;
		}

		public Color[] row(int i)
		{
			return Enumerable.Range(0, values.GetLength(0))
                .Select(x => pixelAt(x, i))
                .ToArray();
        }

        public Color pixelAt(int x, int y)
        {
            Color color = values[x, y];
			return color is null ? Color.Black : color;
        }
    }
}

