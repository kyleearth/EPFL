using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandlePanel : ControlPanelPrototypeBase
{
    // Start is called before the first frame update
    void Awake()
    {
        // set the teleport location
        teleportLocation = new Vector3(-21f, 90f, 3.1f); // TODO FIX THIS LOCATION
        controlPanelName = "Candle";
    }
}
