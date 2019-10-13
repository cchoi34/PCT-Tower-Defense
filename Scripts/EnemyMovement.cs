using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
   private Transform target;
   private int waypointIndex = 0;
   private Enemy enemy;

   public Transform partToRotate;

   void Start () {
      enemy = GetComponent<Enemy>();
      target = Waypoints.points[0];
      InvokeRepeating("LockOnWaypoint", 0f, .01f);
   }

   void Update () {
      Vector3 direction = target.position - transform.position;
      transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

      if (Vector3.Distance(transform.position, target.position) <= 0.2f) {
          GetNextWaypoint();
      }
  }

  void GetNextWaypoint() {
      if (waypointIndex >= Waypoints.points.Length - 1) {
          EndPath();
          return;
      }
      waypointIndex++;
      target = Waypoints.points[waypointIndex];
  }

  void EndPath () {
      if (PlayerProperties.Lives > 0) {
          PlayerProperties.Lives--;  
          GameObject.Find("Lives").GetComponent<Text>().color = Color.red;  
      }
      
      Destroy(gameObject);
  }

  void LockOnWaypoint () {
       Vector3 direction = target.position - transform.position;
       Quaternion lookRotation = Quaternion.LookRotation(direction);
       Vector3 rotation = lookRotation.eulerAngles;
       if(transform.name == "Geodude(Clone)" || transform.name == "Rattata(Clone)"){
           rotation.y -= 180;
       }
       partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
   }
}
