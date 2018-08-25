using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	public GameObject Floor;

	void OnTriggerEnter(Collider node){

		SceneManager.LoadScene("PierreLevel");

	}
}