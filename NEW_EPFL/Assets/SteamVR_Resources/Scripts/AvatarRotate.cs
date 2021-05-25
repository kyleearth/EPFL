using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AvatarRotate : MonoBehaviour
{
    private float angle = 0;
    private const int ANGLE_INCREMENT = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ChangeAngle(-ANGLE_INCREMENT*Time.deltaTime*10);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            ChangeAngle(ANGLE_INCREMENT*Time.deltaTime*10);
        }
        else if (Input.GetKey("up"))
        {
            // Debug.Log("up arrow - move forward");
            ChangePosition(true);
        }
        else if (Input.GetKey("down"))
        {
            // Debug.Log("down arrow - move backwards");
            ChangePosition(false);
        }
    }

    private double DegreeToRadian(double angle)
    {
        return Math.PI * angle / 180.0;
    }

    private void ChangePosition(bool isForward)
    {
        Debug.Log("Change Position Angle: " + angle.ToString());

        float x_pos = transform.position.x;
        float z_pos = transform.position.z;
        float y_pos = transform.position.y;
        float x_move = 0f;
        float z_move = 0f;

        float move = Time.deltaTime * 10;

        if (angle == 0)
        {
            // z_move = 1f;
            z_move = move;
        }
        else if (angle == 90)
        {
            x_move = move;
        }
        else if (angle == 180)
        {
            z_move = -move;
        }
        else if(angle == 270)
        {
            x_move = -move;
        }
        else if (angle < 90)
        {
            x_move = Convert.ToSingle(Math.Sin(DegreeToRadian(angle))*move);
            z_move = Convert.ToSingle(Math.Cos(DegreeToRadian(angle))*move);
        }
        else if(angle < 180)
        {
            x_move = Convert.ToSingle(Math.Sin(DegreeToRadian(180-angle)) * move);
            z_move = -Convert.ToSingle(Math.Cos(DegreeToRadian(180-angle)) * move);
        }
        else if(angle < 270)
        {
            x_move = -Convert.ToSingle(Math.Cos(DegreeToRadian(270-angle)) * move);
            z_move = -Convert.ToSingle(Math.Sin(DegreeToRadian(270-angle)) * move);
        }
        else if (angle < 360)
        {
            x_move = -Convert.ToSingle(Math.Sin(DegreeToRadian(360-angle)) * move);
            z_move = Convert.ToSingle(Math.Cos(DegreeToRadian(360-angle))*move);
        }

        if (isForward)
        {
            x_pos += x_move;
            z_pos += z_move;
        }
        else
        {
            x_pos -= x_move;
            z_pos -= z_move;
        }

        transform.position = new Vector3(x_pos, y_pos, z_pos);

    }

    private void ChangeAngle(float delta)
    {
        angle += delta;
        transform.eulerAngles = new Vector3(0f, Convert.ToSingle(angle), 0f);
        angle = Convert.ToInt32(transform.eulerAngles.y);
        Debug.Log(" Angle Change : " + angle.ToString());
    }
}

/*    void OldUpdate()
    {
        if (Input.GetKeyDown("left"))
        {
            Debug.Log("left arrow");
            if (angle > -90f)
            {
                angle -= 5f;
                angle = Mathf.Max(angle, -90f);
                transform.eulerAngles = new Vector3(0f, angle, 0f);
            }
        }

        if (Input.GetKeyDown("right"))
        {
            Debug.Log("right arrow");
            if (angle < 90f)
            {
                angle += 5f;
                angle = Mathf.Min(angle, 90f);
                transform.eulerAngles = new Vector3(0f, angle, 0f);
            }
        }
    }
*/
