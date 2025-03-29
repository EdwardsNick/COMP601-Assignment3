using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public Canvas mainCanvas;
    public QuestionDatabase question;
    public TextMeshProUGUI questionText;
    public Button yesButton;
    public Button noButton;
    public Button idkButton;
    public float questionTransitionTime;

    private float questionTransitionTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadNextQuestion();
    }

    // Update is called once per frame
    void Update()
    {

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
