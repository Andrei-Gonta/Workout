using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Base_Access.Entities
{
    public class ExercisesLog
    {
        public int Id_Workout { get; set; }
        public int Id_Exercice { get; set; }
        public double? Weight { get; set; }
        public int? Sets { get; set; }
        public int? Reps { get; set; }

        public double? Time_Session { get; set; }

        public double? Distance {  get; set; }

        public Exercises Exercise;
        public Workout Workout;

    }
}
