using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneySystem : MonoBehaviour
{


    public delegate int ChangeMoney(int newMoney);
    ChangeMoney ChangeM;

    public static int money = 0;
    public Text moneytxt;
    public Text totalTxt;
    public static int newMoney;

    private void Start()
    {
        ChangeM = AddMoney;
    }
    void Update()
    {
        moneytxt.text = "" + money;
    }
    private int AddMoney(int newMoney)
    {
        newMoney += money;
        return money;
    }
  
}