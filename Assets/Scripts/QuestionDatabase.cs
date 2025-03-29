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

    public TextAsset questionsDataFile;
    private Question currentQuestion;

    private void Awake()
    {
        Load();
    }

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

    public bool nextQuestion()
    {
        questionNumber++;
        if (questionNumber == questions.Count)
        {
            questionNumber--;
            return false;
        }
        else
        {
            return true;
        }
    }

    public int GetQuestionNumber()
    {
        return questionNumber;
    }

    public Question GetCurrentQuestion ()
    {
        return currentQuestion;
    }
    public void Save()
    {
        PlayerPrefs.SetString("SaveState", JsonUtility.ToJson(this));
        PlayerPrefs.Save();
    }

    private void LoadQuestionsFromFile()
    {
        //questions = questionsDataFile.text.Split("\r\n");
    }

    private void LoadQuestionsFromSaveState ()
    {

    }

    private void Load ()
    {
        if (PlayerPrefs.HasKey("SaveState"))
        {
            LoadQuestionsFromSaveState();
        }
        else
        {
            LoadQuestionsFromFile();
        }
    }

    
}
