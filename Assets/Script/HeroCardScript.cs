using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class HeroCardScript : MonoBehaviour
{
    [SerializeField] private Text heroCardCost;
    [SerializeField] private Image heroCardImage;
    [SerializeField] private Button buyCardbuttom;
    [SerializeField] private Image coinIamge;
    [SerializeField] private Text FreeText;
    [SerializeField] private Text cardName;
    [SerializeField] private Text clockText;
    [SerializeField] private Image BuySucces;

    [SerializeField] private Sprite clockSprite;
    [SerializeField] private Sprite Coin;
    [SerializeField] private Sprite diamond;
    [SerializeField] private Sprite subType7;
    [SerializeField] private Sprite subType20;
    [SerializeField] private Sprite subType13;
    [SerializeField] private Sprite subType18;
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
