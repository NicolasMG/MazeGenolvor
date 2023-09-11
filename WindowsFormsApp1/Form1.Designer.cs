namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Hauteur = new System.Windows.Forms.NumericUpDown();
            this.Longueur = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TypePathfinding = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TypeCreation = new System.Windows.Forms.ComboBox();
            this.checkBoxES = new System.Windows.Forms.CheckBox();
            this.pathfinding = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Hauteur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Longueur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(245, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 47);
            this.button1.TabIndex = 0;
            this.button1.Text = "Générer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hauteur";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Longueur";
            // 
            // Hauteur
            // 
            this.Hauteur.Location = new System.Drawing.Point(64, 38);
            this.Hauteur.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Hauteur.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.Hauteur.Name = "Hauteur";
            this.Hauteur.Size = new System.Drawing.Size(79, 20);
            this.Hauteur.TabIndex = 5;
            this.Hauteur.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Hauteur.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // Longueur
            // 
            this.Longueur.Location = new System.Drawing.Point(65, 10);
            this.Longueur.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Longueur.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.Longueur.Name = "Longueur";
            this.Longueur.Size = new System.Drawing.Size(79, 20);
            this.Longueur.TabIndex = 6;
            this.Longueur.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Longueur.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(16, 64);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(560, 400);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // TypePathfinding
            // 
            this.TypePathfinding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypePathfinding.FormattingEnabled = true;
            this.TypePathfinding.Location = new System.Drawing.Point(485, 38);
            this.TypePathfinding.Name = "TypePathfinding";
            this.TypePathfinding.Size = new System.Drawing.Size(170, 21);
            this.TypePathfinding.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(378, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Type de création";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(378, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Type de pathfinding";
            // 
            // TypeCreation
            // 
            this.TypeCreation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeCreation.FormattingEnabled = true;
            this.TypeCreation.Location = new System.Drawing.Point(485, 13);
            this.TypeCreation.Name = "TypeCreation";
            this.TypeCreation.Size = new System.Drawing.Size(170, 21);
            this.TypeCreation.TabIndex = 11;
            this.TypeCreation.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // checkBoxES
            // 
            this.checkBoxES.AutoSize = true;
            this.checkBoxES.Checked = true;
            this.checkBoxES.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxES.Location = new System.Drawing.Point(150, 9);
            this.checkBoxES.Name = "checkBoxES";
            this.checkBoxES.Size = new System.Drawing.Size(89, 17);
            this.checkBoxES.TabIndex = 12;
            this.checkBoxES.Text = "Entrée/Sortie";
            this.checkBoxES.UseVisualStyleBackColor = true;
            this.checkBoxES.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // pathfinding
            // 
            this.pathfinding.Enabled = false;
            this.pathfinding.Location = new System.Drawing.Point(661, 11);
            this.pathfinding.Name = "pathfinding";
            this.pathfinding.Size = new System.Drawing.Size(127, 47);
            this.pathfinding.TabIndex = 13;
            this.pathfinding.Text = "Pathfinding";
            this.pathfinding.UseVisualStyleBackColor = true;
            this.pathfinding.Click += new System.EventHandler(this.pathfinding_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 861);
            this.Controls.Add(this.pathfinding);
            this.Controls.Add(this.checkBoxES);
            this.Controls.Add(this.TypeCreation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TypePathfinding);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Longueur);
            this.Controls.Add(this.Hauteur);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "MazeGenolvor";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Hauteur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Longueur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown Hauteur;
        private System.Windows.Forms.NumericUpDown Longueur;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox TypePathfinding;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox TypeCreation;
        private System.Windows.Forms.CheckBox checkBoxES;
        private System.Windows.Forms.Button pathfinding;
    }
}

