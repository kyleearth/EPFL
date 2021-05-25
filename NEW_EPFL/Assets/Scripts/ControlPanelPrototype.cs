using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class ControlPanelPrototype : MonoBehaviour
{
    // Concrete class should set this in Start
    private Vector3 teleportLocation;

    public Vector3 TeleportLocation
    {
        get;
    }

    public abstract void OnPrototypeGUI(int windowID);
}
