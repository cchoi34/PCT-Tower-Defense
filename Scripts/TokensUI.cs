using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokensUI : MonoBehaviour
{
    public Text TokenText;
    void Update () {
        TokenText.text = "Tokens: " + PlayerProperties.elementToken.ToString();
    }
}
