using System.Collections.Generic;

namespace WindowsFormsApp1.Properties
{
    internal class ArbreCellules
    {
        public int ID { get; set; }
        public Cell cellActuelle { get; set; }
        public List<ArbreCellules> enfantsArbre { get; set; }
        public int ParentID { get; set; }

        public ArbreCellules(Cell cellActuelle, int ID)
        {
            this.cellActuelle = cellActuelle;
            this.ID = ID;
            this.enfantsArbre = new List<ArbreCellules>();
            ParentID = ID;
        }
        public ArbreCellules(Cell cellActuelle, int ID, int parentID)
        {
            this.cellActuelle = cellActuelle;
            this.ID = ID;
            this.ParentID = parentID;
            this.enfantsArbre = new List<ArbreCellules>();
        }

        public void RajouterEnfant(ArbreCellules enfantArbre, int IDPere)
        {
            if(ID == IDPere)
            {
                enfantsArbre.Add(enfantArbre);
            }
            else
            {
                foreach (ArbreCellules arbre in enfantsArbre)
                {
                    arbre.RajouterEnfant(enfantArbre, IDPere);
                }
            }
        }

        public ArbreCellules TrouverArbre(int IDCherche)
        {
            if(IDCherche == ID)
            {
                return this;
            }

            ArbreCellules retour;
            foreach (ArbreCellules arbre in enfantsArbre)
            {
                retour = arbre.TrouverArbre(IDCherche);
                if (retour.ID == IDCherche)
                {
                    return arbre.TrouverArbre(IDCherche);
                }
            }
            retour = this;
            return retour;
        }
    }
}