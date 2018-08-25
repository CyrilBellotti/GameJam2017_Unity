using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WallRunner : MonoBehaviour {

	private bool isWallR = false;
	private bool isWallL = false;
	private RaycastHit hitR;
	private RaycastHit hitL;
	private int jumpCount = 0;
	private RigidbodyFirstPersonController cc;
	private Rigidbody rb;
	public float rotationSpeed = 60.0F;
	private float axex;
	private float axey;



	// Use this for initialization
	void Start () {
		cc = GetComponent<RigidbodyFirstPersonController> ();
		rb = GetComponent<Rigidbody> ();

	}

	// Update is called once per frame
	void Update () {

		axex = 0;
		axey = 0;
		if (cc.Grounded) {
			jumpCount = 0;
		}

		if (Physics.Raycast (transform.position, transform.right, out hitR, 1)) {
			if (hitR.transform.tag == "WallVD") {
				axex = Camera.main.transform.rotation.x;
				axey = Camera.main.transform.rotation.y;
				isWallR = true;
				isWallL = false;
				jumpCount += 1;
				rb.useGravity = false;

				Camera.main.transform.rotation = Quaternion.Euler (0, 90, 15);

				StartCoroutine (afterRun ());
			}
		}

		if (Physics.Raycast (transform.position, -transform.right, out hitL, 1)) {

			if (hitL.transform.tag == "WallVD") {
				axex = Camera.main.transform.rotation.x;
				axey = Camera.main.transform.rotation.y;
				isWallL = true;
				isWallR = false;
				jumpCount += 1;
				rb.useGravity = false;

				Camera.main.transform.rotation = Quaternion.Euler (0, -90, -15);

				StartCoroutine (afterRun ());
			}

		}

		if (Physics.Raycast (transform.position, transform.right, out hitL, 1)) {

			if (hitL.transform.tag == "WallVG") {
				axex = Camera.main.transform.rotation.x;
				axey = Camera.main.transform.rotation.y;
				isWallL = true;
				isWallR = false;
				jumpCount += 1;
				rb.useGravity = false;

				Camera.main.transform.rotation = Quaternion.Euler (0, -90, 15);

				StartCoroutine (afterRun ());
			}

		}

		if (Physics.Raycast (transform.position, -transform.right, out hitL, 1)) {

			if (hitL.transform.tag == "WallVG") {
				axex = Camera.main.transform.rotation.x;
				axey = Camera.main.transform.rotation.y;
				isWallL = true;
				isWallR = false;
				jumpCount += 1;
				rb.useGravity = false;

				Camera.main.transform.rotation = Quaternion.Euler (0, 90, -15);

				StartCoroutine (afterRun ());
			}

		}

		if (Physics.Raycast (transform.position, transform.right, out hitL, 1)) {

			if (hitL.transform.tag == "WallHD") {
				axex = Camera.main.transform.rotation.x;
				axey = Camera.main.transform.rotation.y;
				isWallL = true;
				isWallR = false;
				jumpCount += 1;
				rb.useGravity = false;

				Camera.main.transform.rotation = Quaternion.Euler (0, 0, 15);

				StartCoroutine (afterRun ());
			}

		}

		if (Physics.Raycast (transform.position, -transform.right, out hitL, 1)) {

			if (hitL.transform.tag == "WallHD") {
				axex = Camera.main.transform.rotation.x;
				axey = Camera.main.transform.rotation.y;
				isWallL = true;
				isWallR = false;
				jumpCount += 1;
				rb.useGravity = false;

				Camera.main.transform.rotation = Quaternion.Euler (0, 180, -15);

				StartCoroutine (afterRun ());
			}

		}

		if (Physics.Raycast (transform.position, transform.right, out hitL, 1)) {

			if (hitL.transform.tag == "WallHG") {
				axex = Camera.main.transform.rotation.x;
				axey = Camera.main.transform.rotation.y;
				isWallL = true;
				isWallR = false;
				jumpCount += 1;
				rb.useGravity = false;

				Camera.main.transform.rotation = Quaternion.Euler (0, 180, 15);

				StartCoroutine (afterRun ());
			}

		}

		if (Physics.Raycast (transform.position, -transform.right, out hitL, 1)) {

			if (hitL.transform.tag == "WallHG") {
				axex = Camera.main.transform.rotation.x;
				axey = Camera.main.transform.rotation.y;
				isWallL = true;
				isWallR = false;
				jumpCount += 1;
				rb.useGravity = false;

				Camera.main.transform.rotation = Quaternion.Euler (0, 0, -15);

				StartCoroutine (afterRun ());
			}

		}
	}

	IEnumerator afterRun (){
		yield return new WaitForSeconds (0.8f);
		isWallL = false;
		isWallR = false;
		rb.useGravity = true;

	}

}