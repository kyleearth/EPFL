using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperimentCandle : ControlPanelPrototype
{
    [Min(0)]
    public int candleExtinguishDelay = 50;
    [Min(0)]
    public int candleRelightFrameDelay = 200;
    public bool explodeCandle = false;


    private GameObject candleLight;
    private GameObject candleSmoke;
    private GameObject candleFlame;
    private GameObject candleExplosion;

    private bool explosionOccuring = false;

    private int candleExtinguishCount = -1;
    private int candleRelightCount = -1;

    private AudioSource asrExplosion;

    // Start is called before the first frame update
    void Start()
    {
        candleFlame = transform.Find("CandleFlame").gameObject;
        candleSmoke = transform.Find("WhiteSmoke").gameObject;
        candleLight = transform.Find("CandleLight").gameObject;
        candleExplosion = transform.Find("WFX_Nuke").gameObject;
        asrExplosion = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // set up framecountdown for flame extinguish delay
        if (candleExtinguishCount > 0)
        {
            candleExtinguishCount--;
        }
        else if (candleExtinguishCount == 0)
        {
            // TODO: Need to disable collision events until candle is enabled again
            candleFlame.SetActive(false);
            candleLight.SetActive(false);
            // transform.Find("WFX_Nuke").gameObject.GetComponent<ParticleSystem>().Play();
            if (explodeCandle && !explosionOccuring)
            {
                candleExplosion.GetComponent<ParticleSystem>().Play();
                explosionOccuring = true;
                asrExplosion.Play();
            }

            if (!explodeCandle)
            {
                candleSmoke.SendMessage("InitiateCandleSmokeSequence");
            }
            candleRelightCount = candleRelightFrameDelay;
            candleExtinguishCount = -1;
        }

        // set up framecountdown for flame relight delay
        if (candleRelightCount > 0)
        {
            candleRelightCount--;
        }
        else if (candleRelightCount == 0)
        {
            candleLight.SetActive(true);
            candleFlame.SetActive(true);
            candleRelightCount = -1;
            explosionOccuring = false;
        }

    }

    public void BreathCollisionAction(List<ParticleCollisionEvent> collisionEvents)
    {
        int collisionCount = collisionEvents.Count;

        // Set up logic here for when to extinguish, also need to add the flicker to the light and rotate to the flame
        if (collisionCount > 5)
        {
            candleExtinguishCount = candleExtinguishDelay;
        }

        Debug.Log("MESSAGE RECEIVED");
    }

    // public Rect windowRect = new Rect(340, 340, 220, 250);

    float sliderValue = 0;

    public override void OnPrototypeGUI(int windowID)
    {
        sliderValue = GUI.HorizontalSlider(new Rect(10f, 25f, 100f, 30f), sliderValue, 0f, 2f);
        GUI.Label(new Rect(10, 45, 30, 20), "1");
        GUI.Label(new Rect(110, 45, 30, 20), "5");
        explodeCandle = GUI.Toggle(new Rect(10, 50, 200, 30), explodeCandle, " Exploding Candle");
    }

    void DoMyWindow2(int windowID)
    {
        if (GUI.Button(new Rect(10, 20, 50, 60), "Goodbye World"))
        {
            print("Got a click");
        }
    }

}
