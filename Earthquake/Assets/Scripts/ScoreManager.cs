using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

   public GameObject FinishButton, winSound;
   public Text XWins;
   public bool playedWin = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	   var buildings = GameObject.FindObjectsOfType<Building>();
	   int blueAlive = buildings.Count(b => b.collapsed == false && b.owner == "Blue");
	   int redAlive = buildings.Count(b => b.collapsed == false && b.owner == "Red");

	   var scoreTexts = GameObject.FindObjectsOfType<Text>();
	   foreach (var scoreText in scoreTexts)
	   {
	      if (scoreText.name == "BlueScore")
	      {
	         scoreText.text = blueAlive + " buildings left";
	         if (blueAlive <= 0 && !playedWin)
	         {
	            FinishButton.SetActive(true);
               XWins.text = "Player Red wins!!!";
               Instantiate(winSound, new Vector3(0, 0, 0), Quaternion.identity);
               playedWin = true;
	          }
	      }
	      if (scoreText.name == "RedScore")
	      {
	         scoreText.text = redAlive + " buildings left";
            if (redAlive <= 0 && !playedWin)
            {
               FinishButton.SetActive(true);
               XWins.text = "Player Blue wins!!!";
               Instantiate(winSound, new Vector3(0, 0, 0), Quaternion.identity);
               playedWin = true;
            }
         }
	   }

      //Debug.Log("Blue left: " + blueAlive + ", red left: " + redAlive);

	}
}
