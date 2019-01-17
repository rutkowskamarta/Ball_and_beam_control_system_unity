using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class PanelController : MonoBehaviour {

    [SerializeField] private Slider r_slider;
    [SerializeField] private TMP_InputField kp_input;
    [SerializeField] private TMP_InputField ki_input;
    [SerializeField] private TMP_InputField kd_input;

    [SerializeField] private Transform [] pointers;
    [SerializeField] private Transform arm;

    [SerializeField] private PIDControlSystem pidBallAndBeam;

    public static float armLength;

    private void Awake()
    {
        ResetParameters();
        CalculateArmLength();
        MovePointerWithSlider();
    }

    private void ResetParameters()
    {
        r_slider.normalizedValue = 0.3f;
        kp_input.text = "0";
        ki_input.text = "0";
        kd_input.text = "0";
        //pidBallAndBeam.ResetParameters();        
    }

    private void CalculateArmLength()
    {
        armLength = arm.GetComponent<MeshFilter>().mesh.bounds.extents.x*arm.localScale.x*2;
    }

    private void MovePointerWithSlider()
    {
        foreach(Transform t in pointers)
        {
            t.localPosition = new Vector3((r_slider.normalizedValue - 1f) * armLength, t.localPosition.y, t.localPosition.z);
        }
        
    }

    public void ResetButtonOnClick()
    {
        ResetParameters();
        ReloadScene();
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
    public void SetButtonOnClick()
    {
        pidBallAndBeam.Kp = float.Parse(kp_input.text);
        pidBallAndBeam.Ki = float.Parse(ki_input.text);
        pidBallAndBeam.Kd = float.Parse(kd_input.text);
    }

    public void SliderOnSlide()
    {
        MovePointerWithSlider();
    }
}
