using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

   public string PlayerName;
   public float speed = 6.0F;
   public float jumpSpeed = 8.0F;
   public float gravity = 20.0F;
   private Vector3 moveDirection = Vector3.zero;

   private GameObject _dynamite = null;

   void Update()
   {
      CharacterController controller = GetComponent<CharacterController>();
      var horizontalAxisName = PlayerName == "Blue" ? "Horizontal" : "HorizontalB";
      var verticalAxisName = PlayerName == "Blue" ? "Vertical" : "VerticalB";
      moveDirection = new Vector3(Input.GetAxis(horizontalAxisName), 0, Input.GetAxis(verticalAxisName));
      moveDirection = transform.TransformDirection(moveDirection);
      moveDirection *= speed;

      moveDirection.y -= gravity * Time.deltaTime;
      controller.Move(moveDirection * Time.deltaTime);

      var moveDirectionHorizontal = new Vector3(moveDirection.x, 0f, moveDirection.z);
      if(moveDirectionHorizontal!=Vector3.zero) transform.GetChild(0).LookAt(moveDirectionHorizontal);

      var dropButtonName = PlayerName == "Blue" ? "Drop" : "DropB";
      if (_dynamite != null && Input.GetButton(dropButtonName))
      {
         if (moveDirectionHorizontal.sqrMagnitude < .5f) _dynamite.transform.localPosition = new Vector3(0f, 1f, -1f);
         else _dynamite.transform.localPosition = -moveDirectionHorizontal.normalized*1.5f + new Vector3(0f, 1f, 0f);
         _dynamite.transform.parent = null;
         _dynamite = null;
      }
   }

   void OnTriggerEnter(Collider col)
   {
      if (_dynamite == null && col.gameObject.CompareTag("Dynamite"))
      {
         _dynamite = col.gameObject;
         col.gameObject.transform.parent = transform; 
         col.gameObject.transform.localPosition = new Vector3(0f, 3f, 0f);
      }
   }
}
