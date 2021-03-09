using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        MazeGenerateur MazeG = new MazeGenerateur();
        Bitmap Image;
        PathfindingSolver pathfinderSolver = new PathfindingSolver();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MazeG.GenererMaze(Longueur.Value, Hauteur.Value, comboBox1.Text, checkBoxES.Checked);

            //demande moi la solution
            //MazeG.Solution();

            //suite après avoir générer le maze et sa solution ?
            //l'afficher
            Image = MazeG.DessinerMaze();
            pictureBox1.ClientSize = new Size(Image.Size.Width, Image.Size.Height);
            pictureBox1.Image = Image;

            pathfinding.Enabled = true;
        }
        
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //faire si valeur 1 ou - mettre 2
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            //faire si valeur 1 ou - mettre 2
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //nope
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pathfinding_Click(object sender, EventArgs e)
        {
            pathfinderSolver.solve(MazeG);
        }
        
    }
}
