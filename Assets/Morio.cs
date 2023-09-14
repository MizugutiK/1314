using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morio : MonoBehaviour
{
    public int points;          //　ゴールに入れるボールの数

    GameObject gameCtrl;		//　GameObject型の変数　gameCtrlを用意します、このオブジェクトにGoalManagerクラスが入れられています
    GM script;       //　GoalManagert型の変数　scriptを用意します　各クラス（スクリプト）はその型として変数を作ることができます

    public AudioClip snd01;             //鳴らす音データを格納する変数を用意します
    private AudioSource audioS;    //AudioSourceを格納する変数を用意します


  


    // Start is called before the first frame update
    void Start()
    {
        gameCtrl = GameObject.Find("GC"); 	//　変数gameCtrlに　GameControllerオブジェクトを見つけてきて入れます
        script = gameCtrl.GetComponent<GM>();    //　変数scriptに　gameCtrlに入れられたGameControllerにあるGameManagerスクリプトを入れます
       
        audioS = GameObject.Find("SS").GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other)　//　Collisionに当たったら
    {
        if (other.gameObject.tag == "Enemy")		 //　当たった相手のtagが”Player”ならば・・
        {
            points -= 1;			 //　変数pointsから１を引きます

            if (points <= 0)		 //　もし変数pointsの値が０以下だったら
            {
                this.gameObject.SetActive(false);      //　このオブジェクトをScene から消します（setを「止めます」）　
                script.OverFlag();       //　壊される直前に変数scriptに入ったGameManagerスクリプトにあるGoalFlag()メソッドを呼び、実行します
                audioS.PlayOneShot(snd01); //　PlayOneShot命令で、snd01に格納された音を一回鳴らします
               
            }
        }
    }

        // Update is called once per frame
        void Update()
    {
        if (transform.position.y < -10.0f)       //　もしｘの位置が―10以下になったら・・
        {
            this.gameObject.SetActive(false);      //　このオブジェクトをScene から消します（setを「止めます」）　
            script.OverFlag();       //　壊される直前に変数scriptに入ったGameManagerスクリプトにあるGoalFlag()メソッドを呼び、実行します
            audioS.PlayOneShot(snd01);　//　PlayOneShot命令で、snd01に格納された音を一回鳴らします

        }
    }
}
