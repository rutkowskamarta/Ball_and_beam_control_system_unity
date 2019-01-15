using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Panel_controller : MonoBehaviour {

    [SerializeField] private TMP_InputField r_input;
    [SerializeField] private TMP_InputField kp_input;
    [SerializeField] private TMP_InputField ki_input;
    [SerializeField] private TMP_InputField kd_input;

    private static PID_control_system pid_script;


    private void Awake()
    {
        pid_script = gameObject.GetComponent<PID_control_system>();
        ResetParameters();
    }

    private void ResetParameters()
    {
        r_input.text = "0";
        kp_input.text = "0";
        ki_input.text = "0";
        kd_input.text = "0";
        pid_script.ResetParameters();
        
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
        pid_script.R_star = float.Parse(r_input.text);
        pid_script.Kp = float.Parse(kp_input.text);
        pid_script.Ki = float.Parse(ki_input.text);
        pid_script.Kd = float.Parse(kd_input.text);
    }
}
