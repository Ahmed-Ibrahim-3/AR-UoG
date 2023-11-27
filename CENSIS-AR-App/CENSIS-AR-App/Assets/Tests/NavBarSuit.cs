using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace Tests
{
    public class NavBarSuit : InputTestFixture
    {
        Mouse mouse;
        public override void Setup()
        {
            base.Setup();
            EditorSceneManager.OpenScene("Assets/ExampleAssets/Scenes/SampleScene.unity");
            mouse = InputSystem.AddDevice<Mouse>();
        }

        public void ClickUI(GameObject uiElement)
        {
            Camera camera = GameObject.Find("XR Origin/Camera Offset/Main Camera").GetComponent<Camera>();
            Vector3 screenPos = camera.WorldToScreenPoint(uiElement.transform.position);
            Set(mouse.position, screenPos);
            Click(mouse.leftButton);
        }

        // Home Page button tests
        [UnityTest]
        public IEnumerator TestCameraButtonOnHomePage()
        {
            GameObject cameraButton = GameObject.Find("HomeCanvas/NavBar/CameraButton");
            ClickUI(cameraButton);

            // CameraCanvas = SceneManager.GetActiveScene().name;
            Canvas cameraCanvas = GameObject.Find("CameraCanvas").GetComponent<Canvas>();
            Assert.IsTrue(cameraCanvas.enabled);

            yield return null;
        }

        [UnityTest]
        public IEnumerator TestMapButtonOnHomePage()
        {
            GameObject mapButton = GameObject.Find("HomeCanvas/NavBar/MapButton");
            ClickUI(mapButton);

            // CameraCanvas = SceneManager.GetActiveScene().name;
            Canvas mapCanvas = GameObject.Find("MapCanvas").GetComponent<Canvas>();
            Assert.IsTrue(mapCanvas.enabled);

            yield return null;
        }


        [UnityTest]
        public IEnumerator TestInfoButtonOnHomePage()
        {
            GameObject infoButton = GameObject.Find("HomeCanvas/NavBar/InfoButton");
            ClickUI(infoButton);

            // CameraCanvas = SceneManager.GetActiveScene().name;
            Canvas infoCanvas = GameObject.Find("InfoCanvas").GetComponent<Canvas>();
            Assert.IsTrue(infoCanvas.enabled);

            yield return null;
        }

        
    }

}

