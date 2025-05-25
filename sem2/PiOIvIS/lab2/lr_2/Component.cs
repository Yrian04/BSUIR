using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;

namespace lr_2
{
    public class Component : ICloneable
    {
        public Component(object exemplar, int multiplicity)
        {
            Exemplar = exemplar;
            Multiplicity = multiplicity;
        }

        public object Exemplar { get; init; }

        int multiplicity;
        public int Multiplicity
        {
            get
            {
                return multiplicity;
            }
            set
            {
                multiplicity = value < 0 ? 0 : value;
            }
        }

        public static Component operator +(Component component1, Component component2)
        {
            if (!component1.Exemplar.Equals(component2.Exemplar))
                throw new Exception();
            return new Component(component1.Exemplar, component1.Multiplicity + component2.Multiplicity);
        }

        public static Component operator -(Component component1, Component component2)
        {   
            if (!component1.Exemplar.Equals(component2.Exemplar))
                throw new Exception();
            return new Component(component1.Exemplar, component1 > component2 ? component1.Multiplicity - component2.Multiplicity : 0);
        }

        public static bool operator >(Component component1, Component component2)
        {
            return component1.Multiplicity > component2.Multiplicity;
        }
        public static bool operator <(Component component1, Component component2)
        {
            return component1.Multiplicity < component2.Multiplicity;
        }

        public static bool operator ==(Component component1, Component component2)
        {
            return component1.Exemplar.Equals(component2.Exemplar) && component1.Multiplicity == component2.Multiplicity;
        }
        public static bool operator !=(Component component1, Component component2)
        {
            return !(component1 == component2);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Component)
                return (Component)obj == this;
            if (obj is null) 
                return multiplicity == 0;
            return false;
        }

        public override string ToString()
        {
            return "<" + Exemplar.ToString() + "," + Multiplicity.ToString() + ">";
        }

        public object Clone()
        {
            return new Component(Exemplar, Multiplicity);
        }
    }
}
