using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    ScoreKeeper scoreKeeper;
    Quiz quiz;
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        quiz = FindObjectOfType<Quiz>();
    }

    public void ShowFinalScore(){
        finalScoreText.text = "Congratulations!\nYou have scored " +
                                scoreKeeper.CalculateScore(quiz.totalQuestions)+ "%";
        }

}
