using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
 
public class ZombieMovement : MonoBehaviour
{
    Rigidbody2D rb;
    private float timer = 5;
    private GameObject[] player;
    private GameObject[] meat;
    private bool seePlayer;
    public float agroDistance;
    public float speed;
    private bool seeMeat;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        seePlayer = false;
        seeMeat = false;
    }
 
    // Update is called once per frame
    void Update()
    {
        meat = GameObject.FindGameObjectsWithTag("Meat");
        float chance = Random.Range(1, 100);
        Vector2 playerPos = player[0].transform.position;
        Vector2 meatPos = new Vector2(0,0);
        float xMovement = 0, yMovement = 0;
        if (meat.Length != 0 )
        {
            meatPos = meat[0].transform.position;
            if (meatPos.x - this.transform.position.x <= agroDistance && meatPos.y - this.transform.position.y <= agroDistance && meatPos.x - this.transform.position.x >= -agroDistance && meatPos.y - this.transform.position.y >= -agroDistance)
            {
                seeMeat = true;
            }
            else
            {
                seeMeat = false;
            }
        }
        else
        {
            seeMeat = false;
        }
        if (playerPos.x - this.transform.position.x <= agroDistance && playerPos.y - this.transform.position.y <= agroDistance && playerPos.x - this.transform.position.x >= -agroDistance && playerPos.y - this.transform.position.y >= -agroDistance)
        {
            seePlayer = true;
        }
        else
        {
            seePlayer = false;
        }
        if (!seePlayer && !seeMeat) 
        {
            Vector2 stop = new Vector2(0, 0);
            rb.velocity = stop;
        }
        if (timer > 2 && seeMeat)
        {
            xMovement = meatPos.x - this.transform.position.x;
            yMovement = meatPos.y - this.transform.position.y;
            if (xMovement > 0 && xMovement < 2)
            {
                xMovement = 2;
            }
            else if (xMovement < 0 && xMovement > -2)
            {
                xMovement = -2;
            }
            if (yMovement > 0 && yMovement < 3)
            {
                yMovement = 2;
            }
            else if (yMovement < 0 && yMovement > -3)
            {
                yMovement = -3;
            }
            Vector2 newVelocity = new Vector2(xMovement, yMovement);
            rb.velocity = newVelocity * speed;
            timer = 0;
        }
        else if (seePlayer && timer > 2)
        {
            xMovement = playerPos.x - this.transform.position.x;
            yMovement = playerPos.y - this.transform.position.y;
            if (xMovement > 0 && xMovement < 2)
            {
                xMovement = 2;
            }
            else if (xMovement < 0 && xMovement > -2)
            {
                xMovement = -2;
            }
            if (yMovement > 0 && yMovement < 3)
            {
                yMovement = 2;
            }
            else if (yMovement < 0 && yMovement > -3)
            {
                yMovement = -3;
            }
            Vector2 newVelocity = new Vector2(xMovement, yMovement);
            rb.velocity = newVelocity * speed;
            timer = 0;
        }
        else if ((seePlayer || seeMeat) && timer > 1.5)
        {
            Vector2 stop = new Vector2(0, 0);
            rb.velocity = stop;
        }
        timer += Time.deltaTime;
    }
}