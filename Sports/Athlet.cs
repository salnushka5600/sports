using System;
using System.Collections.Generic;

namespace Sports;

public partial class Athlet
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Lastname { get; set; }

    public DateOnly? Birthday { get; set; }

    public string? Category { get; set; }

    public string? Level { get; set; }

    public virtual ICollection<Participation> Participations { get; set; } = new List<Participation>();

    public virtual ICollection<Progress> Progresses { get; set; } = new List<Progress>();
}
