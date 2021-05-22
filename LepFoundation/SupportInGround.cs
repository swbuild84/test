using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engineereing;

namespace LepFoundation
{
    /// <summary>
    /// Тип опоры по виду работы
    /// </summary>
    public enum ESupportType : byte
    {
        /// <summary>
        /// Промежуточная
        /// </summary>
        Promegutochnaya = 1, 
        /// <summary>
        /// Анкерная без углов и разности тяжений
        /// </summary>
        AnkernayaPryamayaBezRaznTyageniy,
        /// <summary>
        /// Анкерно-угловая или концевая
        /// </summary>
        AnkerUglKoncevaya,
        /// <summary>
        /// Специальная или переходная
        /// </summary>
        Special
    }
    /// <summary>
    /// Тип грунта по прил 4 3041тм т6 для опеределения коэффициента трения
    /// </summary>
    public enum EFrictionGroundType : byte
    {
        /// <summary>
        /// Глинистые и скальные грунты с омыливающейся поверхностью (глинистые сланцы), глинистые известняки
        /// </summary>
        GLINA_SKALA_MILO = 1,
        /// <summary>
        /// Глины в твердом состоянии
        /// </summary>
        GLINA_TVERD,
        /// <summary>
        /// Глины в пластичном состоянии
        /// </summary>
        GLINA_PLAST,
        /// <summary>
        /// Суглинки в твердом состоянии

        /// </summary>
        SUGL_TVERD,
        /// <summary>
        /// Суглинки в пластичном состоянии
        /// </summary>
        SUGL_PLAST,
        /// <summary>
        /// Супеси в твердом состоянии
        /// </summary>
        SUPES_TVERD,
        /// <summary>
        /// Супеси в пластичном состоянии
        /// </summary>
        SUPES_PLAST,
        /// <summary>
        /// Пески маловлажные
        /// </summary>
        PESOK_MAOLOVLAGNIY,
        /// <summary>
        /// Пески влажные
        /// </summary>
        PESOK_VLAGNIY,
        /// <summary>
        /// Скальные грунты (с неомыливающейся поверхностью)
        /// </summary>
        SKALA
    }
    /// <summary>
    /// Тип грунта
    /// </summary>
    public enum EGroundType : byte
    {
        /// <summary>
        /// песок пылеватый
        /// </summary>
        PesokPilevatiy = 1,
        /// <summary>
        /// песок мелкий
        /// </summary>
        PesokMelkiy,
        /// <summary>
        /// песок средней крупности
        /// </summary>
        PesokSredKrupnosti,
        /// <summary>
        /// песок гравелистый
        /// </summary>
        PesokGravelistiy,
        /// <summary>
        /// супесь
        /// </summary>
        Supes,
        /// <summary>
        /// суглинок
        /// </summary>
        Suglinok,
        /// <summary>
        /// глина
        /// </summary>
        Glina
    }
    /// <summary>
    /// Грунт
    /// </summary>
    public class GroundObj:ICloneable 
    {
        double _koefPoristostiE;
        /// <summary>
        /// Коэффициент пористости грунта
        /// </summary>
        public double KoefPoristostiE
        {
            get { return _koefPoristostiE; }
            set
            {
                if (value >= 0) _koefPoristostiE = value;
                else _koefPoristostiE = 0;
            }
        }

        EGroundType _type;
        /// <summary>
        /// Тип грунта
        /// </summary>
        public EGroundType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        double _IL;
        /// <summary>
        /// Показатель текучести
        /// </summary>
        public double IL
        {
            get { return _IL; }
            set
            {
                if (_type == EGroundType.Supes || _type == EGroundType.Suglinok || _type == EGroundType.Glina) _IL = value;
                else _IL = 0;
            }
        }

        double _phi2;
        /// <summary>
        /// Нормативный угол внутреннего трения грунта, градусы
        /// </summary>
        public double Phi2
        {
            get { return _phi2; }
            set { _phi2 = value; }
        }


        double _c2;
        /// <summary>
        /// Нормативное удельное сцепление грунта, кПа
        /// </summary>
        public double C2
        {
            get { return _c2; }
            set { _c2 = value; }
        }


        double _E;
        /// <summary>
        /// Модуль деформации грунта, МПа
        /// </summary>
        public double E
        {
            get { return _E; }
            set { _E = value; }
        }

