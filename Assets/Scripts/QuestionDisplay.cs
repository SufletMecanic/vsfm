﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class QuestionDisplay : MonoBehaviour
{
    public GetQuestions getQuestions;

    public Text question;

    public Text answer1;

    public Text answer2;

    public Text answer3;

    public Text answer4;
    // Start is called before the first frame update
    public void DisplayQuestion(Question q)
    {
        for (int i = 0; i < q.incorrect_answers.Count; i++)
        {
            q.incorrect_answers[i] = WebUtility.HtmlDecode(q.incorrect_answers[i]);
        }
        q.correct_answer = WebUtility.HtmlDecode(q.correct_answer);
        question.text = WebUtility.HtmlDecode(q.question);
        var answers = shuffledAnswers(q);
        answer1.text = WebUtility.HtmlDecode(answers[0]);
        answer2.text = WebUtility.HtmlDecode(answers[1]);
        answer3.text = WebUtility.HtmlDecode(answers[2]);
        answer4.text = WebUtility.HtmlDecode(answers[3]);
        answer1.color = Color.white;
        answer2.color = Color.white;
        answer3.color = Color.white;
        answer4.color = Color.white;
        answer1.gameObject.SetActive(true);
        answer2.gameObject.SetActive(true);
        answer3.gameObject.SetActive(true);
        answer4.gameObject.SetActive(true);
    }

    private List<string> shuffledAnswers(Question q) {
        var answers = q.incorrect_answers.ToList();
        // foreach (var answer in answers)
        // {
        //     Debug.Log(answer);
        // }
        answers.Add(q.correct_answer);
        Utils.shuffle(answers);
        return new List<string>(answers);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
