﻿using System.Collections;
using UnityEngine;

public class buildManager : MonoBehaviour
{
    public static buildManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than once buildManager in scene!");
            return;
        }
        instance = this;
    }

   
    public GameObject buildEffectPrefab;

    private TurretBluePrint turretToBuild;
    private Node selectedNode;
    public NodeUI nodeUI;


    public bool CanBuild { get { return turretToBuild != null; }}
    public bool HasMoney { get { return PlayerStats.Money >=turretToBuild.cost; }}
    

    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);
    }
    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }
    public TurretBluePrint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
