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
      Gizmos.color = Color.yellow;

      var x = transform.rotation.eulerAngles;
      Debug.Log(x);

      float angleRange = 45f;
      float angleZ = transform.rotation.eulerAngles.z;
      float angleX = transform.rotation.eulerAngles.x;
      if (CheckAngle(angleZ, angleRange) && CheckAngle(angleX, angleRange))
      {
         return;
      }
      Destroy(gameObject);
   }

   void OnDrawGizmos()
	{
      //Gizmos.color = Color.yellow;
      //
      //var x = transform.rotation.eulerAngles;
      //Debug.Log(x);
      //
      //float angleRange = 45f;
      //float angleZ = transform.rotation.eulerAngles.z;
      //float angleX = transform.rotation.eulerAngles.x;
      //if (CheckAngle(angleZ, angleRange) && CheckAngle(angleX, angleRange))
      //{
      //   return;
      //}
	   //Gizmos.DrawSphere(transform.position + Vector3.up * 3f, 1f);
	}

   private static bool CheckAngle(float angle, float angleRange)
   {
      return (angle > -1 && angle < angleRange) ||
             (angle > (361 - angleRange) && angle < 361);
   }
}
