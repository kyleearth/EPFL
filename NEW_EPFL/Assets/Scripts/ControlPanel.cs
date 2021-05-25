using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Valve.VR;

public class ControlPanel : MonoBehaviour
{
    public List<ControlPanelPrototype> prototypes;

    public GameObject player;
    private AudioSource teleportASR;

    private Rect windowRect = new Rect(20, 20, 450f, 75f);
    private Rect teleportRecordRect = new Rect(20, 100, 250f, 75f);
    private Rect subRect = new Rect(20, 180f, 250f, 600f);
    private Rect anemometerRect = new Rect(0f, 0f, 100f, 100f);

    private GUISkin skin;
    public GUISkin skinOld;

    void Start()
    {
        teleportASR = GetComponent<AudioSource>();
        // skin = ScriptableObject.CreateInstance<GUISkin>();
        // GUI.skin = skin;
        

        // skin.button.normal.background. = Color.blue;
    }

    // void SetWindowbackground(Texture2D tex)
    void SetWindowbackground(GUIStyle style, Texture2D tex)
    {
        // GUIStyle style = GUI.skin.GetStyle("Window");
        style.onActive.background = tex;
        style.active.background = tex;
        style.hover.background = tex;
        style.onHover.background = tex;
        style.onFocused.background = tex;
        style.focused.background = tex;
        style.onNormal.background = tex;
        style.normal.background = tex;
    }

    void SetWindowFontColor(Color color)
    {
        GUIStyle style = GUI.skin.GetStyle("Window");
        style.normal.textColor = color;
        style.onNormal.textColor = color;
        style.hover.textColor = color;
        style.onHover.textColor = color;
        style.focused.textColor = color;
        style.onFocused.textColor = color;
        style.active.textColor = color;
        style.onActive.textColor = color;
    }

    void SetButtonColors(GUIStyle style)
    {
        Texture2D texButtonHover = GetColorBasedTexture(Color.cyan);
        Texture2D texButtonActive = GetColorBasedTexture(Color.green);
        Texture2D texButtonFocused = GetColorBasedTexture(Color.blue);
        Texture2D texButtonNormal = GetColorBasedTexture(Color.yellow);

        // GUIStyle style = GUI.skin.GetStyle("Button");
        // style.onActive.background = texButtonActive;
        // style.active.background = texButtonActive;
        style.hover.background = texButtonHover;
        style.onHover.background = texButtonHover;
        style.normal.background = texButtonNormal;
        style.onNormal.background = texButtonNormal;
        style.focused.background = texButtonFocused;
        style.onFocused.background = texButtonFocused;
    }

