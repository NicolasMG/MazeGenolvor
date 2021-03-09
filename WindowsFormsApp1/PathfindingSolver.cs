using System;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1
{
    internal class PathfindingSolver
    {
        private MazeGenerateur mazeGenerateur;

        internal void solve(MazeGenerateur mazeG)
        {
            this.mazeGenerateur = mazeG;



            ResoudreClassique();
        }

        private void ResoudreClassique()
        {


        }
    }
}