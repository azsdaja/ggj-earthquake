using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
   public GameObject Origin;

	// Use this for initialization
	void Start ()
	{
	   Object objectToLoad = Resources.Load("Prefabs/PieceOfTerrain", typeof(GameObject));
	   const int gridSize = 33;
      var objects = new Dictionary<Position, GameObject>();
	   for (int i = 0; i < gridSize; i++)
	   {
	      for (int j = 0; j < gridSize; j++)
	      {
	         float iRescaled = (float) i/3f;
	         float jRescaled = (float) j/4f;
	         float height = 1f;//Mathf.Sin(iRescaled) + Mathf.Cos(jRescaled);
            GameObject instance = Instantiate(objectToLoad, new Vector3(i, .5f + height*.5f, j), Quaternion.identity) as GameObject;
	         objects[new Position(i, j)] = instance;
	      }
	   }

	   for (int i = 0; i < gridSize; i++)
	   {
	      for (int j = 0; j < gridSize; j++)
         {
            GameObject currentPiece = objects[new Position(i, j)];
            if (Random.Range(0.0f, 1.0f) > 0.985f)
            {
               bool loadTree = Random.Range(0.0f, 1.0f) > 0.5f;
               Object treeToLoad;
               if (loadTree) treeToLoad = Resources.Load("Prefabs/Tree", typeof(GameObject));
               else treeToLoad = Resources.Load("Prefabs/Bush", typeof(GameObject));
               GameObject instance = Instantiate(treeToLoad, currentPiece.GetComponent<PieceOfTerrain>().MovablePart.transform) as GameObject;
               instance.transform.Translate(-.5f, 4.7f, -1f);
               instance.transform.localScale = new Vector3(3f, 3f, 3f);
            }

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
         joint.spring = 100f;
         joint.damper = 0.1f;
         joint.tolerance = 0f;
         joint.enablePreprocessing = true;
      }
   }

   // Update is called once per frame
	void Update () {
		
	}
}
