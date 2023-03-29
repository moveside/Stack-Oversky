using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;


public class user1_block_prev : MonoBehaviourPunCallbacks
{
    public GameObject blockFactory;
    public GameObject blockPosition;
    public Vector3 start;
    public float move = 0.1f;
    public float speed = 0.05f;
    public float up = 1;
    int k = 1;
    public int cnt;
    public int cnt_drop;
    public int cnt_drop_check;
    float delta;
    GameObject block;
    int tmp;
    float delayTimeBlockShoot = 0.4f;
    public int score = 0;
    public GameObject blockContainer; //block prefab 


    // Start is called before the first frame update

    public void BlockShoot(int t)
    {
        //Debug.Log("RPC3");
        //Create PhotonNetwork Object -> management with Photonview

        if (Input.GetKeyDown(KeyCode.Space) && delta > delayTimeBlockShoot && PhotonNetwork.LocalPlayer.CustomProperties["team"].Equals(t))
        {
            //Debug.Log("RPC4");
            GameObject block = PhotonNetwork.Instantiate("block(groom)", blockPosition.transform.position, Quaternion.identity, 0);
            
            block.GetPhotonView().TransferOwnership(PhotonNetwork.LocalPlayer);
            Debug.Log(block.GetPhotonView().Owner.CustomProperties["team"]);
            //rig2d.AddForce(new Vector2(0,speed), ForceMode2D.Force);
            cnt++;
            k = 0;
            block.transform.position = blockPosition.transform.position;

            block.name = "block num : " + cnt;
            block.transform.parent = blockContainer.transform;  //blockContainer

            
            //Debug.Log("key");

            
            if (cnt > 7 && k == 0)
            {
                //Debug.Log(score);
                //this.transform.position += new Vector3(0, 1, 0);
                for (int i = 0; i < 100; i++)
                {
                    //Debug.Log(score);
                    this.transform.position += new Vector3(0, up * Time.deltaTime, 0);
                }
                k = 0;

                //rig2d.AddForce(new Vector2(start.x,1), ForceMode2D.Force);

            }
            
            delta = 0f;

        }
    }

    public void BlockMove()
    {
        //Debug.Log("Move" + score);
        if (this.photonView.IsMine)
        {
            {
                if (this.transform.position.x > start.x + 1.5f || this.transform.position.x < start.x - 1.5f)
                    move *= -1;
                this.transform.position -= new Vector3(speed * move, 0, 0);

            }
        }
        
    }
        void timeCount()
        {
            //Debug.Log("time " + score);
            delta += Time.deltaTime;
        }

         void calScore()
        {
            if (cnt_drop == cnt_drop_check)
            {
                k = 1;
                cnt_drop_check++;
            }
        }

    private void calBlockPosition()
    {
        if (this.photonView.IsMine)
        {
            //Debug.Log(score);
            //Debug.Log(tmp);
            if (score != tmp && score > 7) //score
            {
                //Debug.Log("7>" + score);
                Vector3 destination = new Vector3(this.transform.position.x, start.y+ (score - 7) * 0.7f, 0); //
                this.transform.position = Vector3.MoveTowards(this.transform.position, destination, 10);
            }
            else if (score != tmp && score <= 7) //score
            {
                //Debug.Log("7<"+score);
                Vector3 destination = new Vector3(this.transform.position.x, start.y, 0); //
                this.transform.position = Vector3.MoveTowards(this.transform.position, destination, 10);
            }
        }
    }

    void Start()
    {
        start = this.transform.position;

        cnt = 0;
        cnt_drop = 0;
        cnt_drop_check = 1;

        //

        GameObject.Find("user" + PhotonNetwork.LocalPlayer.CustomProperties["team"]).GetPhotonView().TransferOwnership(PhotonNetwork.LocalPlayer);


    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            photonView.RPC("saveScore", RpcTarget.All, score);
            BlockMove();
            //CameraDown();
            timeCount();
            score = cnt - cnt_drop;
            calBlockPosition();
            tmp = score;
            
        }
        

    }

    [PunRPC]
    public void saveScore(int remotescore)
    {
        score = remotescore;
        Debug.Log(this.name + " : " + score);
    }

    /*
    void CameraDown()
    {
        if (cnt_drop == cnt_drop_check)
        {
            for (int i = 0; i < 100; i++)
            {
                this.transform.position += new Vector3(0, -up * Time.deltaTime, 0);
            }
            k = 1;
            cnt_drop_check++;
        }
    }
    */

    public void DestroyAllBlocks()
    {
        var blocks = new List<GameObject>();
        foreach (Transform child in blockContainer.transform) blocks.Add(child.gameObject);
        blocks.ForEach(child => PhotonNetwork.Destroy(child));
        
        this.transform.position = start;

        cnt = 0;
        cnt_drop = 0;
        cnt_drop_check = 1;
    }
}