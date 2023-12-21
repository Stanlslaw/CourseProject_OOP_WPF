using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents;
using PDDTestBelarus.Models;
using PDDTestBelarus.View.UserControls;
using PDDTestBelarus.ViewModel;
using Question = PDDTestBelarus.View.UserControls.Question;

namespace PDDTestBelarus.View;

public partial class TestPage : Page
{
    private MainViewModel Context;
    public Question question;
    public BottomTestHint bottomTestHint;
    public TopQuestionNumPanel numPanel;
    public int currentQuestionNum=1;
    public List<QuestionData> questions;
    public List<QuestionData> results;
    public TicketTime ticketTime;
    public int elapsedTime;
    public List<int> userAnswers = new List<int>();
    public TestPage(MainViewModel context,int topicId)
    {
        InitializeComponent();
        Context = context;
        results = new List<QuestionData>();
        if (topicId > 0)
        {
            questions= context.GetQuestionsForTest(topicId);
        }
        else
        {
            questions= context.GetRandomQuestionsForTest();
        }
       
        question = new Question(questions[0],questions[0].asnwers,userAnswers);
        bottomTestHint = new BottomTestHint();
        numPanel = new TopQuestionNumPanel(10);
        ticketTime = new TicketTime(true, onTimeIsGone);
        TimerContainer.Children.Add(ticketTime);
        QuestionContainer.Children.Add(question);
        BottomTestHintContainer.Children.Add(bottomTestHint);
        NumPanelContainer.Children.Add(numPanel);
       
    }

    public void onTimeIsGone()
    {
        results = results.Distinct().ToList();
        userAnswers.Add(question.currentAnswer??-1);
        Context.CurrentPage = new ResultPage(results,ticketTime.elapsedTime,userAnswers);
    }

    public void GoToNextQuestion()
    {
        question = new Question(questions[currentQuestionNum],questions[currentQuestionNum].asnwers,userAnswers);
        QuestionContainer.Children.RemoveAt(0);
        QuestionContainer.Children.Add(question);
        bottomTestHint.ShowHowGiveAnswer();
        currentQuestionNum++;
    }

    public void ShowFastResults()
    {
        results = results.Distinct().ToList();
        QuestionContainer.Children.Clear();
        QuestionContainer.Children.Add(new FastResult(results));
        elapsedTime = ticketTime.StopTimer();
    }

   
    public void GoToResultPage()
    {
        results = results.Distinct().ToList();
        Context.CurrentPage = new ResultPage(results,elapsedTime,userAnswers);
    }
}