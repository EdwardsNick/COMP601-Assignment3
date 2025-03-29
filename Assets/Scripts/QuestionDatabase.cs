using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QuestionDatabase : MonoBehaviour
{
    
    [SerializeField]
    public List<Question> questions;
    [SerializeField]
    public int questionNumber;

    private Question currentQuestion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetQuestionNumber (int number)
    {
        questionNumber = number;
        currentQuestion = questions[number];
    }

    public int GetQuestionNumber ()
    {
        return questionNumber;
    }

    public Question GetCurrentQuestion ()
    {
        return currentQuestion;
    }
}
