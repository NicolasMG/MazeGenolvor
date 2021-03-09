using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Properties
{
    class MazeGenerateur
    {
        const int tailleCasepx = 100;

        public Maze maze;
        public int hauteur;
        public int longueur;

        public bool entreeSortie;
        public string genealgo;

        //hauteur, longueur
        public void GenererMaze(decimal longueur, decimal hauteur, string genealgo, bool entreeSortie)
        {
            this.longueur = Decimal.ToInt32(longueur);
            this.hauteur = Decimal.ToInt32(hauteur);
            this.genealgo = genealgo;
            this.entreeSortie = entreeSortie;

            maze = new Maze(this.longueur, this.hauteur, genealgo,entreeSortie);
        }



        public Bitmap DessinerMaze()
        {
            Bitmap b = new Bitmap(longueur * 20, hauteur * 20);
            Graphics g = Graphics.FromImage(b);
            
            foreach(Cell cell in maze.cells)
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

        internal void Solution()
        {
            throw new NotImplementedException();
        }

    }
}
