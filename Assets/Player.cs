using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Cursor.lockState = CursorLockMode.Locked;
		}
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Cursor.lockState = CursorLockMode.None;
		}

		var moveVector = new Vector3();
		
		moveVector.x = Input.GetAxis("Horizontal");
		moveVector.z = Input.GetAxis("Vertical");

		transform.Translate(moveVector);

		var rotateVector = new Vector3();

		rotateVector.x = -Input.GetAxis("Mouse Y");
		rotateVector.y = Input.GetAxis("Mouse X");
		rotateVector.z = -Input.GetAxis("Rotate");

		transform.Rotate(rotateVector);
	}
}
