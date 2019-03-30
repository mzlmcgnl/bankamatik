using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metotlar
{
    class Program
    {

        static Random rnd = new Random();

        static double hesap = 100;
        static double parayatır = 0;
        static double paracekme = 0;
        static string[] hareketler;
        static string[] yedek;
        static void Main(string[] args)

        {
            #region metotlar
            //    for (int i = 0; i < 3; i++)
            //    {
            //        Console.WriteLine("\t"+PrgUret(rnd.Next(10,20)));
            //        Console.WriteLine("\n");
            //    }
            //    Console.ReadLine();  
            //}
            //static string PrgUret(int  cumleSayi)
            //{
            //    string Prg = "";
            //    for (int i = 0; i < cumleSayi; i++)
            //    {
            //        Prg += CumleUret(rnd.Next(2, 15)) +" ";
            //    }
            //    return Prg;
            //}
            //static string KelimeUret(int harfSayi)
            //{
            //    string kelime = "";
            //    for (int i = 0; i < harfSayi; i++)
            //    {
            //        kelime += (char)rnd.Next(97, 123); 
            //    }
            //    return kelime;
            //}
            // static string CumleUret(int kelimeSayi)
            //{
            //    string cumle = "";
            //    for (int i = 0; i < kelimeSayi; i++)
            //    {
            //        cumle += KelimeUret(rnd.Next(2,15))+" ";
            //    }
            //    return cumle;
            //} 
            #endregion
            AnaMenu();

            Console.ReadLine();

        }

        private static void Hareketler()
        {
            Console.Clear();
            Console.WriteLine("¦        Hareketler       ¦");
            Console.WriteLine("   TİP TUTAR  TARİH        ");

            if (hareketler == null)
            {
                Console.WriteLine("Hiçbir para çekme ve ekleme işlemleri yapılmamıştır.");
            }
            else
            {
                for (int i = 0; i < hareketler.Length; i++)
                {
                    Console.WriteLine(hareketler[i]);
                }
            }
            Console.WriteLine($"Toplam bakiye:  {hesap}");

            Console.WriteLine("Anamenüye dönmek için bir tuşa basın. <a>");
            switch (Console.ReadLine())
            {
                case "a":
                    AnaMenu();
                    break;
            }
        }


        private static void ParaCek()
        {
            Console.Clear();
            Console.WriteLine("  -===============================================¬");
            Console.WriteLine("  ¦                 Para Çek                      ¦");
            Console.WriteLine("  L===============================================-");

            Console.WriteLine("Çekmek istediğiniz miktarı giriniz :");

            paracekme = Convert.ToDouble(Console.ReadLine());

            hesap -= paracekme;

            if (hareketler == null)
            {
                hareketler = new string[1];
                hareketler[0] = $"+\t{paracekme}\t{DateTime.Now.ToShortTimeString()}";
            }
            else
            {
                yedek = hareketler;
                hareketler = new string[hareketler.Length + 1];
                for (int i = 0; i < yedek.Length; i++)
                {
                    hareketler[i] = yedek[i];
                }

                hareketler[hareketler.Length - 1] = $"-\t{paracekme}\t{DateTime.Now.ToShortTimeString()}";
            }
            Console.Write($"Hesabınızda şuan {hesap} TL vardır");
            Console.Clear();
            Console.Write("Başka bir işlem yapmak ister misiniz? <e/h>");
            switch (Console.ReadLine())
            {
                case "e":
                    ParaCek();
                    break;
                case "h":
                    Console.Clear();
                    AnaMenu();
                    break;
            }
        }

        private static void ParaYatir()
        {
            Console.Clear();
            Console.WriteLine(" -===============================================¬");
            Console.WriteLine(" ¦                 Para Yatır                    ¦");
            Console.WriteLine(" L===============================================-");

            Console.Write("Yatırmak istediğiniz miktarı giriniz :");
            parayatır = Convert.ToDouble(Console.ReadLine());
            hesap += parayatır;
            if (hareketler == null)
            {
                hareketler = new string[1];
                hareketler[0] = $"+\t{parayatır}\t{DateTime.Now.ToShortTimeString()}";
            }
            else
            {
                yedek = hareketler;
                hareketler = new string[hareketler.Length + 1];
                for (int i = 0; i < yedek.Length; i++)
                {
                    hareketler[i] = yedek[i];
                }
                hareketler[hareketler.Length - 1] = $"+\t{parayatır}\t{DateTime.Now.ToShortTimeString()}";
            }
            Console.Write($"Hesabınızda şuan {hesap} TL vardır");
            Console.Clear();
            Console.Write("Başka bir işlem yapmak ister misiniz? <e/h>");
            switch (Console.ReadLine())
            {
                case "e":
                    ParaYatir();
                    break;

                case "h":
                    Console.Clear();
                    AnaMenu();
                    break;

            }
        }



        private static void AnaMenu()
        {
            Console.WriteLine("  -===============================================================¬");
            Console.WriteLine("  ¦                          Bankamatik                           ¦");
            Console.WriteLine("  ¦ 1.Para Yatır                                                  ¦");
            Console.WriteLine("  ¦ 2.Para Çek                                                    ¦");
            Console.WriteLine("  ¦ 3.Hareketler                                                  ¦");
            Console.WriteLine("  ¦ 4.Çıkış                                                       ¦");
            Console.WriteLine("  L===============================================================-");
            Console.WriteLine("  Menü seçiniz");
            switch (Console.ReadLine())
            {
                case "1":
                    ParaYatir();

                    break;
                case "2":
                    ParaCek();


                    break;
                case "3":
                    Hareketler();

                    switch (Console.ReadLine())
                    {
                        case "a":
                            AnaMenu();
                            break;
                    }
                    break;
                case "4":
                    break;
            }

        }
    }
}