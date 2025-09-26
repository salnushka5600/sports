using System;
using System.Collections.Generic;

namespace Sports;

public partial class Participation
{
    public int Id { get; set; }

    public int IdAthlet { get; set; }

    public int IdWorkout { get; set; }

    public virtual Athlet IdAthletNavigation { get; set; } = null!;

    public virtual Workout IdWorkoutNavigation { get; set; } = null!;
}
