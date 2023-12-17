using System;
using System.Collections.Generic;

namespace PDDTestBelarus.Models;

public partial class Question
{
    public long Id { get; set; }

    public long TopicId { get; set; }

    public string QuestionText { get; set; } = null!;

    public string? Image { get; set; }
}
