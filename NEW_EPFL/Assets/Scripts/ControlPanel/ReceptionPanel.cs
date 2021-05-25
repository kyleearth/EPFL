using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptionPanel : ControlPanelPrototypeBase
{
    // Start is called before the first frame update
    void Awake()
    {
        // set the teleport location
        teleportLocation = new Vector3(15.2f, 90f, -3.65f);
        controlPanelName = "Reception";
    }
}
