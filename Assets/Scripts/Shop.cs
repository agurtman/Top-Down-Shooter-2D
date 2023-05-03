using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private UI ui;
    private Player player;
    public static int money;
    private int cost;
    private int costCount;

    private void Start()
    {
        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
        cost = 100;
        ui.IncreaseCost(cost);
        ui.MoneyToText(money);
        player = FindObjectOfType<Player>();
    }

    public void BuyUpgrade()
    {
        if (money >= cost && costCount < 4)
        {
            player.UpgradeGun();
            money -= cost;
            cost *= 2;
            ui.IncreaseCost(cost);
            ui.MoneyToText(money);
            costCount += 1;

            if (costCount >= 4)
            {
                ui.IncreaseCost(0);
            }
        }
    }
}
