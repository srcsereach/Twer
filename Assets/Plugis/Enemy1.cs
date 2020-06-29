using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1 : Monster
{
     
    void Start()
    {
        blood = 100;
        hurt = 5;
        speed = 10;
        navMesh = FindObjectOfType<NavMeshAgent>();
        endpoint = GameObject.Find("end");
        navMesh.SetDestination(endpoint.transform.position);
        navMesh.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }
}
