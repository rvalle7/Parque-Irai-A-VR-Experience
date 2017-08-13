using System;
using UnityEngine;
using UnityEngine.UI;

namespace ClimberFX.Utility
{
    [RequireComponent(typeof(Text))]
    public class HudVR : MonoBehaviour
    {
        const float fpsMeasurePeriod = 0.5f;
        private int m_FpsAccumulator = 0;
        private float m_FpsNextPeriod = 0;
        private int m_CurrentFps;
        const string display = "fps\t\t {0}\naccel\t {1} %\nvel\t\t {2} m/s\nalt\t\t {3} m";
        private Text m_Text;
        private float accelPerc;


        private void Start()
        {
            m_FpsNextPeriod = Time.realtimeSinceStartup + fpsMeasurePeriod;
            m_Text = GetComponent<Text>();
        }


        private void Update()
        {
            // measure average frames per second
            m_FpsAccumulator++;
            if (Time.realtimeSinceStartup > m_FpsNextPeriod)
            {
                m_CurrentFps = (int)(m_FpsAccumulator / fpsMeasurePeriod);
                m_FpsAccumulator = 0;
                m_FpsNextPeriod += fpsMeasurePeriod;
                accelPerc = FlyParaglider.accel * 100;
                m_Text.text = string.Format(display, m_CurrentFps, accelPerc.ToString("F"), FlyParaglider.velo.ToString("F"), FlyParaglider.currentAlt.ToString("F"));
            }
        }
    }
}
