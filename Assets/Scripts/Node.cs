using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Vector3 positionOffset;
    private Renderer rend;

    private Color startColor;

    buildManager BuildManager;
    private GameObject turret;
    void Start()
    {
        
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        BuildManager = buildManager.instance;

    }
   
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (BuildManager.GetTurretToBuild() == null)
            return;
        if(turret != null)
        {
            Debug.Log("Can`t build there - Todo: Display O n Screne");
            return;
        }

        //build a tower
        GameObject turretToBuild = BuildManager.GetTurretToBuild();

        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (BuildManager.GetTurretToBuild() == null)
            return;
        rend.material.color = hoverColor;

    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
