using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HysteresisControlSystem : ControlSystem {

    [SerializeField] private float hystheresis;
    private float previous_u;

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

        if (error < -hystheresis)
        {
            previous_u = normalizedMaxValue;
            return normalizedMaxValue;
        }
        else if (error > hystheresis)
        {
            previous_u = normalizedMinValue;
            return normalizedMinValue;
        }
        else
        {
            return previous_u;
        }
    }

    override protected void InitilizeAuxiliaries()
    {

    }
}
