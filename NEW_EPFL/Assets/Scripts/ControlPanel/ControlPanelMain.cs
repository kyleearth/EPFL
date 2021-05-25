using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class ControlPanelMain : MonoBehaviour
{
    // List of prototypes
    public List<ControlPanelPrototypeBase> prototypes;

    private int activePrototypeIndex = 0;

    // for teleport fadein/fadeout
    private float fadeTime = 2f;
    private bool inFadeOut = false;
    private bool inFadeIn = false;
    private bool teleportNow = false;
    private bool recordNow = false;
    public GameObject player;
    public GameObject cameraRotationContainer;
    private AudioSource teleportASR;
    
    void Start()
    {
        // reparent and disable all prototype canvases
        foreach (ControlPanelPrototypeBase prototype in prototypes)
        {
            // Get parent canvas object for prototype
            GameObject prototypeParentCanvas = prototype.transform.parent.transform.gameObject;
            // reparent to Control Panel container
            prototype.transform.SetParent(this.transform.parent, false);
            // destroy original canvas as not needed
            Destroy(prototypeParentCanvas);
            // set prototype menu inactive
            prototype.transform.gameObject.SetActive(false);
        }

        // set starting selection to 0 item in list
        if (prototypes.Count > 0)
            prototypes[0].gameObject.SetActive(true);

        // populate the drop down list
        Dropdown dropdown = GetComponentInChildren<Dropdown>();
        dropdown.options.Clear();
        foreach (ControlPanelPrototypeBase prototype in prototypes)
        {
            dropdown.options.Add(new Dropdown.OptionData(prototype.ControlPanelName));
        }

        // Get teleport audio source
        teleportASR = GetComponent<AudioSource>();

    }

    public void OnMenuSelectionChange(int newPrototypeIndex)
    {
        prototypes[activePrototypeIndex].gameObject.SetActive(false);
        activePrototypeIndex = newPrototypeIndex;
        prototypes[newPrototypeIndex].gameObject.SetActive(true);
        // Debug.Log("Menu selection changed: " + index.ToString());
    }

       
    public void OnTeleportButtonPress()
    {
        teleportNow = true;
        // Debug.Log("Teleport Button pressed");
    }

    private void Update()
    {
        // If teleport then go to prototype location
        if (teleportNow && !inFadeOut && !inFadeIn/* && Input.GetKey(KeyCode.F)*/)
        {
            inFadeOut = true;
            SteamVR_Fade.Start(Color.black, 2f);
            teleportNow = false;
        }

        if ((inFadeOut || inFadeIn) && fadeTime > 0f)
        {
            fadeTime -= Time.deltaTime;
        }
        else if (inFadeIn)
        {
            inFadeIn = false;
            fadeTime = 2f;
        }
        else if (inFadeOut)
        {
            inFadeOut = false;
            inFadeIn = true;
            fadeTime = 2f;
            // player.transform.position = new Vector3(player.transform.position.x - 5f, player.transform.position.y, player.transform.position.z - 3f);
            player.transform.position = new Vector3(prototypes[activePrototypeIndex].TeleportLocation.x, 
                player.transform.position.y, prototypes[activePrototypeIndex].TeleportLocation.z);

            // cameraRotationContainer.transform.localEulerAngles = new Vector3(cameraRotationContainer.transform.localEulerAngles.x, 
            //    90f, cameraRotationContainer.transform.localEulerAngles.z);

            cameraRotationContainer.transform.rotation = Quaternion.Euler(cameraRotationContainer.transform.rotation.x,
                135f, cameraRotationContainer.transform.rotation.z);

            // player.transform.localRotation = Quaternion.Euler(player.transform.localRotation.x, 0f,
            //    player.transform.localRotation.z);

            // player.transform.localRotation = Quaternion.Euler(player.transform.localRotation.x, prototypes[activePrototypeIndex].TeleportLocation.y, 
            //    player.transform.localRotation.z);
            // player.transform.localEulerAngles = new Vector3(player.transform.localEulerAngles.x, prototypes[activePrototypeIndex].TeleportLocation.y,
            // player.transform.localEulerAngles.z);
            SteamVR_Fade.Start(Color.clear, 2f);
            teleportASR.Play();
        }
    }
}
