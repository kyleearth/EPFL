using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotate : MonoBehaviour
{
    float xRot = 0f;
    float currentRate = 0f;

    [Range(0, 0.1f)]
    public float sensitivity = .1f;

    [Range(0, 0.1f)]
    float decayRate = .01f;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void BreathCollisionAction(List<ParticleCollisionEvent> collisionEvents)
    {
        int collisionCount = collisionEvents.Count;

        currentRate += collisionCount * sensitivity;

        Debug.Log("MESSAGE RECEIVED");
    }

    // Update is called once per frame
    void Update()
    {
        currentRate *= (1 - decayRate);
        /* if (Input.GetKey(KeyCode.T))
        {
            currentRate += increaseRate;
        } */
        if (currentRate < 10f) currentRate = 0f;

        xRot += currentRate * Time.deltaTime;
        if (xRot > 360f) xRot -= 360f;
        Vector3 newAngles = new Vector3(xRot, 0f, 0f);
        transform.localEulerAngles = newAngles;
        // Debug.Log(" Angles: " + transform.localEulerAngles.ToString() + " New Angle: " + newAngles.ToString());
    }
}
