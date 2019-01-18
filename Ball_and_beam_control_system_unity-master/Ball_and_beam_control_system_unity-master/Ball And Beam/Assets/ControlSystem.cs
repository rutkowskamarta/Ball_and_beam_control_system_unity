using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ControlSystem : MonoBehaviour
{
    [SerializeField] protected Transform ball;
    [SerializeField] protected Transform pointer;

    [SerializeField] protected int normalizedMinValue = -1;
    [SerializeField] protected int normalizedMaxValue = 1;

    protected float[] e_arr;

    protected float R_star { get; set; }
    protected float r { get; set; }

    private void Awake()
    {
        R_star = pointer.transform.localPosition.x;
        r = ball.transform.localPosition.x;
        
        e_arr = new float[2];

        e_arr[0] = R_star - r;
        InitilizeAuxiliaries();
    }

    protected abstract void InitilizeAuxiliaries();

    protected abstract float CalculateError();

    public abstract float CalculateControl();

}
