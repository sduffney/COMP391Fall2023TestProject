using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SkeletonMovement : MonoBehaviour
{
    Rigidbody2D rb;
    private float timer = 5;
    private GameObject[] player;
    private bool seenPlayer;
    public float agroDistance;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        seenPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        float chance = Random.Range(1, 100);
        Vector2 playerPos = player[0].transform.position;
        float xMovement = 0, yMovement = 0;
        if (playerPos.x - this.transform.position.x <= agroDistance && playerPos.y - this.transform.position.y <= agroDistance && playerPos.x - this.transform.position.x >= -agroDistance && playerPos.y - this.transform.position.y >= -agroDistance)
        {
            seenPlayer = true;
        }
        else
        {
            seenPlayer = false;
            rb.velocity = Vector2.zero;
        }
        if (seenPlayer && timer > 0.5)
        {
            xMovement = playerPos.x - this.transform.position.x;
            yMovement = playerPos.y - this.transform.position.y;
            if (xMovement > 0 && xMovement < 2 )
            {
                xMovement = 2;
            }
            else if (xMovement < 0 && xMovement > -2 )
            {
                xMovement = -2;
            }
            if ( yMovement > 0 && yMovement < 3)
            {
                yMovement = 2;
            }
            else if ( yMovement < 0 && yMovement > -3)
            {
                yMovement = -3;
            }
            Vector2 newVelocity = new Vector2(xMovement, yMovement);
            rb.velocity = newVelocity * speed;
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
