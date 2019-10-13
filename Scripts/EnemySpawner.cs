using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {
 
    [Header("Set Enemies")]
    public Transform enemyPrefabDefault;
    public Transform enemyPrefab1;
    public Transform enemyPrefab2;
    public Transform enemyPrefab3;
    public Transform enemyPrefab4;
    public Transform spawnPoint;

    [Header("Wave Properies")]
    public float timeBetweenWaves = 20f;
    public float timeBetweenEnemies = 0.5f;
    private float countdown = 3f;

    public Text waveCountdownText;

    public int waveNumber = 10;
    public int maxLevel = 5;

    [Header("LevelText UI")]
    public Text levelUI;
    private int level = 0;

    [Header("Notification Text")]
     public GameObject TokenText;
     public Text enemyTypeText;

     private string nextEnemyType;

    void Start () {
       nextEnemyType = "Water";
       enemyTypeText.text = "Next Level Enemies: " + nextEnemyType;
    }

    void Update () {
        if (countdown <= 0f) {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = "Time to next level: " + string.Format("{0:00.00}", countdown);
        levelUI.text = "Current Level: " + PlayerProperties.Rounds.ToString();
        enemyTypeText.text = "Next Level Enemies: " + nextEnemyType;
    }

    IEnumerator SpawnWave () {
        PlayerProperties.Rounds++;
        if (PlayerProperties.Rounds == 1 || PlayerProperties.Rounds == 6 || PlayerProperties.Rounds == 11 || PlayerProperties.Rounds == 16 || PlayerProperties.Rounds == 21 || PlayerProperties.Rounds == 26 || PlayerProperties.Rounds == 31 || PlayerProperties.Rounds == 36) { // for testing purposes loops through all the rounds again
           level = 1;
           nextEnemyType = "Fire";
        }
        if(PlayerProperties.Rounds == 2 || PlayerProperties.Rounds == 7 || PlayerProperties.Rounds == 12 || PlayerProperties.Rounds == 17 || PlayerProperties.Rounds == 22 || PlayerProperties.Rounds == 27 || PlayerProperties.Rounds == 32 || PlayerProperties.Rounds == 37){
           level = 2;
           nextEnemyType = "Grass";
        }
        if(PlayerProperties.Rounds == 3 || PlayerProperties.Rounds == 8 || PlayerProperties.Rounds == 13 || PlayerProperties.Rounds == 18 || PlayerProperties.Rounds == 23 || PlayerProperties.Rounds == 28 || PlayerProperties.Rounds == 33 || PlayerProperties.Rounds == 38){
           level = 3;
           nextEnemyType = "Psychic";
        }
        if(PlayerProperties.Rounds == 4 || PlayerProperties.Rounds == 9 || PlayerProperties.Rounds == 14 || PlayerProperties.Rounds == 19 || PlayerProperties.Rounds == 24 || PlayerProperties.Rounds == 29 || PlayerProperties.Rounds == 34 || PlayerProperties.Rounds == 39){
           level = 4;
           nextEnemyType = "";
        }
        if(PlayerProperties.Rounds % 5==0 && PlayerProperties.Rounds <= 40){
           level = 5;
           PlayerProperties.elementToken++;
           TokenText.SetActive(true);
           Invoke("TurnOffNotication", 3);
           nextEnemyType = "Water";
        }
       /* else if(levelCounter==40){
           for (int i = 0; i < waveNumber; i++) {
               SpawnEnemy();
           yield return new WaitForSeconds(timeBetweenEnemies);
           }
       }  */

        for (int i = 0; i < waveNumber; i++) {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
        
    }

    void TurnOffNotication () {
       TokenText.SetActive(false);
    }

    void SpawnEnemy() {
        switch (level) {
            case 1:
                Instantiate(enemyPrefab1, spawnPoint.position, spawnPoint.rotation);
                break;
            case 2:
                Instantiate(enemyPrefab2, spawnPoint.position, spawnPoint.rotation);
                break;
            case 3:
                Instantiate(enemyPrefab3, spawnPoint.position, spawnPoint.rotation);
                break;
            case 4:
                Instantiate(enemyPrefab4, spawnPoint.position, spawnPoint.rotation);
                break;
            case 5:
                // Instantiate(enemyPrefab5, spawnPoint.position, spawnPoint.rotation);
                break;
            default:
                Instantiate(enemyPrefabDefault, spawnPoint.position, spawnPoint.rotation);
                break;
        }
    }

}
