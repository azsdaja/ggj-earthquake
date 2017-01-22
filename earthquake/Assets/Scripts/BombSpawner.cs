using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour {

	
    public int gridSize = 30;
    public int maxSpawnTime=3;
    Dictionary<float, int> forces = new Dictionary<float, int>();
    public GameObject bomb;
    private float timePassed;
	void Start ()
    {
        forces.Add(50.0f, 100);
        forces.Add(60.0f, 120);
        forces.Add(70.0f, 160);
        forces.Add(80.0f, 180);
        forces.Add(90.0f, 200);
        forces.Add(100.0f, 200);
        SpawnBomb();
        timePassed = maxSpawnTime;    		
	}
	
	void Update ()
    {
        timePassed -= Time.unscaledDeltaTime;
        if (timePassed <= 0)
        {
            SpawnBomb();
            timePassed = maxSpawnTime;
        }
		    
	}


    
    void SpawnBomb()
    {

        float r = Random.Range(0.4f, 1.0f);
        bomb.transform.localScale = new Vector3 (r, r, r);

        bomb.GetComponent<Bomb>().explosionForce = Mathf.Round(bomb.transform.localScale.x * 100) * 6;
        
        Instantiate(bomb, new Vector3(Random.Range(1, gridSize), 6, Random.Range(1, gridSize)), Quaternion.identity);
    }

}
