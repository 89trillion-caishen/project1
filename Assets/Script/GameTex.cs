using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

class Card
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
    public GameObject buy;
    public GameObject coins;
    public GameObject hero;
    public GameObject diamonds;
    public  static string moveSpriet;
    public GameObject Unlocks;
    public Sprite subType7;
    public Sprite subType20;
    public Sprite subType13;
    public Sprite subType18;
    private List<Card> cardlist;
     void Start()
    {
       
    }

    void Update ()
    {
        InitTextList ();
        //createcard();
    }
    public void InitTextList()
    {
        cardlist = new List<Card>();
        var n = JSONNode.Parse (moveSpriet);
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
            cardlist.Add(card);
        }
    }

    public void createcard()
    {
        int len=cardlist.Count;
        int n=0;
        float rl=352.0f;
        float ud=630.0f;
        if(len%3!=0)
        {
            n=3*(len/3+1)-len;
        }
        for(int i=0;i<len;i++)
        {
            GameObject newGameObject;
            if(cardlist[i].type==1){
                   newGameObject = Instantiate (		
			       coins, transform		
                  )as GameObject;	
                  newGameObject.transform.Translate(Vector3.left * rl);
            }
            if(cardlist[i].type==2)
            {
              newGameObject = Instantiate (		
			  diamonds, 					
			  transform		
            )as GameObject;
            newGameObject.transform.Translate(Vector3.left * rl);
            }
            if(cardlist[i].type==3)
            {
                
                if(cardlist[i].subType==7)
                {
                   newGameObject = Instantiate (		
			       hero, 					
			       transform
                   )as GameObject;
                   Hero h=newGameObject.GetComponent<Hero>();
                   h.Etext(cardlist[i].costGold.ToString());
                   
                   h.s.sprite=subType7;
                   //transform.GetComponent<Image>().sprite=subType7;
                    //h.T=cardlist[i].costGold;
                //   newGameObject.GetComponent<Hero>().sprite
                }
                if(cardlist[i].subType==20)
                {
                   newGameObject = Instantiate (		
			       hero, 					
			       transform
                   )as GameObject;
                   newGameObject.transform.Translate(Vector3.right * rl);
                   Hero h=newGameObject.GetComponent<Hero>();
                   h.Etext(cardlist[i].costGold.ToString());
                   h.s.sprite=subType20;
                }
                if(cardlist[i].subType==13)
                {
                   newGameObject = Instantiate (		
			       hero, 					
			       transform
                   )as GameObject;
                   newGameObject.transform.Translate(Vector3.left * rl);
                   newGameObject.transform.Translate(Vector3.down * ud);
                   Hero h=newGameObject.GetComponent<Hero>();
                   h.Etext(cardlist[i].costGold.ToString());
                   h.s.sprite=subType13;
                }

                if(cardlist[i].subType==18)
                {
                    newGameObject = Instantiate (		
			       hero, 					
			       transform
                   )as GameObject;
                  newGameObject.transform.Translate(Vector3.down * ud);
                  Hero h=newGameObject.GetComponent<Hero>();
                  h.Etext(cardlist[i].costGold.ToString());
                   h.s.sprite=subType18;
                }
                
            }
        }
        for(int i=0;i<n;i++)
        {
            GameObject newGameObject;
              newGameObject = Instantiate (		
			  Unlocks, 					
			  transform		
            )as GameObject;
            newGameObject.transform.Translate(Vector3.right * rl);
            newGameObject.transform.Translate(Vector3.down * ud);
        }
    }

    public void bought()
    {
        GameObject newGameObject;
        newGameObject = Instantiate (		
		buy, 					
		transform
        )as GameObject;
    }

}








