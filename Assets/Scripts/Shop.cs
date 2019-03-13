using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    buildManager BuildManager;


    void Start()
    {
        BuildManager = buildManager.instance;
    }
    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard Turret purchased");
        BuildManager.SetTurretToBuild(BuildManager.standardTurretPrefab);
    }
    public void PurchaseAnotherTurret()
    {
        Debug.Log("Another Turret purchased");
        BuildManager.SetTurretToBuild(BuildManager.anotherTurretPrefab);
    }
}
