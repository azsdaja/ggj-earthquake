using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour {

	
    public int gridSize = 30;
    public int maxSpawnTime=1;
    public GameObject Bomb;
    private float timePassed;
	void Start ()
    {
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

        Instantiate(Bomb, new Vector3(Random.Range(1, gridSize), 6, Random.Range(1, gridSize)), Quaternion.identity);
    }

}
