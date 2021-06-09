using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;

public class CreateHeroCard : MonoBehaviour
{
    
    [SerializeField] private Transform contentTransform;
    //生成卡片的预设体
    [SerializeField] private GameObject heroCardPrefab;
    private bool isCreatePrefab = false;
    
  //生成卡片，获取卡片的脚本，调用脚本里的方法  
    public void CreateCard()
    {
        if (isCreatePrefab)
        {
            return;
        }
        isCreatePrefab = true;
        int listLen = AnalyzeJson.cardList.Count;
        int cardSum = 0;
        if (listLen % 3 != 0)
        {
            cardSum = 3 * (listLen / 3 + 1) - listLen;
        }
        for (int i = 0; i < listLen; i++)
        {
            GameObject newGameObject = Instantiate(heroCardPrefab, contentTransform) as GameObject;
            HeroCardScript HeroCardScriptObject = newGameObject.GetComponent<HeroCardScript>();
            HeroCardScriptObject.Init(i,AnalyzeJson.cardList[i].type, AnalyzeJson.cardList[i].subType, AnalyzeJson.cardList[i].costGold);
        }
        for (int i = 0; i < cardSum; i++)
        {
            GameObject newGameObject;
            newGameObject = Instantiate(heroCardPrefab, contentTransform) as GameObject;
            HeroCardScript HeroCardScriptObject = newGameObject.GetComponent<HeroCardScript>();
            HeroCardScriptObject.Init(-1,0,0,0);
        }
    }
}







