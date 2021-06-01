using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Hero : MonoBehaviour
{
    public Text heroCardCost;
    public Image heroCardImage;
    public Button buyHeroCard;

    //购买之后隐藏button
    public void Click()
    {
        buyHeroCard.gameObject.SetActive(false);
    }

    // Prefab英雄卡片heroCardCost赋值
    public void Etext(string s){
    heroCardCost.text=s;
    }
    void Start()
    {
        //transform.GetComponent<Image>().Sprite=sprite;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
