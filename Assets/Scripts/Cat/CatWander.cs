using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatWander : MonoBehaviour
{
    Cat cat;
    Vector3 targetPos;
    float speed = 1.0f;
    [SerializeField] Vector2 limitsX; // Limit on the X-axis for the Wander with limitsX.x the left and limitsX.y the right
    [SerializeField] Vector2 limitsY; // Limit on the Y-axis for the Wander with limitsY.x the left and limitsY.y the right

    // Start is called before the first frame update
    void Start()
    {
        cat = GetComponent<Cat>();
        targetPos = transform.position;
        StartCoroutine(AnimationTreeFallCat());
    }

    public void SetLimits(Vector2 _limitsX, Vector2 _limitsY)
    {
        limitsX = _limitsX;
        limitsY = _limitsY;
    }

    Vector3 NewTagertPos()
    {
        return new Vector3(Random.Range(limitsX.x, limitsX.y), Random.Range(limitsY.x, limitsY.y), 0.0f);
    }

    void FixedUpdate()
    {
        if (cat.CanMove())
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

            if (transform.position == targetPos)
            {
                targetPos = NewTagertPos();
                cat.Flip(targetPos.x < transform.position.x); // If destination is on the left then flip sprite in this direction
            }
        }
    }

    IEnumerator AnimationTreeFallCat() // Will randomly move high and bottom the cat to make an animation without sprites
    {
        while (cat.IsAlive())
        {
            yield return new WaitForSeconds(0.2f); // Time between animation

            if (cat.CanMove()) transform.position = new Vector3(transform.position.x, Random.Range(transform.position.y - 0.1f, transform.position.y + 0.1f), 0.0f);
        }
    }
}