        double _gamma2;
        /// <summary>
        /// Нормативный объемный вес, КН/м3
        /// </summary>
        public double Gamma2
        {
            get { return _gamma2; }
            set { _gamma2 = value; }
        }

        double _phi1;
        /// <summary>
        /// Расчетный угол внутреннего трения грунта, градусы
        /// </summary>
        public double Phi1
        {
            get { return _phi1; }
            set { _phi1 = value; }
        }


        double _c1;
        /// <summary>
        /// Расчетное удельное сцепление грунта, кПа
        /// </summary>
        public double C1
        {
            get { return _c1; }
            set { _c1 = value; }
        }


        double _gamma1;
        /// <summary>
        /// Расчетный объемный вес, КН/м3
        /// </summary>
        public double Gamma1
        {
            get { return _gamma1; }
            set { _gamma1 = value; }
        }
        public GroundObj()
        {
            this._type = EGroundType.PesokPilevatiy;
        }

        /// <summary>
        /// Расчет расчетной характеристики угла внутренного трения по СНиП
        /// </summary>
        public void CalcPhi1()
        {
            if (Phi2 > 0) Phi1 = Phi2 / 1.1;
        }

        /// <summary>
        /// Расчет расчетной характеристики угла внутренного трения по СНиП
        /// </summary>
        public void CalcС1()
        {
            if (Phi2 < 0) return;
            if (Type == EGroundType.PesokMelkiy ||
                Type == EGroundType.PesokSredKrupnosti ||
                Type == EGroundType.PesokGravelistiy ||
                Type == EGroundType.PesokPilevatiy)
                C1 = C2 / 4.0;
            if (Type == EGroundType.Supes && _IL <= 0.25) C1 = C2 / 2.4;
            if ((Type == EGroundType.Suglinok || Type == EGroundType.Glina) && _IL <= 0.5) C1 = C2 / 2.4;
            if (Type == EGroundType.Supes && _IL > 0.25) C1 = C2 / 3.3;
            if ((Type == EGroundType.Suglinok || Type == EGroundType.Glina) && _IL > 0.5) C1 = C2 / 3.3;
            return;
        }

        public object Clone()
        {
            return new GroundObj
            {
                C1 = this.C1,
                C2 = this.C2,
                E = this.E,
                Gamma1 = this.Gamma1,
                Gamma2 = this.Gamma2,
                IL = this.IL,
                KoefPoristostiE = this.KoefPoristostiE,
                Phi1 = this.Phi1,
                Phi2 = this.Phi2,
                Type = this.Type
            };
        }
    }
    /// <summary>
    /// Стойка в грунте
    /// </summary>
    public class SupportInGround
    {              
 //PRIVATE MEMBERS
        /// <summary>
        /// длина верхнего ригеля, м
        /// </summary>
        private double lr = 1;
        /// <summary>
        /// длина нижнего ригеля, м
        /// </summary>
        private double lr1 = 1;
        /// <summary>
        /// высота верхнего ригеля, м
        /// </summary>
        private double hr;
        /// <summary>
        /// высота нижнего ригеля, м
        /// </summary>
        private double hr1;
        /// <summary>
        /// расст. от поверхн. грунта (банкетки) до середины высоты верхн. ригеля, м
        /// </summary>
        private double yr;
        /// <summary>
        /// расст. от нижнего основания стойки до середины высоты нижнего ригеля, м
        /// </summary>
        private double yr1;
        /// <summary>
        /// толщина верхнего ригеля, м
        /// </summary>
        private double ar;
        /// <summary>
        /// толщина нижнего ригеля, м
        /// </summary>
        private double ar1;

        private GroundObj m_grnd;

        //PUBLIC MEMBERS

        /// <summary>
        /// Нагрузки
        /// </summary>
        public SupportLoads Loads { get; set; }
        /// <summary>
        /// глубина заделки стойки в грунт, м 
        /// </summary>
        public double h { get; set; }
        /// <summary>
        /// средняя ширина стоики в грунте, м
        /// </summary>
        public double b0 { get; set; }
        /// <summary>
        /// высота банкетки, м
        /// </summary>
        public double hb { get; set; }


