using System;

namespace WindowsFormsApp1.Properties
{
    public class Cell
    {
        public int[] coordonne; //longueur, hauteur
        public bool[] mur;      //haut, droite, bas, gauche avec vrai pour mur ouvert
        public int visited;     //to use in recursive
        public int setValue;    //used il Eller alg

        public Cell()
        {
        }

        public Cell(int ilong, int ihaut)
        {
            this.coordonne = new int[2] { ilong, ihaut };
            mur = new bool[4] { false, false, false, false };
            visited = 0;
            setValue = -1;
        }

        public Cell(int ilong, int ihaut, Random random)
        {
            //Random random = new Random();
            this.coordonne = new int[2] { ilong, ihaut };
            mur = new bool[4] { false, false, false, false };
        }
    }
}