using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
     
    public int blood;
    public int hurt;
    public int speed;    
    public GameObject  endpoint;
    public NavMeshAgent navMesh;

    void Awak()
    {
        endpoint = GameObject.Find("end");
         
    }
    void LateUpdate()
    {
       
    }

}
