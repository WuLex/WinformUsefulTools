using ClickAutomation.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickAutomation.Models
{
    internal struct MakeAction
    {
        public ActionType Type { get; set; }
        public Point? Pos { get; set; }
        public int? Index { get; set; }
        public int? Tag { get; set; }
        public int? Times { get; set; }
    }
}
