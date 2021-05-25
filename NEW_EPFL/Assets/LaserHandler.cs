/* SceneHandler.cs*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;

public class LaserHandler : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {

        //Debug.Log("Entered the Pointer Inside method");
        Debug.Log("Interacting with target inside click " + e.target.name);
        if (e.target.name == "QButtton")
        {
            Debug.Log("Qbutton was clicked");
        }

        if (e.target.name == "Checkbox")
        {
            GameObject checkBox = GameObject.FindGameObjectWithTag("check_consent");
            Debug.Log(checkBox.GetComponent<Toggle>().isOn);
            checkBox.GetComponent<Toggle>().isOn = !checkBox.GetComponent<Toggle>().isOn;
        }

        if (e.target.name == "submit_consent")
        {

            // The value of the agree consent will be available here to use. 
            Destroy(GameObject.FindGameObjectWithTag("consent_canvas"));
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {

        //Debug.Log("Entered the Pointer Inside method");
        Debug.Log("Interacting with target " + e.target.name);
        if (e.target.name == "QButton")
        {
            Debug.Log("QButton was entered");
        }
        else if (e.target.name == "Button")
        {
            Debug.Log("Button was entered");
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {

        //Debug.Log("Entered the Pointer Outside method");
        //Debug.Log("Interacting with target " + e.target.name);
        if (e.target.name == "QButton")
        {
            Debug.Log("QButton was exited");
        }
        else if (e.target.name == "Button")
        {
            Debug.Log("Button was exited");
        }
    }

   
}