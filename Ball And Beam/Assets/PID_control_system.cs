using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PID_control_system : MonoBehaviour {
    //assigned to panel

    [SerializeField] public float R_star { get; set;}
    [SerializeField] public float Kp { get; set; }
    [SerializeField] public float Ki { get; set; }
    [SerializeField] public float Kd { get; set; }

    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject beam;

    private float mass; //mass of the ball
    private float radius;
    private float length; //length of the beam
    private float g = 9.81f; //gravitation - try to get it from engine
    private float J = (float)(9.99 * Math.Pow(10,-6)); //ball's moment of interia
    private float d; //offset ramienia

    private float[] u_arr; //controlling, [0]- previous, [1]- current
    private float[] r_arr;
    private float[] y_arr; 
    private float[] e_arr; //error

    private float e_der;
    private float e_sum;

    private float r0 = 0; //0 because of transform function- transmitancja
    private float y0 = 0; //same

    //h - time.deltaTime
    private float u_max;
    private float u_min;



    private void Awake()
    {
        Rigidbody ballRigidbody = ball.GetComponentInChildren<Rigidbody>();
        mass = ballRigidbody.mass;
        radius = ball.transform.localScale.x;
        length = transform.localScale.y; //?
        d = 1;

        u_arr = new float[2];
        r_arr = new float[2];
        y_arr = new float[2];
        e_arr = new float[2];

        r_arr[0] = r0;
        y_arr[0] = y0;
        e_arr[0] = R_star - r_arr[0];

        e_sum = e_arr[0] * Time.deltaTime;
        e_der = 0;
        u_arr[0] = Kp * e_arr[0] + Ki * e_sum + Kd * e_der;



    }

    private void Start()
    {
        
    }

    private void Update()
    {
        r_arr[1] = ball.transform.position.x;
        //u_arr[1] = Kp * e_arr[0] + Ki * e_sum + Kd * e_der;

        //gear_script.ModifyAngle(u_arr[1]);
 
        e_arr[1] = R_star - r_arr[1];


        //e_sum += e_arr[1] * Time.deltaTime;
        //e_der = (e_arr[1] - e_arr[0]) / Time.deltaTime;
        
    }

    public void ResetParameters()
    {
        R_star = 0;
        Kp = 0;
        Ki = 0;
        Kd = 0;
    }

}
