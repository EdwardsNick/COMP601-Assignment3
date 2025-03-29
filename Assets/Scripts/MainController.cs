using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public CanvasGroup titleCanvas;
    public TextMeshProUGUI titleButtonText;
    public CanvasGroup mainCanvas;
    public QuestionDatabase questionDatabase;
    public TextMeshProUGUI questionText;
    public Button yesButton;
    public Button noButton;
    public Button idkButton;
    public float questionTransitionTime;

    private float questionTransitionTimer;
    private bool titleFade;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        titleFade = false;
        if (PlayerPrefs.HasKey("SaveState"))
        {
            titleButtonText.text = "Resume";
            LoadQuestionDatabase();
            if (questionDatabase.QuestionsComplete())
            {
                //Generate Report
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (titleFade)
        {
            titleCanvas.alpha = Mathf.MoveTowards(titleCanvas.alpha, 0, Time.deltaTime);
            if (titleCanvas.alpha <= 0)
            {
                titleFade = false;
                titleCanvas.gameObject.SetActive(false);
                mainCanvas.interactable = true;
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

    private void LoadQuestionDatabase ()
    {
        questionDatabase = JsonUtility.FromJson<QuestionDatabase>(PlayerPrefs.GetString("SaveState"));
    }

    public void LoadNextQuestion()
    {
        /*if (questionNumber < questions.Length)
        {
            questionText.text = questions[questionNumber++];
        }
        else
        {
            Quit();
        }*/

        questionDatabase.Save();
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

    public void onStart()
    {

        LoadNextQuestion(); 
        titleFade = true;
        
    }

    public void OnYes()
    {
        questionTransitionTimer = questionTransitionTime;
    }

    public void OnNo()
    {
        questionTransitionTimer = questionTransitionTime;
    }

    public void OnIDK ()
    {
        questionTransitionTimer = questionTransitionTime;
    }
}
