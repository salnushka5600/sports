using System;
using System.Collections.Generic;

namespace WpfApp3;

public partial class Workout
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public DateTime? Datetime { get; set; }

    public int? Duration { get; set; }

    public string? Type { get; set; }
}
