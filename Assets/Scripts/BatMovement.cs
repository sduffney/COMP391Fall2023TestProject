using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Added rigidbody2d to bats, dynamic, gravity scale 0
//Toggled on isTrigger collider on bats
//Set Min X to -12.5, Min Y to -4.5, Max X to 12.5, and Max Y to 5.5
//Added Player tag to Dewy

//NEW
//Tagged bat as "Bat"
public class BatMovement : MonoBehaviour
{
    Rigidbody2D rb;
    private float movementRate;
    private float timer = 0;
    public float minX, maxX, minY, maxY;
    private GameObject[] player;
    private bool seenPlayer;
    public float agroDistance;
    public float hitBox;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        movementRate = 0.0f;
        seenPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        float chance = Random.Range(1, 100);
        Vector2 playerPos = player[0].transform.position;
        float xMovement = 0, yMovement = 0;
        if (playerPos.x - this.transform.position.x <= hitBox && playerPos.y - this.transform.position.y <= hitBox && playerPos.x - this.transform.position.x >= -hitBox && playerPos.y - this.transform.position.y >= -hitBox)
        {
            player[0].gameObject.GetComponent<DewyHealthSystem>().TakeDamage(10);
        }
        if (playerPos.x - this.transform.position.x <= agroDistance && playerPos.y - this.transform.position.y <= agroDistance && playerPos.x - this.transform.position.x >= -agroDistance && playerPos.y - this.transform.position.y >= -agroDistance)
        {
            seenPlayer = true;
        }
        else
        {
            seenPlayer = false;
            Vector2 stop = new Vector2(0, 0);
            rb.velocity = stop;
        }
        if (seenPlayer)
        {
            if (chance > 70)
            {
                xMovement = Random.Range(-5, 5);
                yMovement = Random.Range(-5, 5);
            }
            else
            {
                xMovement = playerPos.x - this.transform.position.x;
                yMovement = playerPos.y - this.transform.position.y;
                if (this.gameObject.tag == "Bat")
                {
                    if (xMovement < 0 && xMovement > -2)
                    {
                        xMovement = -2f;
                    }
                    else if (xMovement > 0 && xMovement < 2)
                    {
                        xMovement = 2f;
                    }
                    if (yMovement < 0 && yMovement > -2)
                    {
                        yMovement = -2f;
                    }
                    else if (yMovement > 0 && yMovement < 2)
                    {
                        yMovement = -2f;
                    }
                }
            }
            if (timer > movementRate)
            {
                Vector2 newVelocity = new Vector2(xMovement, yMovement);
                rb.velocity = newVelocity;
                timer = 0;
                movementRate = Random.Range(1, 10) / 10.0f;
            }
            timer += Time.deltaTime;
        }
        float newX, newY;


        newX = Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, minX, maxX);
        newY = Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, minY, maxY);
        GetComponent<Rigidbody2D>().position = new Vector2(newX, newY);
    }
}