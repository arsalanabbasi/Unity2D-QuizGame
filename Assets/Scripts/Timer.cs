using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]float timeToCompleteQuestion = 30f;
    [SerializeField]float timeToShowAnswer = 10f;
    public bool isAnsweringQuestion = false;
    public bool loadNextQuestion = true;
    public float timeFraction;


    float timerValue;
   
    void Update(){
        UpdateTime();
        }

    public void CancelTimer(){
        timerValue = 0;
        }

    void UpdateTime(){
        timerValue -= Time.deltaTime;

        if(isAnsweringQuestion){
            if(timerValue >= 0){
                timeFraction = timerValue / timeToCompleteQuestion;
                }

            else{
                timerValue = timeToShowAnswer;
                isAnsweringQuestion = false;
                loadNextQuestion = false;
                Debug.Log("Showing Answer");
                Debug.Log(isAnsweringQuestion);
                Debug.Log(loadNextQuestion);
                Debug.Log(timerValue);
                }
            
            }

        else{
            if(timerValue >= 0){
                timeFraction = timerValue / timeToShowAnswer;
                }
            
            else{
                timerValue = timeToCompleteQuestion;
                isAnsweringQuestion = true;
                loadNextQuestion = true;
                Debug.Log("Showing Question");
                Debug.Log(isAnsweringQuestion);
                Debug.Log(loadNextQuestion);
                Debug.Log(timerValue);
                }
            
            }
        
        
        } 

}
