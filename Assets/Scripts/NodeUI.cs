using UnityEngine.UI;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    public Text upgradeCost;
    public Text sellAmount;
    public GameObject ui;
    public Button upgradeButton;
    private Node target;
    public  void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBluePrint.upgradeCost;
            upgradeButton.interactable = true;
            target.isUpgraded = true;
        }
        else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }


        sellAmount.text = "$" + target.turretBluePrint.GetSellAmount();
        ui.SetActive(true);
    }
    public void Hide()
    {
        ui.SetActive(false);
    }
    public void Upgrade()
    {
        target.UpgradeTurret();
        buildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        buildManager.instance.DeselectNode();
    }
}
