using System;
using System.Collections.Generic;

namespace Sports;

public partial class Workout
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public DateTime? Datetime { get; set; }

    public int? Duration { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Participation> Participations { get; set; } = new List<Participation>();

    public virtual ICollection<Progress> Progresses { get; set; } = new List<Progress>();
}
