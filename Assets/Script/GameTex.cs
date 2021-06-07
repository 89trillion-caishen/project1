using System.Collections;
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
    [SerializeField] private TextAsset txt;
    
    [SerializeField] private Transform contentTransform;

    //生成卡片的预设体
    [SerializeField] private GameObject Prefab;

    [SerializeField] private string moveSpriet;

    //存放实体类的链表
    [SerializeField] private  List<Card> cardList;
    private bool isCreatePrefab = false;

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
        if (isCreatePrefab)
        {
            return;
        }
        isCreatePrefab = true;
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
            HeroCardScript HeroCardScriptObject = newGameObject.GetComponent<HeroCardScript>();
            Debug.Log(cardList[i].type);
            Debug.Log(cardList[i].subType);
            Debug.Log(cardList[i].costGold);
            HeroCardScriptObject.Init(cardList[i].type, cardList[i].subType, cardList[i].costGold);
        }

        for (int i = 0; i < cardSum; i++)
        {
            GameObject newGameObject;
            newGameObject = Instantiate(Prefab, contentTransform) as GameObject;
            HeroCardScript HeroCardScriptObject = newGameObject.GetComponent<HeroCardScript>();
            HeroCardScriptObject.Init(0,0,0);
        }
    }
}







