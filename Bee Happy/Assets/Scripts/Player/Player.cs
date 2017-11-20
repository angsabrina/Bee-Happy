using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public static Player Instance { get; private set; }

    public Slider xpSlider;
    public Text levelNum;
    public Text levelUpText;
    Text leveluptext;
    GameObject canvas;
    int XP = 0;
    int level = 0;
    public Inventory inventory;

    void start()
    {
        xpSlider.value = XP;
        levelNum.text = level.ToString();
        inventory = new Inventory(54);
    }

    public void increaseXP(int XPamount)
    {
        XP += XPamount;
        xpSlider.value = XP;
        int XPneeded = 200;
        xpSlider.maxValue = XPneeded;
        if (XP >= XPneeded)
        {
            //level up
            showLevelUpMessage(++level);
            levelNum.text = level.ToString();

            //xp reset
            XP -= XPneeded;
            xpSlider.minValue = XP;
            xpSlider.value = XP;
            XPneeded *= 2;
            xpSlider.maxValue = XPneeded;
        }
    }

    void showLevelUpMessage(int level)
    {
        leveluptext = Instantiate(levelUpText);
        canvas = GameObject.Find("Canvas");
        leveluptext.text = "You just leveled up! You're now level " + level.ToString();
        leveluptext.transform.SetParent(canvas.transform, false);
        Destroy(leveluptext.gameObject, 1);
    }
}
