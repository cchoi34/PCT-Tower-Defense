using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProperties : MonoBehaviour
{
    public static int Money;
    public int startMoney = 100;

    public static int Lives;
    public int startLives = 30;

    public static int Interest;
    public int startInterest = 1;
    public float TimeBetweenInterest = 5f;
    private float InterestTimer;

    public static int Rounds;
    public static int Mewtwos;
    public int MewtwoRound = 40;

    public Text InterestText;

    private bool IsMewtwoRound = false;

    public static int fireLevel;
    public static int waterLevel;
    public static int grassLevel;
    public static int psychicLevel;
    public static float interestPercentage;
    public static int elementToken;

    public static bool fireIsDead;
    public static bool waterIsDead;
    public static bool grassIsDead;
    public static bool psychicIsDead;

    void Start () {
        Money = startMoney;
        Lives = startLives;
        Interest = startInterest;
        InterestTimer = TimeBetweenInterest;
        Rounds = 0;
        Mewtwos = 0;

        fireLevel = 0;
        waterLevel = 0;
        grassLevel = 0;
        psychicLevel = 0;
        interestPercentage = 10;
        elementToken = 2;

        fireIsDead = true;
        waterIsDead = true;
        grassIsDead = true;
        psychicIsDead = true;
    }

    void Update () {
        if (Rounds >= MewtwoRound && !IsMewtwoRound) {
            StartMewtwoRound();
            Debug.Log("Starting MewTwo Round!");
        }

        if (InterestTimer <= 0f) {
            AddInterest();
            InterestTimer = TimeBetweenInterest;
        }

        if (!IsMewtwoRound) {
            InterestTimer -= Time.deltaTime;
        }
        else {
            InterestTimer = 0f;
        }
        InterestTimer = Mathf.Clamp(InterestTimer, 0f, Mathf.Infinity);
        InterestText.text = "Time till next interest: " + string.Format("{0:00.00}", InterestTimer);
    }

    void AddInterest () {
        if (!IsMewtwoRound) {
            Money = Money + ((Money / 10) * Interest);
        }
    }

    void StartMewtwoRound () {
        IsMewtwoRound = true;
    }
}
