using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTrigger : MonoBehaviour
{
    private CharacterController player;

    private bool hitted = false;
    private float timer;
    
    public GameObject explosionSet;
    void Start()
    {
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
    }
    
    void Update()
    {
        
    }
    
    private void FixedUpdate() {

        if (hitted)
        {
            
            timer += Time.deltaTime;

            
            
            Debug.Log(timer);
            
            
            player.Move((Vector3.back + Vector3.up * 4) * Time.deltaTime / timer);
            if (timer >= 1)
            {
                hitted = false;
                timer = 0;
            }
         
            
        }
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name.Contains("ThirdPersonPlayer"))
        {
            if (collision.gameObject.name.Contains("ThirdPersonPlayer") && !hitted) 
            {
                Vector3 pointOfContact = player.transform.position;
                Vector3 pointAfterContact = player.transform.position - Vector3.back;
                hitted = true;
            }
            
            Instantiate(explosionSet, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.2f);
        }
    }
}



