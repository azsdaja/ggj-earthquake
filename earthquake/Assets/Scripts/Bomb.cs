using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public float maxTimeToExplode;
    private float timePassed;
    private GameObject healthBar;
    private bool explode = false;
    private float initialLocalscale;
    void Start()
    {
       healthBar = gameObject.transform.GetChild(0).gameObject;
       timePassed = 0;
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
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground" && explode)
        {

            other.transform.GetComponent<Rigidbody>().AddForce(Vector3.up * 50, ForceMode.Impulse);
            Destroy(gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ground" && explode)
        {

            other.transform.GetComponent<Rigidbody>().AddForce(Vector3.up * 50, ForceMode.Impulse);
            Destroy(gameObject);
        }
    }


}
