using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatsManager : MonoBehaviour
{
    [SerializeField] CatData data; // All cats infos
    [SerializeField] Cat[] cats; // Cats
    [SerializeField] GameObject prefabHeart; // Used to instantiate
    [SerializeField] Happy happyEffect; // used to place at cat's position
    CatInteractions[] catsInteractions; // Component CatInteractions from cats;

    // Start is called before the first frame update
    void Start()
    {
        catsInteractions = new CatInteractions[cats.Length];

        for (int i = 0; i < cats.Length; i++) // Init all cats with the correspond name and color
        {
            cats[i].Init(data.cats[i]);
            cats[i].gameObject.GetComponent<CatWander>().SetLimits(data.limitsX, data.limitsY);
            catsInteractions[i] = cats[i].gameObject.GetComponent<CatInteractions>(); // Add component

        }
    }

    public bool FingerIsOnACat() // Return is player touched a cat where is finger is. Used for camera drag
    {
        for (int i = 0; i < catsInteractions.Length; i++) // Check all cats
        {
            if (catsInteractions[i].isFingerOn()) return true;
        }
        return false;
    }

    public void ShowHeart(Vector3 spawnPosition) // Will spawn an heart at cat's position
    {
        Instantiate(prefabHeart, spawnPosition, Quaternion.identity);
    }

    public void ShowHappy(Vector3 spawnPosition)
    {
        happyEffect.Play(spawnPosition);
    }

    public void StopHappy()
    {
        happyEffect.Stop();
    }
}
