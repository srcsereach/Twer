using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2 : Monster
{
    // Start is called before the first frame update
    void Start()
    {
        blood = 50;
        hurt = 2;
        speed = 20;
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
