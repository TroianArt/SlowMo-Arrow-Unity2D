using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoEffect : MonoBehaviour
{
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;
    public GameObject echo;
    private player Player;
    void Start()
    {
        Player = GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {

        


        if (timeBtwSpawns <= 0)
        {
            Instantiate(echo, transform.position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else{
            timeBtwSpawns -= Time.deltaTime;
        }
        
    }
}
