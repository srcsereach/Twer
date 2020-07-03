using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 
public class MoneyManager :GenericSingle<MoneyManager>
{
     
    public static float money = 1000;
    public Text text;
    public Animation animation;
   
 
    public void UpdateUI()
    {
        text.text = money.ToString();
    }

    public void LockMoney()
    {
        animation.Play();
    }
    public void AddMoney(float fee)
    {
        money += fee;
        UpdateUI();
    }
    public void MinusMoney(float fee)
    {
        money -= fee;
        UpdateUI();
    }

}
