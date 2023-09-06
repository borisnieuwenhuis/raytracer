using System;
namespace raytracer.Tests
{
	public class PPMTest
	{
        [Fact]
        public void TestCanvasHeader()
        {
            String expectedHeader = "P3\n5 3\n255";
            Canvas canvas = new Canvas(5, 3);
            PPM ppm = new PPM(canvas);
            String header = ppm.header();
            Assert.Equal(expectedHeader, header);
        }

        [Fact]
        public void TestCanvasPixels()
        {
            Color color1 = new Color(1.5, 0, 0);
            Color color2 = new Color(0, 0.5, 0);
            Color color3 = new Color(-0.5, 0, 1);

            Canvas canvas = new Canvas(5, 3);
            PPM ppm = new PPM(canvas);
            canvas.writePixel(0, 0, color1);
            canvas.writePixel(2, 1, color2);
            canvas.writePixel(4, 2, color3);
            String colors = ppm.colorString(canvas, scaleFactor: 255);
            
            String[] expectedColorsLines = new String[] {
                "255 0 0 0 0 0 0 0 0 0 0 0 0 0 0",
                "0 0 0 0 0 0 0 128 0 0 0 0 0 0 0",
                "0 0 0 0 0 0 0 0 0 0 0 0 0 0 255"
            };

            String expectedColors = String.Join("\n", expectedColorsLines).Trim('\n');
            Assert.Equal(expectedColors, colors);
        }
    }
}

