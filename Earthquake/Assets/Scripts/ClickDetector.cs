using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetector : MonoBehaviour
{

   // Use this for initialization
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
      if (Input.GetMouseButton(0))
      {
         RaycastHit hit;
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         if (Physics.Raycast(ray, out hit))
         {
            //hit.transform.GetComponent<Rigidbody>().AddExplosionForce(9999999, Vector3.up, 0, 0);
            hit.transform.GetComponent<Rigidbody>().AddForce(Vector3.up*100, ForceMode.Impulse);
         }
      }
   }
}