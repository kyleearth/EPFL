using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class ControlPanelPrototypeBase : MonoBehaviour
{
    // Each derived class must set teleport location in Start()
    private protected Vector3 teleportLocation = new Vector3();
    
    public Vector3 TeleportLocation
    {
        get { return teleportLocation; }
    }

    // each derived class must set this name, it is what appears in the dropdown selection list
    private protected string controlPanelName = "";

    public string ControlPanelName
    {
        get { return controlPanelName; }
    }

}
