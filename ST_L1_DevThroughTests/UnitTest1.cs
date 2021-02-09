using System;
using Xunit;
using ClassLibrary1;

namespace ST_L1_DevThroughTests
{
    public class UnitTest1
    {
        /// <summary>
        /// ѕроверка правильности поиска рассто€ни€.
        /// </summary>
        [Fact]
        public void Distance1()
        {
            MyPoint point = new MyPoint(77.1539, -139.398);
            Assert.Equal(17166029, point.getDistance(new MyPoint(-77.1804, -139.55)));
        }

        [Fact]
        public void Distance2()
        {
            MyPoint point = new MyPoint(77.1539, 120.398);
            Assert.Equal(225883, point.getDistance(new MyPoint(77.1804, 129.55)));
        }

        [Fact]
        public void Distance3()
        {
            MyPoint point = new MyPoint(77.1539, -120.398);
            Assert.Equal(2332669, point.getDistance(new MyPoint(77.1804, 129.55)));
        }

        /// <summary>
        /// ѕроверка правильности поиска азимута.
        /// </summary>
        [Fact]
        public void Azimuth1()
        {
            MyPoint point = new MyPoint(77.1539, -139.398);
            Assert.Equal(180.07786781052403, point.getAzimuth(new MyPoint(-77.1804, -139.55)));
        }

        [Fact]
        public void Azimuth2()
        {
            MyPoint point = new MyPoint(77.1539, 120.398);
            Assert.Equal(84.79251590333678, point.getAzimuth(new MyPoint(77.1804, 129.55)));
        }

        [Fact]
        public void Azimuth3()
        {
            MyPoint point = new MyPoint(77.1539, -120.398);
            Assert.Equal(324.3841127040391, point.getAzimuth(new MyPoint(77.1804, 129.55)));
        }

        /// <summary>
        /// ѕроверка принадлежности выходных значений интервалу [0; 360).
        /// </summary>
        [Fact]
        public void Azimuth4()
        {
            MyPoint point = new MyPoint(77.1539, -120.398);
            Assert.InRange(point.getAzimuth(new MyPoint(77.1804, 129.55)), 0, 359.999999);
        }

        [Fact]
        public void AzimuthAntipod1()
        {
            MyPoint point = new MyPoint(40.698470, -73.951442);
            Assert.Equal(MyPoint.AzimuthEnum.any.ToString(), point.getAzimuth(new MyPoint(-40.698470, 106.048558)).ToString());
        }

    }
}
