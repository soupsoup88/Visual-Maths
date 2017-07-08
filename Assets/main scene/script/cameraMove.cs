using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour {
	// Use this for initialization
	public GameObject target;
	public GameObject pointsHolder;
	private bool moveLeft;
	private bool moveRight;
	private bool moveUp;
	private bool moveDown;
	private bool moveForward;
	private bool moveBackward;
	public float maxZoom;
	public float minZoom;
	void Start () {
		transform.LookAt (target.transform);
	}
	
	// Update is called once per frame
	void Update () {
		checkKey ();
		getNewPos();



	}

	private void checkKey () {
		if (Input.GetButtonDown ("left"))
			moveLeft = true;
		if (Input.GetButtonUp ("left"))
			moveLeft = false;

		if (Input.GetButtonDown ("right"))
			moveRight = true;
		if (Input.GetButtonUp ("right"))
			moveRight = false;

		if (Input.GetButtonDown ("up"))
			moveUp = true;
		if (Input.GetButtonUp ("up"))
			moveUp = false;

		if (Input.GetButtonDown ("down"))
			moveDown = true;
		if (Input.GetButtonUp ("down"))
			moveDown = false;

		if (Input.GetButtonDown ("A"))
			moveForward = true;
		if (Input.GetButtonUp ("A"))
			moveForward = false;

		if (Input.GetButtonDown ("Z"))
			moveBackward = true;
		if (Input.GetButtonUp ("Z"))
			moveBackward = false;
	}

	private void getNewPos() {
		if (moveLeft) {
			transform.RotateAround (target.transform.position, Vector3.up, 20 * Time.deltaTime);
		}
		if (moveRight) {
			transform.RotateAround (target.transform.position, Vector3.down, 20 * Time.deltaTime);
		}
		if (moveUp) {
			transform.RotateAround (target.transform.position, Vector3.left, 20 * Time.deltaTime);
		}
		if (moveDown) {
			transform.RotateAround (target.transform.position, Vector3.right, 20 * Time.deltaTime);
		}

		if (moveBackward) {
			if (Camera.main.fieldOfView + 1 < maxZoom)
				Camera.main.fieldOfView += 1;
		}

		if (moveForward) {
			if (Camera.main.fieldOfView - 1 > minZoom)
				Camera.main.fieldOfView -= 1;
		}

	}
		
}
