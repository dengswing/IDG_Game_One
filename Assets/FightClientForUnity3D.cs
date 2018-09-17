﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IDG;
using IDG.FightClient;
using UnityEngine.UI;
public class FightClientForUnity3D : MonoBehaviour {
    
    protected FightClient client;
    public static FightClientForUnity3D instance;
    public static FightClientForUnity3D Instance
    {
        get { return instance; }
    }
    // Use this for initialization
    void Awake () {
        if (instance == null) instance = this;
        client = new FightClient();
        client.Connect("127.0.0.1", 12345,10);
        //V2 v2 = new V2(1, 0);
        //for (int i =0; i <= 360; i+=30)
        //{
        //   // Debug.Log("sin"+i+":"+MathR.SinAngle(new Ratio(i)).ToFloat());
        //   // Debug.Log("cos" + i + ":" + MathR.CosAngle(new Ratio(i)).ToFloat());
        //}

        // InputCenter.Instance.framUpdate += FrameUpdate;
      //  V2 v2 = new V2(-1,-1);
      //  Debug.Log(v2.ToRotation());
      //  Debug.LogError((10 & 2) == 2);
       // Debug.LogError(V2.left+V2.up);
    }
	

  
    
	// Update is called once per frame
	void Update () {
        
            if (client.MessageList.Count > 0)
            {
                client.ParseMessage(client.MessageList.Dequeue());
            }
        
        CommitKey();
    }
    public void CommitKey()
    {
        if (Input.GetKey(KeyCode.A))
        {
            InputCenter.Instance.SetKey(FrameKey.Left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            InputCenter.Instance.SetKey(FrameKey.Right);
        }
        if (Input.GetKey(KeyCode.S))
        {
            InputCenter.Instance.SetKey(FrameKey.Down);
        }
        if (Input.GetKey(KeyCode.W))
        {
            InputCenter.Instance.SetKey(FrameKey.Up);
        }
    }
    public void OnDestroy()
    {
        client.Stop();
    }
}