using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int correctAnswers = 0;
    
    public int GetCorrectAnswers(){
        return correctAnswers;
        }

    public void IncrementCorrectAnswers(){
        correctAnswers++;
        }

    public int CalculateScore(int totalQuestions){
        return Mathf.RoundToInt(correctAnswers / (float)totalQuestions * 100);
    }


}
