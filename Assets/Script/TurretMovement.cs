using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMovement : MonoBehaviour
{
    public List<GameObject> enemies=new List<GameObject>();
    public GameObject attackedEnemy;
    public Transform turretHead;
    public GameObject bulletPrefeb, gun;
    public float span = 0.5f;
    private float timeTotal ;

    public bool isLaser=false;
    public LineRenderer lineRenderer;
    public GameObject laserEffect;
    public float laserHurt=40;
    // Start is called before the first frame update
    void Start()
    {
        turretHead = transform.Find("Head").transform;
        timeTotal = span;
    }

    // Update is called once per frame
    void Update()
    {
        
        GetAttackedEnemy();
        if (attackedEnemy != null)
        {
            turretHead.LookAt(attackedEnemy.transform);
            if (!isLaser)
            {
                timeTotal += Time.deltaTime;                 
                if (timeTotal >= span)
                {
                    Attack();
                    timeTotal = 0;
                }
            }
            else
            {
                lineRenderer.enabled = true;
                laserEffect.SetActive(true);
                lineRenderer.SetPositions(new Vector3[] { gun.transform.position, attackedEnemy.transform.position });
                attackedEnemy.GetComponent<Monster>().Damage(laserHurt*Time.deltaTime);
                laserEffect.transform.position = attackedEnemy.transform.position;
                laserEffect.transform.LookAt( transform.position);
            }
        }
        else
        {
            if (isLaser)
            {
                lineRenderer.enabled = false;
                laserEffect.SetActive(false);
            }
        }
    }
    void GetAttackedEnemy()
    {
        if (enemies.Count > 0 && enemies[0] != null)
        {
            attackedEnemy = enemies[0];
        }
        else
        {
            attackedEnemy = null;
            if (enemies.Count > 0)
            {
                enemies.RemoveAt(0);
            }
        }
    }
    public void Attack()
    {
        Debug.Log("1");
        GameObject bullet= Instantiate(bulletPrefeb, gun.transform.position, gun.transform.rotation);
        bullet.GetComponent<Bullet>().SetTarget(attackedEnemy.transform);
        //bullet.GetComponent<Rigidbody>().AddForce(gun.transform.forward * 1000 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            enemies.Add(other.gameObject);
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "enemy")
        {
            enemies.Remove(other.gameObject);
           
        }
    }

}
