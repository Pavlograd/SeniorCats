using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFallCat : MonoBehaviour
{
    [SerializeField] Cat cat;
    [SerializeField] NutDestroyer nutDestroyer;
    Vector3 targetPos;
    float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
        //StartCoroutine(AnimationTreeFallCat());
    }

    Vector3 NewTagertPos()
    {
        return new Vector3(Random.Range(-2.6f, 2.6f), -4.2f, 0.0f);
    }

    void FixedUpdate()
    {
        /*transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (transform.position == targetPos)
        {
            targetPos = NewTagertPos();
            cat.Flip(targetPos.x < transform.position.x); // If destination is on the left then flip sprite in this direction
        }*/
    }

    IEnumerator AnimationTreeFallCat()
    {
        while (cat.IsAlive())
        {
            yield return new WaitForSeconds(0.2f);
            transform.position = new Vector3(transform.position.x, Random.Range(-4.1f, -4.3f), 0.0f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Miaou X_X !");
        DestroyCat();
    }

    public void DestroyCat()
    {
        GameManagerParent.instance.PlaySFX("Crack"); // Crack when called not my OnMouseDown (when killing a cat for instance)
        GameManagerParent.instance.End(); // End game
        cat.Kill();
        Destroy(cat.boxCollider);
        Destroy(cat._rigidbody);
        Destroy(this);
        nutDestroyer.enabled = true; // NutDestroyer do the animation of death
    }
}
