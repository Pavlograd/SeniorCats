using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        float clipLength = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;

        Debug.Log(clipLength);

        Invoke("DestroyItself", clipLength);
    }

    void DestroyItself()
    {
        Destroy(gameObject);
    }
}
