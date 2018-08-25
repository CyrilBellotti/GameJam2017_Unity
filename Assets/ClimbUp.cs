using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ClimbUp : MonoBehaviour {


	private bool canClimb = false;
	private Rigidbody rb;
	private RigidbodyFirstPersonController cc;
	public Animator anim;
	public Camera parkourCam;
	public Camera regularCam;
	public RaycastHit hitR;
	private bool blocked = false;
	private double timestamp = 2.0;


	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody> ();
		cc = GetComponent <RigidbodyFirstPersonController> ();

	}



	// Update is called once per frame
	void Update () {

		canClimb = false;

		if (Physics.Raycast (transform.position, transform.forward, out hitR, 1)) {
			if (hitR.transform.tag == "Climb") {

				canClimb = true;
			}
		}

		if (canClimb && Input.GetKeyDown (KeyCode.E) && !blocked) {

			blocked = true;
			timestamp = Time.time + 3.0;
			regularCam.depth = 0;
			parkourCam.depth = 1;
			cc.enabled = false;
			rb.isKinematic = true;
			anim.SetTrigger ("Climb");
			StartCoroutine (afterClimb());

		}

		if (Time.time >= timestamp) {
			blocked = false;
		}


	}

	IEnumerator afterClimb (){
		yield return new WaitForSeconds (1);
		regularCam.depth = 1;
		parkourCam.depth = 0;
		cc.enabled = true;
		rb.isKinematic = false;
		transform.position = parkourCam.transform.position;

	}

}