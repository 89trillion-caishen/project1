using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

//定义实体类，用来存放Json的数据
public class CardData
{
    public int ProductId;
    public int type;
    public int subType;
    public int num;
    public int costGold;
    public int isPurchased;
}
public class AnalyzeJson : MonoBehaviour
{
    [SerializeField] private TextAsset jsonTxt;
    //存放实体类的链表
    public static List<CardData> cardList=new List<CardData>();
    private string jsonData;
    public void InitTextList()
    {
        cardList = new List<CardData>();
        var n = JSONNode.Parse(jsonData);
        var m = n["dailyProduct"];
        for (int i = 0; i < m.Count; i++)
        {
            CardData card = new CardData();
            card.ProductId = m[i]["ProductId"];
            card.type = m[i]["type"];
            card.subType = m[i]["subType"];
            card.num = m[i]["num"];
            card.costGold = m[i]["costGold"];
            card.isPurchased = m[i]["isPurchased"];
            cardList.Add(card);
        }
    }
    void Start()
    {
        jsonData=jsonTxt.text;
        InitTextList();
    }
}
