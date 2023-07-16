using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    [SerializeField] TextMeshProUGUI moneyText;

    int money;

    private void Awake()
    {
        instance= this;
    }

    private void Start()
    {
        Money = PlayerPrefs.GetInt("Money");
        //UpdateMoneyText();
    }


    public int Money { get => money; set 
        {
            money = value;
            UpdateMoneyText();
            PlayerPrefs.SetInt("Money", money);
        } }

    public void UpdateMoneyText()
    {
        moneyText.text = money.ToString();
    }

    public void GiveMoney()
    {
        Money += 100;
    }
}
