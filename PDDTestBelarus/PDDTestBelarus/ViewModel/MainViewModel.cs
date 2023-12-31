﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PDDTestBelarus.Models;
using PDDTestBelarus.View;

namespace PDDTestBelarus.ViewModel;

public class MainViewModel:ViewModelBase
{

    public Page Home;
    public Page Exit;
    public Page About;
    public Page Test;
    public Page Result;
    public Page _currentPage;

    public Page CurrentPage
    {
        get
        {
            return _currentPage;
        }
        set
        {
            _currentPage = value;
        }
    }

    public PddContext db;
    
    public MainViewModel()
    {
        Home = new HomePage(this);
        Exit = new ExitPage();
        About = new AboutPage();
        CurrentPage = Home;
        db = new PddContext();
    }

    public List<QuestionData> GetQuestionsForTest(int topicId)
    {
       List<QuestionData> qdList= new ();
       List<Question> questions=  db.Questions.FromSqlRaw($"SELECT * FROM Questions where TopicId={topicId} ORDER BY RANDOM()").Take(10).ToList();
       foreach (var question in questions)
       {
           QuestionData qd = new();
           qd.Question = new Question(){Id=question.Id,Image = question.Image,QuestionText = RSAEncryption.Decrypt(question.QuestionText),TopicId = question.TopicId};
           qd.questionDescription = db.QuestionDescriptions.FirstOrDefault(q => q.QuestionId == qd.Question.Id);
           qd.asnwers = db.Answers.Where((a) => a.QuestionId == qd.Question.Id).ToList();
           qdList.Add(qd);
       }
       return (qdList);
    }
    public List<QuestionData> GetRandomQuestionsForTest()
    {
        List<QuestionData> qdList= new ();
        List<Question> questions=  db.Questions.FromSqlRaw($"SELECT * FROM Questions ORDER BY RANDOM()").Take(10).ToList();
        foreach (var question in questions)
        {
            QuestionData qd = new();
            qd.Question = new Question(){Id=question.Id,Image = question.Image,QuestionText = RSAEncryption.Decrypt(question.QuestionText),TopicId = question.TopicId};
            qd.questionDescription = db.QuestionDescriptions.FirstOrDefault(q => q.QuestionId == qd.Question.Id);
            qd.asnwers = db.Answers.Where((a) => a.QuestionId == qd.Question.Id).ToList();
            qdList.Add(qd);
        }
        return (qdList);
    }
}