using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool movementActive = true;
    [Header("Panning Attributes")]
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public Vector2 panLimit;

    [Header("Scrolling Attributes")]
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;

    void Update () {

        if (GameManager.GameIsOver) {
            this.enabled = false;
            return;
        }

        Vector3 position = transform.position;

        if (Input.GetKeyDown (KeyCode.Escape)) {
            movementActive = !movementActive;
        }

        if (!movementActive) // exit camera panning on escape keypress
            return;


        if (Input.GetKey(KeyCode.UpArrow) || Input.mousePosition.y >= Screen.height - panBorderThickness) {
            position.z += panSpeed * Time.deltaTime; //new Vector3(0, 0, panspeed)
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.mousePosition.y <= panBorderThickness) {
            position.z -= panSpeed * Time.deltaTime;; 
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.mousePosition.x >= Screen.width - panBorderThickness) {
            position.x += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.mousePosition.x <= panBorderThickness) {
            position.x -= panSpeed * Time.deltaTime;; 
        }

        position.x = Mathf.Clamp(position.x, -panLimit.x, panLimit.x);
        position.z = Mathf.Clamp(position.z, -panLimit.y, panLimit.y);

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        position.y -= scroll * 50 * scrollSpeed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, minY, maxY);

        transform.position = position;
    }
}
