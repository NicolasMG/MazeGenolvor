using System;
using System.Collections;
using System.Collections.Generic;

namespace WindowsFormsApp1.Properties
{
    public class Maze
    {
        private int longueur;
        private int hauteur;
        public Cell[,] cells;

        public Random random;

        public string genealgo; //type d'algo pour générer le Maze
        public bool entreeSortie;

        public Maze(int longueur, int hauteur, string genealgo,bool entreeSortie)
        {
            this.random = new Random();

            this.longueur = longueur;
            this.hauteur = hauteur;

            this.genealgo = genealgo;
            this.entreeSortie = entreeSortie;

            this.cells = new Cell[longueur, hauteur];
            
            for (int ilong = 0; ilong < longueur; ilong++)
            {
                for (int ihaut = 0; ihaut < hauteur; ihaut++)
                {
                    //cells[ilong, ihaut] = new Cell(ilong, ihaut, random);
                    cells[ilong, ihaut] = new Cell(ilong, ihaut);
                }
            }

            //Maintenant faut créer le Maze
            //Bonne chance

            AbbattreLesMurs(genealgo);
            if (entreeSortie)
            {
                CreerAcces();
            }
        }

        private void CreerAcces()
        {
            cells[0, 0].mur[0] = true;
            cells[longueur-1, hauteur-1].mur[2] = true;
        }

        public void AbbattreLesMurs(string genealgo)
        {
            switch (genealgo)
            {
                case "Recursive implementation":
                    RecursiveImplementation();
                    break;
                case "Iterative implementation":
                    IterativeImplementation();
                    break;
                case "Randomized Kruskal's algorithm":
                    RandomizedKruskalAlgorithm();
                    break;
                case "Randomized Prim's algorithm":
                    RandomizedPrimAlgorithm();
                    break;
                case "Wilson's algorithm":
                    WilsonAlgorithm();
                    break;
                case "Aldous-Broder algorithm":
                    AldousBroderAlgorithm();
                    break;
                default:
                    RecursiveImplementation();
                    break;
            }
        }

        /// <summary>
        /// Choisir une case aléatoire
        /// la marqué comme visité
        /// voir une case a coté si non visité
        /// creuser un mur entre les deux
        /// continuer jusqu'a ne plus en trouver
        /// reculer 
        /// </summary>
        /// 
        private void RecursiveImplementation()
        {

            Stack stack = new Stack();
            int cellStopCounter = longueur * hauteur;
            int cellCount = 0;
            int[] indXY = new int[2] { random.Next(longueur), random.Next(hauteur) };
            Cell cellAct = cells[indXY[0], indXY[1]];
            cellAct.visited ++;
            cellCount++;
            stack.Push(cellAct);

            List<Cell> cellAdj = ChoisirCelluleProche(cellAct);
            Cell cellSuivante;
            if(cellAdj.Count > 0)
            {
                cellSuivante = cellAdj[random.Next(cellAdj.Count)];
                ChangerMurCellule(cellAct, cellSuivante);
                cellSuivante.visited++;
                cellAct = cellSuivante;
                stack.Push(cellAct);
                cellCount++;

            }

            while (cellCount < cellStopCounter)
            {
                cellAdj = ChoisirCelluleProche(cellAct);
                if (cellAdj.Count > 0)
                {
                    cellSuivante = cellAdj[random.Next(cellAdj.Count)];
                    ChangerMurCellule(cellAct, cellSuivante);
                    cellSuivante.visited++;
                    cellAct = cellSuivante;
                    stack.Push(cellAct);
                    cellCount++;
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        System.Console.WriteLine("something" + stack.Count);
                        break;
                    }
                    cellAct = (Cell) stack.Pop();
                }

            }
            /*
            int cellStopCounter = longueur * hauteur;
            int cellCount = 0;

            //coordonne 1er cellule rand
            int[] indXY = new int[2] { random.Next(longueur), random.Next(hauteur) };

            ArbreCellules arbreCellules = new ArbreCellules(cells[indXY[0], indXY[1]], cellCount);
            ArbreCellules nouveauArbre = new ArbreCellules(cells[indXY[0], indXY[1]], cellCount);

            cells[indXY[0], indXY[1]].visited = 1;
            cellCount++;

            Cell cellSuivante;

            cellSuivante = ChoisirCelluleProche(arbreCellules.cellActuelle);

            while (cellCount < cellStopCounter)
            {

                if(cellSuivante.visited == 0)
                {
                    cellSuivante.visited = 1;
                    ChangerMurCellule(arbreCellules.cellActuelle, cellSuivante);
                    cellCount++;
                    nouveauArbre = new ArbreCellules(cellSuivante, cellCount);
                    arbreCellules.RajouterEnfant(nouveauArbre, arbreCellules.ID);
                    cellSuivante = ChoisirCelluleProche(nouveauArbre.cellActuelle);
                }       
                else //on nous a renvoyé la meme cellule car il n'y en a pas de disponible, on remonte l arbre
                {
                    nouveauArbre = arbreCellules.TrouverArbre(nouveauArbre.ParentID);
                    cellSuivante = ChoisirCelluleProche(nouveauArbre.cellActuelle);

                }
            }



            Cell cellActuelle = cells[indXY[0], indXY[1]];
            
            
            

            //Faire un arbre de cellule avec Racine
            */

        }

