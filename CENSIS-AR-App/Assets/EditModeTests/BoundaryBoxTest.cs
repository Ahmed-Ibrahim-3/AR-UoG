using System;
using NUnit.Framework;
using UnityEngine;
using CENSIS.Utility;

namespace EditModeTests
{
    public class BoundaryBoxTest
    {
        [Test]
        public void  ConvertToCartesian_CorrectlyConverts()
        {
            Vector2 longlat = new Vector2(55.8740145f, -4.2920211f);
            Vector2 longlatAsCart = BoundaryBoxes.ConvertToCartesian(longlat);
            Vector2 cart = new Vector2(3576405.012f, -268410.39f);
            Debug.Log(
                "diffs : " + (Math.Abs(longlatAsCart.x - cart.x), Math.Abs(longlatAsCart.y - cart.y))
            );
            var acceptableDiff = 0.5;
            Assert.IsTrue(
                Math.Abs(longlatAsCart.x - cart.x) < acceptableDiff
                    && Math.Abs(longlatAsCart.y - cart.y) < acceptableDiff
            );
        }
    
        [Test]
        public void IsPointInPolygon_CorrectlyIdentifiesWhenPointInPolygon()
        {
            Vector2[] polygon = new Vector2[]
            {
                new Vector2(0, 0),
                new Vector2(0, 10),
                new Vector2(10, 10),
                new Vector2(10, 0)
            };
            Vector2 point1 = new Vector2(5, 5);
            Vector2 point2 = new Vector2(15, 5);
            Vector2 point3 = new Vector2(0, 0);
            Vector2 point4 = new Vector2(10, 15);
            Vector2 point5 = new Vector2(5, 10);
            Vector2 point6 = new Vector2(5, 0);
    
            bool result1 = BoundaryBoxes.IsPointInPolygon(point1, polygon); // returns true
            bool result2 = BoundaryBoxes.IsPointInPolygon(point2, polygon); // returns false
            bool result3 = BoundaryBoxes.IsPointInPolygon(point3, polygon); // returns true
            bool result4 = BoundaryBoxes.IsPointInPolygon(point4, polygon); // returns false
            bool result5 = BoundaryBoxes.IsPointInPolygon(point5, polygon); // returns true
            bool result6 = BoundaryBoxes.IsPointInPolygon(point6, polygon); // returns true
            Assert.IsTrue(
                result1 == true
                    && result2 == false
                    && result3 == true
                    && result4 == false
                    && result5 == true
                    && result6 == true
            );
        }
    
        [Test]
        public void IsPointInPolygonGPS_WhenUserInAlwynBox_ReturnsTrue()
        {
            Vector2[] polygon = new Vector2[]
            {
                new Vector2(55.8740145f, -4.2920211f),
                new Vector2(55.8740176f, -4.2917896f),
                new Vector2(55.8740208f, -4.2915686f),
                new Vector2(55.8739457f, -4.2914601f),
                new Vector2(55.8737967f, -4.2918125f),
                new Vector2(55.8738249f, -4.2918538f),
                new Vector2(55.8737938f, -4.2919222f),
                new Vector2(55.8739423f, -4.2921254f),
                new Vector2(55.8739423f, -4.2921254f),
                new Vector2(55.8739947f, -4.2920999f),
                new Vector2(55.8739961f, -4.2920208f),
                new Vector2(55.8740145f, -4.2920211f)
            };
            Vector2 examplePosition = new Vector2(55.87393f, -4.29185f);
            bool isinside = BoundaryBoxes.IsPointInPolygonGPS(examplePosition, polygon, new Vector3(0,0,0));
            Assert.IsTrue(isinside);
        }
    
        [Test]
        public void IsPointInPolygonGPS_WhenUserNotInAlwynBox_ReturnsFalse()
        {
            Vector2[] polygon = new Vector2[]
            {
                new Vector2(55.8740145f, -4.2920211f),
                new Vector2(55.8740176f, -4.2917896f),
                new Vector2(55.8740208f, -4.2915686f),
                new Vector2(55.8739457f, -4.2914601f),
                new Vector2(55.8737967f, -4.2918125f),
                new Vector2(55.8738249f, -4.2918538f),
                new Vector2(55.8737938f, -4.2919222f),
                new Vector2(55.8739423f, -4.2921254f),
                new Vector2(55.8739423f, -4.2921254f),
                new Vector2(55.8739947f, -4.2920999f),
                new Vector2(55.8739961f, -4.2920208f),
                new Vector2(55.8740145f, -4.2920211f)
            };
            Vector2 locationA = new Vector2(55.87375f, -4.29185f);
            Assert.IsFalse(BoundaryBoxes.IsPointInPolygonGPS(locationA, polygon, new Vector3(0,0,0)));
        }
    }

}