        /// <summary>
        /// Тип опоры
        /// </summary>
        public ESupportType SupportType { get; set; }
        /// <summary>
        /// установка стойки в сверленый или копаный котлован
        /// </summary>
        public bool IsDrilled { get; set; } = true;
        /// <summary>
        /// Грунт средневзвешенные значения
        /// </summary>
        public GroundObj InputGround { get; set; }
        /// <summary>
        /// Тип грунта по прил 4 3041тм т6 для опеределения коэффициента трения
        /// </summary>
        public EFrictionGroundType FrictionGroundType { get; set; }

        private Rigel m_upperRigel = null;

        /// <summary>
        /// Верхний ригель
        /// </summary>
        public Rigel UpperRigel { get => m_upperRigel; set => m_upperRigel = value; }

        private Rigel m_LoweRigel = null;        

        /// <summary>
        /// Нижний ригель
        /// </summary>
        public Rigel LowerRigel
        {
            get
            {
                return m_LoweRigel;
            }

            set
            {
                if (value != null)
                {
                    m_LoweRigel = value;
                    IsDrilled = false;  //!!!только копаный котлован при установке нижнего ригеля!!!
                }
            }
        }

        public SupportInGround()
        {
            this.Loads = new SupportLoads();
        }

        private void Init()
        {

            //Характеристики грунта засыпки в случае копаного котлована принимаются по 
            //указаниям п.6.15 3041тм-т2
            if (!IsDrilled)
            {
                m_grnd = (GroundObj)InputGround.Clone();
                m_grnd.Phi1 *= 0.8;
                m_grnd.C1 *= 0.5;
            }
            else { m_grnd = InputGround; };

            //верхний ригель
            if(m_upperRigel!=null)
            {
                lr = m_upperRigel.L;
                hr = m_upperRigel.B;
                ar = m_upperRigel.A;
                yr = m_upperRigel.Yr;
            }

            //нижний ригель
            if (m_LoweRigel != null)
            {
                lr1 = m_LoweRigel.L;
                hr1 = m_LoweRigel.B;
                ar1 = m_LoweRigel.A;
                yr1 = h - m_LoweRigel.Yr;
            }
        }

        /// <summary>
        /// Проверка по первому ПС (устойчивости)
        /// </summary>
        /// <returns>Проверка по первому ПС (устойчивости)</returns>
        public bool CheckFirstPS()
        {
            Init();
            double H = Loads.Mr / Loads.Qr;
            double omega = 1.0 - 0.003 * m_grnd.C1;
            double alpha = H / h;
            double f_tr = GetFriction(FrictionGroundType);
            double fd = f_tr * b0 / (2.0 * h);

            double m = m_grnd.Gamma1 * Math.Pow(Math.Tan(EngMath.DegreeToRadian(45 + m_grnd.Phi1 / 2.0)), 2);
            double mc = 2.0 * m_grnd.C1 * Math.Tan(EngMath.DegreeToRadian(45 + m_grnd.Phi1 / 2));
            double etta = mc / (m * h);
            double sigma = 100;
            double psi = Math.Atan(Math.Tan(EngMath.DegreeToRadian(m_grnd.Phi1)) + m_grnd.C1 / sigma);
            double Cod = (2.0 / 3.0) * Math.Tan(psi / 5.0) / Math.Tan(EngMath.DegreeToRadian(45) - psi / 2.0);
            double Kod = 1.0 + Cod * h / b0;
            double b = b0 * Kod;

            double lambdaD = (b0 / 2.0 + ar) * f_tr / h;
            double lambdaD1 = (b0 / 2.0 + ar1) * f_tr / h;

            double u = m * b * h * h / 2.0;
            double A = (lr - b0) * hr * (mc + m * yr) * (1.0 + 0.3 / lr);
            double A1 = (lr1 - b0) * hr1 * (mc + m * (h - yr1)) * (1.0 + 0.3 / lr1);

            double epsilon = A / u;
            double epsilon1 = A1 / u;
            double fn = f_tr * Loads.Nr / u;

            //Относительная глубина центра поворота определяется из уравнения 6.78
            double x0 = 0.5;
            double fx0 = x0 * x0 * x0 + 3.0 / 2.0 * (alpha + etta) * x0 * x0 + 3.0 * alpha * etta * x0 - 1.0 / 4.0 * ((2.0 * etta + 1.0) * (3.0 * alpha + 3.0 * fd + 2.0) - etta) - 3.0 / 4.0 * fn * (1 + alpha) - 3.0 / 4.0 * (epsilon * (alpha + yr / h - lambdaD) - epsilon1 * (alpha - yr1 / h + lambdaD1 + 1.0));
            double dfx0 = 2.0 * x0 * x0 + 3.0 * (alpha + etta) * x0 + 3.0 * alpha * etta;
            double x1 = x0 - fx0 / dfx0; // первое приближение

            int i = 0;
            while (Math.Abs(x1 - x0) > 0.000001)
            { // пока не достигнута точность 0.000001
                x0 = x1;
                fx0 = x0 * x0 * x0 + 3.0 / 2.0 * (alpha + etta) * x0 * x0 + 3.0 * alpha * etta * x0 - 1.0 / 4.0 * ((2.0 * etta + 1.0) * (3.0 * alpha + 3.0 * fd + 2.0) - etta) - 3.0 / 4.0 * fn * (1 + alpha) - 3.0 / 4.0 * (epsilon * (alpha + yr / h - lambdaD) - epsilon1 * (alpha - yr1 / h + lambdaD1 + 1.0));
                dfx0 = 2.0 * x0 * x0 + 3.0 * (alpha + etta) * x0 + 3.0 * alpha * etta;
                x1 = x0 - fx0 / dfx0; // последующие приближения
                i++;
            }


            double Tetta = x1;
            double QnMax = omega / (alpha + Tetta) * (u * (2.0 / 3.0 * (Math.Pow(Tetta, 3)
                + 3.0 * etta * (Math.Pow(Tetta, 2) - Tetta + 0.5) - 3.0 / 2.0 * Tetta + 1.0)
                + (2.0 * etta + 1.0) * fd) + A * (Tetta - yr / h + lambdaD) + A1 * (Tetta - yr1 / h + lambdaD1) + f_tr * Loads.Nr * (1.0 - Tetta));
            double kn = GetKoefNadegnosti(this.SupportType);
            double mz = GetKoefUslRaboti(this.InputGround, this.IsDrilled);
            double Qn = 1 / kn * mz * QnMax;
            return Qn >= this.Loads.Qr;
        }

