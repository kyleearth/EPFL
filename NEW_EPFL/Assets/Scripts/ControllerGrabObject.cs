using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerGrabObject : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;

    private GameObject collidingObject; // 1
    private GameObject objectInHand; // 2

    // private FixedJoint joint;

    private void SetCollidingObject(Collider col)
    {
        // 1
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        // 2
        collidingObject = col.gameObject;
    }

    // 1
    public void OnTriggerEnter(Collider other)
    {
        if ((other.name == "Wand" || other.name == "Bottle1") && !objectInHand)
        {
            Debug.Log("On Trigger Enter: " + other.name);
            SetCollidingObject(other);
        }
    }

    // 2
    /*
    public void OnTriggerStay(Collider other)
    {
        // return;

        if (other.name == "Cube")
        {
            Debug.Log("On Trigger Stay: " + other.name);
            SetCollidingObject(other);
        }
    } */

    // 3
    /* public void OnTriggerExit(Collider other)
    {
        // return;

        if (other.name == "Cube")
        {
            Debug.Log("On Trigger Exit: " + other.name);

            if (!collidingObject)
            {
                return;
            }

            collidingObject = null;
        }
    }
    */

    private void GrabObject()
    {
        Debug.Log("Grab Object: " + collidingObject.name);

        // 1
        objectInHand = collidingObject;
        collidingObject = null;
        // 2

        // TODO: may have to set kinematics, or can remove rigid body I think

        Vector3 thisPosition = this.transform.position;

        // Set parent of collided object to be 
        objectInHand.transform.SetParent(this.transform);
        objectInHand.GetComponent<Rigidbody>().isKinematic = true;
        // objectInHand.transform.position = new Vector3(thisPosition.x-0.02f, thisPosition.y-0.05f, thisPosition.z+0.05f);
        /*objectInHand.transform.localPosition = new Vector3(-0.25f, 0f, -0.04f);
        objectInHand.transform.localEulerAngles = new Vector3(-90f, 180f, 0f);*/

        Collider col = GetComponent<BoxCollider>();
        col.enabled = false;

    }

    private void GrabObjectOld()
    {
        Debug.Log("Grab Object: " + collidingObject.name);

        // 1
        objectInHand = collidingObject;
        collidingObject = null;
        // 2
        // joint = GetComponent<FixedJoint>();

        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
        
    }

    // 3
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        // 1
        // if(joint)
        if (GetComponent<FixedJoint>())
        {
            // 2
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            // 3
            objectInHand.GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity();
            objectInHand.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity();

        }
        // 4
        objectInHand = null;
    }
    
    // Update is called once per frame
    void Update()
    {
        // 1
        if (grabAction.GetLastStateDown(handType) && !objectInHand)
        {
            if (collidingObject)
            {
                Debug.Log("State Down Colliding Object: " + collidingObject.name);

                GrabObject();
            }
        }

        // 2
        /* if (grabAction.GetLastStateUp(handType))
        {
            if (objectInHand)
            {
                Debug.Log("State Up Colliding Object: " + objectInHand.name);
                ReleaseObject();
            }
        }
        */
    }
}
