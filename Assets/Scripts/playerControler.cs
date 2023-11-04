using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour
{
    public float playerSpeed;
    public GameObject meat;
    public GameObject meatSpawner;
    public Animator animator;

    private float meatCooldown = 1.0f;
    private float meatTimer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 4;
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

        if (Input.GetAxis("Fire1") > 0 && meatTimer > meatCooldown)
        {
            GameObject goObj;
            goObj = GameObject.Instantiate(meat, meatSpawner.transform.position, meatSpawner.transform.rotation);
            goObj.transform.Rotate(0.0f, 0.0f, 0.0f);
            meatTimer = 0;

        }
        meatTimer += Time.deltaTime;
    }
}