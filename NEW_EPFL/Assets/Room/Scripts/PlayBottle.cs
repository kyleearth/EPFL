using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBottle : MonoBehaviour
{

    private int collisionCount = 0;
    private AudioSource asr;
    private string colliding_bottle = "";

    // Start is called before the first frame update
    void Start()
    {
        asr = GetComponent<AudioSource>();
        asr.volume = 0.0f;
        asr.time = 0.0f;
        asr.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (collisionCount > 5)
        {
            if (colliding_bottle.CompareTo("Bottle1") == 0)
            {
                asr.pitch = Mathf.Pow(1.05946f, 2);
                
            } else if (colliding_bottle.CompareTo("Bottle2") == 0) { 
                asr.pitch = Mathf.Pow(1.05946f, 6);
            }
            asr.volume = (collisionCount / 50) > 1f ? 1f : (collisionCount / 50);
        }
        else
        {
            asr.volume = 0.0f;
        }
    }

    public void BreathCollisionAction(List<ParticleCollisionEvent> collisionEvents)
    {
        collisionCount = collisionEvents.Count;
        colliding_bottle = collisionEvents[0].colliderComponent.name;
        Debug.Log("Colliding with: " + colliding_bottle);
    }
}
