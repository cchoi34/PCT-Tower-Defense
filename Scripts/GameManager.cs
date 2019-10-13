﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    public GameObject gameOverUI;

    void Start () {
        GameIsOver = false;
    }

    void Update () {
        if (GameIsOver)
            return;

        if (Input.GetKeyDown("`")) { // allow quick access to EndScreen for testing purposes
            EndGame();
        }

        if (PlayerProperties.Lives <= 0) {
            EndGame();
        }
    }

    void EndGame () {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }
}