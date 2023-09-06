using System;
using System.Drawing;

namespace raytracer.Tests
{
	public class ColorTest
	{
        [Fact]
        public void TestColor()
        {
            Color color = new Color(-0.2, 0.4, 1.7);
            Assert.Equal(-0.2, color.R);
            Assert.Equal(0.4, color.G);
            Assert.Equal(1.7, color.B);
        }

        [Fact]
        public void TestAddColor()
        {
            Color color1 = new Color(0.9, 0.6, 0.75);
            Color color2 = new Color(0.7, 0.1, 0.25);
            Color color3 = color1 + color2;
            Assert.Equal(new Color(1.6, 0.7, 1.0), color3);
        }

        [Fact]
        public void TestSubtractColor()
        {
            Color color1 = new Color(0.9, 0.6, 0.75);
            Color color2 = new Color(0.7, 0.1, 0.25);
            Color color3 = color1 - color2;
            Assert.Equal(new Color(0.2, 0.5, 0.5), color3);
        }

        [Fact]
        public void TestMultiplyColorScalar()
        {
            Color color = 2 * new Color(0.2, 0.3, 0.4);
            Assert.Equal(new Color(0.4, 0.6, 0.8), color);
        }

        [Fact]
        public void TestMultiplyColorColor()
        {
            Color color1 = new Color(1, 0.2, 0.4);
            Color color2 = new Color(1, 0.2, 0.4);
            Color color3 = new Color(0.9, 0.2, 0.04);
            Assert.Equal(color3, color1 * color2);
        }

    }
}

