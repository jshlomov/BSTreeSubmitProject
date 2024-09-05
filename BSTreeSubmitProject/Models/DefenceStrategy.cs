using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BSTreeSubmitProject.Models
{
    internal class DefenceStrategy :IComparable<DefenceStrategy>
    {
        public int MinSeverity { get; set; }
        public int MaxSeverity { get; set; }
        public List<string> Defenses { get; set; }

        public int CompareTo(DefenceStrategy? other)
        {
            return MinSeverity - other.MinSeverity;
        }

        public override bool Equals(object? obj)
        {
            return obj is DefenceStrategy strategy &&
                   MinSeverity == strategy.MinSeverity &&
                   MaxSeverity == strategy.MaxSeverity;
        }

        public override string ToString()
        {
            return $"[{MinSeverity}-{MaxSeverity}] Defences:{string.Join(",",Defenses)}";
        }


    }
}
