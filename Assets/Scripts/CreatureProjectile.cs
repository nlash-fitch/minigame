using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    private int speed = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (transform.position.x > 100 || transform.position.z > 100 || transform.position.x < -100 || transform.position.z < -100)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log("player hit");
        }
    }
}
