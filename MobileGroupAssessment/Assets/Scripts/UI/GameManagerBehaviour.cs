﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerBehaviour : MonoBehaviour
{
    private void Start()
    {
        Gold = 1000;
    }
    public Text goldLabel;

    private int gold;
    public int Gold
    {
        get
        {
            return gold;
        }
        set
        {
            gold = value;
            goldLabel.GetComponent<Text>().text = "Gold: " + gold;
        }
    }
}