        /// <summary>
        /// Проверка по второму ПС (устойчивости)
        /// </summary>
        /// <returns>Проверка по  второму ПС (деформациям)</returns>
        public bool CheckSecondPS()
        {
            double beta0 = 0;
            double Q = this.Loads.Qn/ 9.80665; //перевод кН в т
            double H = Loads.Mn / Loads.Qn;
            double alpha = H / h;
            double E = this.InputGround.E * 102;    //перевод МПа в т/м2

            if (this.m_upperRigel==null && this.m_LoweRigel==null)  //безригельное
            {
                double nyu = GetNyu(b0 / h);
                beta0 = 3 * Q / (4 * E * h * h) * (6 * alpha + 3) * nyu;
            }
            if (this.m_upperRigel != null && this.m_LoweRigel == null)  //только верхний ригель           
            {      
                double Fb = m_upperRigel.L * m_upperRigel.B;
                double nyuV = GetNyu(b0 / h);
                beta0 = 3 * Q / (8 * E * h * h) * (6 * alpha + 5) * nyuV;
            }
            if (this.m_upperRigel != null && this.m_LoweRigel != null)  //верхний и нижний ригель           
            {
                double Fb = m_upperRigel.L * m_upperRigel.B;
                double Fh = m_LoweRigel.L * m_LoweRigel.B;
                double nyuV = GetNyu(3 * Fb / (h * h));
                double nyuN = GetNyu(3 * Fh / (h * h));
                beta0 = 3 * Q / (8 * E * h * h) * ((6 * alpha + 5) * nyuV+(6*alpha+1)* nyuN);
            }
            if (this.m_upperRigel == null && this.m_LoweRigel != null)  //нижний ригель           
            {                
                double Fh = m_LoweRigel.L * m_LoweRigel.B;               
                double nyuN = GetNyu(b0 / h);
                beta0 = 3 * Q / (8 * E * h * h) * (6 * alpha + 1) * nyuN;
            }
            return beta0 < 0.01;
        }

