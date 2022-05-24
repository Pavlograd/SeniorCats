using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    bool moved = false;

    // Update is called once per frame
    void Update()
    {
        moved = false;

        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began) // Finger is hover
            {
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended) // Finger is not hvoer anymore
            {
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved) // Finger moed since last frame
            {
                moved = true;
            }
        }
    }

    public bool FingerIsMoving()
    {
        return moved;
    }
}
