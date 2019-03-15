using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    public Text moneyCountdownText;

    // Update is called once per frame
    void Update()
    {
        moneyCountdownText.text = "$" + PlayerStats.Money.ToString();
    }
}
