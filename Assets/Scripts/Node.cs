using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColor;  
    private Renderer rend;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    private Color startColor;

    buildManager BuildManager;
    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBluePrint turretBluePrint;
    [HideInInspector]
    public bool isUpgraded;


    void Start()
    {
        
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        BuildManager = buildManager.instance;

    }
    
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    void OnMouseDown()
    {
        
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        
        if(turret != null)
        {
            BuildManager.SelectNode(this);
            return;
        }

        if (!BuildManager.CanBuild)
            return;

        //build a tower
        BuildTurret(BuildManager.GetTurretToBuild());

    }
    void BuildTurret(TurretBluePrint bluePrint)
    {

        if (PlayerStats.Money < bluePrint.cost)
        {
            Debug.Log("not enough money");
            return;
        }
        PlayerStats.Money -= bluePrint.cost;
        turretBluePrint = bluePrint;

        GameObject _turret = (GameObject)Instantiate(bluePrint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(BuildManager.buildEffectPrefab, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 2f);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBluePrint.upgradeCost)
        {
            Debug.Log("not enough money to upgrade");
            return;
        }
        PlayerStats.Money -= turretBluePrint.upgradeCost;
        //get rid of the old turret
        Destroy(turret);
        //build new turret

        GameObject _turret = (GameObject)Instantiate(turretBluePrint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(BuildManager.buildEffectPrefab, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 2f);
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!BuildManager.CanBuild)
            return;

        if (BuildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
 

    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
