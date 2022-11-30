using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviourPunCallbacks
{
    private Camera camera;
    private Color color;
    public GameObject block1;
    public GameObject block2;
    public GameObject block3;
    public GameObject block4;
    public TMP_InputField textField;

    private RaycastHit2D hit;

    PhotonView PV;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        PV = photonView;
        //isChat = false;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(block1.GetComponent<user1_block_prev>().cnt - block1.GetComponent<user1_block_prev>().cnt_drop);
        //Debug.Log(block2.GetComponent<user1_block_prev>().cnt - block2.GetComponent<user1_block_prev>().cnt_drop);
        //Debug.Log(block3.GetComponent<user1_block_prev>().cnt - block3.GetComponent<user1_block_prev>().cnt_drop);
        //Debug.Log(block4.GetComponent<user1_block_prev>().cnt - block4.GetComponent<user1_block_prev>().cnt_drop);

        //Debug.Log(textField.isFocused);
        if (textField.isFocused == false)
        {
            //if Input Space Key -> RUN RPC Function

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Debug.Log("Space");
                //LocalPlayer team = 1
                if (PhotonNetwork.LocalPlayer.CustomProperties["team"].Equals(1))
                {
                    //Debug.Log("RPC1");
                    //block1.GetComponent<user1_block>().BlockShoot();
                    BlockShoot(1);
                }
                //LocalPlayer team = 2
                else if (PhotonNetwork.LocalPlayer.CustomProperties["team"].Equals(2))
                {
                    //block2.GetComponent<user2_block>().BlockShoot();
                    BlockShoot(2);
                }
                //LocalPlayer team = 2
                else if (PhotonNetwork.LocalPlayer.CustomProperties["team"].Equals(3))
                {
                    //block2.GetComponent<user2_block>().BlockShoot();
                    BlockShoot(3);
                }
                //LocalPlayer team = 2
                else if (PhotonNetwork.LocalPlayer.CustomProperties["team"].Equals(4))
                {
                    //block2.GetComponent<user2_block>().BlockShoot();
                    BlockShoot(4);
                }
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                //Debug.Log("Q");
                //LocalPlayer team = 1
                if (PhotonNetwork.LocalPlayer.CustomProperties["team"].Equals(1))
                {
                    //block1.GetComponent<user1_block>().BlockShoot();
                    BlockFast(1);
                }
                //LocalPlayer team = 2
                else if (PhotonNetwork.LocalPlayer.CustomProperties["team"].Equals(2))
                {
                    //block2.GetComponent<user2_block>().BlockShoot();
                    BlockFast(2);
                }
                //LocalPlayer team = 2
                else if (PhotonNetwork.LocalPlayer.CustomProperties["team"].Equals(3))
                {
                    //block2.GetComponent<user2_block>().BlockShoot();
                    BlockFast(3);
                }
                //LocalPlayer team = 2
                else if (PhotonNetwork.LocalPlayer.CustomProperties["team"].Equals(4))
                {
                    //block2.GetComponent<user2_block>().BlockShoot();
                    BlockFast(4);
                }
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                //Debug.Log("Q");
                //LocalPlayer team = 1
                if (PhotonNetwork.LocalPlayer.CustomProperties["team"].Equals(1))
                {
                    //block1.GetComponent<user1_block>().BlockShoot();
                    BlockSlow(1);
                }
                //LocalPlayer team = 2
                else if (PhotonNetwork.LocalPlayer.CustomProperties["team"].Equals(2))
                {
                    //block2.GetComponent<user2_block>().BlockShoot();
                    BlockSlow(2);
                }
                //LocalPlayer team = 2
                else if (PhotonNetwork.LocalPlayer.CustomProperties["team"].Equals(3))
                {
                    //block2.GetComponent<user2_block>().BlockShoot();
                    BlockSlow(3);
                }
                //LocalPlayer team = 2
                else if (PhotonNetwork.LocalPlayer.CustomProperties["team"].Equals(4))
                {
                    //block2.GetComponent<user2_block>().BlockShoot();
                    BlockSlow(4);
                }
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                //Debug.Log("Q");
                //LocalPlayer team = 1
                if (PhotonNetwork.LocalPlayer.CustomProperties["team"].Equals(1))
                {
                    //block1.GetComponent<user1_block>().BlockShoot();
                    BlockDelete(1);
                }
                //LocalPlayer team = 2
                else if (PhotonNetwork.LocalPlayer.CustomProperties["team"].Equals(2))
                {
                    //block2.GetComponent<user2_block>().BlockShoot();
                    BlockDelete(2);
                }
                //LocalPlayer team = 2
                else if (PhotonNetwork.LocalPlayer.CustomProperties["team"].Equals(3))
                {
                    //block2.GetComponent<user2_block>().BlockShoot();
                    BlockDelete(3);
                }
                //LocalPlayer team = 2
                else if (PhotonNetwork.LocalPlayer.CustomProperties["team"].Equals(4))
                {
                    //block2.GetComponent<user2_block>().BlockShoot();
                    BlockDelete(4);
                }
            }
        }

        //DummyGame Key Function
        /*
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetButtonDown("Jump"))
        {
            
            if (PhotonNetwork.LocalPlayer.CustomProperties["team"].Equals(0))
            {
                Debug.Log(PhotonNetwork.LocalPlayer.CustomProperties["team"]);
            }
            else if (PhotonNetwork.LocalPlayer.CustomProperties["team"].Equals(1))
            {
                block1.GetComponent<DummyGame>().PlayerMove(PhotonNetwork.LocalPlayer);
            }
            else if (PhotonNetwork.LocalPlayer.CustomProperties["team"].Equals(2))
            {
                block2.GetComponent<DummyGame1>().PlayerMove(PhotonNetwork.LocalPlayer);
            }

        }
        */

        //MoveSide Function
        /*
        if (photonView.IsMine)
        {
            /*
            // object ?????? ???? ???????? squareScript????
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Debug.Log(worldPoint);
                hit = Physics2D.Raycast(worldPoint, Vector2.zero);

                if (hit.collider != null)
                {

                    GameObject clickObject = hit.collider.gameObject;
                    clickObject.GetComponent<DummyGame>().Click(PhotonNetwork.LocalPlayer);
                }

            }
            

            
        }*/

    }
    [PunRPC]

    //Find Object and Run BlockShoot Func
    public void BlockShoot(int i)
    {

        //Debug.Log(block.gameObject.name);
        if (i == 1)
        {
            //Debug.Log("RPC2");
            block1.GetComponent<user1_block_prev>().BlockShoot(i);
        }
        else if (i == 2)
        {
            block2.GetComponent<user1_block_prev>().BlockShoot(i);
        }
        else if (i == 3)
        {
            block3.GetComponent<user1_block_prev>().BlockShoot(i);
        }
        else if (i == 4)
        {
            block4.GetComponent<user1_block_prev>().BlockShoot(i);
        }

    }

    public void BlockFast(int i)
    {

        //Debug.Log(block.gameObject.name);
        if (i != 1)
        {
            block1.GetComponent<user1_block_prev>().speed *= 1.1f;
        }
        if (i != 2)
        {
            block2.GetComponent<user1_block_prev>().speed *= 1.1f;
        }
        if (i != 3)
        {
            block3.GetComponent<user1_block_prev>().speed *= 1.1f;
        }
        if (i != 4)
        {
            block4.GetComponent<user1_block_prev>().speed *= 1.1f;
        }
    }

    public void BlockSlow(int i)
    {

        //Debug.Log(block.gameObject.name);
        if (i == 1)
        {
            block1.GetComponent<user1_block_prev>().speed *= 0.9f;
        }
        else if (i == 2)
        {
            block2.GetComponent<user1_block_prev>().speed *= 0.9f;
        }
        else if(i == 3)
        {
            block3.GetComponent<user1_block_prev>().speed *= 0.9f;
        }
        else if (i == 4)
        {
            block4.GetComponent<user1_block_prev>().speed *= 0.9f;
        }
    }

    public void BlockDelete(int i)
    {

        //Debug.Log(block.gameObject.name);
        if (i == 1)
        {
            block1.GetComponent<user1_block_prev>().DestroyAllBlocks();
        }
        else if (i == 2)
        {
            block2.GetComponent<user1_block_prev>().DestroyAllBlocks();
        }
        else if (i == 3)
        {
            block3.GetComponent<user1_block_prev>().DestroyAllBlocks();
        }
        else if (i == 4)
        {
            block4.GetComponent<user1_block_prev>().DestroyAllBlocks();
        }
    }
}
