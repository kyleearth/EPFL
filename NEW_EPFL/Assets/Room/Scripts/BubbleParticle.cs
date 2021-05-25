using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleParticle : MonoBehaviour
{
    
    private int keyPressed = 2;
    private int collisionCount = 0;

    private GameObject flame;
    private ParticleSystem.EmissionModule flame_outModules;

    // Start is called before the first frame update
    private GameObject Bubble_Emit;
    private ParticleSystem.EmissionModule bubble_emissionModule;

    private GameObject Ice_Ray;
    private GameObject Flare_Ice;
    private ParticleSystem.EmissionModule ice_emissionModule;
    private int frame = 0;
    FrostEffect Frost = new FrostEffect();
    AudioSource FrostSound;

    private GameObject smoke;
    private ParticleSystem.EmissionModule smoke_emissionModule;
    private GameObject storm;
    private ParticleSystem.EmissionModule storm_emissionModule;
    private float stromIncrement = 0;
    AudioSource stormSound;

    bool playAudio = true;
    bool playOnce = false;

    public GameObject breath_particle;
    bool rotation = true;

    // Start is called before the first frame update
    void Start()
    {
        

        flame = transform.Find("Flame_Effect").gameObject;
        flame_outModules = flame.GetComponent<ParticleSystem>().emission;
        flame_outModules.rateOverTime = 0;
 
        Bubble_Emit = transform.Find("Bubble_Emit").gameObject;
        bubble_emissionModule = Bubble_Emit.GetComponent<ParticleSystem>().emission;
        bubble_emissionModule.rateOverTime = 0;

        Ice_Ray = transform.Find("IceRaySet/IceRay").gameObject;
        Flare_Ice = transform.Find("IceRaySet/Flare Ice").gameObject;
        Flare_Ice.SetActive(false);
        ice_emissionModule = Ice_Ray.GetComponent<ParticleSystem>().emission;
        ice_emissionModule.rateOverTime = 0;
        FrostSound = Ice_Ray.GetComponent<AudioSource>();

        smoke = transform.Find("Smoke").gameObject;
        smoke_emissionModule = smoke.GetComponent<ParticleSystem>().emission;
        smoke_emissionModule.rateOverTime = 0;
        storm = transform.Find("Smoke/DustStorm").gameObject;
        storm_emissionModule = storm.GetComponent<ParticleSystem>().emission;
        storm_emissionModule.rateOverTime = 0;
        stormSound = storm.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = breath_particle.transform.position;
        Vector3 dir = (this.transform.position - pos).normalized;
        //Debug.Log("dir = " + pos);
        if (Input.GetKey("1"))
        {
            keyPressed = 1;             // For Fire option
            collisionCount = 0;

        }
        else if (Input.GetKey("2"))
        {
            keyPressed = 2;             // For Bubble option
            collisionCount = 0;
            rotation = true;

        }
        else if (Input.GetKey("3"))
        {
            keyPressed = 3;             // For Ice option
            collisionCount = 0;
            frame = 0;
            playAudio = true;
            playOnce = false;

        }
        else if (Input.GetKey("4"))
        {
            keyPressed = 4;             // For Smoke option
            collisionCount = 0;
            stromIncrement = 0;
            playAudio = true;
            playOnce = false;
        }

        if (keyPressed == 1)
        {
           // Debug.Log("fire count " + collisionCount);

            if (collisionCount > 0)
            {
                flame_outModules.rateOverTime = collisionCount * 50;
                collisionCount --;

                Quaternion r = Quaternion.LookRotation(dir, Vector3.up);
                flame.transform.rotation = r;
            }
            else
            {
                flame_outModules.rateOverTime = 0;
            }

        }
        if (keyPressed == 2)
        {
            // Debug.Log("bubble count " + bubble_collisionCount);
            
            if (collisionCount > 0)
            {
                bubble_emissionModule.rateOverTime = collisionCount * 50;
                collisionCount = 0;
                ParticleSystem bubble = Bubble_Emit.GetComponent<ParticleSystem>();

                Quaternion r = Quaternion.LookRotation(dir, Vector3.up);
                Bubble_Emit.transform.rotation = r;
 
            }
            else
            {
                bubble_emissionModule.rateOverTime = collisionCount;
            }

        }
        if (keyPressed == 3)
        {
            // Debug.Log("bubble count " + bubble_collisionCount);

            if (collisionCount > 0)
            {
                ice_emissionModule.rateOverTime = collisionCount * 50;
                collisionCount = 0;
                Flare_Ice.SetActive(true);

                
                FrostEffect.instance.FrostAmount = frame * 0.005f;
                // Debug.Log("Frost " + FrostEffect.instance.FrostAmount);
                frame++;
                playOnce = true;

                Quaternion r = Quaternion.LookRotation(dir, Vector3.up);
                transform.Find("IceRaySet").gameObject.transform.rotation = r;

            }
            else
            {
                ice_emissionModule.rateOverTime = 0;
                Flare_Ice.SetActive(false);
                if (frame > 0)
                {
                    frame--;
                }
                else
                {
                    FrostSound.Stop();
                    playAudio = true;
                    playOnce = false;
                }
                FrostEffect.instance.FrostAmount = frame * 0.005f;
            }

            if (playAudio && playOnce)
            {
                FrostSound.Play();
                playAudio = false;
            }

        }
        if (keyPressed == 4)
        {

            //Debug.Log("collision count " + collisionCount);
            if (collisionCount > 0)
            {
                smoke_emissionModule.rateOverTime = collisionCount*0.5f;
                stromIncrement += 0.15f;
                storm_emissionModule.rateOverTime = stromIncrement;
                collisionCount--;
                stormSound.volume = stromIncrement / 10; //adjust this
                playOnce = true;
                Quaternion r = Quaternion.LookRotation(dir, Vector3.up);
                smoke.transform.rotation = r;
            }
            else
            {
                //Debug.Log("collision count 0");

                smoke_emissionModule.rateOverTime = 0;
                if (stromIncrement > 0) {
                    stromIncrement -= 0.2f;
                    storm_emissionModule.rateOverTime = stromIncrement;
                    stormSound.volume = stromIncrement / 10;
                }
                else
                {
                    stormSound.Stop();
                    playAudio = true;
                    playOnce = false;
                }
            }

            if (playAudio && playOnce)
            {
                //Debug.Log("sound play");
                stormSound.Play();
                playAudio = false;
            }



        }

    }

    public void BreathCollisionAction(List<ParticleCollisionEvent> collisionEvents)
    {
        collisionCount = collisionEvents.Count;

    //Debug.Log("MESSAGE RECEIVED "+ collisionCount);

    }

}