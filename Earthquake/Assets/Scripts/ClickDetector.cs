using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClickDetector : MonoBehaviour
{
    public bool P1Active = true, P2Active = false;
    public float placeTimeLeft, placeMaxTime = 5;
    public Text timeLeftText;
    GameObject P1Wave, P2Wave;

    private int active=0;
   
   // Use this for initialization
   void Start()
   {
        placeTimeLeft = placeMaxTime;
   }

   // Update is called once per frame
   void Update()
   {
        placeTimeLeft -= Time.unscaledDeltaTime;
        timeLeftText.text = ((int)placeTimeLeft).ToString();


        if (P1Active && placeTimeLeft <= 0)
        {
            P1Active = false;
            P2Active = true;
            placeTimeLeft = placeMaxTime;
            active++;
        }
        else if (P2Active && placeTimeLeft <= 0)
        {
            P1Active = false;
            P2Active = true;
            placeTimeLeft = placeMaxTime;
            active++;
        }
        if (Input.GetMouseButton(0))
      {
         RaycastHit hit;
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         if (Physics.Raycast(ray, out hit))
         {
                if (P1Active)
                {
                    if (P1Wave == null)
                    {
                        P1Wave = hit.transform.gameObject;
                        P1Wave.GetComponent<Renderer>().material.color = Color.red;
                    }
                    else
                    {
                        P1Wave.GetComponent<Renderer>().material.color = Color.white;
                        P1Wave = hit.transform.gameObject;
                        P1Wave.GetComponent<Renderer>().material.color = Color.red;
                    }
                }
                if(P2Active)
                {
                    if (P2Wave == null)
                    {
                        P2Wave = hit.transform.gameObject;
                        P2Wave.GetComponent<Renderer>().material.color = Color.blue;
                    }
                    else
                    {
                        P2Wave.GetComponent<Renderer>().material.color = Color.white;
                        P2Wave = hit.transform.gameObject;
                        P2Wave.GetComponent<Renderer>().material.color = Color.blue;
                    }                    
                }
         }
      }

        if (active == 2)
        {
            StartEarthquake(P1Wave, 300);
            StartEarthquake(P2Wave, 300);
            active = 0;
            P1Active = true;
            P2Active = false;
            placeTimeLeft = placeMaxTime;

        }
    }

    void StartEarthquake(GameObject tile,int f)
    {
        tile.transform.GetComponent<Rigidbody>().AddForce(Vector3.up * f, ForceMode.Impulse);
    }
}