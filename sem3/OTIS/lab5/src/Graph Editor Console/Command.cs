using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Editor_Console
{
    internal abstract class Command
    {
        public abstract string Name { get; }
        public abstract string[] Help { get; } 
        abstract public void Execute(params string[] args);
        abstract public bool CanExecute();
    }
}
