using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerParent : MonoBehaviour
{
    public static GameManagerParent instance { get; private set; }
    public int score = 0;
    bool gameOver = false;
    [SerializeField] SFXManager sFXManager;
    [SerializeField] ScoreTF scoreUI;
    [SerializeField] EndGame endGame;

    void Awake()
    {
        instance = this;
    }

    public void IncreaseScore(int number = 1)
    {
        if (!gameOver) score += number;
        scoreUI.UpdateScore(score); // Not improtant if game over
    }

    public void PlaySFX(string state)
    {
        sFXManager.ChangeState(state);
    }

    public void End()
    {
        Debug.Log("End");
        Pause.PauseGame(); // Prevent further score
        Debug.Log(score); // Final score

        endGame.gameObject.SetActive(true); // UI for lose/win
        endGame.Init(score);
    }
}
