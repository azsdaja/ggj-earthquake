using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{

   public GameObject Origin;

	// Use this for initialization
	void Start ()
	{
	   Object objectToLoad = Resources.Load("Prefabs/PieceOfTerrain", typeof(GameObject));
	   const int gridSize = 30;
      var objects = new Dictionary<Position, GameObject>();
	   for (int i = 0; i < gridSize; i++)
	   {
	      for (int j = 0; j < gridSize; j++)
	      {
            GameObject instance = Instantiate(objectToLoad, new Vector3(i, 0, j), Quaternion.identity) as GameObject;
	         objects[new Position(i, j)] = instance;
	      }
	   }

	   for (int i = 0; i < gridSize; i++)
	   {
	      for (int j = 0; j < gridSize; j++)
	      {
	         GameObject currentPiece = objects[new Position(i, j)];
	         var currentMovable = currentPiece.GetComponent<PieceOfTerrain>().MovablePart;
            var upperNeighbourPosition = new Position(i+1, j);
	         JoinToNeighbour(objects, upperNeighbourPosition, currentMovable);
            var rightNeighbourPosition = new Position(i, j+1);
	         JoinToNeighbour(objects, rightNeighbourPosition, currentMovable);
	      }
	   }
	   
	}

   private static void JoinToNeighbour(Dictionary<Position, GameObject> objects, Position neighbourPosition, GameObject currentMovable)
   {
      if (objects.ContainsKey(neighbourPosition))
      {
         var upperNeighbour = objects[neighbourPosition];
         var upperNeighbourMovable = upperNeighbour.GetComponent<PieceOfTerrain>().MovablePart;

         var joint = currentMovable.AddComponent<SpringJoint>();
         joint.connectedBody = upperNeighbourMovable.GetComponent<Rigidbody>();
         joint.spring = 50f;
      }
   }

   // Update is called once per frame
	void Update () {
		
	}
}
