using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentExam
{
    internal class Student
    {
        private string _fullName;
        private int _no;
        public Dictionary<string, double> exams = new Dictionary<string, double>();

        public void AddExam(string examName, double point)
        {
            exams.Add(examName, point);
        }
        public double GetExamResult(string examName)
        {
            if (exams.ContainsKey(examName))
            {
                return exams[examName];
            }
            else
            {
                return -1;
            }
        }
        public double GetExamAvg()
        {
            if (exams.Count > 0)
            {
                double sum = 0;

                foreach (var examPoint in exams.Values)
                {
                    sum += examPoint;
                }

                return sum / exams.Count;
            }
            else
            {
                return 0;
            }
        }



        public int No
        {
            get { return _no; }
            set
            {
                if (value > 0)
                {
                    _no = value;
                }
                else
                {
                    Console.WriteLine("Error:Telebe nomresi 0-dan boyuk olmalidir");
                }
            }
        }
        public string FullName
        {
            get { return _fullName; }
            set
            {
                if (CheckName(value))
                {
                    _fullName = value;
                }
                else
                {
                    Console.WriteLine("Error:Fullname ad ve soyaddan ibaret olmalidir.");
                }
            }
        }

    public static bool CheckName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Error: Fullname bosh olmamalidir.");
                return false;
            }

            string[] nameParts = name?.Split(' ');

            if (nameParts == null || nameParts.Length != 2)
            {
                Console.WriteLine("Error:Fullname ad ve soyaddan ibaret olmalidir.");
                return false;
            }

            foreach (var part in nameParts)
            {
                if (string.IsNullOrWhiteSpace(part))
                {
                    Console.WriteLine("Error: Fullname daxilinde boshluq olmamalidir.");
                    return false;
                }

                for (int j = 0; j < part.Length; j++)
                {
                    if (!char.IsLetter(part[j]))
                    {
                        Console.WriteLine("Error: Fullname yalniz herflerden ibaret olmalidir.");
                        return false;
                    }
                }
            }

            return true;
        }
    }
}