        //done, renvoie cellule non visité ou cellule actuelle
        private List<Cell> ChoisirCelluleProche(Cell cell)
        {
            List<Cell> cellulesAdj = new List<Cell>();
            int indX = cell.coordonne[0];
            int indY = cell.coordonne[1];

            if (indX > 0)
            {
                if (cells[indX - 1, indY].visited == 0)
                {
                    cellulesAdj.Add(cells[indX - 1, indY]);
                }
            }
            if (indX < longueur-1 )
            {
                if (cells[indX + 1, indY].visited == 0)
                {
                    cellulesAdj.Add(cells[indX + 1, indY]);
                }
            }
            if (indY > 0)
            {
                if (cells[indX, indY - 1].visited == 0)
                {
                    cellulesAdj.Add(cells[indX, indY - 1]);

                }
            }
            if (indY < hauteur-1)
            {
                if (cells[indX, indY + 1].visited == 0)
                {

                cellulesAdj.Add(cells[indX, indY + 1]);
                }
            }
            
            return cellulesAdj;
        }

        //done
        private void ChangerMurCellule(Cell cell1, Cell cell2)
        {
            if(cell1.coordonne[0] == cell2.coordonne[0])//meme ligne
            {
                if (cell1.coordonne[1] == cell2.coordonne[1] - 1)// 1 suivante
                {
                    cell1.mur[2] = true;// vers le bas
                    cell2.mur[0] = true;// vers le haut
                }
                else if (cell1.coordonne[1] == cell2.coordonne[1] + 1)// 2 avant
                {
                    cell1.mur[0] = true;// vers le haut
                    cell2.mur[2] = true;// vers le bas
                }
                else
                {
                    throw new Exception();
                }

            }
            else if (cell1.coordonne[1] == cell2.coordonne[1])//meme colonne
            {
                if (cell1.coordonne[0] == cell2.coordonne[0] - 1)// 2 suivant
                {
                    cell1.mur[1]= true;// vers la droite
                    cell2.mur[3]= true;// vers la gauche
                }
                else if (cell1.coordonne[0] == cell2.coordonne[0] + 1)// 2 avant
                {
                    cell1.mur[3]= true;// vers la gauche
                    cell2.mur[1]= true;// vers la droite
                }
                else
                {
                    throw new Exception();
                }
            }
            else
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void IterativeImplementation()
        {
            throw new NotImplementedException();
        }
        private void RandomizedKruskalAlgorithm()
        {
            throw new NotImplementedException();
        }
        private void RandomizedPrimAlgorithm()
        {
            throw new NotImplementedException();
        }
        private void WilsonAlgorithm()
        {
            throw new NotImplementedException();
        }
        private void AldousBroderAlgorithm()
        {
            throw new NotImplementedException();
        }
    }
}