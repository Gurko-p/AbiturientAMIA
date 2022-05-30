﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    public class Abiturient : IComparable<Abiturient>
    {

        public int Id { get; set; }
        public string FIO { get; set; }
        public int Sex { get; set; }
        public int Result { get; set; }
        public int Lgota { get; set; }
        public int[] Specialities { get; set; }
        public Abiturient() { }
        public Abiturient(Abiturient a)
        {
            Id = a.Id; Result = a.Result; Specialities = a.Specialities;
        }
        public int CompareTo(Abiturient a)
        {
            return a.Result.CompareTo(Result);
        }
        public static bool Contains(Abiturient[] a, Abiturient b)
        {
            bool res = false;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i].Id == b.Id)
                {
                    res = true;
                    break;
                }
            }
            return res;
        }

        public static int CompareArrayLists(ArrayList al1, ArrayList al2)
        {
            for (int i = 0; i < al1.Count; i++)
            {
                if (Convert.ToInt32(al1[i]) > Convert.ToInt32(al2[i]))
                {
                    return 1;
                }
                else if (Convert.ToInt32(al1[i]) < Convert.ToInt32(al2[i]))
                {
                    return -1;
                }
            }
            return 0;
        }
}
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<int, List<int>> lgots = new Dictionary<int, List<int>>
            //{
            //    [9] = new List<int> { 9999 },
            //    [8] = new List<int> { 9999 },
            //    [7] = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 13, 14 },
            //    [6] = new List<int> { 6, 11, 13 },
            //    [5] = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 13, 14 },
            //    [4] = new List<int> { 9999 },
            //    [3] = new List<int> { 3, 6, 11, 13 },
            //    [2] = new List<int> { 9999 },
            //    [1] = new List<int> { 9999 },
            //};

            //List<Abiturient> ab = new List<Abiturient>
            //{
            //    new Abiturient { Id = 1, FIO = "Иванов", Sex = 1, Lgota = 1, Result = 180, Specialities = new int[]{ 2, 1 } }, // 2
            //    new Abiturient { Id = 2, FIO = "Петров", Sex = 1, Lgota = 0, Result = 330, Specialities = new int[]{ 1, 0 } }, // 2
            //    new Abiturient { Id = 3, FIO = "Сидоров", Sex = 1, Lgota = 2, Result = 181, Specialities = new int[]{ 1, 2 } }, // 2
            //    new Abiturient { Id = 4, FIO = "Смирнов", Sex = 1, Lgota = 1, Result = 237, Specialities = new int[]{ 1, 2 } }, // 2
            //    new Abiturient { Id = 5, FIO = "Хващевский", Sex = 1, Lgota = 2, Result = 280, Specialities = new int[]{ 1, 2 } }, // 2
            //    new Abiturient { Id = 6, FIO = "Сидоров", Sex = 1, Lgota = 0, Result = 300, Specialities = new int[]{ 1, 2 } }, // 2
            //    new Abiturient { Id = 7, FIO = "Сидоров", Sex = 1, Lgota = 0, Result = 320, Specialities = new int[]{ 1, 2 } }, // 2
            //};

            //ab.Sort();

            //List<Abiturient> failed = new List<Abiturient>();
            //List<int> success = new List<int>();

            //List<Abiturient> sp1 = new List<Abiturient>(3);
            //List<Abiturient> sp2 = new List<Abiturient>(2);
            //Dictionary<string, List<Abiturient>> dict = new Dictionary<string, List<Abiturient>>()
            //{
            //    ["sp1"] = sp1,
            //    ["sp2"] = sp2,
            //};

            //foreach (var num in lgots)
            //{
            //    List<Abiturient> lgota = ab.Where(a => a.Lgota == num.Key).ToList();

            //    for (int i = 0; i < 2; i++)
            //    {
            //        for (int j = 0; j < lgota.Count; j++)
            //        {
            //            int sp = lgota[j].Specialities[i];
            //            Dictionary<string, List<Abiturient>> abiturients = dict;
            //            if (sp != 0 && lgots[lgota[j].Lgota].Contains(sp) && lgota[j].Lgota == 1)
            //            {
            //                if (abiturients["sp" + sp].Count < Math.Round(abiturients["sp" + sp].Capacity * 0.3) )
            //                {
            //                    if (!success.Contains(lgota[j].Id))
            //                    {
            //                        abiturients["sp" + sp].Add(lgota[j]);
            //                        success.Add(lgota[j].Id);
            //                    }
            //                }
            //                else
            //                {
            //                    int minResSp = abiturients["sp" + sp].Min(a => a.Result);
            //                    int countMinAbiturient = abiturients["sp" + sp].Where(a => a.Result == minResSp).Count();
            //                    if (countMinAbiturient == 1)
            //                    {
            //                        Abiturient a = abiturients["sp" + sp].Where(a => a.Result == minResSp).LastOrDefault();
            //                        if (lgota[j].Result > minResSp && !success.Contains(lgota[j].Id))
            //                        {
            //                            abiturients["sp" + sp].Remove(a);
            //                            abiturients["sp" + sp].Add(lgota[j]);
            //                            success.Remove(a.Id);
            //                            success.Add(lgota[j].Id);
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (lgota[j].Result == minResSp && !success.Contains(lgota[j].Id))
            //                        {
            //                            Console.WriteLine("Есть равные баллы среди абитуриентов!");
            //                            List<Abiturient> abits = abiturients["sp" + sp].Where(a => a.Result == minResSp).ToList();
            //                            foreach (var abiturient in abits)
            //                            {
            //                                Console.WriteLine(abiturient.Id + " - " + abiturient.Result);
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            //for (int x = 0; x < success.Count; x++)
            //{
            //    Abiturient a = ab.FirstOrDefault(a => a.Id == success[x]);
            //    ab.Remove(a);
            //}

            //for (int i = 0; i < success.Count; i++)
            //{
            //    Console.WriteLine(success[i]);
            //}

            //зачисление по общим основаниям

            //for (int i = 0; i < 2; i++)
            //{
            //    for (int j = 0; j < ab.Count; j++)
            //    {
            //        int sp = ab[j].Specialities[i];
            //        Dictionary<string, List<Abiturient>> abiturients = dict;
            //        if (sp != 0)
            //        {
            //            if (abiturients["sp" + sp].Count < abiturients["sp" + sp].Capacity)
            //            {
            //                if (!success.Contains(ab[j].Id))
            //                {
            //                    abiturients["sp" + sp].Add(ab[j]);
            //                    success.Add(ab[j].Id);
            //                }
            //            }
            //            else
            //            {
            //                int minResSp = abiturients["sp" + sp].Min(a => a.Result);
            //                int countMinAbiturient = abiturients["sp" + sp].Where(a => a.Result == minResSp).Count();
            //                if (countMinAbiturient == 1)
            //                {
            //                    Abiturient a = abiturients["sp" + sp].Where(a => a.Result == minResSp).LastOrDefault();
            //                    if (ab[j].Result > minResSp && !success.Contains(ab[j].Id) && !success.Contains(a.Id))
            //                    {
            //                        abiturients["sp" + sp].Remove(a);
            //                        abiturients["sp" + sp].Add(ab[j]);
            //                        success.Remove(a.Id);
            //                        Console.WriteLine(a.Id);
            //                        success.Add(ab[j].Id);
            //                    }
            //                }
            //                else
            //                {
            //                    if (ab[j].Result == minResSp && !success.Contains(ab[j].Id))
            //                    {
            //                        Console.WriteLine("Есть равные баллы среди абитуриентов!");
            //                        List<Abiturient> abits = abiturients["sp" + sp].Where(a => a.Result == minResSp).ToList();
            //                        foreach (var abiturient in abits)
            //                        {
            //                            Console.WriteLine(abiturient.Id + " - " + abiturient.Result);
            //                        }
            //                    }
            //                }
            //            }
            //            if (i + 1 >= ab[j].Specialities.Length && !success.Contains(ab[j].Id) && !failed.Contains(ab[j]))
            //            {
            //                failed.Add(ab[j]);
            //            }
            //        }
            //        else
            //        {
            //            if (!success.Contains(ab[j].Id) && !failed.Contains(ab[j]))
            //            {
            //                failed.Add(ab[j]);
            //            }
            //        }
            //    }
            //}



            //Console.WriteLine("Spec1");
            //for (int i = 0; i < dict["sp1"].Count; i++)
            //{
            //    Console.WriteLine(dict["sp1"][i].Id + " - " + dict["sp1"][i].Result);
            //}
            //Console.WriteLine(" ----------------------------- ");
            //Console.WriteLine("Spec2");
            //for (int i = 0; i < dict["sp2"].Count; i++)
            //{
            //    Console.WriteLine(dict["sp2"][i].Id + " - " + dict["sp2"][i].Result);
            //}


            //Console.WriteLine(" ----------------------------- ");
            //Console.WriteLine("Success");
            //for (int i = 0; i < success.Count; i++)
            //{
            //    Console.WriteLine(success[i]);
            //}

            //Console.WriteLine(" ----------------------------- ");
            //Console.WriteLine("Failed");
            //for (int i = 0; i < failed.Count; i++)
            //{
            //    Console.WriteLine(failed[i].Id);
            //}

            //преимущественное право на зачисление при равном количестве баллов среди льготников
            ArrayList arrayList1 = new ArrayList() { 9, 8, 7, 7, true, true, 85 };
            ArrayList arrayList2 = new ArrayList() { 9, 8, 7, 7, true, true, 85 };

            Console.WriteLine(Abiturient.CompareArrayLists(arrayList1, arrayList2));

            Console.ReadKey();
        }
    }
}
