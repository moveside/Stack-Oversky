using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    

public class user1_block : MonoBehaviour
{
    public GameObject blockFactory;
    public GameObject blockPosition;
    public Vector3 start;
    public float move = 0.1f;
    public float speed=0.05f;
    public float up = 5;
    Rigidbody2D rig2d;
    int k = 1;
    GameObject block;
    public GameObject blockContainer; //block prefab ?�??�?관리하??변??
    public int cnt;
    public int cnt_drop;
    public int cnt_drop_check;

    int score = 0;
    int tmp;
    //?�페?�스�??�간 지??
    float delta;
    float delayTimeBlockShoot = 0.4f;


    private void BlockMove()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&delta>delayTimeBlockShoot)
        {
            block = Instantiate(blockFactory);
            //rig2d.AddForce(new Vector2(0,speed), ForceMode2D.Force);
            cnt=cnt+1;
            k = 0;
            block.transform.position = blockPosition.transform.position;

            block.name = "block num : " + cnt;
            block.transform.parent = blockContainer.transform;  //blockContainer??블록 ?�리???�

            delta = 0f;
        }
        else
        {
            if (this.transform.position.x > start.x + 1.5f || this.transform.position.x < start.x - 1.5f)
                move *= -1;
            this.transform.position -= new Vector3(speed * move, 0, 0);
        }


        //if (cnt > 7 && k == 0)  //블록??7�??�상 ?�성 ???�후 블록???�성???�마??
        //{
        //    //this.transform.position += new Vector3(0, 1, 0);
        //    //for (int i = 0; i < 100; i++)
        //    //{
        //    //    this.transform.position += new Vector3(0, up * Time.deltaTime, 0);
        //    //}

        //    k = 1;
        //}

    }

    private void timeCount()
    {
        delta += Time.deltaTime;
    }

    private void calScore()
    {
        if (cnt_drop==cnt_drop_check)
        {
            k = 1;
            cnt_drop_check++;
        }
    }


    private void calBlockPosition()
    {
      
        if (score != tmp &&score>7) //score가 바뀌면
        {
            Vector3 destination = new Vector3(0, 2.6f+ (score - 7) * 0.7f, 0); //???�치�??�동
            this.transform.position = Vector3.MoveTowards(this.transform.position, destination, 10);
            //Debug.Log(user1_block)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
        }
        if(score!=tmp && score <= 7) //score가 바뀌면
        {
            Vector3 destination = new Vector3(0, 2.6f, 0); //고정???�치�???
            this.transform.position = Vector3.MoveTowards(this.transform.position, destination, 10);
        }
    }

    void Start()
    {
        rig2d = gameObject.GetComponent<Rigidbody2D>();
        cnt = 0;
        cnt_drop = 0;
        cnt_drop_check = 1;
    }

    // Update is called once per frame
    void Update()
    {
        BlockMove();

        
        timeCount();
        score = cnt - cnt_drop;
        calBlockPosition();
        tmp = score; //score값이 변?��? ?�는지 ?�인?�기 ?�한 변??
    }
}