using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoStepControlSystem : ControlSystem {

    private float previuos_u;

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

        if (error < 0)
        {
            previuos_u = normalizedMaxValue;
            return normalizedMaxValue;
        }
        else if(error == 0)
        {
            return previuos_u;
        }
        else
        {
            previuos_u = normalizedMinValue;
            return normalizedMinValue;
        }
    }

    override protected void InitilizeAuxiliaries()
    {

    }
}
