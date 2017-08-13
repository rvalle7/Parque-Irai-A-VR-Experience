using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ClimberFX.Utility
{
    public class ScreenshotMovie : MonoBehaviour
    {
        // The folder we place all screenshots inside.
        // If the folder exists we will append numbers to create an empty folder.

        public string savePath = "Assets/Movies";
        public int frameRate = 30;
        public int sizeMultiplier = 1;

        private string realFolder = "";

        void Start()
        {
            // Set the playback framerate!
            // (real time doesn't influence time anymore)
            Time.captureFramerate = frameRate;

            // Find a folder that doesn't exist yet by appending numbers!
            realFolder = savePath;
            int count = 1;
            while (System.IO.Directory.Exists(realFolder))
            {
                realFolder = savePath + count;
                count++;
            }
            // Create the folder
            System.IO.Directory.CreateDirectory(realFolder);
        }

        void Update()
        {
            // filename is "realFolder/shot 005.png"
            var filename = string.Format("{0}/shot {1:D03}.png", realFolder, Time.frameCount);

            // Capture the screenshot
            Application.CaptureScreenshot(filename, sizeMultiplier);
        }
    }
}