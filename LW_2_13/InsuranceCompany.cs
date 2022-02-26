using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW_2_13
{
    public class InsuranceCompany : Organization, IComparable, ICloneable, IExecutable
    {
        public int NumberOfClients { get; set; }

        public InsuranceCompany(string name, string locationCity, int numOfClients, double avgSalary) 
            : base(name, locationCity, avgSalary)
        {
            NumberOfClients = numOfClients;
        }

        public InsuranceCompany(ref Random rn) : base(ref rn)
        {
            NumberOfClients = rn.Next(0, 100);
        }

        public override string Print()
        {
            string res = base.Print();
            res += $"Number of clients: {NumberOfClients}\n";
            return res;
        }
        public override string ToString()
        {
            return $"Insurance {base.ToString()}; clients:{NumberOfClients}";
        }


        public new int CompareTo(object obj)
        {
            InsuranceCompany org = obj as InsuranceCompany;
            int res = 1;
            if (org != null)
            {
                res = base.CompareTo(org);
                if (res == 0)
                {
                    res = this.NumberOfClients.CompareTo(org.NumberOfClients);
                }
            }
            return res;
        }

        public new object Clone()
        {
            var res = (InsuranceCompany)this.MemberwiseClone();
            res.Name += " clone";
            return res;
        }
    }
}
