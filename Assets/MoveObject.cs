using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {

	public GameObject item;
	public GameObject tempParent;
	public Transform guide;

	//   public MoveObject()
	//   {
	//   }

	void Start()
	{
		item.GetComponent<Rigidbody>().useGravity = true;
	}

	void Update()
	{

	}

	void OnMouseDown()
	{
		item.GetComponent<Rigidbody>().useGravity = false;
		item.GetComponent<Rigidbody>().isKinematic = true;
		item.transform.position = guide.transform.position;
		item.transform.rotation = guide.transform.rotation;
		item.transform.parent = tempParent.transform;
	}

	void OnMouseUp()
	{
		item.GetComponent<Rigidbody>().useGravity = true;
		item.GetComponent<Rigidbody>().isKinematic = false;
		item.transform.position = guide.transform.position;
		item.transform.parent = null;
	}
}

