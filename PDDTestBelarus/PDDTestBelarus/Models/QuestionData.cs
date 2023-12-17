using System.Collections.Generic;
using System.Windows.Documents;

namespace PDDTestBelarus.Models;

public class QuestionData
{
    public Question Question { get; set; }
    public List<Answer> asnwers { get; set; }
    public QuestionDescription questionDescription { get; set; }
}