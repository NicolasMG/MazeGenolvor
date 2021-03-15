using System;
using System.Collections.Generic;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1
{
    internal class PathfindingSolver
    {
        private Maze maze;

        public List<Node> solution;

        private Node start;
        private Node end;


        internal void solve(string TypePathfinding, Maze mazeG)
        {
            this.maze = mazeG;
            maze.CacherAcces();
            solution = new List<Node>();

            int[] positionStart = { 0, 0 };
            start = new Node(positionStart);
            start.H = 0;
            int[] positionEnd = { maze.hauteur - 1, maze.longueur - 1 };
            end = new Node(positionEnd);

            switch (TypePathfinding)
            {
                case "A Star":
                    SolveAStar();
                    break;
                    /*
                     * ...
                     * 
                     */
                default:
                    SolveAStar();
                    break;
            }


            maze.CreerAcces();
        }

        private bool SolveAStar()
        {
            List<Node> openSet = new List<Node>();
            List<Node> closedSet = new List<Node>();
            openSet.Add(start);

            while (openSet.Count > 0)
            {
                Node currentNode = openSet[0];
                foreach (Node node in openSet)
                {
                    if (node.getScoreF() <= currentNode.getScoreF())
                    {
                        currentNode = node;
                    }
                }

                if(currentNode.coordonates[0] == end.coordonates[0] && currentNode.coordonates[1] == end.coordonates[1])
                {
                    BuildPath(currentNode);
                    return true;
                }

                closedSet.Add(currentNode);
                openSet.Remove(currentNode);
                
                bool[] murVoisin = maze.cells[currentNode.coordonates[0], currentNode.coordonates[1]].mur;
                for (int i = 0; i< 4; i++)
                {
                    if (murVoisin[i])
                    {
                        int[] positionVoisin = new int[2];
                        switch (i)
                        {
                            case 0:
                                positionVoisin[0] = currentNode.coordonates[0];
                                positionVoisin[1] = currentNode.coordonates[1]-1;
                                break;
                            case 1:
                                positionVoisin[0] = currentNode.coordonates[0]+1;
                                positionVoisin[1] = currentNode.coordonates[1];
                                break;
                            case 2:
                                positionVoisin[0] = currentNode.coordonates[0];
                                positionVoisin[1] = currentNode.coordonates[1]+1;
                                break;
                            case 3:
                                positionVoisin[0] = currentNode.coordonates[0]-1;
                                positionVoisin[1] = currentNode.coordonates[1];
                                break;
                        }
                        if (NodeNotInBound(positionVoisin))
                        {
                            continue;
                        }
                        Node nouveauVoisin = new Node(positionVoisin);
                        if (FindNodeInSet(closedSet, nouveauVoisin) != null)
                        {
                            continue;
                        }

                        nouveauVoisin.G = currentNode.G + 1;
                        Node VoisinInOpenSet = FindNodeInSet(openSet, nouveauVoisin);

                        if (VoisinInOpenSet == null)
                        {
                            VoisinInOpenSet = new Node(positionVoisin, currentNode);
                            VoisinInOpenSet.G = nouveauVoisin.G;
                            VoisinInOpenSet.H = DistanceH(VoisinInOpenSet,end);
                            VoisinInOpenSet.parent = currentNode;
                            openSet.Add(VoisinInOpenSet);
                        }
                        else
                        {
                            if (nouveauVoisin.G < VoisinInOpenSet.G)
                            {
                                VoisinInOpenSet.parent = currentNode;
                                VoisinInOpenSet.G = nouveauVoisin.G;
                            }
                        }
                    }
                }

            }
            return false;
        }

        private void BuildPath(Node currentNode)
        {
            solution.Add(end);
            while (currentNode != start)
            {
                solution.Add(currentNode.parent);
                currentNode = currentNode.parent;
            }
        }

        private bool NodeNotInBound(int[] positionVoisin)
        {
            if (positionVoisin[0] >= 0 && positionVoisin[0] < maze.hauteur
                && positionVoisin[1] >= 0 && positionVoisin[1] < maze.longueur )
            {
                return false;
            }
            return true;
        }

        private Node FindNodeInSet(List<Node> closedSet, Node nouveauVoisin)
        {
            foreach(Node node in closedSet)
            {
                if (node.coordonates[0] == nouveauVoisin.coordonates[0] && node.coordonates[1] == nouveauVoisin.coordonates[1])
                {
                    return node;
                }
            }
            return null;
        }

        private int DistanceH(Node nouveauVoisin, Node end)
        {
            return Math.Abs(end.coordonates[0] - nouveauVoisin.coordonates[0]) + Math.Abs(end.coordonates[1] - nouveauVoisin.coordonates[1]);
        }

        private int Compare2Nodes(Node node1, Node node2)
        {
            if (node1.H < node2.H)
            {
                return 1;
            }
            if (node1.H == node2.H)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}