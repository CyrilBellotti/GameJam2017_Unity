using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	public float fallDelay = 2.0f;
	public float floorTimer = 0.0f;
	public float fallTimer = 2.0f;
	public double startTime;
	private bool blocked = true;

	void OnCollisionEnter (Collision collideWithThis)
	{

		//startTime = Time.time + 2.0;
		if (collideWithThis.gameObject.tag == "Floor" /* && Time.time > startTime*/) {

				collideWithThis.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
			}
		}

	IEnumerator FallAfterDelay()
	{
		yield return new WaitForSeconds (2);
		//GetComponent<Rigidbody>() .isKinematic = false;
	}

}
