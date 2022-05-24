using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct StructNut
{
    public GameObject prefab;
    public int minScore;
    public float probability;
}

public class NutsSpawner : MonoBehaviour
{
    [SerializeField] Vector3 spawnPos;
    [SerializeField] float spawnFrequence;
    [SerializeField] NutsData data;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnFrequence)
        {
            timer = 0;
            int nbrNuts = Random.Range(1, 2 + (GameManagerParent.instance.score / 10));

            for (int i = 0; i < nbrNuts; i++)
            {
                SpawnNut(GetRandomPosition());
            }

            spawnFrequence = spawnFrequence <= 1.0f ? spawnFrequence : spawnFrequence - 0.05f; // Decrease time between spawns
        }
    }

    public void SpawnNut(Vector3 position) // Will also be called by nuts when destroyed if not a little nut (or not I changed that)
    {
        GameObject newObject = Instantiate(GetNutPrefab(), position, GetRandomRotation(), transform); // Create random nut (need to change later with probability)

        //newObject.transform.localScale = transformScale; // Scale with phone's width
    }

    GameObject GetNutPrefab()
    {
        foreach (StructNut nut in data.nuts)
        {
            if (nut.minScore <= GameManagerParent.instance.score && Random.Range(0.0f, 100.0f) <= nut.probability)
            {
                return nut.prefab;
            }
        }
        return null;
    }

    Vector3 GetRandomPosition() // Create random position for the nut
    {
        return new Vector3(Random.Range(spawnPos.x * -1.0f, spawnPos.x), spawnPos.y, spawnPos.z);
    }

    Quaternion GetRandomRotation() // random roation of the nut
    {
        return Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
    }
}
