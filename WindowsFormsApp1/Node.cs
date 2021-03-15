using System;

namespace WindowsFormsApp1
{
    public class Node
    {
        public int G, H;
        public int[] coordonates;
        public Node parent;

        public Node(int[] coordonates)
        {
            this.coordonates = coordonates;
        }
        public Node(int[] coordonates, Node parent)
        {
            this.coordonates = coordonates;
        }

        public int getScoreF()
        {
            return G + H;
        }

        internal void CalculateHFromNode(Node start)
        {
            throw new NotImplementedException();
        }
    }
}