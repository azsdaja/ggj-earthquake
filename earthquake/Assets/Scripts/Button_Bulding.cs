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
        building = Instantiate(obj,new Vector3(0, 8.7f, 0), Quaternion.identity);
        selectedBuilding = true;
    }
    Vector3 newPosition;
    void Update()
    {
        if (sceneManager.editorActive)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (selectedBuilding == true && Physics.Raycast(ray, out hit))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (building.transform.tag == "P1_Building")
                    {
                        Rigidbody[] sections = building.GetComponentsInChildren<Rigidbody>();
                        foreach (Rigidbody child in sections)
                        {
                            child.isKinematic = false;
                            child.useGravity = true;
                        }
                        sceneManager.FirstPlayerBuildings.Add(building);
                        sceneManager.P1UIActive = false;
                        sceneManager.P2UIActive = true;
                    }
                    else if (building.transform.tag == "P2_Building")
                    {
                        Rigidbody[] sections = building.GetComponentsInChildren<Rigidbody>();
                        foreach (Rigidbody child in sections)
                        {
                            child.isKinematic = false;
                            child.useGravity = true;
                        }
                        sceneManager.SecondPlayerBuildings.Add(building);
                        sceneManager.P1UIActive = true;
                        sceneManager.P2UIActive = false;
                    }
                    sceneManager.timeLeft = sceneManager.maxTime;
                    selectedBuilding = false;
                }
                if (hit.transform.tag == "Ground")
                {
                    newPosition = hit.point;
                    newPosition.y = 8.7f;

                    building.transform.position = newPosition;
                }

            }
            
        }
    }
}
