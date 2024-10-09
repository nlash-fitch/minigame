using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMove : MonoBehaviour
{
    public GameObject player;
    private int speed = 20;
    private int chargeBar = 0;
    public GameObject Projectile;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, player.transform.position - transform.position, 1, 1));
        transform.rotation.Set(0.0f, transform.rotation[1], 0.0f, transform.rotation[3]);

        //Debug.Log(Vector3.Distance(player.transform.position, transform.position));
        if (Vector3.Distance(player.transform.position, transform.position) > 15)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Vector3.Distance(player.transform.position, transform.position) < 15)
        {
            transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        }
        chargeBar++;
        if (chargeBar >= 1200)
        {
            Instantiate(Projectile, transform.position, transform.rotation);
            chargeBar = 0;
        }
    }
}
