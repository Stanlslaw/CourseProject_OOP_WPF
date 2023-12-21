using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AddQuestionPanel.Models;
using AddQuestionPanel.Pages;
using Microsoft.EntityFrameworkCore;

namespace AddQuestionPanel.ViewModel;

public class MainViewModel
{
    public Page Page { get; set; }
    public PddContext db;

    public MainViewModel()
    {
        db = new PddContext();
        Page = new Add(this);
    }

    public List<Topic> GetTopics()
    {
        return db.Topics.ToList();
    }

    public long GetNewId()
    {
        return db.Questions.Count() + 1;
    }


    public void AddQuestion()
    {
        long id = GetNewId();  
      Add page = (Add)Page;
      Question question = new Question()
      {
          Id = id,
          TopicId = page.GetTopicId(),
          QuestionText = RSAEncryption.Encrypt(page.GetQuestionText()),
          Image = page.GetQuestionImage()
      };
      List<Answer> answers = page.GetAnswers();
      QuestionDescription desc= new QuestionDescription()
      {
          Id = id,
          QuestionId =id,
          BodyText = page.GetDescText(),
          HeaderText = page.GetDescHeader()
      };
      db.Questions.Add(question);
      db.QuestionDescriptions.Add(desc);
      foreach (var answer in answers)
      {
          answer.QuestionId = id;
          db.Answers.Add(answer);
      }

      db.SaveChanges();
      MessageBox.Show("Вопрос Добавлен");
    }
}