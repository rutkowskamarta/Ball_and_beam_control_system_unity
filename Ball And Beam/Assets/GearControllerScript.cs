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

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GearController();
	}

    private void GearController()
    {
        if (Input.GetKey(KeyCode.S))
        {
            gearSide.transform.Rotate(new Vector3(0, 0, gearPower) , Time.deltaTime*gearPower, Space.World);
            motileScrew.transform.Rotate(new Vector3(0, -motileScrewPower, 0)*Time.deltaTime, Space.Self);
            armScrew.transform.Rotate(new Vector3(0, armScrewPower, 0)*Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.W))
        {
            gearSide.transform.Rotate(new Vector3(0, 0, -gearPower), Time.deltaTime*gearPower, Space.World);
            motileScrew.transform.Rotate(new Vector3(0, motileScrewPower, 0)*Time.deltaTime, Space.Self);
            armScrew.transform.Rotate(new Vector3(0, -armScrewPower, 0) * Time.deltaTime, Space.Self);


        }
    }
}
