using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearControllerScript : MonoBehaviour {

    [SerializeField] private float gearPower=100;
    [SerializeField] private float motileScrewPower = 10;
    [SerializeField] private float armScrewPower = 10;
    [SerializeField] private GameObject gearSide;
    [SerializeField] private GameObject motileScrew;
    [SerializeField] private GameObject armScrew;
    [SerializeField] private GameObject arm;

    [SerializeField] private float maximumAngle = 20;
    [SerializeField] private float minimumAngle = -20;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        GearController();
	}

    private void GearController()
    {
        if (Input.GetKey(KeyCode.S))
        {
            Move(1);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Move(-1);
        }

       
    }

    private void Move(int direction)
    {
        bool canArmMoveUpwards = true;
        bool canArmMoveDownwards = true;

       
        Vector3 forward = arm.transform.position - armScrew.transform.position;
        float angle = Mathf.Atan2(forward[1], forward[0]);
        angle = Mathf.Rad2Deg * (angle);

        if (angle > maximumAngle)
        {
            angle = maximumAngle;
            canArmMoveUpwards = false;
            canArmMoveDownwards = true;
        }
        else if (angle < minimumAngle)
        {
            angle = minimumAngle;
            canArmMoveUpwards = true;
            canArmMoveDownwards = false;
        }
        else
        {
            canArmMoveUpwards = true;
            canArmMoveDownwards = true;
        }


        if (canArmMoveUpwards && direction > 0 || canArmMoveDownwards && direction < 0)
        {
            MoveArm(direction);
        }

        if(canArmMoveDownwards && canArmMoveUpwards)
        {
            forward = arm.transform.position - armScrew.transform.position;
            angle = Mathf.Atan2(forward[1], forward[0]);
            angle = Mathf.Rad2Deg * (angle);
        }

        arm.transform.eulerAngles = new Vector3(arm.transform.eulerAngles.x, arm.transform.eulerAngles.y, angle);


    }

    private void MoveArm(int direction)
    {
        gearSide.transform.Rotate(new Vector3(0, 0, direction * gearPower), Time.deltaTime * gearPower, Space.World);
        motileScrew.transform.Rotate(new Vector3(0, -direction * motileScrewPower, 0) * Time.deltaTime, Space.Self);
        armScrew.transform.Rotate(new Vector3(0, direction * armScrewPower, 0) * Time.deltaTime, Space.Self);
    }
}
