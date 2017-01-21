using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceOfTerrain : MonoBehaviour
{
   public GameObject MovablePart;
   private Rigidbody _rigidBody;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	   //if (transform.position.y < 1f)
	   //{
	   //   _rigidBody = _rigidBody ?? GetComponent<Rigidbody>();
      //   _rigidBody.velocity = Vector3.zero;
	   //}
	}
}
