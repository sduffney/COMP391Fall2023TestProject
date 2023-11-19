using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//add Rigid Body 2D to golden_key
//add Box Collider 2D to golden_key
//add KeyPickup.cs to golden_key
public class KeyPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            InventoryInterface inventory = other.GetComponent<InventoryInterface>();
            if (inventory != null)
            {
                inventory.Key = inventory.Key + 1;
                print("Keys = " + inventory.Key);
                gameObject.SetActive(false);
            }
        }
    }
}