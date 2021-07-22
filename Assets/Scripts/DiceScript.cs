using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour
{

    public Rigidbody rb;

    public Vector3 diceVelocity;

    public bool canRoll = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update()
    {
        diceVelocity = rb.velocity;

        if (Input.GetKeyDown (KeyCode.Space) && rb.velocity == new Vector3(0, 0, 0) && canRoll)
        {
            float dirX = Random.Range (400, 100);
            float dirY = Random.Range (400, 1000);
            float dirZ = Random.Range (400, 1000);

            transform.position = new Vector3 (0, 7, 0);
            //transform.rotation = Quaternion.identity;
            rb.AddForce (transform.up * 700);
            rb.AddTorque (dirX, dirY, dirZ);
            canRoll = false;

        }
    }
}
