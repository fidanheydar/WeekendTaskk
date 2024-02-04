using System;
using System.Collections.Generic;

namespace StudentExam
{
    internal class Program
    {
        static void Main()
        {
            List<Student> students = new List<Student>();

            string opt;
            do
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Telebe elave et");
                Console.WriteLine("2. Telebeye imtahan elave et");
                Console.WriteLine("3. Telebenin bir imtahan balina bax");
                Console.WriteLine("4. Telebenin bütün imtahanlarini göster");
                Console.WriteLine("5. Telebenin imtahan ortalamasini göster");
                Console.WriteLine("6. Telebeden imtahan sil");
                Console.WriteLine("0. Proqrami Bitir");

                Console.Write("Sechim daxil edin: ");
                opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        AddStudent(students);
                        break;
                    case "2":
                        AddExam(students);
                        break;
                    case "3":
                        ShowExamResult(students);
                        break;
                    case "4":
                        ShowAllExamsAndResults(students);
                        break;
                    case "5":
                        ShowAverageExamScore(students);
                        break;
                    case "6":
                        RemoveExamFromStudent(students);
                        break;

                    case "0":
                        Console.WriteLine("Chixhish....");
                        break;

                    default:
                        Console.WriteLine("Yalnish sechim zehmet olmasa duzgun sechim daxil edin!");
                        break;
                }

            } while (opt != "0");
        }

        static void AddStudent(List<Student> students)
        {
            string fullName;
            do
            {
                Console.Write("Telebenin Fullname'ni daxil edin: ");
                fullName = Console.ReadLine();
            } while (!Student.CheckName(fullName));

            Student student = new Student
            {
                No = students.Count + 1,
                FullName = fullName
            };

            students.Add(student);
            Console.WriteLine($"Telebe {student.No} - {student.FullName} ughurla elave olundu.");
        }
        static void AddExam(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Telebe siyahisi boshdur ilk once telebe elave edin.");
                return;
            }

            string examName;
            do
            {
                Console.Write("Imtahan adini daxil edin: ");
                examName = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(examName));

            double examPoint;
            do
            {
                Console.Write("Imtahan neticesini daxil edin: ");
            } while (!double.TryParse(Console.ReadLine(), out examPoint) || examPoint < 0 || examPoint > 100);

            int studentNo;
            do
            {
                Console.Write("Telebenin No'ni daxil edin: ");
            } while (!int.TryParse(Console.ReadLine(), out studentNo) || studentNo <= 0 || studentNo > students.Count);

            students[studentNo - 1].AddExam(examName, examPoint);
            Console.WriteLine($"Imtahan ugurla elave olundu: {examName}, Giymet: {examPoint}");
        }
        static void ShowExamResult(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Telebe siyahisi boshdur ilk once telebe elave edin.");
                return;
            }

            int studentNo;
            do
            {
                Console.Write("Telebenin No-sunu daxil edin: ");
            } while (!int.TryParse(Console.ReadLine(), out studentNo) || studentNo <= 0 || studentNo > students.Count);

            string examName;
            do
            {
                Console.Write("Imtahan adini daxil edin: ");
                examName = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(examName));

            double examResult = students[studentNo - 1].GetExamResult(examName);

            if (examResult != -1)
            {
                Console.WriteLine($"Telebe {studentNo} - {students[studentNo - 1].FullName}, {examName}  Imtahan neticesi: {examResult}");
            }
            else
            {
                Console.WriteLine($"Xeta:telebenin imtahani tapilmadi.");
            }
        }
        static void ShowAllExamsAndResults(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Telebe siyahisi boshdur ilk once telebe elave edin.");
                return;
            }

            int studentNo;
            do
            {
                Console.Write("Telebenin No'ni daxil edin: ");
            } while (!int.TryParse(Console.ReadLine(), out studentNo) || studentNo <= 0 || studentNo > students.Count);

            Student student = students[studentNo - 1];

            if (student.exams.Count == 0)
            {
                Console.WriteLine($"Telebe {studentNo} - {student.FullName} hechbir imtahani yoxdur.");
            }
            else
            {
                Console.WriteLine($"Telebe {studentNo} - {student.FullName} uchun neticeler:");

                foreach (var exam in student.exams)
                {
                    Console.WriteLine($"{exam.Key}: {exam.Value}");
                }
            }
        }
        static void ShowAverageExamScore(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Telebe siyahisi boshdur ilk once telebe elave edin.");
                return;
            }

            int studentNo;
            do
            {
                Console.Write("Telebenin No'ni daxil edin: ");
            } while (!int.TryParse(Console.ReadLine(), out studentNo) || studentNo <= 0 || studentNo > students.Count);

            Student student = students[studentNo - 1];

            if (student.exams.Count == 0)
            {
                Console.WriteLine($"Telebe {studentNo} - {student.FullName} hechbir imtahani yoxdur.");
            }
            else
            {
                double averageScore = student.GetExamAvg();
                Console.WriteLine($"Telebe {studentNo} - {student.FullName} uchun imtahan neticelerinin ortalamasi: {averageScore}");
            }
        }
        static void RemoveExamFromStudent(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Telebe siyahisi boshdur ilk once telebe elave edin.");
                return;
            }

            int studentNo;
            do
            {
                Console.Write("Telebenin No'ni daxil edin: ");
            } while (!int.TryParse(Console.ReadLine(), out studentNo) || studentNo <= 0 || studentNo > students.Count);

            Student student = students[studentNo - 1];

            if (student.exams.Count == 0)
            {
                Console.WriteLine($"Telebe {studentNo} - {student.FullName} hechbir imtahani yoxdur.");
            }
            else
            {
                string examName;
                do
                {
                    Console.Write("Silinecek imtahan adini daxil edin: ");
                    examName = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(examName));

                if (student.exams.ContainsKey(examName))
                {
                    student.exams.Remove(examName);
                    Console.WriteLine($"Telebe {studentNo} - {student.FullName} uchun {examName} imtahan deyeri ugurla silindi.");
                }
                else
                {
                    Console.WriteLine($"Xeta:telebenin imtahani tapilmadi.");
                }
            }
        }






    }


}
