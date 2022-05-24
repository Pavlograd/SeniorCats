using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ParralaxElement
{
    public Sprite sprite;
    public Vector3 speed; // Direction to translate element
}


public class Parralax : MonoBehaviour
{
    [SerializeField] ParralaxData data;
    [SerializeField] GameObject parralaxElement;
    Transform[] sprites; // We only move object so we don't need the gameObject

    // INIT

    void Start()
    {
        CreateSprites();
    }

    void CreateSprites()
    {
        sprites = new Transform[data.elements.Length * 2]; // Two sprites parralax version
        int index = 0;

        foreach (ParralaxElement element in data.elements)
        {
            index = CreateSprite(index, Vector3.zero, false, element.sprite); // First sprite in center
            index = CreateSprite(index, data.offset, true, element.sprite); // Second sprite with the offset and flip to create pattern
        }
    }

    int CreateSprite(int index, Vector3 position, bool flip, Sprite sprite)
    {
        GameObject newObject = Instantiate(parralaxElement, position, Quaternion.identity, transform);
        SpriteRenderer spriteRenderer = newObject.GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = sprite;
        spriteRenderer.flipX = flip;

        sprites[index] = newObject.transform;
        return ++index;
    }

    // END INIT

    // Update is called once per frame
    void Update()
    {
        int index = 0;

        foreach (ParralaxElement element in data.elements) // Move the two sprites of each element
        {
            index = MoveElement(index, element.speed);
            index = MoveElement(index, element.speed);
        }
    }

    int MoveElement(int index, Vector3 speed)
    {
        sprites[index].position += speed * Time.deltaTime;

        if (sprites[index].position.x <= (data.offset * -1).x)
        {
            sprites[index].position = data.offset;
        }

        return ++index;
    }
}
