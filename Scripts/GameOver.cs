using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text roundsText;
    public Text MewtwosText;

    void OnEnable () {
        roundsText.text = PlayerProperties.Rounds.ToString();
        MewtwosText.text = PlayerProperties.Mewtwos.ToString();
    }

    public void PlayAgain () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu () {
        SceneManager.LoadScene("MainMenu");
    }
}