using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphLibrary
{
    public abstract class Graph : IGraph
    {
        public int Number { get; set; }

        public Graph()
        {
            Number = 0;
        }

        public Graph(int n)
        {
            Number = n;
        }

        public abstract string inf();
    }

    public class Top : Graph
    {
        public Top(int number) : base(number)  
        {
        }

        public override string inf()
        {
            return $"Top {Number} is here";
        }
    }


    public class Arc : Graph
    {
        public int Start { get; set; }
        public int End { get; set; }

        public Arc(int n, int s, int e)
        {
            Number = n;
            Start = s;
            End = e;
        }

        public override string inf()
        {
            return $"Arc {Number} is here, start top is {Start}, end top is {End}";
        }
    }

    public class Container : IContainer
    {
        private List<Graph> elements;

        public Container()
        {
            elements = new List<Graph>();
        }

        public void Add(Graph element)
        {
            elements.Add(element);
        }

        public void Remove(Graph element)
        {
            if (element is Top top)
            {
                elements.RemoveAll(e => e is Arc arc &&
                    (arc.Start == top.Number || arc.End == top.Number));
            }
            elements.Remove(element);
        }

        public List<Graph> GetAll()
        {
            return elements;
        }
        public Graph FindNumber(int number)
        {
            return elements.FirstOrDefault(e => e.Number == number);
        }
        public int Counttop()
        {
            return elements.OfType<Top>().Count();
        }

        public int GetAdjacentArcCount(int topNumber)
        {
            return elements.OfType<Arc>().Count(arc => arc.Start == topNumber || arc.End == topNumber);
        }
    }
}
