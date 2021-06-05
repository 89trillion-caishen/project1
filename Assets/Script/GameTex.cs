﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

//定义实体类，用来存放Json的数据
class  Card
{
    public int ProductId;
    public int type;
    public int subType;
    public int num;
    public int costGold;
    public int isPurchased;
}



public class GameTex : MonoBehaviour
{
    public TextAsset txt;
    
    public Transform contentTransform;

    //生成卡片的预设体
    public GameObject Prefab;

    private string moveSpriet;

    //存放实体类的链表
    private  List<Card> cardList;

    void Start()
    {
        moveSpriet=txt.text;
        InitTextList();
    }

    //解析Json，存放到List中
    public void InitTextList()
    {
        cardList = new List<Card>();
        var n = JSONNode.Parse(moveSpriet);
        var m = n["dailyProduct"];
        for (int i = 0; i < m.Count; i++)
        {
            Card card = new Card();
            card.ProductId = m[i]["ProductId"];
            card.type = m[i]["type"];
            card.subType = m[i]["subType"];
            card.num = m[i]["num"];
            card.costGold = m[i]["costGold"];
            card.isPurchased = m[i]["isPurchased"];
            cardList.Add(card);
        }
    }

    public void createcard()
    {
        int listLen = cardList.Count;
        Debug.Log(listLen);
        int cardSum = 0;
        if (listLen % 3 != 0)
        {
            cardSum = 3 * (listLen / 3 + 1) - listLen;
        }

        for (int i = 0; i < listLen; i++)
        {
            GameObject newGameObject = Instantiate(Prefab, contentTransform) as GameObject;
            Hero h1 = newGameObject.GetComponent<Hero>();
            Debug.Log(cardList[i].type);
            Debug.Log(cardList[i].subType);
            Debug.Log(cardList[i].costGold);
            h1.Init(cardList[i].type, cardList[i].subType, cardList[i].costGold);
        }

        for (int i = 0; i < cardSum; i++)
        {
            GameObject newGameObject;
            newGameObject = Instantiate(Prefab, contentTransform) as GameObject;
            Hero h2 = newGameObject.GetComponent<Hero>();
            h2.Init(0,0,0);
        }
    }
}

// //根据Json提供的数据显示英雄卡
    // public void createcard()
    // {
    //     int listLen=cardList.Count;
    //     int cardSum=0;
    //     //左右上下位移prefab
    //     float horizontal_move=352.0f;
    //     float vertical_move=630.0f;
    //
    //     if(listLen%3!=0)
    //     {
    //         cardSum=3*(listLen/3+1)-listLen;
    //     }
    //
    //     //循环生产卡片的Prefab和卡片信息的赋值
    //     for(int i=0;i<listLen;i++)
    //     {
    //         GameObject newGameObject;
    //         if(cardList[i].type==1){
    //                newGameObject = Instantiate (		
			 //       freeCoinPrefab, transform		
    //               )as GameObject;	
    //               newGameObject.transform.Translate(Vector3.left * horizontal_move);
    //         }
    //         if(cardList[i].type==2)
    //         {
    //           newGameObject = Instantiate (		
			 //  freeDiamondsPrefab, 					
			 //  transform		
    //         )as GameObject;
    //         newGameObject.transform.Translate(Vector3.left * horizontal_move);
    //         }
    //         if(cardList[i].type==3)
    //         {
    //             
    //             if(cardList[i].subType==7)
    //             {
    //                newGameObject = Instantiate (		
    //                 heroCardPrefab, 					
			 //       transform
    //                )as GameObject;
    //                Hero h=newGameObject.GetComponent<Hero>();
    //                h.heroCardImage.sprite=subType7;
    //                h.Etext(cardList[i].costGold.ToString());
    //             }
    //             if(cardList[i].subType==20)
    //             {
    //                newGameObject = Instantiate (		
			 //       heroCardPrefab, 					
			 //       transform
    //                )as GameObject;
    //                newGameObject.transform.Translate(Vector3.right * horizontal_move);
    //                Hero h=newGameObject.GetComponent<Hero>();
    //                h.Etext(cardList[i].costGold.ToString());
    //                h.heroCardImage.sprite=subType20;
    //             }
    //             if(cardList[i].subType==13)
    //             {
    //                newGameObject = Instantiate (		
			 //       heroCardPrefab, 					
			 //       transform
    //                )as GameObject;
    //                newGameObject.transform.Translate(Vector3.left * horizontal_move);
    //                newGameObject.transform.Translate(Vector3.down * vertical_move);
    //                Hero h=newGameObject.GetComponent<Hero>();
    //                h.Etext(cardList[i].costGold.ToString());
    //                h.heroCardImage.sprite=subType13;
    //             }
    //
    //             if(cardList[i].subType==18)
    //             {
    //                 newGameObject = Instantiate (		
			 //       heroCardPrefab, 					
			 //       transform
    //                )as GameObject;
    //                newGameObject.transform.Translate(Vector3.down * vertical_move);
    //                Hero h=newGameObject.GetComponent<Hero>();
    //                h.Etext(cardList[i].costGold.ToString());
    //                h.heroCardImage.sprite=subType18;
    //             }
    //         }
    //     }
    //     for(int i=0;i<cardSum;i++)
    //     {
    //         GameObject newGameObject;
    //           newGameObject = Instantiate (		
			 //  noCardPrefab, 					
			 //  transform		
    //         )as GameObject;
    //         newGameObject.transform.Translate(Vector3.right * horizontal_move);
    //         newGameObject.transform.Translate(Vector3.down * vertical_move);
    //     }
    // }