    Texture2D GetColorBasedTexture(Color color)
    {
        var tex = new Texture2D(1, 1);
        tex.SetPixel(1, 1, color);
        tex.Apply();
        return tex;
    }
    void OnGUI()
    {
        GUIStyle existStyleWindow = new GUIStyle(GUI.skin.window);
        // GUI.skin = null;

        // GUI.backgroundColor = new Color(1, 1, 1, .8f);

        // var tex = new Texture2D(1, 1);
        // tex.SetPixel(1, 1, new Color(1, 1, 1, 0.6f));
        // tex.Apply();
        Texture2D texWindow = GetColorBasedTexture(new Color(1, 1, 0f, 0.5f));
        Texture2D tex = GetColorBasedTexture(new Color(0.1f, 0.1f, 0.1f, 0.9f));

        // GUIStyle toolbarStyle = GUI.skin.GetStyle("Toolbar");


        // GUI.skin.button.active.background = tex;
        // GUI.skin.button.normal.background = tex;
        // GUI.skin.window.active.textColor = Color.red;
        // GUI.skin.window.normal.textColor = Color.red;
        // GUI.skin.window.onHover.textColor = Color.blue;
        // GUI.skin.window.onFocused.textColor = Color.red;

        /* Texture2D texButtonHover = GetColorBasedTexture(Color.cyan);
        Texture2D texButtonActive = GetColorBasedTexture(Color.green);
        Texture2D texButtonFocused = GetColorBasedTexture(Color.blue);
        Texture2D texButtonNormal = GetColorBasedTexture(Color.yellow);
               
        GUI.skin.GetStyle("Button").onActive.background = GUI.skin.GetStyle("Button").onNormal.background;
        GUI.skin.GetStyle("Button").active.background = GUI.skin.GetStyle("Button").normal.background;
        GUI.skin.GetStyle("Button").hover.background = GUI.skin.GetStyle("Button").normal.background;
        GUI.skin.GetStyle("Button").onHover.background = GUI.skin.GetStyle("Button").normal.background; */

        SetWindowbackground(existStyleWindow, texWindow);

        //GUIStyle existStyleButton = new GUIStyle(GUI.skin.button);

        // SetWindowFontColor(Color.white);
        // SetButtonColors(existStyleButton);
        // Texture2D texButtonHover = GetColorBasedTexture(Color.cyan);
        // existStyleButton.hover.background = texButtonHover;
        // existStyleButton.onHover.background = texButtonHover;


        /* GUI.skin.GetStyle("Window").onActive.background = GUI.skin.GetStyle("Button").onNormal.background;
        GUI.skin.GetStyle("Window").active.background = GUI.skin.GetStyle("Button").normal.background;
        GUI.skin.GetStyle("Window").hover.background = GUI.skin.GetStyle("Button").normal.background;
        GUI.skin.GetStyle("Window").onHover.background = GUI.skin.GetStyle("Button").normal.background;
        GUI.skin.GetStyle("Window").onFocused.background = GUI.skin.GetStyle("Button").normal.background;
        GUI.skin.GetStyle("Window").focused.background = GUI.skin.GetStyle("Button").normal.background;
        GUI.skin.GetStyle("Window").onNormal.background = GUI.skin.GetStyle("Button").normal.background;
        GUI.skin.GetStyle("Window").normal.background = GUI.skin.GetStyle("Button").normal.background; */

        /* GUI.skin.GetStyle("Window").normal.textColor = Color.white;
        GUI.skin.GetStyle("Window").onNormal.textColor = Color.white;
        GUI.skin.GetStyle("Window").hover.textColor = Color.white;
        GUI.skin.GetStyle("Window").onHover.textColor = Color.white;
        GUI.skin.GetStyle("Window").focused.textColor = Color.white;
        GUI.skin.GetStyle("Window").onFocused.textColor = Color.white;
        GUI.skin.GetStyle("Window").active.textColor = Color.white;
        GUI.skin.GetStyle("Window").onActive.textColor = Color.white; */



        // GUI.BeginGroup(windowRect, "Main");

        // GUI.Toolbar(new Rect(Screen.width - 200f, Screen.height - 200f, 100, 100), 0, buttons);

        // GUI.EndGroup();

        // GUI.skin = skinOld;

        windowRect = GUI.Window(0, windowRect, EffectSelectionWindow, "Select Effect", existStyleWindow);
        teleportRecordRect = GUI.Window(1, teleportRecordRect, TeleportRecordWindow, "Teleport/Record");
        subRect = GUI.Window(2, subRect, prototypes[0].OnPrototypeGUI, "Specific Effect");
        anemometerRect.x = Screen.width - 120f;
        anemometerRect.y = Screen.height - 120f;
        // GUI.backgroundColor = Color.magenta;
        // GUI.contentColor = Color.blue;
        // GUI.color = Color.green;

        // var tex = new Texture2D(1, 1);
        // GUI.skin.box.normal.background = tex;
        anemometerRect = GUI.Window(3, anemometerRect, AnemometerWindow, "Anemometer");


        // Register the window. Notice the 3rd parameter
        // GUI.Box(new Rect(200, 200, 80, 80), content);
        // windowRect = GUI.Window(0, windowRect, DoMyWindow, "My Window");
        // prototypes[0].OnPrototypeGUI();

        // RectOffset bdr = GUI.skin.button.border;
        // Debug.Log("Left: " + bdr.left + " Right: " + bdr.right);
        // Debug.Log("Top: " + bdr.top + " Bottom: " + bdr.bottom);
    }

