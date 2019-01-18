using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearControllerScript : MonoBehaviour {

    [SerializeField] public ControlSystem controlSystem;
    [SerializeField] public float gearPower=10;
    [SerializeField] private GameObject armSystem;

    [SerializeField] private float maximumAngle = 5;
    private float minimumAngle;

    private void Awake()
    {
        minimumAngle = -maximumAngle;
    }

    void FixedUpdate()
    {
        Move(controlSystem.CalculateControl());
    }

    public void Move(float modifier)
    {
        modifier = Mathf.Clamp(modifier, -1, 1);
        bool canArmMoveUpwards = true;
        bool canArmMoveDownwards = true;

        modifier *= maximumAngle;
        
        if (modifier > maximumAngle)
        {
            modifier = maximumAngle;
            canArmMoveUpwards = false;
            canArmMoveDownwards = true;
        }
        else if (modifier < minimumAngle)
        {
            modifier = minimumAngle;
            canArmMoveUpwards = true;
            canArmMoveDownwards = false;
        }
        else
        {
            canArmMoveUpwards = true;
            canArmMoveDownwards = true;
        }

        if (canArmMoveUpwards && modifier < maximumAngle || canArmMoveDownwards && modifier > minimumAngle)
        {
            MoveArm(modifier);
        }
    }

    private void MoveArm(float modifier)
    {
        Vector3 desiredRotation = new Vector3(armSystem.transform.eulerAngles.x, armSystem.transform.eulerAngles.y, modifier);
        var desiredRotQ = Quaternion.Euler(desiredRotation);
        armSystem.transform.rotation = Quaternion.Lerp(armSystem.transform.rotation, desiredRotQ, Time.deltaTime*gearPower);
    }
}
