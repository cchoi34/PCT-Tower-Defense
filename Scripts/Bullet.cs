using UnityEngine;

public class Bullet : MonoBehaviour {
    
    private Transform target;
    public Tower tower;

[Header("Bullet Stats")]
    public float speed;
    public float damage;
    public float AOERadius;
    
[Header("Class Types")]
    public string classType;
    public string classBonus;
    public bool hasActiveBonus;

[Header("Type of Debuff")]
    public bool hasDebuff = false;
    public string debuff;

[Header("Debuff Stats")]
    public float slowPercentage;
    public float slowDuration;
    public float paralyzeChance;
    public float paralyzeDuration;
    public float baseArmorShred;
    public float poisonDuration;
    public float poisonDamage;
    public float drowsyStunChance;
    public float drowsyDuration;
    public float drowsySlow;
    public float spacialRend;
    public float chillMultiplier;

    // public GameObject impactEffect;

    public void Seek (Transform newTarget){
        target = newTarget;
    }

    void Update()
    {
        // damage = tower.damage;
        // slowPercentage = tower.baseSlowPercentage;
        // slowDuration = tower.slowDuration;
        // AOERadius = tower.AOERadius;

        if(target == null){
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distance = speed * Time.deltaTime;

        if(direction.magnitude <= distance){
            HitTarget();
            return;
        }
        transform.Translate(direction.normalized * distance, Space.World);
        transform.LookAt(target);
    }

    void HitTarget () {
        // GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        // Destroy(effectIns, 4f);
        if (AOERadius > 0f) {
            Explode();
        } 
        else {
            Damage(target);
        }

        Destroy(gameObject);
    }

    void Explode () {
        Collider[] affectedObjects = Physics.OverlapSphere(transform.position, AOERadius);
        foreach (Collider collider in affectedObjects) {
            if (collider.tag == "Enemy") {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy) {
        Enemy enemyComponent = enemy.GetComponent<Enemy>();
        
        if (enemyComponent != null) {
            if (hasActiveBonus) {
                if (classBonus == "sap") {
                    enemyComponent.Slow(slowPercentage, slowDuration);
                }
            }
            if (hasDebuff) {
                ApplyDebuff(enemyComponent, debuff);
            }
            enemyComponent.TakeDamage(damage, classType);
        }
    }

    void ApplyDebuff (Enemy enemy, string debuff) {
        switch (debuff) {
            case "slow":
                enemy.Slow(slowPercentage, slowDuration);
                break;

            case "curse":
                enemy.Curse(baseArmorShred);
                break;

            case "paralyze":
                enemy.Paralyze(paralyzeChance, paralyzeDuration);
                break;

            case "poison":
                enemy.Poison(poisonDamage, poisonDuration);
                break;

            case "drowsy":
                enemy.Drowsy(drowsySlow, drowsyStunChance, drowsyDuration);
                break;

            default:
                Debug.Log("No debuff applied!");
                break;
        }
    }

    void OnDrawGizmosSelected () {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AOERadius);
    }
}
