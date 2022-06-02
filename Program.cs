using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{

    public static class Methods<T>
    {
        public static bool RemoveLowerAddHigher(List<T> list, T deleted, T added)
        {
            if (list.Contains(deleted))
            {
                list.Remove(deleted);
                list.Add(added);
                return true;
            }
            return false;
        }
    }

    public class Abiturient : IComparable<Abiturient>
    {

        public int Id { get; set; }
        public string FIO { get; set; }
        public int Sex { get; set; }
        public int Lgota { get; set; }
        public short FirstCT { get; set; }
        public short SecondCT { get; set; }
        public short RusCT { get; set; }
        public short BallAttestat { get; set; }
        public int Result { get; set; }
        public int[] Specialities { get; set; }
        public short FirstProfBallAtt { get; set; }
        public short SecondProfBallAtt { get; set; }
        public short RusBelSum { get; set; }
        public bool Ideas100ForRB { get; set; }
        public bool KindHearth { get; set; }
        public bool Sotr { get; set; }
        public bool PK { get; set; }
        public bool MOOP { get; set; }
        public Abiturient() { }

        public int CompareTo(Abiturient a)
        {
            return a.Result - Result;
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

        public static int CompareLgotsPower(Abiturient ab1, Abiturient ab2)
        {
            if (ab1.Lgota > ab2.Lgota)
            {
                return 1;
            }
            else if (ab1.Lgota < ab2.Lgota)
            {
                return -1;
            }
            return 0;
        }
        public static Abiturient FindAbiturientWithLowerLgots(List<Abiturient> abs)
        {
            int count = abs.Where(a => a.Lgota == abs[0].Lgota).Count();
            int min = 0;
            Abiturient abiturientMin = null;
            if (abs.Count == count)
            {
                Console.WriteLine("Льготы в списке абитуриентов равны!");
                return null;
            }
            else if (count > 1)
            {
                min = abs[0].Lgota;
                abiturientMin = abs[0];
                for (int i = 0; i < abs.Count; i++)
                {
                    if (abs[i].Lgota < min)
                    {
                        min = abs[i].Lgota;
                        abiturientMin = abs[i];
                    }
                }
            }
            return abiturientMin;
        }

        public static int CompareWhenEqualAmountGeneral(Abiturient ab1, Abiturient ab2) // преимущественное право при зачислении на общих основаниях
        {
            ArrayList arrayList1 = new ArrayList()
            {
                ab1.FirstCT,
                ab1.SecondCT,
                ab1.FirstProfBallAtt,
                ab1.SecondProfBallAtt,
                ab1.Ideas100ForRB,
                ab1.KindHearth,
                ab1.BallAttestat,
                ab1.Sotr,
                ab1.PK,
                ab1.MOOP
            };
            ArrayList arrayList2 = new ArrayList()
            {
                ab2.FirstCT,
                ab2.SecondCT,
                ab2.FirstProfBallAtt,
                ab2.SecondProfBallAtt,
                ab2.Ideas100ForRB,
                ab2.KindHearth,
                ab2.BallAttestat,
                ab2.Sotr,
                ab2.PK,
                ab2.MOOP
            };
            return CompareArrayLists(arrayList1, arrayList2);
        }
        public static int CompareWhenEqualAmountLgota24(Abiturient ab1, Abiturient ab2) // преимущественное право при зачислении по п. 24 Правил
        {
            ArrayList arrayList1 = new ArrayList()
            {
                ab1.FirstProfBallAtt,
                ab1.SecondProfBallAtt,
                ab1.Ideas100ForRB,
                ab1.KindHearth,
                ab1.BallAttestat,
                ab1.RusBelSum,
                ab1.MOOP,
                ab1.FirstCT,
                ab1.SecondCT,
            };
            ArrayList arrayList2 = new ArrayList()
            {
                ab2.FirstProfBallAtt,
                ab2.SecondProfBallAtt,
                ab2.Ideas100ForRB,
                ab2.KindHearth,
                ab2.BallAttestat,
                ab2.RusBelSum,
                ab2.MOOP,
                ab2.FirstCT,
                ab2.SecondCT,
            };
            return CompareArrayLists(arrayList1, arrayList2);
        }
        public static int CompareWhenEqualAmountLgota26(Abiturient ab1, Abiturient ab2) // преимущественное право при зачислении по п. 26 Правил
        {
            ArrayList arrayList1 = new ArrayList()
            {
                ab1.FirstCT,
                ab1.SecondCT,
                ab1.FirstProfBallAtt,
                ab1.SecondProfBallAtt,
                ab1.Ideas100ForRB,
                ab1.KindHearth,
                ab1.BallAttestat,
                ab1.PK,
                ab1.MOOP
            };
            ArrayList arrayList2 = new ArrayList()
            {
                ab2.FirstCT,
                ab2.SecondCT,
                ab2.FirstProfBallAtt,
                ab2.SecondProfBallAtt,
                ab2.Ideas100ForRB,
                ab2.KindHearth,
                ab2.BallAttestat,
                ab2.PK,
                ab2.MOOP
            };
            return CompareArrayLists(arrayList1, arrayList2);
        }
        public static Abiturient FindAbiturientWithLowerBalls24(List<Abiturient> abs)
        {
            Dictionary<int, ArrayList> abiturients = new Dictionary<int, ArrayList>();
            for (int i = 0; i < abs.Count; i++)
            {
                ArrayList arrayList = new ArrayList()
                {
                    abs[i].FirstProfBallAtt,
                    abs[i].SecondProfBallAtt,
                    abs[i].Ideas100ForRB,
                    abs[i].KindHearth,
                    abs[i].BallAttestat,
                    abs[i].RusBelSum,
                    abs[i].MOOP,
                    abs[i].FirstCT,
                    abs[i].SecondCT,
                };
                abiturients[abs[i].Id] = arrayList;
            }

            Abiturient min = abs.FirstOrDefault();
            ArrayList listToCompareMin = abiturients[min.Id];

            foreach (var al in abiturients)
            {
                if (al.Key != min.Id)
                {
                    int res = CompareArrayLists(al.Value, listToCompareMin);
                    if (res == 1)
                    {
                        continue;
                    }
                    else if (res == -1)
                    {
                        listToCompareMin = al.Value;
                        min = abs.FirstOrDefault(a => a.Id == al.Key);
                    }
                    else
                    {
                        min = null;
                        Console.WriteLine("Есть абитуриенты с равными баллами");
                    }
                }
            }
            return min;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, List<int>> lgots = new Dictionary<int, List<int>>
            {
                [9] = new List<int> { 9999 },
                [8] = new List<int> { 9999 },
                [7] = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 13, 14 },
                [6] = new List<int> { 6, 11, 13 },
                [5] = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 13, 14 },
                [4] = new List<int> { 9999 },
                [3] = new List<int> { 3, 6, 11, 13 },
                [2] = new List<int> { 9999 },
                [1] = new List<int> { 9999 },
            };


            Dictionary<int, double> capacityLgots = new Dictionary<int, double>
            {
                [9] = 1,
                [8] = 1,
                [7] = 0.3,
                [6] = 0.3,
                [5] = 0.3,
                [4] = 0.3,
                [3] = 0.3,
                [2] = 0.1,
                [1] = 1.0,
            };



            List<Abiturient> ab = new List<Abiturient>
            {
                new Abiturient
                {
                    Id = 1,
                    FIO = "Иванов Иван Иванович",
                    Sex = 1,
                    Lgota = 8,
                    FirstCT = 98,
                    SecondCT = 100,
                    BallAttestat = 98,
                    Result = 297,
                    Specialities = new int[]{ 1, 0 },
                    FirstProfBallAtt = 10,
                    SecondProfBallAtt = 9,
                    RusBelSum = 14,
                    Ideas100ForRB = true,
                    KindHearth = true,
                    MOOP = true,
                },
                new Abiturient
                {
                    Id = 2,
                    FIO = "Петров Петр Петрович",
                    Sex = 1,
                    Lgota = 9,
                    FirstCT = 100,
                    SecondCT = 100,
                    BallAttestat = 100,
                    Result = 300,
                    Specialities = new int[]{ 1, 0 },
                    FirstProfBallAtt = 9,
                    SecondProfBallAtt = 9,
                    RusBelSum = 14,
                    Ideas100ForRB = true,
                    KindHearth = true,
                    MOOP = true,
                },
                new Abiturient
                {
                    Id = 3,
                    FIO = "Сидоров Сидор Сидорович",
                    Sex = 1,
                    Lgota = 9,
                    FirstCT = 100,
                    SecondCT = 100,
                    BallAttestat = 100,
                    Result = 300,
                    Specialities = new int[]{ 1, 0 },
                    FirstProfBallAtt = 9,
                    SecondProfBallAtt = 9,
                    RusBelSum = 14,
                    Ideas100ForRB = true,
                    KindHearth = true,
                    MOOP = true,
                },
                new Abiturient
                {
                    Id = 4,
                    FIO = "Степанов Степан Степанович",
                    Sex = 1,
                    Lgota = 7,
                    FirstCT = 100,
                    SecondCT = 50,
                    BallAttestat = 75,
                    Result = 225,
                    Specialities = new int[]{ 1, 2 },
                    FirstProfBallAtt = 8,
                    SecondProfBallAtt = 9,
                    Ideas100ForRB = true,
                    KindHearth = true,
                    MOOP = true,
                },
                new Abiturient
                {
                    Id = 5,
                    FIO = "Макаров Макар Макарович",
                    Sex = 1,
                    Lgota = 7,
                    FirstCT = 30,
                    SecondCT = 60,
                    BallAttestat = 55,
                    Result = 145,
                    Specialities = new int[]{ 1, 2 },
                    FirstProfBallAtt = 6,
                    SecondProfBallAtt = 6,
                    Ideas100ForRB = true,
                    KindHearth = true,
                    MOOP = true,
                },
            };

            ab.Sort();

            List<Abiturient> failed = new List<Abiturient>();
            List<int> success = new List<int>();

            List<Abiturient> sp1 = new List<Abiturient>(10);
            List<Abiturient> sp2 = new List<Abiturient>(10);
            Dictionary<string, List<Abiturient>> abiturients = new Dictionary<string, List<Abiturient>>()
            {
                ["sp1"] = sp1,
                ["sp2"] = sp2,
            };

            List<Abiturient> abiturientsLgota = ab.Where(a => a.Lgota >= 9).OrderByDescending(a => a.Lgota).ToList();

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < abiturientsLgota.Count; j++)
                {
                    int sp = abiturientsLgota[j].Specialities[i]; // id специальности
                    int lgota = abiturientsLgota[j].Lgota; // id льготы
                    if (sp != 0 && (lgots[lgota].Contains(sp) || lgots[lgota].Contains(9999))) // если специальность не равна 0 и льгота распространияется на указанную специальность и
                    {
                        int capacity = 0;
                        int capacityLgot = (int)Math.Round(abiturients["sp" + sp].Count + (abiturients["sp" + sp].Capacity * capacityLgots[lgota]));
                        if (capacityLgot <= abiturients["sp" + sp].Capacity)
                        {
                            capacity = capacityLgot;
                        }
                        else
                        {
                            capacity = abiturients["sp" + sp].Capacity;
                        }
                        if (abiturients["sp" + sp].Count < abiturients["sp" + sp].Capacity) // если количество абитуриетнов на указанную специальность  меньше количества выделенных мест и
                        {
                            if (!success.Contains(abiturientsLgota[j].Id)) // если текущий абитуриент еще не зачислен
                            {
                                abiturients["sp" + sp].Add(abiturientsLgota[j]); // добавляем абитуриента на указанную им специальность
                                success.Add(abiturientsLgota[j].Id); // добавляем его идентификатор в лист зачисленных абитуриентов
                            }
                        }
                        else
                        {

                            int minResSp = abiturients["sp" + sp].Min(a => a.Result); // находим минимальный общий результат
                            int countMinAbiturient = abiturients["sp" + sp].Where(a => a.Result == minResSp).Count(); // количество абитуриентов с минимальным баллом
                            if (countMinAbiturient == 1) // если количество абитуриентов на указанную специальность с минимальным баллом  равно 1
                            {
                                Abiturient a = abiturients["sp" + sp].Where(a => a.Result == minResSp).LastOrDefault(); // находим абитуриента с минимальным баллом
                                if (abiturientsLgota[j].Result > minResSp && !success.Contains(abiturientsLgota[j].Id)) // если балл текущего абитуриента больше чем вышеуказанного и текущий абитуриент еще не зачислен
                                {
                                    Methods<Abiturient>.RemoveLowerAddHigher(abiturients["sp" + sp], a, abiturientsLgota[j]); // заменяем абитуриента с меньшим баллом в списке зачисленных на абитуриента с высшим баллом
                                    Methods<int>.RemoveLowerAddHigher(success, a.Id, abiturientsLgota[j].Id); // заменяем id абитуриента с меньшим баллом на id абитуриента с большим баллом в списке зачисленных
                                }
                                else if (abiturientsLgota[j].Result == minResSp && !success.Contains(abiturientsLgota[j].Id)) // если баллы абитуриентов равны, то сравниваем абитуриентов по правилам преимущественного зачисления
                                {
                                    int res = Abiturient.CompareWhenEqualAmountLgota24(abiturientsLgota[j], a); // сравниваем все баллы абитуриентов
                                    if (res == 1) // если результат равен 1, то баллы текущего абитуриента выше, чем у абитуриента уже зачисленного
                                    {
                                        Methods<Abiturient>.RemoveLowerAddHigher(abiturients["sp" + sp], a, abiturientsLgota[j]); // заменяем абитуриента с меньшим баллом в списке зачисленных на абитуриента с высшим баллом
                                        Methods<int>.RemoveLowerAddHigher(success, a.Id, abiturientsLgota[j].Id); // заменяем id абитуриента с меньшим баллом на id абитуриента с большим баллом в списке зачисленных
                                        //Console.WriteLine(abiturientsLgota[j].Id + " - " + abiturientsLgota[j].FirstCT + " больше, чем " + a.Id + " - " + a.FirstCT);
                                    }
                                    else if (res == 0)
                                    {
                                        Console.WriteLine("Необходимо участие члена приемной комиссии - равные баллы при зачислении на специальность " + sp);
                                        Console.WriteLine(abiturientsLgota[j].FIO + " " + abiturientsLgota[j].Result + " --- " + a.FIO + " - " + a.Result);
                                        Console.Read();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Меньше");
                                    }
                                }
                            }
                            else if (countMinAbiturient > 1)
                            {
                                List<Abiturient> abiturientsWithMinBalls = abiturients["sp" + sp].Where(a => a.Result == minResSp).ToList(); // получаем список абитуриентов с минимальным баллом

                                Abiturient a = Abiturient.FindAbiturientWithLowerBalls24(abiturientsWithMinBalls); // получаем абитуриента из списка с минимальным баллом после проверки по правилам преимущественного зачисления
                                int res = Abiturient.CompareWhenEqualAmountLgota24(abiturientsLgota[j], a); // сравниваем текущего абитуриента с абитуриентом а
                                if (res == 1) // если результат равен 1, то баллы текущего абитуриента выше, чем у абитуриента а
                                {
                                    Methods<Abiturient>.RemoveLowerAddHigher(abiturients["sp" + sp], a, abiturientsLgota[j]); // заменяем абитуриента с меньшим баллом в списке зачисленных на абитуриента с высшим баллом
                                    Methods<int>.RemoveLowerAddHigher(success, a.Id, abiturientsLgota[j].Id); // заменяем id абитуриента с меньшим баллом на id абитуриента с большим баллом в списке зачисленных                                                         
                                }
                                else if (res == 0)
                                {
                                    Console.WriteLine("Необходимо участие члена приемной комиссии - равные баллы при зачислении на специальность " + sp);
                                    Console.WriteLine(abiturientsLgota[j].FIO + " " + abiturientsLgota[j].Result + " --- " + a.FIO + " - " + a.Result);
                                    Console.Read();
                                }
                                else
                                {
                                    Console.WriteLine("Меньше");
                                }
                            }
                        }
                    }
                }
            }


            //for (int i = 0; i < 2; i++)
            //{
            //    for (int j = 0; j < abiturientsLgota.Count; j++)
            //    {
            //        int sp = abiturientsLgota[j].Specialities[i]; // id специальности
            //        int lgota = abiturientsLgota[j].Lgota; // id льготы
            //        if (sp != 0 && (lgots[lgota].Contains(sp) || lgots[lgota].Contains(9999))) // если специальность не равна 0 и льгота распространияется на указанную специальность и
            //        {
            //            if (abiturients["sp" + sp].Count < abiturients["sp" + sp].Capacity) // если количество абитуриетнов на указанную специальность  меньше количества выделенных мест и
            //            {
            //                if (!success.Contains(abiturientsLgota[j].Id)) // если текущий абитуриент еще не зачислен
            //                {
            //                    abiturients["sp" + sp].Add(abiturientsLgota[j]); // добавляем абитуриента на указанную им специальность
            //                    success.Add(abiturientsLgota[j].Id); // добавляем его идентификатор в лист зачисленных абитуриентов
            //                }
            //            }
            //            else
            //            {
            //                //сначала сравниваем льготы у абитуриентов, претендующих на 1 место

            //                int minLgota = abiturients["sp" + sp].Min(a => a.Lgota); // находим минимальную льготу в выбранной специальности
            //                int countMinLgota = abiturients["sp" + sp].Where(a => a.Lgota == minLgota).Count(); 
            //                Abiturient a = null;
            //                List<Abiturient> abiturientsWithMinLgots = null;

            //                if (countMinLgota == 1)
            //                {
            //                    a = abiturients["sp" + sp].Where(a => a.Lgota == minLgota).LastOrDefault(); // находим абитуриента с минимальной льготой
            //                }
            //                else if (countMinLgota > 1)
            //                {
            //                    abiturientsWithMinLgots = abiturients["sp" + sp].Where(a => a.Lgota == minLgota).ToList();
            //                    a = Abiturient.FindAbiturientWithLowerLgots(abiturientsWithMinLgots);
            //                }

            //                if (a != null) // если смогли найти абитуриента с минимальной льготой, то
            //                {
            //                    int res = Abiturient.CompareLgotsPower(abiturientsLgota[j], a); // сравниваем льготы абитуриентов
            //                    if (res == 1) // если результат равен 1, то баллы текущего абитуриента выше, чем у абитуриента уже зачисленного
            //                    {
            //                        Methods<Abiturient>.RemoveLowerAddHigher(abiturients["sp" + sp], a, abiturientsLgota[j]); // заменяем абитуриента с меньшим баллом в списке зачисленных на абитуриента с высшим баллом
            //                        Methods<int>.RemoveLowerAddHigher(success, a.Id, abiturientsLgota[j].Id); // заменяем id абитуриента с меньшим баллом на id абитуриента с большим баллом в списке зачисленных                                                                      //Console.WriteLine(abiturientsLgota[j].Id + " - " + abiturientsLgota[j].FirstCT + " больше, чем " + a.Id + " - " + a.FirstCT);
            //                    }
            //                    // если у абитуриентов равные льготы, то сравниваем их по правилам преимущественного  зачисления для льготников без экзаменов
            //                    else if (res == 0) 
            //                    {
            //                        int minResSp = abiturients["sp" + sp].Where(a => a.Lgota == minLgota).Min(a => a.FirstProfBallAtt); // находим минимальный балл по обществоведению в аттестате
            //                        int countMinAbiturient = abiturients["sp" + sp].Where(a => a.Lgota == minLgota && a.FirstProfBallAtt == minResSp).Count(); // количество абитуриентов с минимальным баллом по обществоведению в аттестате
            //                        if (countMinAbiturient == 1) // если количество абитуриентов на указанную специальность с минимальным баллом  равно 1
            //                        {
            //                            Abiturient a1 = abiturients["sp" + sp].Where(a => a.FirstProfBallAtt == minResSp).LastOrDefault(); // находим абитуриента с минимальным баллом
            //                            if (abiturientsLgota[j].FirstProfBallAtt >= minResSp && !success.Contains(abiturientsLgota[j].Id)) // если балл текущего абитуриента больше чем вышеуказанного и текущий абитуриент еще не зачислен
            //                            {
            //                                int res1 = Abiturient.CompareWhenEqualAmountLgota24(abiturientsLgota[j], a); // сравниваем все баллы абитуриентов
            //                                if (res1 == 1) // если результат равен 1, то баллы текущего абитуриента выше, чем у абитуриента уже зачисленного
            //                                {
            //                                    Methods<Abiturient>.RemoveLowerAddHigher(abiturients["sp" + sp], a, abiturientsLgota[j]); // заменяем абитуриента с меньшим баллом в списке зачисленных на абитуриента с высшим баллом
            //                                    Methods<int>.RemoveLowerAddHigher(success, a.Id, abiturientsLgota[j].Id); // заменяем id абитуриента с меньшим баллом на id абитуриента с большим баллом в списке зачисленных
            //                                                                                                              //Console.WriteLine(abiturientsLgota[j].Id + " - " + abiturientsLgota[j].FirstCT + " больше, чем " + a.Id + " - " + a.FirstCT);
            //                                }
            //                                else if (res1 == 0)
            //                                {
            //                                    Console.WriteLine("Необходимо участие члена приемной комиссии - равные баллы при зачислении на специальность " + sp + " у следующих абитуриентов:");
            //                                    Console.WriteLine(abiturientsLgota[j].FIO + " " + abiturientsLgota[j].FirstProfBallAtt + " --- " + a.FIO + " - " + a.FirstProfBallAtt);
            //                                    Console.Read();
            //                                }
            //                                else
            //                                {
            //                                    Console.WriteLine("Меньше");
            //                                }
            //                            }
            //                        }
            //                        else if (countMinAbiturient > 1)
            //                        {
            //                            List<Abiturient> abiturientsWithMinBalls = abiturients["sp" + sp].Where(a => a.FirstProfBallAtt == minResSp).ToList(); // получаем список абитуриентов с минимальным баллом

            //                            Abiturient a1 = Abiturient.FindAbiturientWithLowerBalls24(abiturientsWithMinBalls); // получаем абитуриента из списка с минимальным баллом после проверки по правилам преимущественного зачисления
            //                            if (a != null) // если смогли определить абитуриента с меньшим баллом, то
            //                            {
            //                                int res1 = Abiturient.CompareWhenEqualAmountLgota24(abiturientsLgota[j], a); // сравниваем текущего абитуриента с абитуриентом а
            //                                if (res1 == 1) // если результат равен 1, то баллы текущего абитуриента выше, чем у абитуриента а
            //                                {
            //                                    Methods<Abiturient>.RemoveLowerAddHigher(abiturients["sp" + sp], a, abiturientsLgota[j]); // заменяем абитуриента с меньшим баллом в списке зачисленных на абитуриента с высшим баллом
            //                                    Methods<int>.RemoveLowerAddHigher(success, a.Id, abiturientsLgota[j].Id); // заменяем id абитуриента с меньшим баллом на id абитуриента с большим баллом в списке зачисленных                                                         
            //                                }
            //                                else if (res1 == 0)
            //                                {
            //                                    Console.WriteLine("Необходимо участие члена приемной комиссии - равные баллы при зачислении на специальность " + sp + " у следующих абитуриентов:");
            //                                    Console.WriteLine(abiturientsLgota[j].FIO + " " + abiturientsLgota[j].FirstProfBallAtt + " --- " + a.FIO + " - " + a.FirstProfBallAtt);
            //                                }
            //                                else
            //                                {
            //                                    Console.WriteLine("Меньше");
            //                                }
            //                            }
            //                            else
            //                            {
            //                                Console.WriteLine("Необходимо участие члена приемной комиссии - равные баллы при зачислении на специальность " + sp + " у следующих абитуриентов:");
            //                                for (int k = 0; k < abiturientsWithMinBalls.Count; k++)
            //                                {
            //                                    Console.WriteLine(abiturientsWithMinBalls[k].FIO + " - " + abiturientsWithMinBalls[k].FirstProfBallAtt + ";");
            //                                }
            //                            }
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    if (abiturientsWithMinLgots == null)
            //                    {
            //                        Console.WriteLine("Необходимо участие члена приемной комиссии - равные баллы при зачислении на специальность " + sp + " у следующих абитуриентов:");
            //                        Console.WriteLine(abiturientsLgota[j].FIO + " льгота - " + abiturientsLgota[j].Lgota + " --- " + a.FIO + " - " + a.Lgota);
            //                    }
            //                    else
            //                    {
            //                        Console.WriteLine("Необходимо участие члена приемной комиссии - равные баллы при зачислении на специальность " + sp + " у следующих абитуриентов:");
            //                        for (int k = 0; k < abiturientsWithMinLgots.Count; k++)
            //                        {
            //                            Console.WriteLine(abiturientsWithMinLgots[k].FIO + " льгота - " + abiturientsWithMinLgots[k].Lgota + ";");
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}






































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



            Console.WriteLine("Spec1");
            for (int i = 0; i < abiturients["sp1"].Count; i++)
            {
                Console.WriteLine(abiturients["sp1"][i].Id + " - " + abiturients["sp1"][i].Result);
            }
            Console.WriteLine(" ----------------------------- ");
            Console.WriteLine("Spec2");
            for (int i = 0; i < abiturients["sp2"].Count; i++)
            {
                Console.WriteLine(abiturients["sp2"][i].Id + " - " + abiturients["sp2"][i].Result);
            }


            Console.WriteLine(" ----------------------------- ");
            Console.WriteLine("Success");
            for (int i = 0; i < success.Count; i++)
            {
                Console.WriteLine(success[i]);
            }

            //Console.WriteLine(" ----------------------------- ");
            //Console.WriteLine("Failed");
            //for (int i = 0; i < failed.Count; i++)
            //{
            //    Console.WriteLine(failed[i].Id);
            //}

            //преимущественное право на зачисление при равном количестве баллов среди льготников
            //ArrayList arrayList1 = new ArrayList() { 9, 8, 7, 7, true, true, 85 };
            //ArrayList arrayList2 = new ArrayList() { 9, 8, 7, 7, true, true, 85 };

            //Console.WriteLine(Abiturient.CompareArrayLists(arrayList1, arrayList2));

            Console.ReadKey();
        }
    }
}

