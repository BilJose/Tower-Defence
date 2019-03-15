using System.Collections;
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

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;
    public GameObject BuildEffectPrefab;

    private TorretBluePrint turretToBuild;


    public bool CanBuild { get { return turretToBuild != null; }}
    public bool HasMoney { get { return PlayerStats.Money >=turretToBuild.cost; }}

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("not enough money");
            return;
        }
        PlayerStats.Money -= turretToBuild.cost;


        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab,node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(BuildEffectPrefab, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 2f);
    }
    public void SelectTorretToBuild(TorretBluePrint turret)
    {
        turretToBuild = turret;
    }
}
