using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//add ChestBehavior.cs to chest
public class ChestBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject key;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(key, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}