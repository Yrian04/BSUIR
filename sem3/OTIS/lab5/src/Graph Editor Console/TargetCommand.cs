using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Editor_Console
{
    internal abstract class TargetCommand<T> : Command
    {
        public T Target { get; set; }
    }
}
