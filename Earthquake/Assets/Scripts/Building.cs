using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
      
   }

   void OnDrawGizmos()
	{
      Gizmos.color = Color.yellow;

      var up = transform.TransformDirection(transform.localPosition);
      Gizmos.DrawLine(transform.position, up);
   }
}
