using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PID_control_system : MonoBehaviour {
    //przypisane do panelu

    [SerializeField] public float R { get; set;}
    [SerializeField] public float Kp { get; set; }
    [SerializeField] public float Ki { get; set; }
    [SerializeField] public float Kd { get; set; }

    private void Awake()
    {

    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void ResetParameters()
    {
        R = 0;
        Kp = 0;
        Ki = 0;
        Kd = 0;
    }

}
