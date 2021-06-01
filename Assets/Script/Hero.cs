using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Hero : MonoBehaviour
{
    public Text T;
    public Image s;
    public Button B;

    public void Click()
    {
        B.gameObject.SetActive(false);
    }

    // Start is called bsefore the first frame update
    public void Etext(string s){
    T.text=s;
    }
    public void EImage()
    {
        
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
