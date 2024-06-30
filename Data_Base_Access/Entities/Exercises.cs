using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Base_Access.Entities
{
    public class Exercises
    {
        public int Id { get; set; }
        public string Ex_Name { get; set; }

        public ICollection<ExercisesLog> ExerciseLogs { get; set; } = null!;

    }
}
