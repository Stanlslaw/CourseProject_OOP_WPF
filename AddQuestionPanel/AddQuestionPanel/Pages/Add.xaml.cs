using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using AddQuestionPanel.Models;
using AddQuestionPanel.ViewModel;
using Microsoft.Win32;

namespace AddQuestionPanel.Pages;

public partial class Add : Page
{
    public List<Topic> Topics;
    public string QuestionImagePath { get; set; } = null;
    public string QuestionImageLocalPath { get; set; } = null;
    public MainViewModel Context;
    public Add(MainViewModel context)
    {
        
        InitializeComponent();
        Context = context;
        Topics = context.GetTopics();
        FillTopicsBox(Topics);
    }

    public void FillTopicsBox(List<Topic> topics)
    {
        foreach (var topic in topics)
        {
            ComboBoxItem cmbItem = new ComboBoxItem();
            cmbItem.Content = topic.TopicName;
            TopicsBox.Items.Add(cmbItem);
        }
    }

    public long GetTopicId()
    {
       string selectedItemText = ((ComboBoxItem)TopicsBox.SelectedItem).Content.ToString();
       Topic selectedTopic = Topics.Find((i) => i.TopicName == selectedItemText);
       return selectedTopic.Id;
    }
    public string GetQuestionText()
    {
      return QuestionText.Text;
    }

    public string GetQuestionImage()
    {
        return QuestionImageLocalPath;
    }

    public string GetDescText()
    {
        return DescText.Text;
    }
    public string GetDescHeader()
    {
        return DescHeader.Text;
    }

    public List<Answer> GetAnswers()
    {
        List<Answer> answers = new();
        answers.Add(new Answer(){AnswerText = ((TextBox)AnswersBox.Children[0]).Text,IsCorrect = 1});
        answers.Add(new Answer(){AnswerText = ((TextBox)AnswersBox.Children[1]).Text,IsCorrect = 0});
        answers.Add(new Answer(){AnswerText = ((TextBox)AnswersBox.Children[2]).Text,IsCorrect = 0});
        answers.Add(new Answer(){AnswerText = ((TextBox)AnswersBox.Children[3]).Text,IsCorrect = 0});
        return answers;
    }
    public void onGetImagePath(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "JPEG Files (*.jpg)|*.jpg|All Files (*.*)|*.*";
        openFileDialog.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");

        if (openFileDialog.ShowDialog() == true)
        {
          QuestionImagePath = openFileDialog.FileName;
          QuestionImageLocalPath ="\\Images\\"+Path.GetFileName(QuestionImagePath);
        }

        QuestionImage.Source = new BitmapImage(new Uri(QuestionImagePath));
    }

    public void onAddQuestion(object sender, EventArgs e)
    {
        Context.AddQuestion();
    }
}