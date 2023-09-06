
using System;
using System.Drawing;

namespace raytracer.Tests
{
	public class CanvasTest
	{
        [Fact]
        public void TestCanvas()
        {
            Canvas canvas = new Canvas(10, 20);
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Color color = canvas.pixelAt(i, j);
                    Assert.Equal(new Color(0, 0, 0), color);
                }

            }
        }

        [Fact]
        public void TestCanvasWritePixel()
        {
            Canvas canvas = new Canvas(10, 20);
            Color red = new Color(1, 0, 0);
            canvas.writePixel(2, 3, red);
            Assert.Equal(red, canvas.pixelAt(2, 3));
            
        }

        [Fact]
        public void TestCanvasRow()
        {
            Canvas canvas = new Canvas(4, 3);
            Color red = new Color(1, 0, 0);
            Color green = new Color(0, 1, 0);
            canvas.writePixel(0, 2, red);
            canvas.writePixel(1, 2, green);
            canvas.writePixel(2, 2, red);
            canvas.writePixel(3, 2, red);

            Color[] row = { red, green, red , red};
            Assert.Equal(row, canvas.row(2));

        }
    }
}

