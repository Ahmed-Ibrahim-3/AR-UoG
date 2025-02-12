using System;
using System.Net.Security;
using Mapbox.Unity.Location;
using Mapbox.Utils;
using UnityEngine;

namespace CENSIS.Runtime
{
    public static class Player
    {
        /// <returns>The current GPS location of the user's device</returns>
        public static Vector2 GetUserLocation()
        {
            return Vector2dToVector2(
                LocationProviderFactory
                    .Instance
                    .DefaultLocationProvider
                    .CurrentLocation
                    .LatitudeLongitude
            );
        }

        private static Vector2 Vector2dToVector2(Vector2d vector2D)
        {
            return new Vector2((float)vector2D.x, (float)vector2D.y);
        }
        
        public static bool CheckUserLocation()
        {
            var currLocation = LocationProviderFactory.Instance.DefaultLocationProvider.CurrentLocation;
            
            if (
                (currLocation.IsLocationServiceEnabled || currLocation.IsLocationServiceInitializing)
                && ConvertToUnixTimestamp(DateTime.Now) - currLocation.Timestamp < 10
            )
                return true;
            else
                return false;
        }

        private static double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return diff.TotalSeconds;
        }
    }
}
