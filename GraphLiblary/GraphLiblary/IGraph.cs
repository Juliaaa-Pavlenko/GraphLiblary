using System.Collections.Generic;

namespace GraphLibrary
{
    public interface IGraph
    {
        int Number { get; set; }
        string inf(); 
    }

    public interface IContainer
    {
        void Add(Graph element);
        void Remove(Graph element);
        List<Graph> GetAll();
        Graph FindNumber(int number);
        int Counttop();
        int GetAdjacentArcCount(int vertexNumber);
    }
}
