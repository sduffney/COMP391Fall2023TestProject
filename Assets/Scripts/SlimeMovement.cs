using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
 
public class SlimeMovement : MonoBehaviour
{
    Rigidbody2D rb;
    private float timer = 0;
    private GameObject[] player;
    private bool seenPlayer;
    public float agroDistance;
    public float speed;
    private Vector2 prePlayerPos;
    private float playerTimer = 0;
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
        if (playerTimer > 2.25 && timer > 1 && seenPlayer)
        {
            playerTimer = 0;
            prePlayerPos = new Vector2(playerPos.x, playerPos.y);
        }
        if (seenPlayer && timer > 2)
        {
            xMovement = prePlayerPos.x - this.transform.position.x;
            yMovement = prePlayerPos.y - this.transform.position.y;
            if (xMovement > 0 && xMovement < 2.25)
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
        else if (seenPlayer && timer > 0.25)
        {
            rb.velocity = Vector2.zero;
        }
        if (seenPlayer)
        {
            timer += Time.deltaTime;
            playerTimer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            playerTimer = 0;
        }
    }
}