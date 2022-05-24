using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    bool playing = false;
    [SerializeField] SpriteRenderer spriteRenderer;
    Color color;
    float timeBeforeTransparent = 0.0f; // Calcul need for transparancy of the sprite;
    float speed = 2.5f;

    // Play the effect
    public void Play(Vector3 spawn, Vector3 scale)
    {
        transform.localPosition = spawn;
        transform.localScale = scale;
        color = Color.white;
        spriteRenderer.color = color;
        timeBeforeTransparent = 1f - scale.x; // will take at maximum one scond to be transparent
        playing = true;
    }

    public bool IsPlaying()
    {
        return playing;
    }

    public void Stop()
    {
        playing = false;
    }

    void FixedUpdate()
    {
        if (playing)
        {
            transform.localScale += Vector3.one * (speed * Time.deltaTime);
            color.a -= Time.deltaTime / timeBeforeTransparent; // Divide numebr is the number of seconds before object is fully transparent

            if (transform.localScale.x >= 1.0f)
            {
                transform.localScale = Vector3.one;
                color.a = 0;
                spriteRenderer.color = color;
                playing = false;
            }
        }
    }
}
