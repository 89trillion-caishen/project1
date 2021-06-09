using System;
using System.Collections;
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
    [SerializeField] private Sprite[] subTypeSprite=new Sprite[4];

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
        if (type < 3)
        {
            purpleBackGround.gameObject.SetActive(false);
            clockText.gameObject.SetActive(false);
            freeText.gameObject.SetActive(true);
            coinIamge.gameObject.SetActive(false);
            if (type == 1)
            {
                heroCardImage.sprite = coin;
                cardName.text = "Coins";
            }
            if (type == 2)
            {
                heroCardImage.sprite = diamond;
                cardName.text = "Diamond";
            }
        }
        if (type == 3)
        {
            //英雄卡片
            clockText.gameObject.SetActive(false);
            heroCardCost.text = costgold.ToString();
            cardName.text = "Viking Wattion";
            freeText.gameObject.SetActive(false);
            if (subtype == 7) heroCardImage.sprite = subTypeSprite[0];
            if (subtype == 13) heroCardImage.sprite = subTypeSprite[1];
            if (subtype == 18) heroCardImage.sprite = subTypeSprite[2];
            if (subtype == 20) heroCardImage.sprite = subTypeSprite[3];
        }
        if (type == 0)
        {
            //空卡片
            purpleBackGround.gameObject.SetActive(false);
            buySucces.gameObject.SetActive(false);
            buyCardButtom.gameObject.SetActive(false);
            heroCardImage.sprite = clockSprite;
        }
    }

    private void Awake()
    {
        subTypeSprite[0] = Resources.Load<Sprite>("7");
        subTypeSprite[1] = Resources.Load<Sprite>("13");
        subTypeSprite[2] = Resources.Load<Sprite>("18");
        subTypeSprite[3] = Resources.Load<Sprite>("20");
    }
}
