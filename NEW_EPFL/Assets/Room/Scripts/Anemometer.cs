using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anemometer : MonoBehaviour
{
    public OSC osc;

    private float WindSpeed_MPH;
    private float TempCtimes100;
    private double zeroWindAdjustment = 0.265;
    private float artifical_Speed;
    public float ArtificalSpeed
    {
        get
        {
            return artifical_Speed;
        }
    }

    /**
   public double WindSpeed_MPH
    {
        get
        {
            return WindSpeed_MPH;
        }
    }
    
    public double TempCtimes100
    {
        get
        {
            return TempCtimes100;
        }
    }
**/
    // Start is called before the first frame update
    void Start()
    {
        // register handlers
        osc.SetAddressHandler("/inputs/analogue", OnReceiveBreathData);
        osc.SetAddressHandler("/imu", VoidHandler); // did not see option to turn these off in OSC board. 
        osc.SetAddressHandler("/battery", VoidHandler); // should add low battery warning to game
    }

    void OnReceiveBreathData(OscMessage message)
    {
        
        float TMP_Therm_ADunits = message.GetFloat(0);
        float RV_Wind_ADunits = message.GetFloat(1);
        //float x2 = message.GetFloat(2);
        
        
        float zeroWind_ADunits = (float)(-0.0006*(TMP_Therm_ADunits * TMP_Therm_ADunits) + 1.0727 * TMP_Therm_ADunits + 47.172);  //  13.0C  553  482.39
        float zeroWind_volts = (float)((zeroWind_ADunits * 0.0048828125) - zeroWindAdjustment);
        //float RV_Wind_Volts = (float)(RV_Wind_ADunits *  0.0048828125);
        float RV_Wind_Volts = (float)(RV_Wind_ADunits );
        
        TempCtimes100 = (float)((0.005 *(TMP_Therm_ADunits * TMP_Therm_ADunits)) - (16.862 * TMP_Therm_ADunits) + 9075.4);
        WindSpeed_MPH =  (float)(Math.Pow(((RV_Wind_Volts - zeroWind_volts) /0.2300) , 2.7265));

        float Win_MPS = (float) (WindSpeed_MPH / 2.237);
        artifical_Speed = (float)((Win_MPS - 10) * 1.5);

        // Debug.Log("V1 " + TMP_Therm_ADunits.ToString());

        // Debug.Log("Meter per second is  "+ artifical_Speed);
        
        
        //Debug.Log("TempCtimes100 is " + TempCtimes100 );
        //Debug.Log("wind speed"+WindSpeed_MPH );

        //WindSpeed_MPH = Mathf.Max(WindSpeed_MPH - 18f, 0f) * 100;
        //x0 = Mathf.Max(x0 - .04f, 0f);
        //velocity = x0 * 800;
    }

    void VoidHandler(OscMessage message)
    {
    }

    // Update is called once per frame
    void Update()
    {        
    }
}
