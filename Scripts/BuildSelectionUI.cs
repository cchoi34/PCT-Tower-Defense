using UnityEngine;
using UnityEngine.UI;

public class BuildSelectionUI : MonoBehaviour {

    public GameObject ui;
    public Text upgradeCost;
    public Button upgradeButton;

    public Text sellAmount;
    
    private Tile targetTile;

    public void SetTargetTile (Tile tile) {
        targetTile = tile;

        if (!targetTile.isFinalUpgrade) {
            upgradeCost.text = "$" + targetTile.tower.linearCost;
            upgradeButton.interactable = true;
        }
        else {
            upgradeCost.text = "Fully Upgraded!";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "$" + targetTile.tower.GetSellAmount();
        ui.SetActive(true);
        Debug.Log("UI Set Active");
    }

    public void Hide () { 
        ui.SetActive(false);
    }

    public void UpgradeBlueprint (Tower tower) {
        targetTile.UpgradeTower(tower);
        BuildManager.instance.SelectTile(targetTile);
    }

    public void Sell () {
        targetTile.SellTower();
        BuildManager.instance.DeselectTile();
    }
}


