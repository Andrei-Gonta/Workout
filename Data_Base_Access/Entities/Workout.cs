using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Base_Access.Entities
{
    public class Workout
    {
        public int Id { get; set; }

        public int CientID { get; set; }

        public int Duration { get; set; }

        public DateTime Date { get; set; }

        public Users User { get; set; } = null;

        public ICollection<ExercisesLog> ExercisesLog { get; set; } = null!;

    }
}
