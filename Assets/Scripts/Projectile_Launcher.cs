using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Launcher : MonoBehaviour
{
    public GameObject projectile; // what to spawn
    public Transform spawnLocation; // where to spawn
    public Quaternion spawnRotation; // rotation the projectile
    public float spawnTime = 200f;
    private float timeSinceSpawned=0f;
    public DetectionZone detectionZone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(detectionZone.detectedObjs.Count>0)
        {
            timeSinceSpawned += Time.deltaTime;
            if (timeSinceSpawned >= spawnTime)
            {
                //GameObject gooObj;
                //gooObj = GameObject.Instantiate(projectile, transform.position, transform.rotation);
                Instantiate(projectile, spawnLocation.position, spawnRotation);
                timeSinceSpawned = 0;
            }
        }
        else { timeSinceSpawned = 0.5f; }

    }

}
