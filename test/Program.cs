using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LepFoundation;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            SupportInGround sup = new SupportInGround();
            sup.SupportType = Enums.ESupportType.AnkerUglKoncevaya;
            GroundObj gr = new GroundObj();
            gr.Type = Enums.EGroundType.PesokPilevatiy;
            gr.IL = 0.5;
            gr.E = 50;            

            gr.Gamma1 = 20.7;
            gr.Phi1 = 34;
            gr.C1 = 5.1;
            sup.InputGround = gr;

            sup.Loads.Nr = 10;
            sup.Loads.Mr = 46;
            sup.Loads.Qr = 5.5;

            sup.Loads.Nn = 10;
            sup.Loads.Mn = 46;
            sup.Loads.Qn = 5.5;

            sup.h = 2.5;

            sup.FrictionGroundType = Enums.EFrictionGroundType.PESOK_VLAGNIY;
            sup.b0 = 0.17;
            sup.IsDrilled = true;
            
            Console.WriteLine(sup.CheckFirstPS());
            Console.WriteLine(sup.CheckSecondPS());
            Console.ReadKey();
        }
    }
}
