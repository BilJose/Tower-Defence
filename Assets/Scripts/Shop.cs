using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public TorretBluePrint standardTurret;
    public TorretBluePrint missileLauncher;
    public TorretBluePrint laserBeamer;

    buildManager BuildManager;


    void Start()
    {
        BuildManager = buildManager.instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret purchased");
        BuildManager.SelectTorretToBuild(standardTurret);
    }
    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher purchased");
        BuildManager.SelectTorretToBuild(missileLauncher);
    }
    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer purchased");
        BuildManager.SelectTorretToBuild(laserBeamer);
    }
}
