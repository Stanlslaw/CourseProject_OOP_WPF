using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PDDTestBelarus.Models;
using PDDTestBelarus.View;
using PDDTestBelarus.View.UserControls;
using PDDTestBelarus.ViewModel;

namespace PDDTestBelarus
{
    public class InputHandler
    {
        private MainViewModel Context;
        private bool goToNextQuestionFlag = false;
        private bool stopTest = false;
        private bool showFastResult = false;
        public InputHandler(MainViewModel context)
        {
            Context=context;
        }

        public void MainInputHandler(object sender, KeyEventArgs e)
        {
            string pageName = Context.CurrentPage.Name;
            switch (pageName)
            {
                case "HomePageView":
                {
                    HomePageHandler(sender,e);
                    break;
                }
                case "ExitPageView":
                {
                    ExitPageHandler(sender, e);
                    break;
                }
                case "AboutPageView":
                {
                    Context.CurrentPage = Context.Home;
                    break;
                }
                case "TestPageView":
                {
                    TestPageHandler(sender,e);
                    break;
                }
                case "ResultPageView":
                {
                    ResultPageHandler(sender,e);
                    break;
                }
                default: return;
            }
        }

        public void HomePageHandler(object sender, KeyEventArgs e)
        {
            HomePage page = (HomePage)Context.CurrentPage;
            switch (e.Key)
            {
                case Key.Escape:
                {
                    Context.CurrentPage = Context.Exit;
                    break;
                }
                case Key.Up:
                {
                    page.OnArrowUpDown(sender, e);
                        break;
                }
                case Key.Down:
                {
                    page.OnArrowUpDown(sender, e);
                        break;
                }
                case Key.Z:
                {
                    Context.CurrentPage=Context.About;
                    break;
                }
                case Key.Enter:
                {
                    if (page.SelectedItem == 0)
                    {
                        Context.CurrentPage = new TestPage(Context);
                    }
                    break;
                }
            }
        }
        public void ExitPageHandler(object sender, KeyEventArgs e)
        {
            ExitPage page = (ExitPage)Context.CurrentPage;
            switch (e.Key)
            {
                case Key.Escape:
                {
                    
                    break;
                }
                case Key.Up:
                {
                    page.OnArrowUpDown(sender, e);
                    break;
                }
                case Key.Down:
                {
                    page.OnArrowUpDown(sender, e);
                    break;
                }
                case Key.Enter:
                {
                    if (page.SelectedItem == 0)
                    {
                        Application.Current.Shutdown();
                    }
                    else
                    {
                        Context.CurrentPage=Context.Home;
                    }
                    break;
                }
            }
        }

        public void TestPageHandler(object sender, KeyEventArgs e)
        {
            TestPage page = (TestPage)Context.CurrentPage;
            switch (e.Key)
            {
                case Key.Escape:
                {
                    Context.CurrentPage = Context.Home;
                    break;
                }
                case Key.D1:
                {
                    page.question.SetAnswer(1,goToNextQuestionFlag);
                    break;
                }
                case Key.D2:
                {
                    page.question.SetAnswer(2,goToNextQuestionFlag);
                    break;
                }
                case Key.D3:
                {
                    page.question.SetAnswer(3,goToNextQuestionFlag);
                    break;
                }
                case Key.D4:
                {
                    page.question.SetAnswer(4,goToNextQuestionFlag);
                    break;
                }
                case Key.Back:
                {
                    page.question.ResetAnswer();
                    page.bottomTestHint.ShowHowGiveAnswer();
                    break;
                }
                case Key.Enter:
                {
                    bool? isRight = page.question.IsRightAnswer();
                    if ( isRight== null)
                    {
                        page.bottomTestHint.ShowHowGiveAnswer();
                    }
                    else
                    {
                       page.numPanel.ChangeColor(page.currentQuestionNum,isRight??false);
                       QuestionData currentQuestion = page.questions[page.currentQuestionNum-1];
                       if (isRight??false)
                       {
                           currentQuestion.result = true;
                           page.results.Add(currentQuestion);
                       }
                       else
                       {
                           currentQuestion.result = false;
                           page.results.Add(currentQuestion);
                       }
                       if (page.currentQuestionNum >= 10)
                       {
                           if (showFastResult)
                           {
                               page.ShowFastResults();
                               if (stopTest)
                               {
                                   page.GoToResultPage();
                                   stopTest = !stopTest;
                                   showFastResult = !showFastResult;
                                   break;
                               }
                               stopTest = !stopTest;
                               break;
                           }

                           showFastResult = !showFastResult;
                           break;
                       }

                    
                       if (goToNextQuestionFlag)
                       {
                          
                           page.GoToNextQuestion();
                           goToNextQuestionFlag = false;
                           break;
                       }
                       

                       goToNextQuestionFlag = true;
                    }
                    break;
                }
            }
        }

        public void ResultPageHandler(object sender, KeyEventArgs e)
        {
            ResultPage page = (ResultPage)Context.CurrentPage;
            switch (e.Key)
            {
                case Key.Up:
                {
                    page.OnArrowUpDown(sender,e);
                    break;
                }
                case Key.Down:
                {
                    page.OnArrowUpDown(sender,e);
                    break;
                }
                case Key.Escape:
                {
                    Context.CurrentPage = Context.Home;
                    break;
                }
            }
        }
        
    }
}
