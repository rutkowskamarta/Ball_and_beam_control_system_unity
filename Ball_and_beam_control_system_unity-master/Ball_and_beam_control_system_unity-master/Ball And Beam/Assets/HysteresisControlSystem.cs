using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HysteresisControlSystem : ControlSystem
{

    [SerializeField] private float switchFrequency = 0.5f;
    [SerializeField] public float min_hystheresis { get; set; }
    [SerializeField] public float max_hystheresis { get; set; }
    private float previous_u;
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

        if (error < -min_hystheresis && Time.time - switchTime >= switchFrequency)
        {
            switchTime = Time.time;
            previous_u = normalizedMaxValue;
            return normalizedMaxValue;
        }
        else if (error > max_hystheresis && Time.time - switchTime >= switchFrequency)
        {
            switchTime = Time.time;
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
        ResetParameters();
    }

    public void ResetParameters()
    {
        min_hystheresis = 0;
        max_hystheresis = 0;
    }
}
