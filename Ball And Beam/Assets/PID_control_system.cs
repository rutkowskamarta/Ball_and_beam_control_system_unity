using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PID_control_system : MonoBehaviour {

    ///
    /// P_ball = -m*g*d/L/(J/R^2+m)/s^2
    /// 
    /// m - masa piłki- np. 0.11 kg
    /// R - średnica piłki- np. 0.015 m
    /// d - przesunięcie ramienia od silniczka, u nas jest to 0
    /// g - przyspieszenie ziemskie 9,81 m/s^2
    /// L - długość poprzeczki- np. 2 metry
    /// J - moment bezwładności piłeczki - 9.99e-6 kg.m^2
    /// r - koordynaty piłeczki
    /// 
    /// 

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
