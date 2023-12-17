using System;
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

    private PddContext db;
    
    public MainViewModel()
    {
        Home = new HomePage();
        Exit = new ExitPage();
        About = new AboutPage();
        CurrentPage = Home;
        db = new PddContext();
    }

    public List<QuestionData> GetQuestionsForTest()
    {
       List<QuestionData> qdList= new ();
       List<Question> questions=  db.Questions.FromSqlRaw("SELECT * FROM Questions ORDER BY RANDOM()").Take(10).ToList();
       foreach (var question in questions)
       {
           QuestionData qd = new();
           qd.Question = question;
           qd.questionDescription = db.QuestionDescriptions.FirstOrDefault(q => q.QuestionId == qd.Question.Id);
           qd.asnwers = db.Answers.Where((a) => a.QuestionId == qd.Question.Id).ToList();
           qdList.Add(qd);
       }
       return (qdList);
    }
}