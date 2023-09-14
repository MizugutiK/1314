﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public Text goalText;
    public Text gameOver;                    // GameOverのテキストを格納する変数を用意します

    void Start()
    {
        goalText = GameObject.Find("Goal").GetComponent<Text>();
        goalText.gameObject.SetActive(false);

        gameOver = GameObject.Find("GO").GetComponent<Text>();	 // gameOverのオブジェクトを探して変数に格納します
        gameOver.gameObject.SetActive(false);            // gameOverのテキスト表示をfalse（off）にして消しておきます
    }


public void GoalFlag()
    {
        goalText.gameObject.SetActive(true);
        return;
    }
    public void OverFlag()					 // gameOverの表示をさせるOverFlagメソッドです
    {
        gameOver.gameObject.SetActive(true);			 // gameOverのテキストオブジェクトをtrue（On）にして表示をさせます
        return;
    }
}
