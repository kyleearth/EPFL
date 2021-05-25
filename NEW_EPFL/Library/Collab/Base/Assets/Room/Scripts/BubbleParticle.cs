using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleParticle : MonoBehaviour
{
    private GameObject flame;
    private int bubble_collisionCount = 0;
    private int flame_collisionCount = 0;
    private int sameCount = 0;
    private int lastCount = 0;
    private ParticleSystem.EmissionModule flame_outModules;
    private int keyPressed=0;

    // Start is called before the first frame update
    private GameObject Bubble_Emit;

    private ParticleSystem.EmissionModule bubble_emissionModule;

    // Start is called before the first frame update
    void Start()
    {
        flame = transform.Find("Flame_Effect").gameObject;
        flame_outModules = flame.GetComponent<ParticleSystem>().emission;
        flame_outModules.rateOverTime = 0;

        Debug.Log("BUBBLE START");

        Bubble_Emit = transform.Find("Bubble_Emit").gameObject;
        bubble_emissionModule = Bubble_Emit.GetComponent<ParticleSystem>().emission;
        bubble_emissionModule.rateOverTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey("1"))
        {
            keyPressed = 1;
            bubble_collisionCount = 0;// For Fire option
        }
        else if (Input.GetKey("2"))
        {
            keyPressed = 2;
            flame_collisionCount = 0; // For Bubble option
        }

        if (keyPressed == 1)
        {
            Debug.Log("fire " + flame_collisionCount);

            if (flame_collisionCount > 0)
            {
                flame_outModules.rateOverTime = flame_collisionCount *100;
                flame_collisionCount--;

            }
            else
            {
                flame_outModules.rateOverTime = 0;
            }

        }
        if (keyPressed == 2)
        {
            Debug.Log("bubble " + bubble_collisionCount);

            if (bubble_collisionCount > 0)
            {
                bubble_emissionModule.rateOverTime = bubble_collisionCount * 4;
                bubble_collisionCount = 0;
            }
            else
            {
                bubble_emissionModule.rateOverTime = bubble_collisionCount;
            }

        }

    }

    public void BubbleCollisionAction(List<ParticleCollisionEvent> collisionEvents)
    {
       // lastCount = collisionCount;
        bubble_collisionCount = collisionEvents.Count;
        flame_collisionCount = collisionEvents.Count;

        //Debug.Log("MESSAGE RECEIVED "+ collisionCount);

        // Set up logic here for when to extinguish, also need to add the flicker to the light and rotate to the flame

    }

}