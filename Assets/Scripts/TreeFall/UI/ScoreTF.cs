using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreTF : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    public void UpdateScore(int score)
    {
        text.text = "Score: " + score.ToString();
    }
}
