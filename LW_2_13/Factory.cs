using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW_2_13
{
    public class Factory : Organization, IComparable, ICloneable, IExecutable
    {
        public string Production { get; set; }

        public Organization HeadOrganization { get; set; }

        public Factory(string name, string locationCity, string production, double avgSalary) 
            : base(name, locationCity, avgSalary)
        {
            Production = production;
            HeadOrganization = null;
        }

        public Factory(ref Random rn) : base(ref rn)
        {
            string[] products = { "Phones", "Tables", "Chairs", "Lamps" };
            Production = products[rn.Next(0, products.Length)];
            HeadOrganization = null;
        }

        public override string Print()
        {
            string res = base.Print();
            res += $"Type of production: {Production}\n";
            if (HeadOrganization != null) res += $"Head organisation: {HeadOrganization.Name}\n";
            return res;
        }
        public override string ToString()
        {
            return $"Factory {base.ToString()}";
        }


        public new int CompareTo(object obj)
        {
            Factory org = obj as Factory;
            int res = 1;
            if (org != null)
            {
                res = base.CompareTo(org);
                if (res == 0)
                {
                    res = this.Production.CompareTo(org.Production);
                }
                if (res == 0)
                {
                    res = this.HeadOrganization.CompareTo(org.HeadOrganization);
                }
            }
            return res;
        }

        // copy == clone
        // shallow
        public new Factory Clone()
        {
            Factory res = (Factory)this.MemberwiseClone();
            res.Name += " clone";
            return res;
        }

        // deep
        public Factory DeepClone()
        {
            Factory res = (Factory)this.MemberwiseClone();
            res.Name += " clone";
            res.HeadOrganization = (Organization)HeadOrganization.Clone();
            return res;
        }
    }
}
