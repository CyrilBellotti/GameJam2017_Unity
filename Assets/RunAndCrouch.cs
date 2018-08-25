using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class RunAndCrouch : MonoBehaviour 
{
	public float walkSpeed = 7; // regular speed
	public float crchSpeed = 3; // crouching speed
	public float runSpeed = 10;

	private RigidbodyFirstPersonController chMotor;
	private Transform tr;
	private Rigidbody rb;
	private float dist; // distance to ground
	private bool isSliding = false;
	private double slideTimer = 0.0;
	private double slideTimerMax = 1.0;
	public float slideSpeed = 7;
	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () 
	{
		chMotor =  GetComponent<RigidbodyFirstPersonController>();
		rb = GetComponent<Rigidbody> ();
		tr = transform;
		chMotor.movementSettings.ForwardSpeed = walkSpeed;
	}

	// Update is called once per frame
	void FixedUpdate ()
	{

		float vScale = 1f;
		chMotor.movementSettings.ForwardSpeed = walkSpeed;

		if ((Input.GetKey("left shift") || Input.GetKey("right shift")) && !Input.GetKey("c") && chMotor.Grounded)
		{
			chMotor.movementSettings.ForwardSpeed = runSpeed;     
		}

		if (Input.GetKey("c"))
		{ // press C to crouch
			vScale = 0.2f;
			chMotor.movementSettings.ForwardSpeed = crchSpeed; // slow down when crouching
		}

		if (Input.GetKey("c"))
		{ // press C to crouch
			vScale = 0.1f;
			chMotor.movementSettings.ForwardSpeed = crchSpeed; // slow down when crouching
		}

		float ultScale = tr.localScale.y; // crouch/stand up smoothly 

		Vector3 tmpScale = tr.localScale;
		Vector3 tmpPosition = tr.position;

		tmpScale.y = Mathf.Lerp(tr.localScale.y, vScale, 5 * Time.deltaTime);
		tr.localScale = tmpScale;

		tmpPosition.y += dist * (tr.localScale.y - ultScale); // fix vertical position        
		tr.position = tmpPosition;



		if (Input.GetKey("z") && Input.GetKeyDown ("c")  && Input.GetKey("left shift") && !isSliding) {			
			slideTimer = 0.0;
			isSliding = true;

			StartCoroutine (afterSlide ());
		}

		if (isSliding) {
			chMotor.movementSettings.ForwardSpeed = slideSpeed;
			transform.Translate((Vector3.forward * slideSpeed) * Time.deltaTime);

			slideTimer += Time.deltaTime;
			if (slideTimer > slideTimerMax) {
				isSliding = false;
			}
		}

	}

	IEnumerator afterSlide (){
		yield return new WaitForSeconds (0.7f);
		isSliding = false;
		rb.useGravity = true;

	}

}