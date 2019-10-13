using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
   public Text livesText;
   private bool invoked = false;
   void Update () {
       livesText.text = "Lives: " + PlayerProperties.Lives.ToString();
       if(GameObject.Find("Lives").GetComponent<Text>().color == Color.red){
           if(!invoked){
               Invoke("ResetColor", .3f);
               invoked = true;
           }
       }
   }
   void ResetColor(){
       GameObject.Find("Lives").GetComponent<Text>().color = Color.white;
       invoked = false;
   }
}