//    new Abiturient
//    {
//        Id = 6,
//        FIO = "Сергеев Сергей Сергеевич",
//        Sex = 1,
//        Lgota = 0,
//        FirstCT = 100,
//        SecondCT = 50,
//        BallAttestat = 75,
//        Result = 225,
//        Specialities = new int[]{ 2, 1 },
//        FirstProfBallAtt = 8,
//        SecondProfBallAtt = 9,
//        Ideas100ForRB = true,
//        KindHearth = true,
//        MOOP = true,
//    },
//    new Abiturient
//    {
//        Id = 7,
//        FIO = "Павлов Павел Павлович",
//        Sex = 1,
//        Lgota = 0,
//        FirstCT = 100,
//        SecondCT = 50,
//        BallAttestat = 75,
//        Result = 225,
//        Specialities = new int[]{ 2, 1 },
//        FirstProfBallAtt = 8,
//        SecondProfBallAtt = 9,
//        Ideas100ForRB = true,
//        KindHearth = true,
//        MOOP = true,
//    },
//    new Abiturient
//    {
//        Id = 8,
//        FIO = "Прокопович Прокоп Прокопьевич",
//        Sex = 1,
//        Lgota = 0,
//        FirstCT = 100,
//        SecondCT = 50,
//        BallAttestat = 75,
//        Result = 225,
//        Specialities = new int[]{ 2, 1 },
//        FirstProfBallAtt = 8,
//        SecondProfBallAtt = 9,
//        Ideas100ForRB = true,
//        KindHearth = true,
//        MOOP = true,
//    },
//    new Abiturient
//    {
//        Id = 9,
//        FIO = "Игнатович Игнат Игнатович",
//        Sex = 1,
//        Lgota = 0,
//        FirstCT = 100,
//        SecondCT = 50,
//        BallAttestat = 75,
//        Result = 225,
//        Specialities = new int[]{ 2, 1 },
//        FirstProfBallAtt = 8,
//        SecondProfBallAtt = 9,
//        Ideas100ForRB = true,
//        KindHearth = true,
//        MOOP = true,
//    },
//    new Abiturient
//    {
//        Id = 10,
//        FIO = "Алексеев Алексей Алексеевич",
//        Sex = 1,
//        Lgota = 0,
//        FirstCT = 100,
//        SecondCT = 50,
//        BallAttestat = 75,
//        Result = 225,
//        Specialities = new int[]{ 2, 1 },
//        FirstProfBallAtt = 8,
//        SecondProfBallAtt = 9,
//        Ideas100ForRB = true,
//        KindHearth = true,
//        MOOP = true,
//    },
//};