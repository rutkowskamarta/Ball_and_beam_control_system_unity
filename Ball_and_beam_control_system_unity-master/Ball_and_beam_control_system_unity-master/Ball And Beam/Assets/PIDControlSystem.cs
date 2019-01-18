using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PIDControlSystem : ControlSystem {

    public float Kp { get; set; }
    public float Ki { get; set; }
    public float Kd { get; set; }

    private float e_der;
    private float e_sum;
    

    override protected void InitilizeAuxiliaries()
    {
        e_der = 0;
        e_arr[1] = 0;
        e_sum += e_arr[0];
    }

    override protected float CalculateError()
    {
        r = ball.transform.position.x;
        R_star = pointer.position.x;

        e_arr[0] = e_arr[1];
        e_arr[1] = R_star - r;

        e_sum += e_arr[1];
        e_der = (e_arr[1] - e_arr[0]);

        return e_arr[1];
    }

    override public float CalculateControl()
    {
        float error = CalculateError();
        float u_control = Kp * error + Ki * e_sum + Kd * e_der;
        return u_control;
    }

   
    public void ResetParameters()
    {
        Kp = 0;
        Ki = 0;
        Kd = 0;
    }

}
