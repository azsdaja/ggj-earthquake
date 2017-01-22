﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectAfterTime : MonoBehaviour {

    public int destroyAfterTime;
    private float timePassed;
    // Use this for initialization
    void Start () {
        timePassed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timePassed += Time.unscaledDeltaTime;
        if (timePassed > destroyAfterTime)
        {
            Destroy(gameObject);
        }
    }
}
