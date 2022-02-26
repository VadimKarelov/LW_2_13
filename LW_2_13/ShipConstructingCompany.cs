using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW_2_13
{
    public class ShipConstructingCompany : Organization, IComparable, ICloneable, IExecutable
    {
        public int ShipConstructed { get; set; }

        public ShipConstructingCompany(string name, string locationCity, double avgSalary) 
            : base(name, locationCity, avgSalary)
        {
            ShipConstructed = 0;
        }

        public ShipConstructingCompany(ref Random rn) : base(ref rn)
        {
            ShipConstructed = rn.Next(0, 1000);
        }

        public override string Print()
        {
            string res = base.Print();
            res += $"Number of constructed ships: {ShipConstructed}\n";
            return res;
        }

        public override string ToString()
        {
            return $"Ship construction {base.ToString()}; ships:{ShipConstructed}";
        }

        public new int CompareTo(object obj)
        {
            ShipConstructingCompany org = obj as ShipConstructingCompany;
            int res = 1;
            if (org != null)
            {
                res = base.CompareTo(org);
                if (res == 0)
                {
                    res = this.ShipConstructed.CompareTo(org.ShipConstructed);
                }
            }
            return res;
        }

        public new object Clone()
        {
            var res = (ShipConstructingCompany)this.MemberwiseClone();
            res.Name += " clone";
            return res;
        }
    }
}
