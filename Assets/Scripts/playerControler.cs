using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
 
public class playerControler : MonoBehaviour
{
    public float playerSpeed;
    public GameObject meat;
    public GameObject meatSpawner;
    public Animator animator;
 
    private float meatCooldown = 10.0f;
    private float meatTimer = 0.0f;
    private GameObject[] meatSpawned;
    private int numOfMeat;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 4;
        numOfMeat = 0;
        pauseMenu.SetActive(false);
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
 
        animator.SetFloat("Horizontal", horizontalMovement);
        animator.SetFloat("Vertical", verticalMovement);
        animator.SetFloat("Speed", newVelocity.sqrMagnitude);
 
        if (Input.GetAxis("Fire1") > 0 && numOfMeat < 1)
        {
            GameObject goObj;
            goObj = GameObject.Instantiate(meat, meatSpawner.transform.position, meatSpawner.transform.rotation);
            goObj.transform.Rotate(0.0f, 0.0f, 0.0f);
            numOfMeat++;
            meatTimer = 0;
        }
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
        }
        if (meatTimer > meatCooldown && numOfMeat > 0)
        {
            meatSpawned = GameObject.FindGameObjectsWithTag("Meat");
            Destroy(meatSpawned[0]);
            numOfMeat--;
        }
        meatTimer += Time.deltaTime;
    }
}