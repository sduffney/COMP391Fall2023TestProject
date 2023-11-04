using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float horenemyspeed = 3.0f;
    public float verenemyspeed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1.0f,1.0f)*horenemyspeed, Random.Range(-1.0f, 1.0f)*verenemyspeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
