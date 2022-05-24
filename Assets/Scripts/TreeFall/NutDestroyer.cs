using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutDestroyer : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float timeBeforeTransparent;
    [SerializeField] float speed;
    [SerializeField] float speedRot;
    Color color = new Color(1f, 1f, 1f, 1f);
    Vector3 direction;
    Quaternion directionRot;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.up;
        direction += (Random.Range(0, 2) == 0 ? Vector3.left : Vector3.right) * 0.5f; // Slighly on the right or left
        if (Random.Range(0, 2) == 0) speedRot *= -1;
        directionRot = Quaternion.Euler(0.0f, 0.0f, speedRot);
        color = spriteRenderer.color; // In case spriteRenderer color is not white
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.color = color;
        color.a -= Time.deltaTime / timeBeforeTransparent; // Divide numebr is the number of seconds before object is fully transparent
        transform.position += direction * Time.deltaTime * speed;
        transform.rotation = Quaternion.Lerp(transform.rotation, directionRot, Time.deltaTime);

        if (color.a <= 0.0f) // Object is completly transparent
        {
            Destroy(gameObject);
        }
    }
}
