using System;
using System.Collections.Generic;

namespace WpfApp3;

public partial class Progress
{
    public int Id { get; set; }

    public int? Grade { get; set; }

    public string? Comment { get; set; }

    public int? IdAthlet { get; set; }

    public int? IdWorkout { get; set; }
}
