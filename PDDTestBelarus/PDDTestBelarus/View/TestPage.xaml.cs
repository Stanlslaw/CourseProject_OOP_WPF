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
    public TestPage(MainViewModel context)
    {
        InitializeComponent();
        Context = context;
        results = new List<QuestionData>();
        questions= context.GetQuestionsForTest();
        question = new Question(questions[0],questions[0].asnwers);
        bottomTestHint = new BottomTestHint();
        numPanel = new TopQuestionNumPanel(10);
        TimerContainer.Children.Add(new TicketTime(true,onTimeIsGone));
        QuestionContainer.Children.Add(question);
        BottomTestHintContainer.Children.Add(bottomTestHint);
        NumPanelContainer.Children.Add(numPanel);
       
    }

    public void onTimeIsGone()
    {
        Context.CurrentPage = new ResultPage(results);
    }

    public void GoToNextQuestion()
    {
        question = new Question(questions[currentQuestionNum],questions[currentQuestionNum].asnwers);
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
    }

   
    public void GoToResultPage()
    {
        results = results.Distinct().ToList();
        Context.CurrentPage = new ResultPage(results);
    }
}