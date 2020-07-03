using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float hurt  ;
    public float speed = 20;
    public Transform target;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        if (target != null)
        {
            transform.LookAt(target.position);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void SetTarget(Transform target)
    {
        this.target = target;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            string tag = other.gameObject.tag;            
            other.gameObject.GetComponent<Monster>().Damage(hurt);
            GameObject effection= GameObject.Instantiate(explosion, transform.position, transform.rotation);           
            Destroy(effection,0.1f);
            Destroy(gameObject);
        }
    }
}
