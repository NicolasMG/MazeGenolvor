using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Properties
{
    static class Constantes
    {
        public static readonly bool[] THaut = { true, true, false, true };
        public static readonly bool[] TDroite = { true, true, true, false };
        public static readonly bool[] TBas = { false, true, true, true };
        public static readonly bool[] TGauche = { true, false, true, true };

        public static readonly bool[] BHaut = { true, false, false, false };
        public static readonly bool[] BDroite = { false, true, false, false };
        public static readonly bool[] BBas = { false, false, true, false };
        public static readonly bool[] BGauche = { false, false, false, true };

        public static readonly bool[] CH_D = { true, true, false, false };
        public static readonly bool[] CB_D = { false, true, true, false };
        public static readonly bool[] CG_B = { false, false, true, true };
        public static readonly bool[] CG_H = { true, false, false, true };

        public static readonly bool[] IVertical= { true, false, true, false };
        public static readonly bool[] IHorizontal = { false, true, false, true };
        public static readonly bool[] XInter = { true, true, true, true };
        public static readonly bool[] Dark = { false, false, false, false };
        
    }
}
