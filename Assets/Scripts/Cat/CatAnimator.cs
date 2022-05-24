using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CatAnimator : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    Cat cat;

    // Start is called before the first frame update
    void Start()
    {
        cat = GetComponent<Cat>();
    }

    public void SetState(CatState state)
    {
        cat.GetSpriteRenderer().sprite = sprites[(int)state];
    }
}
