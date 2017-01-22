using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public float maxTimeToExplode, explosionForce = 0;
    public GameObject ExplosionSound, WaveSound;

    private float timePassed, timer = 1;
    private GameObject healthBar;
    private bool explode = false;
    private GameObject l, pSystem;
    private MeshRenderer healthRenderer, dynamiteRenderer;
    void Start()
    {
        l = gameObject.transform.GetChild(2).gameObject;
        pSystem = gameObject.transform.GetChild(0).gameObject;
        healthBar = gameObject.transform.GetChild(1).gameObject;
        healthRenderer = healthBar.GetComponent<MeshRenderer>();
        dynamiteRenderer = gameObject.GetComponent<MeshRenderer>();
       timePassed = 0.6f;
    }

    void Update()
    {
        timePassed += Time.unscaledDeltaTime;
        float percentage = timePassed / maxTimeToExplode;
        healthBar.transform.localScale = new Vector3(healthBar.transform.localScale.x, 1 - percentage, healthBar.transform.localScale.z);
        if (timePassed > maxTimeToExplode)
        {
            explode = true;
        }
        else if (timePassed > maxTimeToExplode - (maxTimeToExplode * 0.5f) && timePassed <= maxTimeToExplode)
        {
            timer -= Time.unscaledDeltaTime;

            if (timer < 0)
            {
                if (healthRenderer.enabled == true)
                {
                    // l.SetActive(false);
                    pSystem.SetActive(false);
                    healthRenderer.enabled = false;
                    dynamiteRenderer.enabled = false;
                }
                else if (healthRenderer.enabled == false)
                {
                    pSystem.SetActive(true);
                    healthRenderer.enabled = true;
                    dynamiteRenderer.enabled = true;
                    //l.SetActive(true);
                }
                timer = 0.15f;
            }
        }
    }

        void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ground" && explode)
        {
            Instantiate(ExplosionSound, gameObject.transform.position, Quaternion.identity);
            Instantiate(WaveSound, gameObject.transform.position, Quaternion.identity);
            other.transform.GetComponent<Rigidbody>().AddForce(Vector3.up * explosionForce, ForceMode.Impulse);
            Destroy(gameObject);
        }
    }


}
