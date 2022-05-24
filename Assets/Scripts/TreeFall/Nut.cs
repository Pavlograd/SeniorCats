using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum NutType
{
    ExtraLarge,
    Large,
    Normal,
    Little,
    None,
}

public class Nut : MonoBehaviour
{
    bool falling = false;
    [SerializeField] int life = 1;
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] NutDestroyer nutDestroyer;
    int scoreToGive = 0;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartFalling", 0.5f);
        scoreToGive = life;
    }

    void StartFalling()
    {
        falling = true;
    }

    void FixedUpdate()
    {
        if (falling)
        {
            transform.Translate(Vector3.up * -1.0f * Time.deltaTime, Space.World);
        }
    }

    void OnMouseDown()
    {
        life--;

        if (life <= 0)
        {
            GameManagerParent.instance.IncreaseScore(scoreToGive);
            DestroyNut();
        }

        GameManagerParent.instance.PlaySFX("Crack"); // Must be after if so not be called twice with DestroyNut
    }

    public void DestroyNut()
    {
        GameManagerParent.instance.PlaySFX("Crack"); // Crack when called not my OnMouseDown (when killing a cat for instance)
        Destroy(boxCollider);
        Destroy(this);
        nutDestroyer.enabled = true; // NutDestroyer do the animation of death
    }
}
