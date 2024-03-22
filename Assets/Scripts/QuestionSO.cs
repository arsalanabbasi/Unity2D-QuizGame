using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Question", menuName = "Quiz Question", order = 0)]
public class QuestionSO : ScriptableObject {

    [TextArea(2,6)][SerializeField] string question = "Enter your question here!";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctIndex = 0;

    public string GetQuestion(){
        return question;
        }

    public int GetCorrectAnswerIndex(){
        return correctIndex;
        }
    
    public string GetAnswer(int index){
        return answers[index];
        }
}
