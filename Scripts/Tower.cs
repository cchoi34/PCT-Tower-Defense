using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Tile tile;
    
    [Header("Tower Upgrade Properties")]
    public int cost = 0;
    public int linearCost = 0;
    public int fusionCost = 0;

    public Tower linearUpgradeTower;
    public Tower[] fusionTowers;

    [Header("Tower Stats")]
    public float baseRange = 4f;
    [HideInInspector]
    public float range;

    [Header("Rate")]
    public float fireRate = 1f;

    [Header("General")]
    public string classType;

    [Header("Class Passives")]
    public float drizzle = 1f;
    public float combustion = 1f;
    public float sap = 0f;
    public float foresight = 1f;

    [Header("Apply Class Bonus")]
    public string classBonus;
    public bool hasActiveBonus = false;

// **** Class Bonuses ****
    void Start () {
        range = baseRange;
    }

    void Update () {
        // if (hasActiveBonus) {
        //     Debug.Log("Active Bonus is true!");
        //     if (classBonus == "foresight"){
        //         Foresight();
        //     }
        //     else {
        //         RevertForesight();
        //     }

        //     if (classBonus == "drizzle") {
        //         Drizzle();
        //     }
        //     else {
        //         RevertDrizzle();
        //     }

        //     if (classBonus == "sap") {
        //         Sap();
        //     }
        //     else {
        //         RevertSap();
        //     }

        //     if (classBonus == "combustion") {
        //         Combustion();
        //     }
        //     else {
        //         RevertCombustion();
        //     }
        // }
    }

    // public void Drizzle () {
    //     damage = baseDamage * drizzle;
    // }

    // public void Combustion () {
    //     AOERadius = baseAOERadius * combustion;
    // }

    // public void Sap () {
    //     slowPercentage = baseSlowPercentage + sap;
    // }
    
    public void Foresight () {
        range = baseRange * foresight;
    }

    // void setBonusActive () {
    //     hasActiveBonus = true;
    // }

    // void RevertDrizzle () {
    //     damage = baseDamage;
    //     Debug.Log("Reverted damage");
    // }

    // void RevertCombustion () {
    //     AOERadius = baseAOERadius;
    //     Debug.Log("Reverted AOE Radius");
    // }

    // void RevertSap () {
    //     slowPercentage = baseSlowPercentage;
    //     Debug.Log("Reverted Slow");
    // }

    void RevertForesight () {
        range = baseRange;
        Debug.Log("Reverted Range");
    }   

// *** Tower Buffs *** 
    // public void Chill () {
    //     Debug.Log("In CHILL!!!");
    //     chillCounter++;
    //     if (chillCounter > 10) {
    //         chillCounter = 1;
    //         damage = baseDamage;
    //     }
    //     float multiplier = ((chillCounter * chillMultiplier) / 100) + 1;
    //     damage = damage * multiplier;
    // }

    // public void ResetChill () {
    //     damage = baseDamage;
    //     chillCounter = 0;
    // }

    public int GetSellAmount () {
        return (cost * 3) / 4;
    }

// **** selecting a Tower on Game Map *****
    public void GetTileUnderTower (Tile _tile) {
        tile = _tile;
    }

    void OnMouseEnter () {
        tile.OnMouseEnter();
    }

    void OnMouseExit () {
        tile.OnMouseExit();
    }

    void OnMouseDown () {
        tile.OnMouseDown();
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
