using System.Collections.Generic;
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
    public TestPage(MainViewModel context)
    {
        InitializeComponent();
        Context = context;
        questions= context.GetQuestionsForTest();
        question = new Question(questions[0].Question.QuestionText,questions[0].asnwers,questions[0].Question.Image);
        bottomTestHint = new BottomTestHint();
        numPanel = new TopQuestionNumPanel(10);
        TimerContainer.Children.Add(new TicketTime(true,onTimeIsGone));
        QuestionContainer.Children.Add(question);
        BottomTestHintContainer.Children.Add(bottomTestHint);
        NumPanelContainer.Children.Add(numPanel);
       
    }

    public void onTimeIsGone()
    {
        Context.CurrentPage = new ResultPage();
    }

    public void GoToNextQuestion()
    {
        question = new Question(
            questions[currentQuestionNum].Question.QuestionText,
            questions[currentQuestionNum].asnwers,
            questions[currentQuestionNum].Question.Image);
        QuestionContainer.Children.RemoveAt(0);
        QuestionContainer.Children.Add(question);
        bottomTestHint.ShowHowGiveAnswer();
        currentQuestionNum++;
    }
    
}