        /// <summary>
        /// Трение 
        /// </summary>
        /// <param name="Ground"></param>
        /// <returns></returns>
        static double GetFriction(EFrictionGroundType Gtype)
        {
            switch (Gtype)
            {
                case EFrictionGroundType.GLINA_SKALA_MILO: return 0.25;
                case EFrictionGroundType.GLINA_TVERD: return 0.3;
                case EFrictionGroundType.GLINA_PLAST: return 0.2;
                case EFrictionGroundType.SUGL_TVERD: return 0.45;
                case EFrictionGroundType.SUGL_PLAST: return 0.25;
                case EFrictionGroundType.SUPES_TVERD: return 0.5;
                case EFrictionGroundType.SUPES_PLAST: return 0.35;
                case EFrictionGroundType.PESOK_MAOLOVLAGNIY: return 0.55;
                case EFrictionGroundType.PESOK_VLAGNIY: return 0.45;
                case EFrictionGroundType.SKALA: return 0.75;
                default: return -1;
            }
        }
        /// <summary>
        /// Коэф. надежности по табл. 6.10 3041тмт2
        /// </summary>
        /// <param name="type">тип опоры</param>
        /// <returns></returns>
        static double GetKoefNadegnosti(ESupportType type)
        {
            switch (type)
            {
                case ESupportType.Promegutochnaya: return 1;
                case ESupportType.AnkernayaPryamayaBezRaznTyageniy: return 1.2;
                case ESupportType.AnkerUglKoncevaya: return 1.3;
                case ESupportType.Special: return 1.7;
                default: return 0;
            }
        }

        static double GetKoefUslRaboti(GroundObj Ground, bool IsDrilled)
        {
            if(IsDrilled)   
            //сверленый котлован - грунт ненарушенной стр-ры
            {
                switch (Ground.Type)
                {
                    case EGroundType.PesokGravelistiy: return 1.1;
                    case EGroundType.PesokSredKrupnosti: return 1.05;
                    case EGroundType.PesokMelkiy: return 1.1;
                    case EGroundType.PesokPilevatiy: return 1.15;
                    case EGroundType.Supes:
                        if (Ground.IL <= 0.25) return 1.3;
                        if (Ground.IL > 0.25) return 1.4;
                        break;
                    case EGroundType.Suglinok:
                        if (Ground.IL <= 0.25) return 1.25;                        
                        if (Ground.IL > 0.25) return 1.4;
                        break;
                    case EGroundType.Glina: return 1.5;
                    default: return 0;
                }
            }
            else
            //копаный котлован - грунт нарушенной стр-ры
            {
                switch (Ground.Type)
                {
                    case EGroundType.PesokGravelistiy: return 1.0;
                    case EGroundType.PesokSredKrupnosti: return 1.0;
                    case EGroundType.PesokMelkiy: return 1.0;
                    case EGroundType.PesokPilevatiy: return 1.05;
                    case EGroundType.Supes:
                        if (Ground.IL <= 0.25) return 1.2;
                        if (Ground.IL > 0.25) return 1.3;
                        break;
                    case EGroundType.Suglinok:
                        if (Ground.IL <= 0.25) return 1.15;
                        if (Ground.IL > 0.25) return 1.25;
                        break;
                    case EGroundType.Glina:
                        if (Ground.IL <= 0.5) return 1.3;
                        if (Ground.IL > 0.5) return 1.4;
                        break;
                    default: return 0;
                }
            }
            return 0;
        }

        static double GetNyu(double x)
        {
            double[] ar = new double[42] {0.0634548878833812, 0.0872722295455018, 0.12534091697853, 0.143863487997347, 0.179358497726005, 0.219116240036183, 0.262378142406143, 0.308587059663296, 0.356452358589084, 0.406184583189984, 0.457262665284285, 0.53563349986689, 0.562182302776537, 0.615495538669777, 0.669195207890176, 0.723174239750992, 0.76806635948742, 0.831592793445729, 0.892624418795094, 0.940723526556998, 1, 7, 6.46689013789652, 5.79224552048345, 5.52951158284358, 5.10872734085848, 4.723576427565, 4.37534394914281, 4.06407386318733, 3.79394771260713, 3.55834942638038, 3.35477903829024, 3.10149322982397, 3.0287523067067, 2.89868472022009, 2.78530951631479, 2.68463842947831, 2.60794842579344, 2.50918520194511, 2.43635160984468, 2.40047908984234, 2.3732265529452 };
            double res = 0;
            EngMath.InterpOne(ar, x, 21, ref res);
            return res;
        }
    }
}
