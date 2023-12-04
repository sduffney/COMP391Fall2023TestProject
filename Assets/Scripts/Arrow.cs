using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float timetoLive = 3f;
    private float timeSinceSpawned = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveSpeed *-transform.right * Time.deltaTime;
        timeSinceSpawned += Time.deltaTime;
        if(timeSinceSpawned > timetoLive)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<DewyHealthSystem>().TakeDamage(25);
            Destroy(this.gameObject);
        }
    }

}
