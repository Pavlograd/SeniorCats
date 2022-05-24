using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum Direction
{
    North,
    East,
    South,
    West,
    None,
}

public class ObstaclesManager : MonoBehaviour
{
    List<GameObject> obstacles = new List<GameObject>();
    [SerializeField] float speedObstacles = 1.0f;
    [SerializeField] float delaySpawnObstacles = 5.0f;
    [SerializeField] GameObject prefabObstacle;
    [SerializeField] Sprite endObstacleSprite;
    [SerializeField] float startX = 10.0f; // Distance from the center where the obstacles will spawn

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacles", delaySpawnObstacles, delaySpawnObstacles);
    }

    void SpawnObstacles()
    {
        int size = Random.Range(4, 8);
        Direction direction = Random.Range(0, 2) == 0 ? Direction.North : Direction.South;

        Vector3 position = new Vector3(startX, direction == Direction.North ? -4.5f : 4.5f, 0.0f);

        for (int i = 0; i < size; i++)
        {
            GameObject newObject = Instantiate(prefabObstacle, position, Quaternion.identity, transform);
            SpriteRenderer spriteRenderer = newObject.GetComponent<SpriteRenderer>();

            spriteRenderer.flipY = direction == Direction.North;

            if (i == size - 1) // End of obstacle
            {
                spriteRenderer.sprite = endObstacleSprite;
            }

            obstacles.Add(newObject);

            position += Vector3.up * (direction == Direction.North ? 1.0f : -1.0f);
        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 transitionPos = Vector2.left * speedObstacles * Time.deltaTime;

        for (int i = 0; i < obstacles.Count; i++)
        {
            GameObject obstacle = obstacles[i];

            obstacle.transform.position += transitionPos;

            if (obstacle.transform.position.x <= -10.0f)
            {
                obstacles.Remove(obstacle);
                Destroy(obstacle);
            }
        }
    }
}
