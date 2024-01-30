using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Node
    {
        public string Name { get; set; }
        public List<Vertices> Vertices { get; set; }
    }

    public class Vertices
    {

        public Node StartNode { get; set; }
        public Node EndNode { get; set; }
        public int Distance { get; set; }
    }

    public class GraphExample
    {
        private Node CurrentPlanet { get; set; }
        private Node Planet1 = new Node() { Name = "Planet1" };
        private Node Planet2 = new Node() { Name = "Planet2" };
        private Node Planet3 = new Node() { Name = "Planet3" };
        private Node Planet4 = new Node() { Name = "Planet4" };

        public GraphExample()
        {
            Planet1.Vertices = new List<Vertices>() {
                new Vertices()
                {
                    StartNode = Planet1,
                    EndNode = Planet2
                },
                new Vertices()
                {
                    StartNode= Planet1,
                    EndNode = Planet3
                },
            };

            Planet2.Vertices = new List<Vertices>() {
                new Vertices()
                {
                    StartNode = Planet2,
                    EndNode = Planet3
                },
                new Vertices()
                {
                    StartNode= Planet2,
                    EndNode = Planet1
                },
            };

            Planet3.Vertices = new List<Vertices>() {
                new Vertices()
                {
                    StartNode = Planet3,
                    EndNode = Planet2
                },
                new Vertices()
                {
                    StartNode = Planet3,
                    EndNode = Planet1
                },
                new Vertices()
                {
                    StartNode = Planet3,
                    EndNode = Planet4
                },
            };
            Planet4.Vertices = new List<Vertices>() {
                new Vertices()
                {
                    StartNode= Planet4,
                    EndNode = Planet3
                },
            };
        }

        public void StartGame()
        {
            CurrentPlanet = Planet1;
        }

        public void GetDestinations()
        {
            Console.WriteLine($"Hei, tu atrodies uz {CurrentPlanet.Name}");

            Console.WriteLine("Tev pieejamās planētas");
            foreach (var vertice in CurrentPlanet.Vertices)
            {
                Console.WriteLine(vertice.EndNode.Name);
            }
        }

        public void GoTo(string v)
        {
            CurrentPlanet = CurrentPlanet.Vertices
                .First(x => x.EndNode.Name == v).EndNode;
        }
    }
}
