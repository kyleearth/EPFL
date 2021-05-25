using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GUITest : MonoBehaviour
{
    public Rect windowRect = new Rect(140, 140, 320, 250);

    public GameObject player;

    void OnGUI()
    {
        // Register the window. Notice the 3rd parameter
        // windowRect = GUI.Window(5, windowRect, DoMyWindow, "My Window");
    }

    // Make the contents of the window
    void DoMyWindow(int windowID)
    {
        if (GUI.Button(new Rect(10, 20, 100, 20), "Hello World"))
        {
            print("Got a click");
        }
    }

    float fadeTime = 2f;
    bool inFadeOut = false;
    bool inFadeIn = false;

    void Update()
    {
        if (!inFadeOut && !inFadeIn && Input.GetKey(KeyCode.F))
        {
            inFadeOut = true;
            SteamVR_Fade.Start(Color.black, 2f);
        }

        if((inFadeOut || inFadeIn) && fadeTime > 0f)
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
            player.transform.position = new Vector3(player.transform.position.x - 5f, player.transform.position.y, player.transform.position.z - 3f);
            SteamVR_Fade.Start(Color.clear, 2f);
        }

        /* (Input.GetKey(KeyCode.F))
        {
            SteamVR_Fade.Start(Color.black, 2f);
            // SteamVR_Fade.
        } */

        if (Input.GetKey(KeyCode.G))
        {
            SteamVR_Fade.Start(Color.clear, 4f);
            // SteamVR_Fade.
        }
    }
}