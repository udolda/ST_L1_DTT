using System;

namespace ClassLibrary1
{
    public class MyPoint
    {
        private double latitude; //широта в градусах
        private double longtitude; //долгота в градусах

        double Latitude
        {
            get { return latitude; }
            set
            {
                if (value > 90 && value < -90) throw new ArgumentException();
                latitude = value;
            }
        }
        double Longtitude
        {
            get { return longtitude; }
            set
            {
                if (value > 180 && value < -180) throw new ArgumentException();
                longtitude = value;
            }
        }

        public enum AzimuthEnum : short {any = -2, none = -1}

        /// <summary>
        /// Стандартный конструктор
        /// </summary>
        /// <param name="latitude">Широта</param>
        /// <param name="longtitude">Долгота</param>
        public MyPoint(double latitude, double longtitude)
        {
            Latitude = latitude;
            Longtitude = longtitude;
        }

        /// <summary>
        /// Метод принимает точку 2 и находит до неё расстояние от текущей точки.
        /// </summary>
        /// <param name="point2">Точка, до которой считается расстояние.</param>
        /// <returns>Кратчайшее расстояние между двумя точками в метрах.</returns>
        public double getDistance(MyPoint point2/*double latitude1, double longtitude1, double latitude2, double longtitude2*/)
        {
            double rad = 6372795.0; //радиус Земли в метрах

            //Перевод градусов в радианы
            double latitude1 = Latitude * Math.PI / 180;
            double latitude2 = point2.Latitude * Math.PI / 180;
            double longtitude1 = Longtitude * Math.PI / 180;
            double longtitude2 = point2.Longtitude * Math.PI / 180;

            //косинусы и синусы широт и разницы долгот
            double cl1 = Math.Cos(latitude1);
            double cl2 = Math.Cos(latitude2);
            double sl1 = Math.Sin(latitude1);
            double sl2 = Math.Sin(latitude2);
            double delta = longtitude2 - longtitude1;
            double cdelta = Math.Cos(delta);
            double sdelta = Math.Sin(delta);

            //вычисления длины большого круга (кратчайшего расст. )
            double y = Math.Sqrt(Math.Pow(cl2 * sdelta, 2) + Math.Pow(cl1 * sl2 - sl1 * cl2 * cdelta, 2));
            double x = sl1 * sl2 + cl1 * cl2 * cdelta;
            double ad = Math.Atan2(y, x);
            double dist = Math.Round(ad * rad);

            return dist;
        }

        /// <summary>
        /// Находит азимут от точки point до точки 2.
        /// </summary>
        /// <param name="point2">Точка 2.</param>
        /// <returns>Азимут в градусах.</returns>
        public double getAzimuth(MyPoint point2/*double latitude1, double longtitude1, double latitude2, double longtitude2*/)
        {
            /*Если антипод, тогда результат any*/

            //Перевод градусов в радианы
            double latitude1 = Latitude * Math.PI / 180;
            double latitude2 = point2.Latitude * Math.PI / 180;
            double longtitude1 = Longtitude * Math.PI / 180;
            double longtitude2 = point2.Longtitude * Math.PI / 180;

            //косинусы и синусы широт и разницы долгот
            double cl1 = Math.Cos(latitude1);
            double cl2 = Math.Cos(latitude2);
            double sl1 = Math.Sin(latitude1);
            double sl2 = Math.Sin(latitude2);
            double delta = longtitude2 - longtitude1;
            double cdelta = Math.Cos(delta);
            double sdelta = Math.Sin(delta);

            //вычисление начального азимута
            double x = (cl1 * sl2) - (sl1 * cl2 * cdelta);
            double y = sdelta * cl2;
            double z = RadianToDegree(Math.Atan(-y / x));
            
            if (x < 0) z = z + 180;

            double z2 = (z + 180) % 360 - 180;
            z2 = -(DegreeToRadian(z2));
            double anglerad2 = z2 - ((2 * Math.PI) * Math.Floor((z2 / (2 * Math.PI))));
            double angledeg = (anglerad2 * 180) / Math.PI;

            return angledeg;
        }

        private double RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }

        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

    }
}
