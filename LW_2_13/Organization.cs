using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW_2_13
{
    public class Organization : IComparable, ICloneable, IExecutable
    {
        public string Name { get; set; }
        public string City { get; set; }
        public double AverageSalary { get; set; }

        public Organization(string name, string locationCity, double avgSalary)
        {
            Name = name;
            City = locationCity;
            AverageSalary = avgSalary;
        }

        public Organization(ref Random rn)
        {
            string[] names = { "Alpha", "Bravo", "Charlie", "Delta", "Echo", "Foxtrot", "Golf", "Hotel", "India", "Juliet", "Kilo", "Lima", "Mike" };
            string[] cities = { "Magadan", "Arhangelsk", "Sochi", "Moscow", "Omsk" };
            Name = names[rn.Next(0, names.Length)];
            City = cities[rn.Next(0, cities.Length)];
            AverageSalary = rn.Next(0, 1000) + rn.NextDouble();
        }

        public virtual string Print()
        {
            string res = "";
            res += "Organisation name: " + Name + "\n";
            res += "Location city: " + City + "\n";
            res += "Average salary:" + AverageSalary + "\n";
            return res;
        }

        public override string ToString()
        {
            return $"{Name}:{City}:{AverageSalary}";
        }

        public int CompareTo(object? obj)
        {
            Organization org = obj as Organization;
            int res = 1;
            if (org != null)
            {
                res = this.Name.CompareTo(org.Name);
                if (res == 0)
                {
                    res = this.City.CompareTo(org.City);
                }
                if (res == 0)
                {
                    res = this.AverageSalary.CompareTo(org.AverageSalary);
                }
            }
            return res;
        }

        public object Clone()
        {
            var res = (Organization)this.MemberwiseClone();
            res.Name += " clone";
            return res;
        }

        public override bool Equals(object? obj)
        {
            Organization org = obj as Organization;

            if (org == null) return false;

            return this.Name.Equals(org.Name) && this.City.Equals(org.City)
                && this.AverageSalary.Equals(org.AverageSalary);
        }
    }
}
