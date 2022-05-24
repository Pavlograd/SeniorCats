using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatInteractions : MonoBehaviour
{
    Cat cat;
    bool mouseDown = false;
    float timerTouch = 0.0f; // timer for last touch

    // Start is called before the first frame update
    void Start()
    {
        cat = GetComponent<Cat>();
    }

    void Update()
    {
        if (mouseDown == false)
        {

        }
    }

    public bool isFingerOn()
    {
        return mouseDown;
    }

    void OnMouseDown()
    {
        if (GameManager.instance.catsManager.FingerIsOnACat()) return; // One cat is already being interacted with

        cat._SFXManager.ChangeState("Meow");
        cat.StopMove(); // Stop the cat while petting or showing infos
        mouseDown = true;
    }

    void OnMouseUp() // No more finger is being used for the cat
    {
        // If your mouse hovers over the GameObject with the script attached, output this message
        mouseDown = false;
        cat.Move();
        GameManager.instance.catsManager.StopHappy();
    }

    void OnMouseOver() // For computer only
    {
        if (mouseDown)
        {
            MouseDrag();
        }
    }

    void MouseDrag()
    {
        if (cat.GetState() != CatState.HAPPY) // Only improve happiness if cat is not happy yet
        {
            GameManager.instance.catsManager.ShowHappy(transform.position); // Effect with stars

            cat.ImproveHappiness();

            if (cat.GetState() == CatState.HAPPY) // Cat is happy now, let's show that with a heart
            {
                GameManager.instance.catsManager.ShowHeart(transform.position);
            }
        }
        else
        {
            GameManager.instance.catsManager.StopHappy();
        }
    }

    void OnMouseDrag() // Alternative to OneMouseOver for mobile devies
    {
        if (GameManager.instance.playerInputs.FingerIsMoving())
        {
            MouseDrag();
        }
    }
}
