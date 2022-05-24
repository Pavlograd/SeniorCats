using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraDrag : MonoBehaviour
{
    public float dragSpeed = 2;
    private Vector3 dragOrigin;
    [SerializeField] Vector3 leftPillar; // Limits
    [SerializeField] Vector3 rightPillar;


    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return; // If you don't return there the camera will broke
        }

        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject() && !GameManager.instance.catsManager.FingerIsOnACat())
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            Vector3 move = new Vector3(pos.x * dragSpeed, 0, 0);

            transform.Translate(move, Space.World);

            // Limits
            if (transform.position.x < leftPillar.x) transform.position = leftPillar;
            else if (transform.position.x > rightPillar.x) transform.position = rightPillar;

            dragOrigin = Input.mousePosition; // Stop camera if finger doesn't move
        }
    }
}
