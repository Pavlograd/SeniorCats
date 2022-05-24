using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public PlayerInputs playerInputs;
    public CatsManager catsManager;
    public GameObject sceneLoader; // Prefab with this script and the loadingscreen

    void Awake()
    {
        instance = this;
        Pause.ResumeGame(); // Resume game if scene switched;
    }

    public void LoadScene(string sceneName) // Can be called everywhere
    {
        GameObject newObject = Instantiate(sceneLoader, Vector3.zero, Quaternion.identity);

        newObject.GetComponent<SceneLoader>().Init(sceneName);
    }
}
