using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//单例模式管理金币和钻石Text
public class CoinDiamondManager : MonoBehaviour
{
    [SerializeField] private Text coinSumText;
    [SerializeField] private Text diamondSumText;
    private int coinSumInt = 20000;
    private int diamondSumInt = 20000;

    public static CoinDiamondManager Instance { get; set; }

    void Awake()
    {
        Instance = this;
    }
    
    //领取或者购买后更新金币和钻石数量
    public void RefreshCoinDiamond(int i)
    {
        if (AnalyzeJson.cardList[i].type == 1)
        {
            coinSumInt += 5000;
            coinSumText.text = coinSumInt.ToString();
        }
        if (AnalyzeJson.cardList[i].type == 2)
        {
            diamondSumInt += 5000;
            diamondSumText.text = diamondSumInt.ToString();
        }
        if (AnalyzeJson.cardList[i].type == 3)
        {
            coinSumInt -= AnalyzeJson.cardList[i].costGold;
            coinSumText.text = coinSumInt.ToString();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        coinSumText.text = coinSumInt.ToString();
        diamondSumText.text = diamondSumInt.ToString();
    }
}
