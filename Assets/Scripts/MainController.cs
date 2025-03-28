using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public Canvas mainCanvas;
    public TextMeshProUGUI questionText;
    public TextAsset questionsDataFile;
    public Button yesButton;
    public Button noButton;
    public Button idkButton;
    public float buttonTimeout;
    public float questionTransitionTime;

    private int questionNumber;

    private string[] questions;
    private Dictionary<string, int> answers;

    private float buttonTimer;
    private float questionTransitionTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        questionNumber = 0;
        answers = new Dictionary<string, int>();
        LoadQuestionsFromFile();
        LoadNextQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonTimer > 0)
        {
            buttonTimer -= Time.deltaTime;
            if (buttonTimer < 0)
            {
                ActivateButtons();
            }
        }
        if (questionTransitionTimer > 0)
        {
            questionTransitionTimer -= Time.deltaTime;
            questionText.alpha = Mathf.Lerp(0, 1, questionTransitionTimer / questionTransitionTime);
            if (questionTransitionTimer <= 0)
            {
                questionTransitionTimer = -1;
                LoadNextQuestion();
            }
        }
        if (questionTransitionTimer < 0)
        {
            questionTransitionTimer += Time.deltaTime;
            questionText.alpha = Mathf.Lerp(1, 0, questionTransitionTimer / -questionTransitionTime);
            if (questionTransitionTimer >= 0)
            {
                questionText.alpha = 1;
                questionTransitionTimer = 0;
            }
        }
    }

    public void LoadQuestionsFromFile ()
    {
        questions = questionsDataFile.text.Split("\r\n");
    }

    public void ActivateButtons()
    {
        yesButton.enabled = true;
        noButton.enabled = true;
        idkButton.enabled = true;
    }

    public void DeactivateButtons()
    {
        yesButton.enabled = false;
        noButton.enabled = false;
        idkButton.enabled = false;
    }

    public void LoadNextQuestion()
    {
        if (questionNumber < questions.Length)
        {
            questionText.text = questions[questionNumber++];
        }
        else
        {
            Quit();
        }
    }

    public void Quit()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void OnYes()
    {
        DeactivateButtons();
        questionTransitionTimer = questionTransitionTime;
        answers.Add(questions[questionNumber - 1], 1);
        buttonTimer = buttonTimeout;
    }

    public void OnNo()
    {
        DeactivateButtons();
        answers.Add(questions[questionNumber - 1], -1);
        questionTransitionTimer = questionTransitionTime;
        buttonTimer = buttonTimeout;
    }

    public void OnIDK ()
    {
        DeactivateButtons();
        answers.Add(questions[questionNumber - 1], 0);
        questionTransitionTimer = questionTransitionTime;
        buttonTimer = buttonTimeout;
    }
}
