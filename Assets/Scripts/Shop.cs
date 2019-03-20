using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBluePrint standardTurret;
    public TurretBluePrint missileLauncher;
    public TurretBluePrint laserBeamer;

    buildManager BuildManager;


    void Start()
    {
        BuildManager = buildManager.instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret purchased");
        BuildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher purchased");
        BuildManager.SelectTurretToBuild(missileLauncher);
    }
    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer purchased");
        BuildManager.SelectTurretToBuild(laserBeamer);
    }
}
