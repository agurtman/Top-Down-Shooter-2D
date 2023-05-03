using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Text hpText;
    [SerializeField] private Text levelText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text costText;
    [SerializeField] private Text moneyText;
    [SerializeField] private GameObject shop;

    public void UdateScoreAndLevel()
    {
        levelText.text = $"Level {Stats.Level}";
        scoreText.text = "Score: " + Stats.Score.ToString("D4");
    }

    public void UpdateHP(int count)
    {
        hpText.text = $"HP: {count}";
    }

    public void OpenShop()
    {
        shop.SetActive(true);
        Time.timeScale = 0;
        MoneyToText(Shop.money);
    }

    public void CloseShop()
    {
        shop.SetActive(false);
        Time.timeScale = 1;
    }

    public void IncreaseCost(int cost)
    {
        costText.text = cost.ToString();

        if (cost == 0)
        {
            costText.text = "Sold";
        }
    }

    public void MoneyToText(int money)
    {
        moneyText.text = "Money: " + money.ToString();
    }
}
