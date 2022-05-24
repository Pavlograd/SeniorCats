using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyCat : MonoBehaviour
{
    bool alive = true;
    [SerializeField] Rigidbody2D rgdbody;
    float jumpForce = 1000.0f;
    float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("IncreaseScore", 10.0f, 3.0f);
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rgdbody.velocity.y * 10.0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Miaou X_X !");
        DestroyPlane();
    }

    public void DestroyPlane()
    {
        GameManagerParent.instance.PlaySFX("Meow"); // Plane crashed
        GameManagerParent.instance.End(); // End game
        Destroy(rgdbody);
        Destroy(this);
    }

    public void Jump()
    {
        if (alive)
        {
            rgdbody.AddForce(Vector3.up * jumpForce);
        }
    }

    void IncreaseScore()
    {
        GameManagerParent.instance.IncreaseScore();
    }
}
