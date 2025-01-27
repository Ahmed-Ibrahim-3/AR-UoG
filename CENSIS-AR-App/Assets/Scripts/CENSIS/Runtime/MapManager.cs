using Mapbox.Unity.Location;
using UnityEngine;

namespace CENSIS.Runtime
{
    /// <summary>
    /// Manages map scaling, motion and display
    /// </summary>
    public class MapManager : MonoBehaviour
    {

        bool _tracking;
        Camera _mapCamera;

        public void ReCentre()
        {

            var currentLocation = LocationProviderFactory
                    .Instance
                    .DefaultLocationProvider
                    .CurrentLocation;

            LocationProviderFactory.Instance.mapManager.UpdateMap(
                                    currentLocation.LatitudeLongitude
                                );
            _tracking = true;
        }
        
        void Update()
        {
            var viewportPoint = _mapCamera.ScreenToViewportPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0) && (viewportPoint.x is < 1 and > 0 && viewportPoint.y is < 1 and > 0))
            {
                _tracking = false;
            }
            
            if (_tracking)
            {

                var currentLocation = LocationProviderFactory
                    .Instance
                    .DefaultLocationProvider
                    .CurrentLocation;

                if (currentLocation.IsLocationUpdated)
                {
                    LocationProviderFactory.Instance.mapManager.UpdateMap(
                        currentLocation.LatitudeLongitude
                    );
                }

            }
        }

        private void Start()
        {
            _mapCamera = GameObject.Find("MapCamera").GetComponent<Camera>();
        }
    }
}
