using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class HeroCardItem : MonoBehaviour
{
    //紫色卡片底色
    [SerializeField] private Image purpleBackGround;
    //卡片的价格text
    [SerializeField] private Text heroCardCost;
    //卡片英雄图片Image
    [SerializeField] private Image heroCardImage;
    //购买按钮
    [SerializeField] private Button buyCardButtom;
    //金币图案
    [SerializeField] private Image coinIamge;
    //免费领取字样
    [SerializeField] private Text freeText;
    //卡片名字
    [SerializeField] private Text cardName;
    //空卡片名字
    [SerializeField] private Text clockText;
    //购买成功图案
    [SerializeField] private Image buySucces;
    //空卡片显示的图片
    [SerializeField] private Sprite clockSprite;
    //金币图片
    [SerializeField] private Sprite coin;
    //钻石图片
    [SerializeField] private Sprite diamond;
    //四张英雄卡片图片
    [SerializeField] private Sprite[] subTypeSprite=new Sprite[4];
    //链表指针
    private CardData cardData = new CardData();
    /// <summary>
    /// 购买之后隐藏button
    /// 修改金币数和钻石数
    /// </summary>
    public void BuyClick()
    {
        buyCardButtom.gameObject.SetActive(false);
        CoinDiamondManager.Instance.ChangeCoinDiamond(cardData.type,cardData.costGold);
        GameObject.Find("shopCanvas").GetComponent<CardCanvasManager>().RefreshCoinDiamondText();
    }
    // Prefab英雄卡片heroCardCost赋值
    public void Init(CardData cardData)
    {
        this.cardData = cardData;
        clockText.gameObject.SetActive(cardData.type==0);
        buySucces.gameObject.SetActive(cardData.type!=0);
        buyCardButtom.gameObject.SetActive(cardData.type!=0);
        freeText.gameObject.SetActive(cardData.type == 1 || cardData.type == 2);
        Debug.Log(cardData.type);
        if (cardData.type < 3)
        {
            purpleBackGround.gameObject.SetActive(false);
            coinIamge.gameObject.SetActive(false);
            if (cardData.type == 1)
            {
                heroCardImage.sprite = coin;
                cardName.text = "Coins";
            }
            else if (cardData.type == 2)
            {
                heroCardImage.sprite = diamond;
                cardName.text = "Diamond";
            }
            else
            {
                //空卡片
                heroCardImage.sprite = clockSprite;
            }
        }
        else
        {
            //英雄卡片
            heroCardCost.text = cardData.costGold.ToString();
            cardName.text = "Viking Wattion";
            if (cardData.subType == 7) heroCardImage.sprite = subTypeSprite[0];
            else if (cardData.subType == 13) heroCardImage.sprite = subTypeSprite[1];
            else if (cardData.subType == 18) heroCardImage.sprite = subTypeSprite[2];
            else  heroCardImage.sprite = subTypeSprite[3];
        }
        heroCardImage.GetComponent<Image>().SetNativeSize();
    }
    /// <summary>
    /// 动态获取四个卡片的图片
    /// </summary>
    private void Awake()
    {
        subTypeSprite[0] = Resources.Load<Sprite>("7");
        subTypeSprite[1] = Resources.Load<Sprite>("13");
        subTypeSprite[2] = Resources.Load<Sprite>("18");
        subTypeSprite[3] = Resources.Load<Sprite>("20");
    }
}
