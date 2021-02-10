using System;
using Xunit;
using ClassLibrary1;

namespace ST_L1_DevThroughTests
{
    public class UnitTest1
    {
        /// <summary>
        /// Проверка правильности поиска расстояния.
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
        /// Проверка расчёта расстояния по меньшей дуге (комментарий 9)
        /// </summary>
        [Fact]
        public void DistanceSmallest1()
        {
            MyPoint point = new MyPoint(0, 0);
            Assert.InRange(point.getDistance(new MyPoint(0.000000, -179.000000)), 0, Math.PI * 6372795.0);
            Assert.InRange(point.getDistance(new MyPoint(0.000000, 179.000000)), 0, Math.PI * 6372795.0);
        }

        /// <summary>
        /// Проверка правильности поиска азимута.
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
        /// Проверка принадлежности выходных значений интервалу [0; 360) (комментарий 1).
        /// </summary>
        [Fact]
        public void Azimuth4()
        {
            MyPoint point = new MyPoint(77.1539, -120.398);
            Assert.InRange(point.getAzimuth(new MyPoint(77.1804, 129.55)), 0, 359.999999);
        }

        /// <summary>
        /// Проверка для точек-антиподов (комментарий 2).
        /// </summary>
        [Fact]
        public void AzimuthAntipod1()
        {
            MyPoint point = new MyPoint(40.698470, -73.951442);
            Assert.Equal(-2.0, point.getAzimuth(new MyPoint(-40.698470, 106.048558)));
        }

        [Fact]
        public void AzimuthAntipod2()
        {
            MyPoint point = new MyPoint(-43.530955, 172.636645);
            Assert.Equal(-2.0, point.getAzimuth(new MyPoint(43.530955, -7.363355)));
        }

        [Fact]
        public void AzimuthAntipod3()
        {
            MyPoint point = new MyPoint(0, 0);
            Assert.Equal(-2.0, point.getAzimuth(new MyPoint(0, -180)));
        }

        /// <summary>
        /// Проверка для одинаковых точек (комментарий 3).
        /// </summary>
        [Fact]
        public void AzimuthSame1()
        {
            MyPoint point = new MyPoint(40.698470, -73.951442);
            Assert.Equal(-1.0, point.getAzimuth(new MyPoint(40.698470, -73.951442)));
        }

        /// <summary>
        /// Одна точка на северном полюсе, вторая не на полюсе (комментарий 4).
        /// </summary>
        [Fact]
        public void AzimuthPolus1()
        {
            MyPoint point = new MyPoint(90, 0);
            Assert.Equal(180, point.getAzimuth(new MyPoint(55.750446, 37.617494)));
        }

        /// <summary>
        /// Одна точка на южном полюсе, вторая не на полюсе (комментарий 7).
        /// </summary>
        [Fact]
        public void AzimuthPolus2()
        {
            MyPoint point = new MyPoint(-90, 0);
            Assert.Equal(180, point.getAzimuth(new MyPoint(55.750446, 37.617494)));
        }

        /// <summary>
        /// Обе точки на одном из полюсов, т.е. совпадает только широта (комментарий 5).
        /// </summary>
        [Fact]
        public void AzimuthPolus3()
        {
            MyPoint point = new MyPoint(-90, 0);
            Assert.Equal(-1.0, point.getAzimuth(new MyPoint(-90, 37.617494)));

            point = new MyPoint(90, 0);
            Assert.Equal(-1.0, point.getAzimuth(new MyPoint(90, 37.617494)));
        }

        /// <summary>
        /// Точки на противположных полюсах (комментарий 6).
        /// </summary>
        [Fact]
        public void AzimuthPolus4()
        {
            MyPoint point = new MyPoint(-90, 0);
            Assert.Equal(-2.0, point.getAzimuth(new MyPoint(90, 0)));

            point = new MyPoint(90, 0);
            Assert.Equal(-2.0, point.getAzimuth(new MyPoint(-90, 37.617494)));
        }

        /// <summary>
        /// Проверка азимута для двух точек на экваторе (комментарий 8).
        /// </summary>
        [Fact]
        public void AzimuthEquator1()
        {
            MyPoint point = new MyPoint(0, 0);
            Assert.Equal(90, point.getAzimuth(new MyPoint(0, 90)));
        }

        [Fact]
        public void AzimuthEquator2()
        {
            MyPoint point = new MyPoint(0, 90);
            Assert.Equal(270, point.getAzimuth(new MyPoint(0, 0)));
        }

        [Fact]
        public void AzimuthMeridian1()
        {
            MyPoint point = new MyPoint(0, 0);
            Assert.Equal(0, point.getAzimuth(new MyPoint(10, 0)));

            point = new MyPoint(10, 0);
            Assert.Equal(180, point.getAzimuth(new MyPoint(0, 0)));
        }

    }
}
