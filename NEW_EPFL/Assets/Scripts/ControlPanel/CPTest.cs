using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CPTest : MonoBehaviour
{
    // RectTransform par;
    GameObject ngo;

    RectTransform panel;

    void Start()
    {
        // panel = this.GetComponent<RectTransform>();

        GameObject go = GameObject.Find("ControlPanelCanvas");


        // GameObject go = GameObject.Find("ExperimentPanel");
        // go = this.transform.gameObject;

        this.transform.SetParent(go.transform, false);


    }

    void Old2Start()
    {
        panel = this.GetComponent<RectTransform>();

        GameObject go = GameObject.Find("ControlPanelCanvas");

        panel.transform.SetParent(go.transform, false);

    }

    // Start is called before the first frame update
    void OldStart()
    {
        GameObject go = GameObject.Find("ExperimentPanel");
        /* par = go.GetComponent<RectTransform>();
        go.AddComponent<Button>();
        */

        DefaultControls.Resources uiResources = new DefaultControls.Resources();
        // ngo = DefaultControls.CreateButton(uiResources);
        Button btn = ngo.GetComponent<Button>();
        btn.onClick.AddListener(SomeMethod);

        ngo.transform.SetParent(go.transform, false);
        
        // par = (RectTransform)this.transform.parent.GetComponent(;
    }

    public void SomeMethod()
    {
        Debug.Log("Some Method");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
