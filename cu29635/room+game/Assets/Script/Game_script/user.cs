using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//prefab 안에 있는 스크립
public class user : MonoBehaviour
{
    int con = 0;



    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.down * 0);//시작할 때 떨어지는 속도 0
        con = 2;
        //cnt_drop = 0;
    }
   
    void Update()
    {
        Rigidbody2D myRigidbody = GetComponent<Rigidbody2D>();
        this.GetComponent<SpriteRenderer>().color = Color.blue; //블록 떨어트리면 색깔 변하게

        // myRigidbody.useGravity = true; //떨어지는 속도 일정  *

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "rm")
        {
            GameObject.Find("user1").GetComponent<user1_block>().cnt_drop++;
            Destroy(gameObject);
        }

        //if (con != 0) cu29 코드 주석처리
        //{
        //con = 0;
        //GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //GetComponent<Transform>().position += new Vector3(0, 0, 0);
        // Debug.Log(con);
        //}


        //score 떨어지는 순간이 아니라 쌓일 때 점수 업데이트 하기 위해 태그 지
        //if (collision.collider.gameObject.CompareTag("Ground"))
        //{
        //    GameObject.Find("user1").GetComponent<user1_block>().cnt++;
        //}

        //else if (collision.collider.gameObject.CompareTag("Add"))
        //{
        //    GameObject.Find("user1").GetComponent<user1_block>().cnt++;
        //}

        //else if (collision.collider.gameObject.CompareTag("Drop"))
        //{
        //    GameObject.Find("user1").GetComponent<user1_block>().cnt_drop++;
        //    Destroy(gameObject);
        //}

    }
}