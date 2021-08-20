using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text textScore;
    public int scoreInt;

    void Update()
    {
        textScore.text = scoreInt.ToString();
    }
}
