using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerFC : MonoBehaviour
{
    [SerializeField] FlappyCat cat;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cat.Jump();
            return; // If you don't return there the camera will broke
        }
    }
}
