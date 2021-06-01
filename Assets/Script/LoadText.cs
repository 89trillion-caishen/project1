using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using System.Collections;


public class LoadText : MonoBehaviour {
   
    public TextAsset txt;

    void Start()
    {

        GameTex.moveSpriet=txt.text;

    }
}
