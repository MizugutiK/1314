using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour

{
    public float jumpPower = 10.0f;    // 　ジャンプ力を用意します、inspectorからも調整できるようpublic変数にします
    private Vector2 touchPoint;           // 　押した場所を入れるVector3型の変数touchPointを用意します
    Rigidbody2D rigidBody;                   //　 rigidbody型の変数rigidBodyを用意します
   
    float seconds;
    void Start()
    {

        rigidBody = GetComponent<Rigidbody2D>();      // 変数rigidbodyにrigidbody２Dコンポネントを入れます
    }

    void Update()
    {

        if (Input.GetMouseButton(0))　　//　もしMouseボタンが押されたら
        {   //　マウスの位置をワールド座標に変換してオブジェクトの座標から引いてベクトルの方向を求めます

            touchPoint = transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            rigidBody.velocity = Vector2.zero;  // 落下速度を一度リセットします
            seconds += Time.deltaTime;
            rigidBody.AddForce(new Vector2(touchPoint.x, touchPoint.y), ForceMode2D.Impulse);       // 　touchPointベクトル方向に力を加える
        }
        else return;
    }

}
