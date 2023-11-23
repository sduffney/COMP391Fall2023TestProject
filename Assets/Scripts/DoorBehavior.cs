using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    [SerializeField] bool win = false;
    public GameObject gameOverMenu; //Change to Win Screen
    public GameObject winText;
    public GameObject loseText;
    private AudioSource winSound;
    void Start()
    {
        winSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            InventoryInterface inventory = collision.GetComponent<InventoryInterface>();
            if (inventory != null)
            {
                if (inventory.Key >= 1)
                {
                    inventory.Key = inventory.Key - 1;
                    print("Keys = " + inventory.Key);
                    print("You Win!");
                    win = true;
                    gameOverMenu.SetActive(true);
                    winText.SetActive(true);
                    loseText.SetActive(false);
                    winSound.Play();
                    Time.timeScale = 0;
                }
            }
        }
    }
}