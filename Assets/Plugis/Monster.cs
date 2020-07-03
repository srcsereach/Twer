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
    public NavMeshAgent navMesh;
    private Transform enemytransform;


    void Start()
    {
        blood = 100;
        hurt = 5;
        speed = 10;
        endpoint = GameObject.Find("end");
        Debug.Log(endpoint.name);
        navMesh = FindObjectOfType<NavMeshAgent>();
        endpoint = GameObject.Find("end");
        navMesh.SetDestination(endpoint.transform.position);
        navMesh.speed = speed;
        bloodSlider = GetComponentInChildren<Slider>();
        enemytransform = this.transform ;
    }
    private void Update()
    {
        transform.rotation = new Quaternion(0,0,0,0);
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
        bloodSlider.value -= hurt / 100;
        Debug.Log(3);
    }

}
