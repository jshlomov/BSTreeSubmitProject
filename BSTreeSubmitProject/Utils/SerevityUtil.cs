using BSTreeSubmitProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTreeSubmitProject.Utils
{
    internal static class SerevityUtil
    {
        public static int CalculateSeverity(Threat threat)
        {
            int TransformTargetValue = threat.Target switch
            {
                "Web Server" => 10,
                "Database" => 15,
                "User Credentials" => 20,
                _ => 5
            };

            return threat.Volume * threat.Sophistication + TransformTargetValue;
        }

    }
}
