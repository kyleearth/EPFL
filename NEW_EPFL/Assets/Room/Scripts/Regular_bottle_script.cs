using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regular_bottle_script : MonoBehaviour
{
    private GameObject Bottle_obj;
    public GameObject destroyedVersion;
    private int collisionCount = 0;
    private double startTime = 0.0;

    private int bottleHitCount = -1;
    private string colliding_bottle = "";
    private bool isAudioMuted = true;


    AudioSource asr;

    void Start()
    {
        asr = GetComponent<AudioSource>();
        
        asr.volume = 0.0f;
        asr.time = 0.0f;
        asr.Play();
    }

    IEnumerator PlaySoundInterval()
    {
        //asr.volume = Random.Range(.1f, .7f);
        if (colliding_bottle.CompareTo("Bottle1") == 0)
        {
            ///asr.pitch = Mathf.Pow(2, ((float)6) / 12.0f);
            asr.pitch = Mathf.Pow(1.05946f, 2);
            asr.volume = (collisionCount / 50) > 1 ? 1 : (collisionCount / 50);
           // asr.volume = collisionCount / 90;
           //asr.PlayOneShot();
           //asr.SetScheduledEndTime(AudioSettings.dspTime + Time.deltaTime);

        } else if (colliding_bottle.CompareTo("Bottle2") == 0) {
            //asr.pitch = Mathf.Pow(2, ((float)15) / 12.0f);
            asr.pitch = Mathf.Pow(1.05946f, 4);
            //asr.Play();
            asr.volume = (collisionCount / 50) > 1 ? 1 : (collisionCount / 50);
            //asr.PlayOneShot();
            //asr.SetScheduledEndTime(AudioSettings.dspTime + Time.deltaTime);
        } else
        {
            //asr.Play();
            //asr.Play();
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
            
        }
        isAudioMuted = false;
        
        //asr.SetScheduledEndTime(AudioSettings.dspTime + Time.deltaTime);
        
        yield return null;
        
    }

    IEnumerator TaskKiller(float delay, Tasker t)
    {
        yield return new WaitForSeconds(delay);
        t.Stop();
        //asr.volume = 0.0f;
        isAudioMuted = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (collisionCount > 5 && (isAudioMuted == true))
        {

            //StartCoroutine("PlaySoundInterval");
            //bottleHitCount = 0;
            Tasker t = new Tasker(PlaySoundInterval());
            if (t.Running)
            {
                new Tasker(TaskKiller(1, t));
                collisionCount = 0;
            }
        }*/

        if (collisionCount > 5)
        {
            asr.pitch = Mathf.Pow(1.05946f, 2);
            asr.volume = (collisionCount / 50) > 1 ? 1 : (collisionCount / 50);
            //asr.time = (float)AudioSettings.dspTime;
            //asr.time = (float)startTime;
            //asr.SetScheduledEndTime(asr.time + Time.deltaTime);
            
            //asr.Play();
            //startTime = startTime + Time.deltaTime;
        } else
        {
            asr.volume = 0.0f;
        }
             

        /*if (collisionCount > 0)
        {
            audioSource.pitch -= Time.deltaTime * startingPitch / timeToDecrease;
        }*/

    }

    public void BreathCollisionAction(List<ParticleCollisionEvent> collisionEvents)
    {
        collisionCount = collisionEvents.Count;
        colliding_bottle = collisionEvents[0].colliderComponent.name;

        Debug.Log("Collision Count: " + collisionCount);
        
        
        /*Dictionary<string, int> dict = new Dictionary<string, int>();
        int zero;
        for (int i = 0; i < collisionCount; i++)
        {
            Debug.Log("Collding with bottle " + collisionEvents[i].colliderComponent.name);
            if (dict.TryGetValue(collisionEvents[i].colliderComponent.name, out zero))
            {
                dict.Remove(collisionEvents[i].colliderComponent.name);
                dict.Add(collisionEvents[i].colliderComponent.name, zero + 1);
            }
            else
            {
                dict.Add(collisionEvents[i].colliderComponent.name, 0);
            }
        }
        
        foreach (KeyValuePair<string, int> item in dict)
        {
            if (item.Value > bottleHitCount)
            {
                bottleHitCount = item.Value;
                colliding_bottle = item.Key;
            }
        }*/
        
       
    }
}
