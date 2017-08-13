using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClimberFX.Utility
{
    public class Pull : MonoBehaviour
    {

        public float pullforce = 10;
        Vector3 heading;
        Vector3 force;
        float joymoveInfluence;
        float keymoveInfluence;

        // Use this for initialization
        void OnTriggerStay(Collider other)
        {
            if (other.attachedRigidbody)
            {
                heading = other.transform.position - transform.position;
                heading.y = 0;
                keymoveInfluence = Input.GetAxis("Vertical");
                joymoveInfluence = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y;
                force = (heading * pullforce * keymoveInfluence) + (transform.forward * pullforce * keymoveInfluence)
                        + (heading * pullforce * joymoveInfluence) + (transform.forward * pullforce * joymoveInfluence);
                other.attachedRigidbody.AddForce(force);
            }

            //Debug.Log("encostando em algo");

        }
    }
}

//OVRInput.Get(OVRInput.Button.SecondaryShoulder)
// OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger)