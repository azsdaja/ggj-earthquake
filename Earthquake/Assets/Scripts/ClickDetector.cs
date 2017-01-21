using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClickDetector : MonoBehaviour
{
    public bool P1Active = true, P2Active = false;
    public float placeTimeLeft, placeMaxTime = 5;
    public Text timeLeftText;
    public GameObject FightButton; 
    GameObject P1Wave, P2Wave;

    private bool waitForActive = false;
    private float waitForActiveSec = 5;
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
        if (Input.GetMouseButton(0) && waitForActive == false)
      {
         RaycastHit hit;
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         if (Physics.Raycast(ray, out hit))
         {
                if (P1Active && hit.transform.tag == "Ground")
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
                if(P2Active && hit.transform.tag == "Ground")
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

        if (active == 2 && FightButton.activeSelf == false)
        {
            waitForActive = true;
            FightButton.SetActive(true);
            waitForActiveSec = 5;
        }
        if (waitForActive)
        {
            waitForActiveSec -= Time.unscaledDeltaTime;
            timeLeftText.gameObject.SetActive(false);
            if (waitForActiveSec <= 0)
            {
                active = 0;
                P1Active = true;
                P2Active = false;
                placeTimeLeft = placeMaxTime;
                FightButton.SetActive(false);
                waitForActive = false;
                timeLeftText.gameObject.SetActive(true);
            }
        }
    }

    public void ActivateFightButton()
    {
        if (P1Wave) StartEarthquake(P1Wave, 300);
        if (P2Wave) StartEarthquake(P2Wave, 300);
        
        
        
    }

    void StartEarthquake(GameObject tile,int f)
    {
        tile.transform.GetComponent<Rigidbody>().AddForce(Vector3.up * f, ForceMode.Impulse);
    }
}