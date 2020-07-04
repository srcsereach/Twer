using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
     
    public float blood;   
    public int hurt;  
    public int speed;
    public float money = 100;
    private GameObject  endpoint;
    public GameObject deathEffect;
    public Slider bloodSlider;
    public GameObject bloodCanvas;
    public NavMeshAgent navMesh;
   


    void Start()
    {      
        endpoint = GameObject.Find("end");
        //navMesh = FindObjectOfType<NavMeshAgent>();?为什么设置会出错----因为是从头开始找物体的
        navMesh.SetDestination(endpoint.transform.position);
        navMesh.speed = speed;
        bloodSlider = GetComponentInChildren<Slider>();
        bloodSlider.maxValue = blood;
        bloodSlider.value = blood;


    }
    private void Update()
    {

    }
    void LateUpdate()
    {
         
        Death();
    }
    void Death()
    {
        if (blood <= 0)
        {
            MoneyManager.Instance.AddMoney(money);
            GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(effect, 1);
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        EnemyWaves.countEnemy--;
    }
   public void Damage(float hurt)
    {
        this.blood -= hurt;
        bloodSlider.value -= hurt ;
        Debug.Log(3);
    }

}
