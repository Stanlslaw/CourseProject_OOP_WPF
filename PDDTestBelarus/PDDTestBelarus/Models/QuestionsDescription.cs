using System;
using System.Collections.Generic;

namespace PDDTestBelarus.Models;

public partial class QuestionsDescription
{
    public long Id { get; set; }

    public long QuestionId { get; set; }

    public string? HeaderText { get; set; }

    public string? BodyText { get; set; }
}
