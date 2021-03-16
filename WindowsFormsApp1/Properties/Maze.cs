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

        public Cell[,] cells;//longuer,hauteur

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
            cells[0, 0].mur[3] = true;
            cells[longueur - 1, hauteur - 1].mur[1] = true;
        }
        public void CacherAcces()
        {
            cells[0, 0].mur[3] = false;
            cells[longueur - 1, hauteur - 1].mur[1] = false;
        }

        public void AbbattreLesMurs(string genealgo)
        {
            switch (genealgo)
            {
                case "Recursive Implementation":
                    RecursiveImplementation();
                    break;
                case "Eller’s algorithm":
                    EllerAlgorithm();
                    break;
                case "Randomized Kruskal's algorithm":
                    RandomizedKruskalAlgorithm();
                    break;
                case "Randomized Prim's algorithm":
                    RandomizedPrimAlgorithm();
                    break;
                case "Recursive division algorithm":
                    RecursiveDivisionAlgorithm();
                    break;
                case "Aldous-Broder algoritm":
                    AldousBroderAlgoritm();
                    break;
                case "Wilson's alhorithm":
                    WilsonAlhorithm();
                    break;
                case "Iterative Implementation":
                    IterativeImplementation();
                    break;
                case "Growing Tree algorithm":
                    GrowingTreeAlgorithm();
                    break;
                case "Binary Tree algorithm":
                    BinaryTreeAlgorithm();
                    break;
                case "Sidewinder algorithm":
                    SidewinderAlgorithm();
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

        /// <summary>
        /// One of the fastest
        /// build Row by Row 
        ///     1.  First row : Init each cells in different set each
        ///     2.  Join random adjacent cells if not same set. When Joined, merge set in 1
        ///     3.  For each Set, create at least 1 vertical connection down to next row (target cell put in the set)
        ///     4.  Remaning Cell get own set
        ///     5.  Repeat 2-4 until last row
        ///     6.  Last row : do 2.
        /// </summary>
        private void EllerAlgorithm()
        {
            List<List<Cell>> listOfSets = new List<List<Cell>>();
            int setNumber = 0;

            for (int i = 0; i < longueur; i++)
            {
                if (cells[i, 0].setValue < 0)
                {
                    List<Cell> tempSet = new List<Cell>();
                    tempSet.Add(cells[i, 0]);
                    cells[i, 0].setValue = setNumber;
                    setNumber++;
                    listOfSets.Add(tempSet);
                }
            }
            
            for (int haut = 0; haut < hauteur - 1; haut++)
            {
                RowSetFusion(listOfSets, haut);
                VerticalConnection(listOfSets, haut);

                setNumber = NewSetInRow(listOfSets, setNumber, haut);
            }
            while (listOfSets.Count(x => x.Count > 0) != 1)
            {
                RowSetFusion(listOfSets, hauteur-1);

            }
        }

        private int NewSetInRow(List<List<Cell>> listOfSets, int setNumber, int haut)
        {
            for (int longu = 0; longu < longueur ; longu++)
            {
                if (cells[longu, haut + 1].setValue < 0)
                {
                    List<Cell> tempSet = new List<Cell>();
                    tempSet.Add(cells[longu, haut + 1]);
                    cells[longu, haut + 1].setValue = setNumber;
                    setNumber++;
                    listOfSets.Add(tempSet);
                }
            }

            return setNumber;
        }

        private void VerticalConnection(List<List<Cell>> listOfSets, int haut)
        {
            foreach (List<Cell> listCell in listOfSets.FindAll(x => x.Count > 0))
            {
                List<Cell> listCellInRow = listCell.FindAll(x => x.coordonne[1] == haut);
                int numberCellNextRowAdd = random.Next(1, listCellInRow.Count);
                foreach (Cell cell in listCellInRow.OrderBy(x => random.Next()).Take(numberCellNextRowAdd))
                {
                    cells[cell.coordonne[0], haut + 1].setValue = cell.setValue;
                    listCell.Add(cells[cell.coordonne[0], haut + 1]);
                    ChangerMurCellule(cells[cell.coordonne[0], haut], cells[cell.coordonne[0], haut + 1]);

                }
            }
        }

        private void RowSetFusion(List<List<Cell>> listOfSets, int haut)
        {
            for (int i = 0; i < longueur - 1; i++)
            {
                if (random.Next(0, 2) == 0)
                {
                    if (cells[i,haut].setValue != cells[i+1, haut].setValue)
                    {
                        FusionSetAndCell(i, haut, i + 1, haut, listOfSets);
                    }
                }
            }
        }

        private void FusionSetAndCell(int cell1x, int cell1y, int cell2x, int cell2y, List<List<Cell>> listOfSets)
        {
            Cell cell1 = cells[cell1x, cell1y];
            Cell cell2 = cells[cell2x, cell2y];
            //check and open wall between the 2 cell
            ChangerMurCellule(cell1, cell2);
            //Merge sets into 1
            int newSetNumber = cell1.setValue;
            int oldSetNumber = cell2.setValue;
            if(oldSetNumber < 0)
            {
                cell2.setValue = newSetNumber;
                listOfSets[newSetNumber].Add(cells[cell2x, cell2y]);
            }
            else
            {
                foreach (Cell cell in listOfSets[oldSetNumber])
                {
                    cell.setValue = newSetNumber;
                }
                listOfSets[newSetNumber].AddRange(listOfSets[oldSetNumber]);
                listOfSets[oldSetNumber].Clear();
            }
            
        }


        /// <summary>
        /// minimal spanning tree -> Union-Find data stucture
        ///     1. each cell in a set
        ///     2. order each links (2 cells) in increasing order
        ///     3. for each links (u,v) in order :
        ///         if u and v not in same set:
        ///             join u and v 
        /// </summary>
        private void RandomizedKruskalAlgorithm()
        {
            List<int[]> edge = new List<int[]>(); //int[3] with first 2 position, 3rd for direction 0 in longueur, 1 for hauteur

            List<List<Cell>> listOfSets = new List<List<Cell>>();

            int value = 0;
            foreach(Cell cell in cells)
            {
                cell.setValue = value;
                List<Cell> tempSet = new List<Cell>();
                tempSet.Add(cell);
                listOfSets.Add(tempSet);

                value++;
                if (cell.coordonne[0] != longueur - 1)
                {
                    int[] ed = { cell.coordonne[0], cell.coordonne[1], 0 };
                    edge.Add(ed);
                }
                if (cell.coordonne[1] != hauteur - 1)
                {
                    int[] ed = { cell.coordonne[0], cell.coordonne[1], 1 };
                    edge.Add(ed);
                }
            }
            Cell cell1;
            Cell cell2;
            foreach (int[] ed in edge.OrderBy(x => random.Next()))
            {
                switch (ed[2])
                {
                    case 0:
                        cell1 = cells[ed[0], ed[1]];
                        cell2 = cells[ed[0] + 1, ed[1]];
                        if (cell1.setValue != cell2.setValue)
                        {
                            ChangerMurCellule(cell1, cell2);

                            List<Cell> listCells1 = listOfSets[cell1.setValue];
                            List<Cell> listCells2 = listOfSets[cell2.setValue];

                            if (listCells1.Count() >= listCells2.Count())
                            {
                                foreach(Cell cell in listCells2)
                                {
                                    cell.setValue = cell1.setValue;
                                }
                                listCells1.AddRange(listCells2);
                                listCells2.Clear();
                            }
                            else
                            {
                                foreach (Cell cell in listCells1)
                                {
                                    cell.setValue = cell2.setValue;
                                }
                                listCells2.AddRange(listCells1);
                                listCells1.Clear();
                            }
                        }
                        break;
                    case 1:
                        cell1 = cells[ed[0], ed[1]];
                        cell2 = cells[ed[0], ed[1]+1];
                        if (cell1.setValue != cell2.setValue)
                        {
                            ChangerMurCellule(cell1, cell2);

                            List<Cell> listCells1 = listOfSets[cell1.setValue];
                            List<Cell> listCells2 = listOfSets[cell2.setValue];

                            if (listCells1.Count() >= listCells2.Count())
                            {
                                foreach (Cell cell in listCells2)
                                {
                                    cell.setValue = cell1.setValue;
                                }
                                listCells1.AddRange(listCells2);
                                listCells2.Clear();
                            }
                            else
                            {
                                foreach (Cell cell in listCells1)
                                {
                                    cell.setValue = cell2.setValue;
                                }
                                listCells2.AddRange(listCells1);
                                listCells1.Clear();
                            }
                        }
                        break;
                    default:
                        throw new Exception();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void RandomizedPrimAlgorithm()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        private void RecursiveDivisionAlgorithm()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        private void AldousBroderAlgoritm()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        private void WilsonAlhorithm()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        private void IterativeImplementation()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        private void GrowingTreeAlgorithm()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        private void BinaryTreeAlgorithm()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SidewinderAlgorithm()
        {
            throw new NotImplementedException();
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
