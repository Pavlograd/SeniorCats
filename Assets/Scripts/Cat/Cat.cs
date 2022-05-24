using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum CatName
{
    Otto,
    Anna,
    Garfield,
    Lilith,
    None,
}

[System.Serializable]
public enum CatState
{
    IDLE,
    HAPPY,
    SAD,
    None,
}

[System.Serializable]
public struct StructCat
{
    public string name;
    public Color color;
}

public class Cat : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public Rigidbody2D _rigidbody;
    [SerializeField] SpriteRenderer spriteRenderer;
    public SFXManager _SFXManager;
    CatAnimator catAnimator;
    StructCat cat;
    bool alive = true;
    CatState state = CatState.IDLE;
    bool canMove = true;
    float happiness = 0.0f;

    public void Init(StructCat _cat)
    {
        cat = _cat;
        catAnimator = GetComponent<CatAnimator>();
        spriteRenderer.color = cat.color;
    }

    public void ImproveHappiness()
    {
        happiness += Time.deltaTime * 40.0f; // 20.0f is slow
        CheckHappiness();
    }

    public void DecreaseHappiness()
    {
        happiness -= Time.deltaTime * 40.0f; // 20.0f is slow
        CheckHappiness();
    }

    void CheckHappiness()
    {
        if (happiness >= 100.0f)
        {
            happiness = 100.0f; // Maximum value for happiness is 100
            SetState(CatState.HAPPY);
        }
        else if (happiness >= 25.0f)
        {
            SetState(CatState.IDLE);
        }
        else
        {
            if (happiness < 0.0f) happiness = 0.0f; // Minimum value for happiness is 0
            SetState(CatState.SAD);
        }
    }

    public float GetHappiness()
    {
        return happiness;
    }

    public bool CanMove() // Used for Wander
    {
        return canMove;
    }

    public void Move()
    {
        canMove = true;
    }

    public void StopMove()
    {
        canMove = false;
    }

    public bool IsAlive()
    {
        return alive;
    }

    public void Kill()
    {
        alive = false;
        _SFXManager.ChangeState("Meow");
    }

    public void Flip(bool flip)
    {
        spriteRenderer.flipX = flip; // DO A FLIP !
    }

    public SpriteRenderer GetSpriteRenderer()
    {
        return spriteRenderer;
    }

    public void SetState(CatState _state)
    {
        state = _state;
        catAnimator.SetState(_state); // Change Sprite
    }

    public CatState GetState()
    {
        return state;
    }
}
