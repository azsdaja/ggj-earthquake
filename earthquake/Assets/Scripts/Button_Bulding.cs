using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Bulding : MonoBehaviour {

	
   
    public GameObject building;
    private Camera mainCamera;
    private RaycastHit hit;
    private SceneManager sceneManager;
    Ray ray;
    private bool selectedBuilding = false;
	void Start ()
    {
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>();
        mainCamera = Camera.main;
    }

   public void createBuilding(GameObject obj)
    {
        if (building) Destroy(building);
        building = Instantiate(obj, Vector3.zero, Quaternion.identity);
        selectedBuilding = true;
        Debug.Log(building);
    }
    Vector3 newPosition;
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (sceneManager.editorActive && selectedBuilding == true && Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (building.transform.tag == "P1_Building")
                {
                    sceneManager.FirstPlayerBuildings.Add(Instantiate(building));
                    sceneManager.P1UIActive = false;
                    sceneManager.P2UIActive = true;
                }
                else if (building.transform.tag == "P2_Building")
                {
                    sceneManager.SecondPlayerBuildings.Add(Instantiate(building));
                    sceneManager.P1UIActive = true;
                    sceneManager.P2UIActive = false;
                }
                sceneManager.timeLeft = sceneManager.maxTime;
                selectedBuilding = false;
            }
            if (hit.transform.tag == "Ground")
            {
                newPosition = hit.point;
                newPosition.y = 0.5f;

                building.transform.position = newPosition;
            }

        }
    }
}
