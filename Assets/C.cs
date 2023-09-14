using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C : MonoBehaviour
{
    GameObject gameCtrl;		//　GameObject型の変数　gameCtrlを用意します、このオブジェクトにGoalManagerクラスが入れられています
    GM script;       //　GoalManagert型の変数　scriptを用意します　各クラス（スクリプト）はその型として変数を作ることができます

    public AudioClip snd01;             //鳴らす音データを格納する変数を用意します
    private AudioSource audioS;    //AudioSourceを格納する変数を用意します

    public int points;          //　ゴールに入れるボールの数
    void Start()
    {
        gameCtrl = GameObject.Find("GC"); 	//　変数gameCtrlに　GameControllerオブジェクトを見つけてきて入れます
        script = gameCtrl.GetComponent<GM>();    //　変数scriptに　gameCtrlに入れられたGameControllerにあるGameManagerスクリプトを入れます

        audioS = GameObject.Find("SS").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other) //　Trigger（スイッチ）に触れたら・・

    {
        if (other.tag == "Player")		 //　当たった相手のtagが”Player”ならば・・
        {
            points -= 1;			 //　変数pointsから１を引きます

            if (points <= 0)		 //　もし変数pointsの値が０以下だったら
            {
                script.GoalFlag();       //　壊される直前に変数scriptに入ったGameManagerスクリプトにあるGoalFlag()メソッドを呼び、実行します
                audioS.PlayOneShot(snd01);　//　PlayOneShot命令で、snd01に格納された音を一回鳴らします
            }
        }
    }
}

