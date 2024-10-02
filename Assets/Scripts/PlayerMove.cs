using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    private float LeftRight;
    private float ForwardBack;
    private float Speed=10.0f;
    private float rotateSpeed = 90.0f;
    private float chargeBar = 0;
    public GameObject Projectile;
    public GameObject shield;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LeftRight= Input.GetAxis("Horizontal");
        ForwardBack= Input.GetAxis("Vertical");
        if (ForwardBack > 0)
        {
            transform.Translate(Vector3.forward*Speed*Time.deltaTime*ForwardBack);
        }
        if (LeftRight != 0)
        {
            transform.Rotate(Vector3.up*rotateSpeed*Time.deltaTime*LeftRight);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Projectile, transform.position, transform.rotation);
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            chargeBar++;
        }
        else
        {
            chargeBar = 0;
        }
        if (chargeBar >= 360)
        {
            Instantiate(shield, transform.position, transform.rotation);
            chargeBar = 0;
        }
    }
}
