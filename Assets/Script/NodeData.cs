using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodeData : MonoBehaviour
{
    public GameObject turret;
    [HideInInspector]
    public TurretData turretData;
   [HideInInspector]
    public bool isUpdate;
    public GameObject[] Effect;
    private Renderer renderer;
    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }
    public void CreateTurret(TurretData turretData)
    {
        if (turretData != null)
        {
            turret = GameObject.Instantiate(turretData.Turret, transform.position, transform.rotation);
            GameObject effect = GameObject.Instantiate(Effect[0], turret.transform.position, Quaternion.identity);
            Destroy(effect, 1.5f);
            this.turretData = turretData;
        }
    }
    public void DestroyTurret()
    {
        Destroy(turret);
        GameObject effect = GameObject.Instantiate(Effect[1], transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);
        turret = null;
        turretData = null;
        isUpdate = false;
    }
    public void UpdateTurret()
    {
        Destroy(turret);
        turret = GameObject.Instantiate(turretData.UpdateTurret, transform.position, Quaternion.identity);
        GameObject effect = GameObject.Instantiate(Effect[0], turret.transform.position, Quaternion.identity);
        isUpdate = true;
        Destroy(effect, 1.5f);
    }

    private void OnMouseEnter()
    {
        if (turret == null&&EventSystem.current.IsPointerOverGameObject()==false)
        {
            renderer.material.color = Color.red;
        }
    }
    private void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }
}