    private string[] buttons = { "Candle", "Wand", "Music", "Windmill"};
    private int toolBarInt = 0; 

    // Make the contents of the window
    void EffectSelectionWindow(int windowID)
    {
        GUIStyle existStyleButton = new GUIStyle(GUI.skin.button);

        SetButtonColors(existStyleButton);

        // int oldToolBarInt = toolBarInt;
        toolBarInt = GUI.Toolbar(new Rect(10f, 20f, 430f, 50f), toolBarInt, buttons, existStyleButton);
        // if (toolBarInt != oldToolBarInt) Debug.Log("Toolbar Int: " + oldToolBarInt.ToString() + " " + toolBarInt.ToString());
    }

    bool teleportNow = false;
    bool recordNow = false;

    void TeleportRecordWindow(int windowID)
    {
        teleportNow = GUI.Button(new Rect(10f,20f,110f,50f), "Teleport");
        recordNow = GUI.Button(new Rect(125f,20f,110f,50f), "Record");
    }

    float testCounter = 0;
    float increment = 1f;
    public Anemometer anemometer;

    Texture2D emptyProgressBar; // Set this in inspector.
    Texture2D fullProgressBar;  // Set this in inspector.

    [Range(0f, 100f)]
    public float tunerBox = 1f;

    void AnemometerWindow(int windowID)
    {
        var progress = Mathf.Max(anemometer.ArtificalSpeed*6f, 0f);
        // Debug.Log("Windspeed:" + windSpeed.ToString());

        emptyProgressBar = new Texture2D(1, 1);
        emptyProgressBar.SetPixel(1, 1, Color.white);
        emptyProgressBar.Apply();

        fullProgressBar = new Texture2D(1, 1);
        fullProgressBar.SetPixel(1, 1, Color.blue);
        fullProgressBar.Apply();

        GUI.DrawTexture(new Rect(0, 0, 100, 50), emptyProgressBar);
        GUI.DrawTexture(new Rect(0, 0, progress, 50), fullProgressBar);
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        GUI.Label(new Rect(-20, -20, 100, 50), string.Format("{0:N0}%",
                  progress * 100f));
    }

    float fadeTime = 2f;
    bool inFadeOut = false;
    bool inFadeIn = false;

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
            player.transform.position = new Vector3(prototypes[0].TeleportLocation.x, player.transform.position.y, prototypes[0].TeleportLocation.z);
            SteamVR_Fade.Start(Color.clear, 2f);
            teleportASR.Play();
        }
        // Debug.Log(" TELEPORT LOCATION:" + prototypes[0].TeleportLocation.ToString());




        /*
        testCounter += increment;
        if (testCounter >= 70f || testCounter <= 1f)
        {
            testCounter = Mathf.Max(testCounter, 1f);
            testCounter = Mathf.Min(testCounter, 70f);
            // testCounter = 0f;
            increment *= -1f;
        } */
    }

    /*    void AnemometerWindowOld(int windowID)
    {
        var windSpeed = Mathf.Max(anemometer.ArtificalSpeed * 6f, 0f);
        Debug.Log("Windspeed:" + windSpeed.ToString());

        var tex = new Texture2D(1, 1);
        GUI.skin.box.normal.background = tex;

        GUI.backgroundColor = Color.green;
        // GUI.Box(new Rect(20f, 90f - testCounter, 60f, testCounter), "");

        // GUI.Box(new Rect(20f, 95f - windSpeed, 60f, windSpeed), "");
        // GUI.Box(new Rect(20f, 90f-tunerBox, 60f, tunerBox), "");

        GUI.Box(new Rect(20f, 90f, 60f, 0f), (string)null);

        // GUI.Label(new Rect(10f, 20f, 80f, 80f), "LABEL");
    }
    */

}