using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceNavigatorDriver;

namespace ClimberFX.Utility
{
    public class FlyParaglider : MonoBehaviour
    {
        public bool HorizonLock = false;
        public float movSpeed = 1;
        //float keymoveInfluence;
        //float joymoveInfluence;
        float refPos;
        public static float currentAlt;
        public GameObject cameraObject;
        public static float accel;
        public static float velo = 14;
        public float multiplicador;
        public float maxVelo = 21;

        //void Start()
        //{
        //    glider = gameObject.GetComponent<GameObject>("CSharp");
        //}

        //    var csharp = this.gameObject.GetComponent("CSharp");

        public void Update()
        {
            transform.Translate(SpaceNavigator.Translation, Space.Self);
            transform.Rotate(SpaceNavigator.Rotation.eulerAngles, Space.Self);

            //Código Adicionado por Climberfx

            //keymoveInfluence = Input.GetAxis("Vertical");
            //joymoveInfluence = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y;
            //force = (transform.forward * movSpeed * keymoveInfluence) + (transform.forward * movSpeed * joymoveInfluence);
            //transform.Translate(force);
            //velocity = ((transform.position - previous).magnitude) / Time.deltaTime;

            //current = transform.position;
            //acceleration = (Mathf.Abs(current.y - previous.y - 1f));
            //transform.Translate((Vector3.forward * Time.deltaTime * movSpeed * acceleration), Space.Self);
            //Debug.Log("Y = " + (current.y - previous.y));
            //Debug.Log("Acceleration = " + acceleration);
            //previous = transform.position;

            currentAlt = transform.position.y;
            refPos = cameraObject.transform.position.y;
            accel = refPos / currentAlt * (multiplicador + 1) - multiplicador;
            velo += ((accel - 1) / 10);
            if (velo < -1) velo = -1;
            if (velo > maxVelo) velo = maxVelo;
            transform.Translate((Vector3.forward * Time.deltaTime * movSpeed * velo), Space.Self);
            //Debug.Log("Acceleration = " + accel);

        }
    }
}