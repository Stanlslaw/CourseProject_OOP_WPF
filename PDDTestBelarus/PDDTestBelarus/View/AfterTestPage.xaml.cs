using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using PDDTestBelarus.Models;
using PDDTestBelarus.View.UserControls;
using PDDTestBelarus.ViewModel;
using Question = PDDTestBelarus.View.UserControls.Question;

namespace PDDTestBelarus.View;

public partial class AfterTestPage : Page
{
    public BottomTestHint bottomTestHint;
    public TopQuestionNumPanel numPanel;
    public ResultPage Caller;
    public PddContext db;
    public Question questionControl;
    public QuestionDescription questionDescription;
    public bool isPopupOpen = false;
    public AfterTestPage(MainViewModel context,ResultPage caller,List<int> userAnswers)
    {
        InitializeComponent();
        db = context.db;
        bottomTestHint = new BottomTestHint();
        bottomTestHint.ShowHowOpen();
        numPanel = new TopQuestionNumPanel(10,caller.results,caller.SelectedItem);
        Caller = caller;
        NumPanelContainer.Children.Add(numPanel);
        BottomTestHintContainer.Children.Add(bottomTestHint);
        questionControl = new Question
            (caller.results[caller.SelectedItem],
                caller.results[caller.SelectedItem].asnwers,
                userAnswers,
                shuffle:false);
        questionDescription =
            db.QuestionDescriptions.FirstOrDefault(el =>
                el.QuestionId == caller.results[caller.SelectedItem].Question.Id);
        questionControl.SetAnswersColorAfterTest(caller.results[caller.SelectedItem].asnwers,caller.userAnswers[caller.SelectedItem]);
        PopupHeader.Text = questionDescription.HeaderText;
        PopupBody.Text = questionDescription.BodyText;
        questionControl.AnswerNumTB.Text = userAnswers[caller.SelectedItem].ToString();
        QuestionContainer.Children.Add(questionControl);
    }

    public void OpenClosePopup(KeyEventArgs e)
    {
      
        isPopupOpen = !isPopupOpen;
        if (e.Key == Key.Escape)
        {
            isPopupOpen = false;
        }

        if (isPopupOpen)
        {
            bottomTestHint.ShowHowClose();
        }
        else
        {
            bottomTestHint.ShowHowOpen();
        }
        HintPopup.IsOpen = isPopupOpen;
    }
}