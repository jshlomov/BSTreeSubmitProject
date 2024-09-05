using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BSTreeSubmitProject.Models
{
    internal class Threat
    {
        public string ThreatType { get; set; }
        public int Volume { get; set; }
        public int Sophistication { get; set; }
        public string Target { get; set; }

        public override string ToString()
        {
            return string.Join(", ", [ThreatType, Volume, Sophistication, Target]);
        }
    }
}
