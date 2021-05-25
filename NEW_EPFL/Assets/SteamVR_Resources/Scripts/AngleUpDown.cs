using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleUpDown : MonoBehaviour
{
    // for angle of particle emission
    private float angle = -15.3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if rotate up/down for particle system
        if (Input.GetKeyDown(KeyCode.Q))
        // if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("rotate down");
            if (angle > -30f)
            {
                angle -= 2.5f;
                angle = Mathf.Max(angle, -30f);
                transform.eulerAngles = new Vector3(angle, transform.eulerAngles.y, transform.eulerAngles.z);
                // transform.eulerAngles = new Vector3(angle, 0f, 0f);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        // else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("rotate up");
            if (angle < 30f)
            {
                angle += 2.5f;
                angle = Mathf.Min(angle, 30f);
                // transform.eulerAngles.Set(angle, transform.eulerAngles.y, transform.eulerAngles.z);
                transform.eulerAngles = new Vector3(angle, transform.eulerAngles.y, transform.eulerAngles.z);
            }
        }

    }
}
