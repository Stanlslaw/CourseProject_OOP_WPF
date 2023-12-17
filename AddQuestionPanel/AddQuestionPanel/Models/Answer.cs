using System;
using System.Collections.Generic;

namespace AddQuestionPanel.Models;

public partial class Answer
{
    public long Id { get; set; }

    public long QuestionId { get; set; }

    public string AnswerText { get; set; } = null!;

    public long IsCorrect { get; set; }
}
