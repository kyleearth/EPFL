using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Note
{
    C=0, D=2, E=4, F=5, G=7, A=9, B=11, C1=12, D1=14
}

// Site this code is poached from
// https://answers.unity.com/questions/141771/whats-a-good-way-to-do-dynamically-generated-music.html

public class MusicNotes : MonoBehaviour
{
    float transpose = -4;  // transpose in semitones

    AudioSource asr;

    // Start is called before the first frame update
    void Start()
    {
        asr = GetComponent<AudioSource>();
    }

    public void PlayNote(Note note)
    {
        asr.pitch = Mathf.Pow(2, ((float)note + transpose) / 12.0f);
        asr.Play();
    }

    // Update is called once per frame
    void Update()
    {
        float note = -1; // invalid value to detect when note is pressed
        if (Input.GetKeyDown("a")) note = 0;  // C
        if (Input.GetKeyDown("s")) note = 2;  // D
        if (Input.GetKeyDown("d")) note = 4;  // E
        if (Input.GetKeyDown("f")) note = 5;  // F
        if (Input.GetKeyDown("g")) note = 7;  // G
        if (Input.GetKeyDown("h")) note = 9;  // A
        if (Input.GetKeyDown("j")) note = 11; // B
        if (Input.GetKeyDown("k")) note = 12; // C
        if (Input.GetKeyDown("l")) note = 14; // D

        if (note >= 0)
        { // if some key pressed...

            asr.volume = Random.Range(.1f, .7f);
            asr.pitch = Mathf.Pow(2, (note + transpose) / 12.0f);
            Debug.Log("Pitch: " + asr.pitch.ToString());
            asr.Play();
        }

    }

    public void BreathCollisionAction(List<ParticleCollisionEvent> collisionEvents)
    {
        int collisionCount = collisionEvents.Count;

        // Note: gemotery adjusts will need to be made if plane not parralel to either x or z plane. 

        // calculate location of average hit
        Vector3 average = Vector3.zero;
        for (int i = 0; i < collisionCount; i++)
        {
            average += collisionEvents[i].intersection;
        }
        average /= collisionCount;
        Debug.Log("Hit the music plane - Average Coordinate: " + average.ToString());

        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Destroy(go.GetComponent<Collider>());
        go.transform.position = average;
        go.transform.localScale = new Vector3(.025f, .025f, .001f);

        // change pitch and volume of audio clip
        // audioSource.volume = 0.9f;
        // isLastFrameMusic = true;
        // audioVolume = 1f;

        asr.Play();
        // audioSource.

        // Debug.Log("MESSAGE RECEIVED");
    }

}
