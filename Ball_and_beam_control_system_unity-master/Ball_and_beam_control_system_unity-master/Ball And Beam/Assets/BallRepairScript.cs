using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRepairScript : MonoBehaviour {

    [SerializeField] private float acceptableBlockedTime = 1f;
    [SerializeField] private float repairTranslation = 0.1f;

    private float previousMoveTime = 0f;
    private Vector3 previousPosition;
    

	// Use this for initialization
	void Start () {
        previousPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        BlockControl();
	}

    private void BlockControl()
    {
        if (transform.position != previousPosition)
        {
            previousPosition = transform.position;
            previousMoveTime = Time.time;
        }
        else if(Time.time-previousMoveTime>=acceptableBlockedTime)
        {
            Debug.Log("BLOCKED!");
            previousMoveTime = Time.time;
            transform.Translate(new Vector3(0, repairTranslation, 0));
        }
    }
}
