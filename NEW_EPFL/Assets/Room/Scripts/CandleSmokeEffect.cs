using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleSmokeEffect : MonoBehaviour
{
    public int smokeDurationNoFrames = 60;
    [Range(0f, 100f)]
    public float emitterVelocity = 70f;

    private int smokeFrameCounter = -1;

    private ParticleSystem.EmissionModule em;

    // Start is called before the first frame update
    void Start()
    {
        em = GetComponent<ParticleSystem>().emission;
        em.rateOverTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (smokeFrameCounter == 0)
        {
            em.rateOverTime = 0f;
            smokeFrameCounter = -1;
        }
        else if (smokeFrameCounter > 0) smokeFrameCounter--;
    }

    public void InitiateCandleSmokeSequence()
    {
        smokeFrameCounter = smokeDurationNoFrames;
        em.rateOverTime = emitterVelocity;
    }


}
