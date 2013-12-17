using UnityEngine;
using System.Collections;

public class MovementBehevior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space) && constantForce.force.y <= 25)
        {
            constantForce.force = new Vector3(0,(constantForce.force.y + 1),0);
        }
        else
        {
            constantForce.force = new Vector3(constantForce.force.x, 0, constantForce.force.z);
        }

        if (Input.GetKey(KeyCode.D) && constantForce.force.x <= 25)
        {
            constantForce.force = new Vector3(0, (constantForce.force.x + 1), 0);
        }
        else
        {
            //constantForce.force = Vector3.zero;
        }
	}
}

