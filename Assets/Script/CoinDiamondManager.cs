using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//单例模式管理金币和钻石
public class CoinDiamondManager : MonoBehaviour
{
    //初始的金币钻石数
    private int coinSumInt = 20000;
    private int diamondSumInt = 20000;
    //单例模式
    public static CoinDiamondManager Instance { get; set; }
    void Awake()
    {
        Instance = this;
    }
    private void SetCoinDiamond(int type, int coinDiamondNum)
    {
        if (type == 1)
        {
            coinSumInt += coinDiamondNum;
        }
        else
        {
            diamondSumInt += coinDiamondNum;
        }
    }
    
    public int GetCoinDiamond(int type)
    {
        if (type == 1)
        {
            return coinSumInt;
        }
        else
        {
            return diamondSumInt;
        }
    }
    /// <summary>
    /// 根据type判断增加减少金币和钻石数目
    /// </summary>
    /// <param name="type"></param>
    /// <param name="chanegNum"></param>
    public void ChangeCoinDiamond(int type,int chanegNum)
    {
        if (type == 2)
        {
            SetCoinDiamond(0, chanegNum);
        }
        else
        {
            SetCoinDiamond(1,-chanegNum);
        }
    }
}
