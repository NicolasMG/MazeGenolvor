using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Properties
{
    class Maze
    {
        const int tailleCasepx = 100;
        
        public int hauteur;
        public int longueur;

        public bool entreeSortie;
        public string genealgo;

        public Cell[,] cells;

        public Random random;
        

        public void GenererMaze(decimal longueur, decimal hauteur, string genealgo, bool entreeSortie)
        {
            this.longueur = Decimal.ToInt32(longueur);
            this.hauteur = Decimal.ToInt32(hauteur);
            this.genealgo = genealgo;
            this.entreeSortie = entreeSortie;

            this.random = new Random();

            this.cells = new Cell[this.longueur, this.hauteur];

            for (int ilong = 0; ilong < longueur; ilong++)
            {
                for (int ihaut = 0; ihaut < hauteur; ihaut++)
                {
                    cells[ilong, ihaut] = new Cell(ilong, ihaut);
                }
            }

            AbbattreLesMurs(genealgo);

            if (entreeSortie)
            {
                CreerAcces();
            }
        }


        public void CreerAcces()
        {
            cells[0, 0].mur[0] = true;
            cells[longueur - 1, hauteur - 1].mur[2] = true;
        }
        public void CacherAcces()
        {
            cells[0, 0].mur[0] = false;
            cells[longueur - 1, hauteur - 1].mur[2] = false;
        }

        public void AbbattreLesMurs(string genealgo)
        {
            switch (genealgo)
            {
                case "Recursive implementation":
                    RecursiveImplementation();
                    break;
                case "Iterative Implementation":
                    IterativeImplementation();
                    break;
                case "Randomized Kruskal's algorithm":
                    RandomizedKruskalAlgorithm();
                    break;
                case "Randomized Prim's algorithm":
                    RandomizedPrimAlgorithm();
                    break;
                case "Wilson's alhorithm":
                    WilsonAlgorithm();
                    break;
                case "Aldous-Broder algoritm":
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
            cellAct.visited++;
            cellCount++;
            stack.Push(cellAct);

            List<Cell> cellAdj = ChoisirCelluleProche(cellAct);
            Cell cellSuivante;
            if (cellAdj.Count > 0)
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
                    cellAct = (Cell)stack.Pop();
                }
            }
        }
        
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
            if (indX < longueur - 1)
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
            if (indY < hauteur - 1)
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
            if (cell1.coordonne[0] == cell2.coordonne[0])//meme ligne
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
                    cell1.mur[1] = true;// vers la droite
                    cell2.mur[3] = true;// vers la gauche
                }
                else if (cell1.coordonne[0] == cell2.coordonne[0] + 1)// 2 avant
                {
                    cell1.mur[3] = true;// vers la gauche
                    cell2.mur[1] = true;// vers la droite
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

        public Bitmap DessinerMaze()
        {
            Bitmap b = new Bitmap(longueur * 20, hauteur * 20);
            Graphics g = Graphics.FromImage(b);
            
            foreach(Cell cell in cells)
            {
                g.DrawImage(AvoirRessource(cell),
                        cell.coordonne[0] * 20,
                        cell.coordonne[1] * 20);
            }
            //changer les valeurs pour correspondre correctement aux attentes
            //Bitmap objBitmap = new Bitmap(b/*, new Size(longueur * 20, hauteur * 20)*/);
            Bitmap objBitmap = b;
            objBitmap.Save("./maze.png", ImageFormat.Png);
            return objBitmap;
        }

        private Image AvoirRessource(Cell cell)
        {
            if (cell.mur.SequenceEqual(Constantes.BBas)) return Properties.ResourcePic.BBas;
            if (cell.mur.SequenceEqual(Constantes.BDroite)) return Properties.ResourcePic.BDroite;
            if (cell.mur.SequenceEqual(Constantes.BGauche)) return Properties.ResourcePic.BGauche;
            if (cell.mur.SequenceEqual(Constantes.BHaut)) return Properties.ResourcePic.BHaut;
            if (cell.mur.SequenceEqual(Constantes.CB_D)) return Properties.ResourcePic.CB_D;
            if (cell.mur.SequenceEqual(Constantes.CG_B)) return Properties.ResourcePic.CG_B;
            if (cell.mur.SequenceEqual(Constantes.CG_H)) return Properties.ResourcePic.CG_H;
            if (cell.mur.SequenceEqual(Constantes.CH_D)) return Properties.ResourcePic.CH_D;
            if (cell.mur.SequenceEqual(Constantes.IHorizontal)) return Properties.ResourcePic.IHorizontal;
            if (cell.mur.SequenceEqual(Constantes.IVertical)) return Properties.ResourcePic.IVertical;
            if (cell.mur.SequenceEqual(Constantes.TBas)) return Properties.ResourcePic.TBas;
            if (cell.mur.SequenceEqual(Constantes.TDroite)) return Properties.ResourcePic.TDroite;
            if (cell.mur.SequenceEqual(Constantes.TGauche)) return Properties.ResourcePic.TGauche;
            if (cell.mur.SequenceEqual(Constantes.THaut)) return Properties.ResourcePic.THaut;
            if (cell.mur.SequenceEqual(Constantes.XInter)) return Properties.ResourcePic.XInter;
            return Properties.ResourcePic.Dark;
        }

    }
}
