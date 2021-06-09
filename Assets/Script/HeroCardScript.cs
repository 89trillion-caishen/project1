﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class HeroCardScript : MonoBehaviour
{
    [SerializeField] private Text coinSumText;
    [SerializeField] private Text diamondSumText;
    [SerializeField] private Image purpleBackGround;
    [SerializeField] private Text heroCardCost;
    [SerializeField] private Image heroCardImage;
    [SerializeField] private Button buyCardButtom;
    [SerializeField] private Image coinIamge;
    [SerializeField] private Text freeText;
    [SerializeField] private Text cardName;
    [SerializeField] private Text clockText;
    [SerializeField] private Image buySucces;
    [SerializeField] private Sprite clockSprite;
    [SerializeField] private Sprite coin;
    [SerializeField] private Sprite diamond;
    [SerializeField] private Sprite[] subType=new Sprite[4];

    private int coinSumInt = 1000;
    private int diamondSumInt = 1000;
    private int i = 0;
    /// <summary>
    /// 购买之后隐藏button
    /// 修改金币数和钻石数
    /// </summary>
    public void BuyClick()
    {
        CoinDiamondManager.Instance.RefreshCoinDiamond(i);
        buyCardButtom.gameObject.SetActive(false);
    }

    // Prefab英雄卡片heroCardCost赋值
    public void Init(int x,int type, int subtype, int costgold)
    {
        i = x;
        //Debug.Log(type);
        if (type == 1)
        {
            heroCardImage.sprite = coin;
            cardName.text = "Coins";
            purpleBackGround.gameObject.SetActive(false);
            clockText.gameObject.SetActive(false);
            freeText.gameObject.SetActive(true);
            coinIamge.gameObject.SetActive(false);
            //金币卡片
        }

        if (type == 2)
        {
            heroCardImage.sprite = diamond;
            cardName.text = "Diamond";
            purpleBackGround.gameObject.SetActive(false);
            clockText.gameObject.SetActive(false);
            freeText.gameObject.SetActive(true);
            coinIamge.gameObject.SetActive(false);
            //钻石卡片
        }

        if (type == 3)
        {
            clockText.gameObject.SetActive(false);
            heroCardCost.text = costgold.ToString();
            cardName.text = "Viking Wattion";
            freeText.gameObject.SetActive(false);
            if (subtype == 7)
            {
                heroCardImage.sprite = subType[0];
            }

            if (subtype == 13)
            {

                heroCardImage.sprite = subType[1];
            }

            if (subtype == 18)
            {

                heroCardImage.sprite = subType[2];
            }

            if (subtype == 20)
            {
                heroCardImage.sprite = subType[3];
            }
        }

        if (type == 0)
        {
            purpleBackGround.gameObject.SetActive(false);
            buySucces.gameObject.SetActive(false);
            buyCardButtom.gameObject.SetActive(false);
            heroCardImage.sprite = clockSprite;
        }



    }

}
