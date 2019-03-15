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
    [Header("optional")]
    public GameObject turret;
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

        if (!BuildManager.CanBuild)
            return;
        if(turret != null)
        {
            Debug.Log("Can`t build there - Todo: Display O n Screne");
            return;
        }

        //build a tower
        BuildManager.BuildTurretOn(this);

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
