using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    void Awake () {
        if (instance !=null) {
            Debug.Log("More than one Buildmanager in Scene!");
        }
        instance = this;
    }

    public GameObject pokeballTowerPrefab;
    public GameObject greatballTowerPrefab;
    public GameObject charizardTowerPrefab;
    public GameObject alakazamTowerPrefab;
    public GameObject venusaurTowerPrefab;
    public GameObject blastoiseTowerPrefab;

    [Header("Secondary Prefabs")]
    public GameObject swampertTowerPrefab;
    public GameObject tornandusTowerPrefab;
    public GameObject glalieTowerPrefab;
    public GameObject gengarPrefab;
    public GameObject rotomTowerPrefab;
    public GameObject nidokingTowerPrefab;

    [Header("Tertiary Prefabs")]
    public GameObject heatranTowerPrefab;
    public GameObject darkraiTowerPrefab;
    public GameObject xerneasTowerPrefab;
    public GameObject palkiaTowerPrefab;

    [Header("Effects")]
    public GameObject buildEffect;

    private Tower towerToBuild; // changed from TowerBlueprint
    private Tile selectedTile;
    public BuildSelectionUI buildSelectionUI;

    public bool CanBuild { get { return towerToBuild != null; } }
    public bool HasEnoughMoney { get { return PlayerProperties.Money >= towerToBuild.cost; }}

    public void SelectTile (Tile tile) {
        selectedTile = tile;
        towerToBuild = null;

        buildSelectionUI.SetTargetTile(tile);
    }

    public void DeselectTile () {
        selectedTile = null;
        buildSelectionUI.Hide();
    }

    // public void SelectTowerToBuild (TowerBlueprint tower) {
    //     towerToBuild = tower;
    //     DeselectTile();
    // }

    public void SelectTowerToBuild (Tower tower) {
        towerToBuild = tower;
        DeselectTile();
    }

    // public TowerBlueprint GetTowerToBuild () {
    //     return towerToBuild;
    // }

    public Tower GetTowerToBuild () {
        return towerToBuild;
    }
}
