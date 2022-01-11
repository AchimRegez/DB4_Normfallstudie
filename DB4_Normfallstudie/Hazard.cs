using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB4_Normfallstudie
{
    internal class Hazard
    {
        public int Id { get; set; }
        public string? Substance { get; set; }
        public int Severity { get; set; }
    }
}
