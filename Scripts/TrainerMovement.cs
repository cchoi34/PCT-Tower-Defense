using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainerMovement : MonoBehaviour
{
    public GameObject trainer;
    private float speed = 5f;
    void Update () {
        if (Input.GetKey(KeyCode.I)) {
            trainer.transform.Translate(0, 0, 1);
        }

        if (Input.GetKey(KeyCode.K)) {
            trainer.transform.Translate(0, 0, -1);
        }

        if (Input.GetKey(KeyCode.J)) {
            trainer.transform.Translate(-1, 0, 0);
        }

        if (Input.GetKey(KeyCode.L)) {
            trainer.transform.Translate(1, 0, 0);
        }
    }
    
}
