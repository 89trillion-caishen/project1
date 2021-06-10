using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;

public class CardCanvasManager : MonoBehaviour
{
    //现实金币数和钻石数的Text
    public Text coinSumText;
    public Text diamondSumText;
    [SerializeField] private Transform contentTransform;
    //生成卡片的预设体
    [SerializeField] private HeroCardItem heroCardPrefab;
    //判断是否已经生成卡片
    private bool isCreatePrefab = false;
    private HeroCardItem HeroCardScriptObject;
    [SerializeField] private GameObject scrollViewlContent;
    CardData cardData = new CardData();
    /// <summary>
    /// 如果已经生成过了，不再生成器卡片
    /// 如果卡片不是3的倍数，补上空卡片
    /// 生成卡片脚本
    /// 调用脚本里的方法  
    /// </summary>
    public void CreateCard()
    {
        //因为JSON和需求都没有钻石和金币奖励卡片的奖励大小，所以默认为0，领取免费时不会改变金币和钻石数目
        RefreshCoinDiamondText();
        if (isCreatePrefab)
        {
            scrollViewlContent.SetActive(true);
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
            Instantiate(heroCardPrefab, contentTransform).Init(AnalyzeJson.cardList[i]);
        }

        for (int i = 0; i < cardSum; i++)
        {
            Instantiate(heroCardPrefab, contentTransform).Init(cardData);
        }
    }
    
    /// <summary>
    /// 关闭shop
    /// </summary>
    public void CLoseCardView()
    {
        scrollViewlContent.SetActive(false);
    }
    /// <summary>
    /// 刷新金币和钻石数目
    /// type==1代表金币  2代表钻石
    /// </summary>
    public void RefreshCoinDiamondText()
    {
        coinSumText.text = CoinDiamondManager.Instance.GetCoinDiamond(1).ToString();
        diamondSumText.text = CoinDiamondManager.Instance.GetCoinDiamond(2).ToString();
    }
}







