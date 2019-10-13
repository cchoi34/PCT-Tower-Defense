using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy : MonoBehaviour
{
[Header("Enemy Stats:")]
  public float baseSpeed = 5f;
  [HideInInspector]
  public float speed;

  public float startHealth = 100f;
  private float currentHealth;

  public float startArmor = 10f;
  [HideInInspector]
  public float armor;

  public string classType;

  public int moneyValue = 1;
  public GameObject deathEffect;

  private bool poisoned = false;
  private float poisonDamage = 0f;

  [Header("Types")]
  public float advantage;

  [Header("Health Bar")]
  public Image healthBar;

  void Start () {
      speed = baseSpeed;
      currentHealth = startHealth;
      armor = startArmor;
  }

  void Update () {
      if (poisoned) {
          ApplyPoison(poisonDamage);
      }
    //   armor = startArmor * PlayerProperties.Rounds * (float)(1.1);
    //   currentHealth = startHealth * PlayerProperties.Rounds * (float)(1.1);

    // armor = startArmor * (float)(1.3);
    // currentHealth = startHealth * (float)(1.3);
  }

  public void TakeDamage (float damage, string type) {
      float damageToTake = damage * (50 / (50 + armor));

      damageToTake = TypeAdvantage(damageToTake, type);
    //   Debug.Log("Damage Taken: " + damageToTake);
    //   Debug.Log("Current Health before: " + currentHealth);
      currentHealth -= damageToTake;
    //   Debug.Log("Current health after: " + currentHealth);
      healthBar.fillAmount = currentHealth / startHealth;

      if (currentHealth <= 0) {
          Die();
      }
  }

  public float TypeAdvantage (float damage, string type) {
      switch (classType) {
          case "water":
            switch (type) {
                case "grass":
                    damage = damage * advantage;
                    break;
                case "fire":
                    damage = damage / advantage;
                    break;
                default:
                    break;
            }
            return damage;

          case "fire":
            switch (type) {
                case "water":
                    damage = damage * advantage;
                    break;
                case "grass":
                    damage = damage / advantage;
                    break;
                default:
                    break;
            }
            return damage;

          case "grass":
            switch (type) {
                case "fire":
                    damage = damage * advantage;
                    break;
                case "water":
                    damage = damage / advantage;
                    break;
                default:
                    break;
            }
            return damage;

          default:
            return damage;
      }
  }

  public void Slow (float slowPercentage, float duration) {
      speed = baseSpeed * ((100f - slowPercentage) / 100f);
      Debug.Log("Enemy is Slowed!: " + speed);
      Invoke("ResetSpeed", duration);
  }

  public void Stun (float duration) {
      speed = baseSpeed * 0f;
      Debug.Log("Enemy is Stunned!");
      Invoke("ResetSpeed", duration);
  }

  public void Curse (float armorShred) {
      armor = startArmor * (1f - armorShred);
      Debug.Log("Enemy is Cursed!: " + armor);
  }

  public void Paralyze (float paralyzeChance, float stunDuration) {
      float chance = Mathf.Round(Random.Range(1, 100));
      if (chance <= paralyzeChance) {
        Stun(stunDuration);
      }
      Debug.Log("Enemy is Paralyzed!");
  }

  public void Poison (float damagePerSecond, float duration) {
      poisoned = true;
      poisonDamage = damagePerSecond;
      Invoke("ResetPoison", duration);
  }

  public void ApplyPoison (float damagePerSecond) {
      TakeDamage(damagePerSecond * Time.deltaTime, "grass");
      Debug.Log("Enemy Poisoned!");
  }

  public void Drowsy (float slow, float stunChance, float duration ) {
      Slow(slow, duration);
      Paralyze(stunChance, duration);
      Debug.Log("Enemy is Drowsy!");
  }

  void ResetSpeed () {
      Debug.Log("Hit ResetSpeed");
      speed = baseSpeed;
  }

  void ResetPoison () {
      Debug.Log("Hit reset Poison");
      poisoned = false;
  }

  void Die () {
     PlayerProperties.Money += moneyValue;
     //   GameObject DyingEffect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
     //   Destroy(DyingEffect, 4f);
     if (gameObject.name == "Charizard(Clone)") {
          PlayerProperties.fireLevel++;
          Destroy(gameObject);
          PlayerProperties.fireIsDead = true;
          if(GameObject.Find("ElementSelectionUI")) {
              if(GameObject.Find("ElementSelectionUI").activeSelf == true){
                  GameObject.Find("Fire").GetComponent<Button>().interactable = true;
              }
          }
      }
      if (gameObject.name == "Blastoise(Clone)") {
          PlayerProperties.waterLevel++;
          Destroy(gameObject);
          PlayerProperties.waterIsDead = true;
          if(GameObject.Find("ElementSelectionUI")) {
              if(GameObject.Find("ElementSelectionUI").activeSelf == true){
                  GameObject.Find("Water").GetComponent<Button>().interactable = true;
              }
          }
      }
      if (gameObject.name == "Venusaur(Clone)") {
          PlayerProperties.grassLevel++;
          Destroy(gameObject);
          PlayerProperties.grassIsDead = true;
          if(GameObject.Find("ElementSelectionUI")) {
              if(GameObject.Find("ElementSelectionUI").activeSelf == true){
                  GameObject.Find("Grass").GetComponent<Button>().interactable = true;
              }
          }
      }
      if (gameObject.name == "Alakazam(Clone)") {
          PlayerProperties.psychicLevel++;
          Destroy(gameObject);
          PlayerProperties.psychicIsDead = true;
          if(GameObject.Find("ElementSelectionUI")) {
              if(GameObject.Find("ElementSelectionUI").activeSelf == true){
                  GameObject.Find("Psychic").GetComponent<Button>().interactable = true;
              }
          }
      }
      else {
          Destroy(gameObject);
      }
   }
}
