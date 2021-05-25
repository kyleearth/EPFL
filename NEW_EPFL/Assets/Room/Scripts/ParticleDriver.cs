using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using System.Threading.Tasks;

public class ParticleDriver : MonoBehaviour
{
    //public OSC osc;
    public Anemometer meter;

    ParticleSystem breathParticleSystem;
    ParticleSystem.EmissionModule emissionModule;

    // for the collision https://answers.unity.com/questions/1197119/how-to-detect-when-and-where-a-particle-hits-a-sur.html
    private List<ParticleCollisionEvent> CollisionEvents;
    
    void Start()
    {
        // Get the system and the emission module.
        breathParticleSystem = GetComponent<ParticleSystem>();
        emissionModule = breathParticleSystem.emission;

        // Create List for Collision Events
        CollisionEvents = new List<ParticleCollisionEvent>();
    }

    public void OnParticleCollision(GameObject other)
    {
        // the event count should be the number of collisions this frame
        int eventCount = breathParticleSystem.GetCollisionEvents(other, CollisionEvents);
        
        // Debug.Log(" $$ Particle Collision with: " + other.name + " Frame: " + Time.frameCount + " Delta Time: " + Time.deltaTime.ToString() + " - eventcount: " + eventCount.ToString());

        other.BroadcastMessage("BreathCollisionAction", CollisionEvents, SendMessageOptions.DontRequireReceiver);
    }

  // The update is called once per frame
    void Update()
    {
        // Hook into the current velocity from anenometer mediator
        emissionModule.rateOverTime = meter.ArtificalSpeed*1000;

        if(Input.GetKeyDown("v"))
        {
            TurnOnOffBreathVisibility();
        }
    }

    private void TurnOnOffBreathVisibility()
    {
        var main = breathParticleSystem.main;
        ParticleSystem.MinMaxGradient mmg = main.startColor;
        Color color = mmg.color;
        if(color.a > 0.1f)
        {
            color.a = 0f;
        }
        else
        {
            color.a = 0.15f;
        }
        main.startColor = new Color(1f, 1f, 1f, color.a);
    }

}
