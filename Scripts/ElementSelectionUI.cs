using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ElementSelectionUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text message;
    public GameObject UI;
    public GameObject SelectUI;
    public Button elementButton;
    // public Button fire;
    // public Button water;
    // public Button grass;
    // public Button psychic;
    // public Button interest;

    //public EnemySpawner EnemySpawner;
    public Transform fireEnemy;
    public Transform waterEnemy;
    public Transform grassEnemy;
    public Transform psychicEnemy;
    public Transform spawnPoint;

    // Start is called before the first frame update
    
    void Update () {
        if (Input.GetKeyDown(KeyCode.T)) {
            toggle();
        }
        if(PlayerProperties.elementToken==0 && SelectUI.activeSelf == true){
            if(SelectUI.activeSelf == true){
                GameObject.Find("Fire").GetComponent<Button>().interactable = false;
                GameObject.Find("Water").GetComponent<Button>().interactable = false;
                GameObject.Find("Grass").GetComponent<Button>().interactable = false;
                GameObject.Find("Psychic").GetComponent<Button>().interactable = false;
                GameObject.Find("Interest").GetComponent<Button>().interactable = false;
            }
        }
        else{
            if(SelectUI.activeSelf == true){
                GameObject.Find("Fire").GetComponent<Button>().interactable = true;
                GameObject.Find("Water").GetComponent<Button>().interactable = true;
                GameObject.Find("Grass").GetComponent<Button>().interactable = true;
                GameObject.Find("Psychic").GetComponent<Button>().interactable = true;
                GameObject.Find("Interest").GetComponent<Button>().interactable = true;
            }
        }
    }

    public void toggle(){
        SelectUI.SetActive(!SelectUI.activeSelf);
    }

        public void OnPointerEnter(PointerEventData eventData){
            int fireLevel = PlayerProperties.fireLevel;
            int waterLevel = PlayerProperties.waterLevel;
            int grassLevel = PlayerProperties.grassLevel;
            int psychicLevel = PlayerProperties.psychicLevel;
            float interestPercentage = PlayerProperties.interestPercentage;
            if(eventData.pointerEnter.tag == "Fire"){
                if(PlayerProperties.fireLevel == 3){
                    message.text="Max Fire Level";
                    elementButton.interactable = false;
                }
                else{
                    message.text = "Fire " + (PlayerProperties.fireLevel+1).ToString();
                }
            }
            if(eventData.pointerEnter.tag == "Water"){
                if(PlayerProperties.waterLevel == 3){
                    message.text="Max Water Level";
                    elementButton.interactable = false;
                }
                else{
                    message.text = "Water " + (PlayerProperties.waterLevel+1).ToString();
                }
            }
            if(eventData.pointerEnter.tag == "Grass"){
                if(PlayerProperties.grassLevel == 3){
                    message.text="Max Grass Level";
                    elementButton.interactable = false;
                }
                else{
                    message.text = "Grass " + (PlayerProperties.grassLevel+1).ToString();
                }
            }
            if(eventData.pointerEnter.tag == "Psychic"){
                if(PlayerProperties.psychicLevel == 3){
                    message.text="Max Psychic Level";
                    elementButton.interactable = false;
                }
                else{
                    message.text = "Psychic " + (PlayerProperties.psychicLevel+1).ToString();
                }
            }
            if(eventData.pointerEnter.tag == "Interest"){
                message.text = (PlayerProperties.interestPercentage+5).ToString() + "% interest";
            }
            UI.SetActive(true);

        }
        public void OnPointerExit(PointerEventData eventData){
            UI.SetActive(false);
        }

        public void chooseFire(){
            Instantiate(fireEnemy, spawnPoint.position, spawnPoint.rotation);
            PlayerProperties.elementToken--;
            GameObject.Find("Fire").GetComponent<Button>().interactable = false;
        
        }
        public void chooseWater(){
            Instantiate(waterEnemy, spawnPoint.position, spawnPoint.rotation);
            PlayerProperties.elementToken--;
            GameObject.Find("Water").GetComponent<Button>().interactable = false;
        }
        public void chooseGrass(){
            Instantiate(grassEnemy, spawnPoint.position, spawnPoint.rotation);
            PlayerProperties.elementToken--;
            GameObject.Find("Grass").GetComponent<Button>().interactable = false;
        }
        public void choosePsychic(){
            Instantiate(psychicEnemy, spawnPoint.position, spawnPoint.rotation);
            PlayerProperties.elementToken--;
            GameObject.Find("Psychic").GetComponent<Button>().interactable = false;
        }
        public void chooseInterest(){
            PlayerProperties.interestPercentage+=5;
            PlayerProperties.elementToken--;
        }


        
}