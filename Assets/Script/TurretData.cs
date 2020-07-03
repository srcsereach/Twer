using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretData  
{
    public GameObject Turret;
    public float price;
    public GameObject UpdateTurret;
    public float UpdatePrice;
    public TurretType typeName;
}

public enum TurretType
{
    Standard,
    Laser,
    Missile
}