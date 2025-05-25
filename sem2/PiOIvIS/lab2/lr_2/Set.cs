using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr_2
{
    public class Set : IEnumerable, ICloneable
    {
        public List<Component> Components { get; }

        public Set()
        {
            Components = new List<Component>();
        }

        public Set(params (object, int)[] components)
        {
            Components = new List<Component>();
            foreach ((object Exempalar, int Multiplicity) component in components)
            {
                Components.Add(new Component(component.Exempalar, component.Multiplicity));
            }
        }

        public void Add(Component component)
        {
            Component comp = Components.Find(element => element.Exemplar.Equals(component.Exemplar));
            if (comp is null)
            {
                Components.Add(component);
            }
            else
            {
                comp += component;
            }
        }
        public void Remove(Component component)
        {
            Component comp = Components.Find(element => element.Exemplar.Equals(component.Exemplar));
            if (comp is not null)
            {
                comp -= component;
            }
        }

        public static Set Disjunction(Set set1, Set set2)
        {
            Set disjunction = (Set)set1.Clone();
            foreach (Component component in set2)
            {
                Component element = disjunction.Components.Find(e => e.Exemplar.Equals(component.Exemplar));
                if (element is not null)
                {
                    element.Multiplicity = component > element ? component.Multiplicity : element.Multiplicity;
                }
                else
                    disjunction.Add(component);
            }
            return disjunction;
        }

        public static Set Difference(Set set1, Set set2)
        {
            Set difference = new();
            foreach (Component component in set1)
            {
                Component element = set2.Components.Find(e => e.Exemplar.Equals(component.Exemplar));
                if (element is not null)
                {
                    difference.Add(component - element);
                }
                else
                    difference.Add(component);
            }
            return difference;
        }

        public static Set GetFromString(string str)
        {
            Set set = new();
            str = str.Trim(new char[] { '{', '}' });
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '<')
                {
                    i++;
                    string multiplicity = "";
                    string exemplar = "";
                    while (str[i] != ',')
                    {
                        multiplicity += str[i];
                        i++;
                    }
                    i++;
                    while (str[i] != '>')
                    {
                        if (str[i] == '{')
                        {
                            string str1 = "";
                            do
                            {
                                str1 += str[i++];
                            } while (str[i] != '}');
                            str1 += str[i++];
                            set.Add(new Component(GetFromString(str1), Convert.ToInt32(multiplicity)));
                            continue;
                        }
                        else
                        {
                            exemplar += str[i];
                            i++;
                        }
                    }
                    if (exemplar != "")
                        set.Add(new Component(exemplar, Convert.ToInt32(multiplicity)));
                }
            }
            return set;
        }

        public static Set SymmetricDifference(Set set1, Set set2)
        {
            return Disjunction(Difference(set1, set2), Difference(set2, set1));
        }

        public static Set SymmetricDifference(Set set, params Set[] sets)
        {
            Set symmetric_difference = set;
            foreach(Set set2 in sets)
                symmetric_difference = SymmetricDifference(symmetric_difference, set2);
            return symmetric_difference;
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)Components).GetEnumerator();
        }

        public object Clone()
        {
            Set clone = new();
            foreach (Component component in Components)
            {
                clone.Add((Component)component.Clone());
            }
            return clone;
        }

        public override string ToString()
        {
            string str = "{";
            foreach (Component component in Components)
            {
                str += component.ToString() + ",";
            }
            str = str.TrimEnd(',') + "}";
            return str;
        }

        public override bool Equals(object? obj)
        {
            if(obj is Set)
            {
                Set set = (Set)obj;
                foreach(Component component in Components)
                {
                    Component comp = set.Components.Find(c => c.Exemplar.Equals(component.Exemplar));
                    if (comp is null)
                        if (component.Multiplicity != 0)
                            return false;
                        else
                            continue;
                    if (comp != component)
                        return false;
                }
                foreach (Component component in set.Components)
                {
                    Component comp = Components.Find(c => c.Exemplar.Equals(component.Exemplar));
                    if (comp is null)
                        if (component.Multiplicity != 0)
                            return false;
                        else
                            continue;
                    if (comp != component)
                        return false;
                }
                return true;
            }
            return false;
        }
    }
}
