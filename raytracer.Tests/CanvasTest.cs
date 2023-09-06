
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
    }
}

