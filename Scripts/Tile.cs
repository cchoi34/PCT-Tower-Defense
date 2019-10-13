using UnityEngine;

public class Tile : MonoBehaviour
{
    public Color hoverColor;
    public Color hoverTowerColor;
    public Color notEnoughMoneyColor;

    public Vector3 positionOffset;
    
    [HideInInspector]
    public Tower tower;
    [HideInInspector]
    public bool isFinalUpgrade = false;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start () {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition () {
        return transform.position + positionOffset;
    }

    public void OnMouseDown () {
        // if (EventSystem.current.IsPointerOverGameObject())
        //     return;

        if (!buildManager.CanBuild && tower != null) {
            buildManager.SelectTile(this);
            return;
        }

        if (!buildManager.CanBuild) {  // shop icon has been clicked
            buildManager.DeselectTile();
            return;
        }

        if (tower != null) {
            buildManager.SelectTile(this);
            return;
        }

        BuildTower(buildManager.GetTowerToBuild());
    }

    // void BuildTower (TowerBlueprint blueprint) {
    //     if (PlayerProperties.Money < blueprint.cost) {
    //         Debug.Log("Not Enough Money!");
    //         return;
    //     }

    //     PlayerProperties.Money -= blueprint.cost;
    //     Tower _tower = (Tower)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
    //     tower = _tower;

    //     towerBlueprint = blueprint;
    //     tower.GetTileUnderTower(this);

    //     GameObject buildingEffect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
    //     Destroy(buildingEffect, 5f);
    // }

    void BuildTower (Tower builtTower) {
        if (PlayerProperties.Money < builtTower.cost) {
            Debug.Log("Not Enough Money!");
            return;
        }

        PlayerProperties.Money -= builtTower.cost;
        Tower _tower = (Tower)Instantiate(builtTower, GetBuildPosition(), Quaternion.identity);
        tower = _tower;

        tower.GetTileUnderTower(this);

        GameObject buildingEffect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(buildingEffect, 5f);
    }

    public void UpgradeTower (Tower upgradedTower) {
        if (PlayerProperties.Money < upgradedTower.cost) {
            Debug.Log("Not Enough Money to Upgrade!");
            return;
        }
        Debug.Log("UpgradedTower: " + upgradedTower);

        PlayerProperties.Money -= upgradedTower.cost;

        Destroy(tower.gameObject); // get rid of old tower

        Tower _tower = (Tower)Instantiate(upgradedTower, GetBuildPosition(), Quaternion.identity);
        tower = _tower;

        Debug.Log("Tower: " + tower);

        tower.GetTileUnderTower(this);

        GameObject buildingEffect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(buildingEffect, 5f);
    }

    // public void UpgradeTower () {
    //     if (PlayerProperties.Money < towerBlueprint.upgradeCosts[tower.upgradedPrefabIndex]) {
    //         Debug.Log("Not Enough Money to Upgrade!");
    //         return;
    //     }

    //     PlayerProperties.Money -= towerBlueprint.upgradeCosts[tower.upgradedPrefabIndex];
    //     int currentTowerIndex = tower.upgradedPrefabIndex;

    //     Destroy(tower.gameObject); // get rid of old tower

    //     Tower _tower = (Tower)Instantiate(towerBlueprint.upgradedPrefabs[tower.upgradedPrefabIndex], GetBuildPosition(), Quaternion.identity); //upgrade to new tower
    //     tower = _tower;
    //     tower.upgradedPrefabIndex = currentTowerIndex;
        

    //     tower.upgradedPrefabIndex += 1;
    //     if (tower.upgradedPrefabIndex >= towerBlueprint.upgradedPrefabs.Length) {
    //         isFinalUpgrade = true;
    //         Debug.Log("IsFinalUpgrade: " + isFinalUpgrade);
    //     }

    //     GameObject buildingEffect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
    //     Destroy(buildingEffect, 5f);
    // }

    public void SellTower () {
        PlayerProperties.Money += tower.GetSellAmount();

        Destroy(tower.gameObject);
    }

    public void OnMouseEnter () {
        // if (EventSystem.current.IsPointerOverGameObject())
        //     return;

        if (!buildManager.CanBuild && tower != null) {
            rend.material.color = hoverTowerColor;
            Debug.Log("Hovered Tile: " + this);
        }

        if (!buildManager.CanBuild)
            return;
            
        if (buildManager.HasEnoughMoney) {
            rend.material.color = hoverColor;
        }
        else {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    public void OnMouseExit () {
        rend.material.color = startColor;
    }
}
