
namespace Travel
{
    using System;

    [Serializable]
    public class City
    {
        public City(string name, double latitude, double longitude)
        {
            _Name = name;
            _Latitude = latitude;
            _Longitude = longitude;
        }

        public string _Name { set; get; }
        public double _Latitude { get; set; }
        public double _Longitude { get; set; }

        public double GetDistanceFromPosition(double latitude, double longitude)
        {
            var R = 6371; // radius of the earth in km 

            var dLat = DegreesToRadians(latitude - _Latitude);
            var dLon = DegreesToRadians(longitude - _Longitude);
            var a = System.Math.Sin(dLat / 2) * System.Math.Sin(dLat / 2) +
                System.Math.Cos(DegreesToRadians(_Latitude)) *
                System.Math.Cos(DegreesToRadians(latitude)) *
                System.Math.Sin(dLon / 2) *
                System.Math.Sin(dLon / 2);

            var c = 2 * System.Math.Atan2(System.Math.Sqrt(a), System.Math.Sqrt(1 - a));
            var d = R * c;

            // distance in km 
            return d;
        }

        private static double DegreesToRadians(double deg)
        {
            return deg * (System.Math.PI / 180);
        }

        public byte[] ToBinaryString()
        {
            var result = new byte[6];
            return result;
        }

        public override bool Equals(object obj)
        {
            var item = obj as City;
            return Equals(item);
        }

        protected bool Equals(City other)
        {
            return string.Equals(_Name, other._Name) &&
            _Latitude.Equals(other._Latitude) &&
            _Longitude.Equals(other._Longitude);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_Name != null ? _Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _Latitude.GetHashCode();
                hashCode = (hashCode * 397) ^ _Longitude.GetHashCode();
                return hashCode;
            }
        }
    } 
}
