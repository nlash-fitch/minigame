using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMove : MonoBehaviour
{
    public GameObject player;
    private int speed = 20;
    private int chargeBar = 0;
    public GameObject Projectile;

    public GameManager GameManager;
    public GameObject me;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.GameStart) {
            Destroy(me);
        }
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
        
    }
    private void FixedUpdate()
    {
        chargeBar++;
        if (chargeBar >= 200) {
            Instantiate(Projectile, transform.position, transform.rotation);
            chargeBar = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "playerP") {
            Destroy(me);
            GameManager.addScore(5);
        }
    }
}
