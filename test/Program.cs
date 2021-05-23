using LepFoundation;
using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            Pole pole = new Pole();
            pole.b0= 0.545;
            pole.h = 3;
            pole.SupportType = Enums.ESupportType.AnkerUglKoncevaya;
            pole.IsDrilled = true;

            calc.Pole = pole;
            
            GroundObj gr = new GroundObj();
            gr.Type = Enums.EGroundType.PesokPilevatiy;
            gr.IL = 0.2;
            gr.E = 50;

            gr.Gamma1 = 19.5;
            gr.Phi1 = 21;
            gr.C1 = 8.75;
            gr.FrictionGroundType = Enums.EFrictionGroundType.SUPES_PLAST;
            calc.InputGround = gr;

            SupportLoads loads = new SupportLoads();

            loads.Nr = 80;
            loads.Mr = 192;
            loads.Qr = 9.6;

            loads.Nn = 80;
            loads.Mn = 192;
            loads.Qn = 9.6;

            calc.Loads = loads;     

            Console.WriteLine(calc.CheckFirstPS());
            Console.WriteLine(calc.CheckSecondPS());
            Console.ReadKey();
        }
    }
}
