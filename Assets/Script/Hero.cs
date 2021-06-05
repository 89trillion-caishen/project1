using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Hero : MonoBehaviour
{
    public Text heroCardCost;
    public Image heroCardImage;
    public Button buyCardbuttom;
    public Image coinIamge;
    public Text FreeText;
    public Text cardName;
    public Text clockText;
    public Image BuySucces;

    public Sprite clockSprite;
    public Sprite Coin;
    public Sprite diamond;
    public Sprite subType7;
    public Sprite subType20;
    public Sprite subType13;
    public Sprite subType18;
    //购买之后隐藏button
    public void BuyClick()
    {
        buyCardbuttom.gameObject.SetActive(false);
    }

    // Prefab英雄卡片heroCardCost赋值
    public void Init(int type,int subtype,int costgold)
    {
        //Debug.Log(type);
        if (type == 1)
        {
            heroCardImage.sprite = Coin;
            cardName.text = "Coins";
            clockText.gameObject.SetActive(false);
            FreeText.gameObject.SetActive(true);
            coinIamge.gameObject.SetActive(false);
            //金币卡片
        }

        if (type == 2)
        {
            heroCardImage.sprite = diamond;
            cardName.text = "Diamond";
            clockText.gameObject.SetActive(false);
            FreeText.gameObject.SetActive(true);
            coinIamge.gameObject.SetActive(false);
            //钻石卡片
        }

        if (type == 3)
        {
            //Debug.Log(type);
            clockText.gameObject.SetActive(false);
            heroCardCost.text = costgold.ToString();
            cardName.text = "Viking Wattion";
            FreeText.gameObject.SetActive(false);
            
            if (subtype == 7)
            {
                heroCardImage.sprite = subType7;
            }
            if (subtype == 20)
            {
                
                heroCardImage.sprite=subType20;
            }
            if (subtype == 13)
            {
                
                heroCardImage.sprite = subType13;
            }
            if (subtype == 18)
            {
                
                heroCardImage.sprite = subType18;
            }
        }

        if (type == 0)
        {
            BuySucces.gameObject.SetActive(false);
            buyCardbuttom.gameObject.SetActive(false);
            heroCardImage.sprite = clockSprite;
        }
    }

}
