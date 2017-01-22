using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	   var buildings = GameObject.FindObjectsOfType<Building>();
	   int blueAlive = buildings.Count(b => b.collapsed == false && b.owner == "Blue");
	   int redAlive = buildings.Count(b => b.collapsed == false && b.owner == "Red");


      Debug.Log("Blue left: " + blueAlive + ", red left: " + redAlive);

	}
}
