using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading;


public class Quiz : MonoBehaviour
{
    [Header ("Questions")]
    [SerializeField]TextMeshProUGUI questionText;
    [SerializeField]List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO currentQuestion;

    [Header ("Answers")]
    [SerializeField]GameObject[] answerButtons;
    int correctAnswerIndex;
    bool hasAnsweredEarly = true;

    [Header ("Buttons")]
    [SerializeField]Sprite defaultAnswerSprite;
    [SerializeField]Sprite correctAnswerSprite;
    [SerializeField]Image timerImage;
    Timer time;

    [Header ("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    public int totalQuestions;
    [SerializeField] Slider progessBar;
    public bool isComplete;


    void Awake(){
        time = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        totalQuestions = questions.Count;
        progessBar.maxValue = totalQuestions;
        progessBar.value = 0;
        scoreText.text = "Score : " + scoreKeeper.CalculateScore(totalQuestions) + "%";
        }

    void Update(){
        timerImage.fillAmount = time.timeFraction;

        if(time.loadNextQuestion){

            if(progessBar.value == progessBar.maxValue){
                isComplete = true;
                return;
                }

            hasAnsweredEarly = false;
            GetNextQuestion();
            time.loadNextQuestion = false;
            }
        
        else if(!hasAnsweredEarly && !time.isAnsweringQuestion){
            DisplayAnswer(-1);
            SetButtonStates(false);
            }
        }

    public void OnAnswerSelected(int index){
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonStates(false);
        time.CancelTimer();
        scoreText.text = "Score : " + scoreKeeper.CalculateScore(totalQuestions) + "%";

        
        }
    
    void DisplayAnswer(int index){
         Image image;

        if (index == currentQuestion.GetCorrectAnswerIndex()){
            questionText.text = "Correct Answer!";
            image = answerButtons[index].GetComponent<Image>();
            image.sprite = correctAnswerSprite;
            scoreKeeper.IncrementCorrectAnswers();
            }
        
        else{
            correctAnswerIndex = currentQuestion.GetCorrectAnswerIndex();
            questionText.text = "The correct answer was\n" + currentQuestion.GetAnswer(correctAnswerIndex);
            image = answerButtons[correctAnswerIndex].GetComponent<Image>();
            image.sprite = correctAnswerSprite;
            }

        }

    void GetNextQuestion(){
        if (questions.Count >=0){
            SetButtonStates(true);
            SetDefaultButtonSprites();
            GetRandomQuestion();
            DisplayQuestion();
            progessBar.value++;
            }
        
        }

    void GetRandomQuestion(){
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];

        if(questions.Contains(currentQuestion)){
            questions.Remove(currentQuestion);
        }

    }
    void DisplayQuestion(){
        questionText.text = currentQuestion.GetQuestion();

        for (int i=0; i<answerButtons.Length; i++){
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
            }
        }

    void SetButtonStates(bool state){
        for(int i=0; i< answerButtons.Length; i++){
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
            }
        }    

    void SetDefaultButtonSprites(){
        for(int i=0; i<answerButtons.Length; i++){
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
            }
        }

}