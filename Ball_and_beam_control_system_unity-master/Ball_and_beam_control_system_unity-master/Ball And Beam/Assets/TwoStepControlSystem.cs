using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoStepControlSystem : ControlSystem
{

    [SerializeField] private float switchFrequency = 0.5f;
    private float previuos_u;
    private float switchTime = 0;


    override protected float CalculateError()
    {
        r = ball.transform.position.x;
        R_star = pointer.position.x;
        e_arr[1] = R_star - r;

        return e_arr[1];
    }

    override public float CalculateControl()
    {
        float error = CalculateError();
        if (error < 0 && Time.time - switchTime >= switchFrequency)
        {
            switchTime = Time.time;
            previuos_u = normalizedMaxValue;
            return normalizedMaxValue;
        }
        else if (error > 0 && Time.time - switchTime >= switchFrequency)
        {
            switchTime = Time.time;
            previuos_u = normalizedMinValue;
            return normalizedMinValue;

        }
        else
        {
            return previuos_u;
        }
    }

    override protected void InitilizeAuxiliaries()
    {
    }
}
