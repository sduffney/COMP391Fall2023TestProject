using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour
{
    public float playerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 4;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement;
        float verticalMovement;

        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        Vector2 newVelocity = new Vector2(horizontalMovement, verticalMovement);
        GetComponent<Rigidbody2D>().velocity = newVelocity * playerSpeed;

    }
}
