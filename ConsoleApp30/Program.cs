// BİG O => O(N^3)  case 7'yi kaldırınca O(N)
using System;
using System.Collections.Generic;
namespace ConsoleApp30
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**************** HOŞ GELDİNİZ ****************");
            int secim = 0;
            string BagajHacmi = "", Uzunluk = "", MotorHacmi = "", marka = "", ad = "", renk = "";
            int saat = 0, gunluk = 0, haftalik = 0, Toplam = 0;
            List<Arac> rezervasyon = new List<Arac>();
            List<Araba> RezerveAraba = new List<Araba>();
            List<Bisiklet> RezerveBisiklet = new List<Bisiklet>();
            List<Tekne> RezerveTekne = new List<Tekne>();
            List<Motorsiklet> RezerveMotor = new List<Motorsiklet>();

            while (secim != 6)
            {
                Console.WriteLine("\n ÜCRET TARİFESİ= Bisiklet:1000TL/saat , Motorsilet:1500TL/saat , Araba:5500TL/gün (10 gün ve katlarında %5 indirim) , Tekne:55000TL/hafta");
                Console.WriteLine("\n Seçiminizi Yapin: 1.Bisiklet   2.Motorsiklet   3.Araba   4.Tekne   5.Toplam Tutar ve rezervasyoları görüntülemek için    6.Çıkış  7.rezervasyon iptali için");

                secim = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (secim)
                {
                    case 1:

                        Console.WriteLine("\nkaç saat kullanacağınızı giriniz");
                        saat = int.Parse(Console.ReadLine());
                        Bisiklet bisiklet = new Bisiklet(saat);

                        rezervasyon.Add(bisiklet);
                        RezerveBisiklet.Add(bisiklet);
                        bisiklet.ad = "bisiklet";
                        bisiklet.Tanimla();
                        Console.WriteLine("ücret=" + bisiklet.Hesapla(saat));
                        Toplam = Toplam + bisiklet.Hesapla(saat);

                        break;

                    case 2:
                        Console.WriteLine("kaç saat kullanacağınızı giriniz");
                        saat = int.Parse(Console.ReadLine());
                        Console.WriteLine("motor hacmini giriniz");
                        MotorHacmi = Console.ReadLine();
                        Motorsiklet motorsiklet = new Motorsiklet(MotorHacmi, saat);

                        rezervasyon.Add(motorsiklet);
                        RezerveMotor.Add(motorsiklet);
                        motorsiklet.ad = "motorsiklet";
                        motorsiklet.Tanimla();
                        Console.WriteLine("ucret=" + motorsiklet.Hesapla(saat));
                        Toplam = Toplam + motorsiklet.Hesapla(saat);

                        break;

                    case 3:
                        Console.WriteLine("kaç gun icin kullanacağınızı giriniz");
                        gunluk = int.Parse(Console.ReadLine());
                        Console.WriteLine("motor hacmini giriniz");
                        MotorHacmi = Console.ReadLine();
                        Console.WriteLine("bagaj hacmini giriniz");
                        BagajHacmi = Console.ReadLine();

                        Araba araba = new Araba(MotorHacmi, BagajHacmi, gunluk);
                        araba.ad = "araba";

                        rezervasyon.Add(araba);
                        RezerveAraba.Add(araba);
                        araba.Tanimla();
                        Console.WriteLine("ucret=" + araba.Hesapla(gunluk));
                        Toplam = Toplam + araba.Hesapla(gunluk);

                        break;

                    case 4:
                        Console.WriteLine("kaç hafta icin kullanacağınızı giriniz");
                        haftalik = int.Parse(Console.ReadLine());
                        Console.WriteLine("motor hacmini giriniz");
                        MotorHacmi = Console.ReadLine();
                        Console.WriteLine("uzunluğunu giriniz");
                        Uzunluk = Console.ReadLine();
                        Tekne tekne = new Tekne(MotorHacmi, Uzunluk, haftalik);

                        tekne.ad = "tekne";

                        rezervasyon.Add(tekne);
                        RezerveTekne.Add(tekne);
                        tekne.Tanimla();
                        Toplam = Toplam + tekne.Hesapla(haftalik);
                        Console.WriteLine("ucret=" + tekne.Hesapla(haftalik));

                        break;

                    case 5:
                        for (int i = 0; i < rezervasyon.Count; i++)
                            Console.WriteLine(i + 1 + "." + " rezervasyonunuz: " + rezervasyon[i].toplam + " ücretli " + rezervasyon[i].marka + " markalı " + rezervasyon[i].ad + " rezerve ettiniz.");
                        Console.WriteLine("TOPLAM TUTAR={0}", Toplam);

                        break;

                    case 6:
                        Console.WriteLine("HOŞÇA KALIN");
                        break;

                    case 7:
                        Console.WriteLine("iptal etmek istediğiniz aracın adını giriniz (bisiklet,motorsiklet,araba,tekne)");
                        ad = Console.ReadLine();

                        Console.WriteLine("iptal etmek istediğiniz rezervasyonun markasını giriniz:");
                        marka = Console.ReadLine();

                        Console.WriteLine("iptal etmek istediğiniz rezervasyonun rengini giriniz:");
                        renk = Console.ReadLine();

                        for (int k = 0; k < rezervasyon.Count; k++)
                        {
                            if (rezervasyon[k].ad == ad)
                            {
                                if (rezervasyon[k].marka == marka)
                                {
                                    if (rezervasyon[k].renk == renk)
                                    {
                                        rezervasyon.RemoveAt(k);
                                        Console.WriteLine("Rezervasyonunuz başarıyla silindi.");
                                        if (ad == "bisiklet")
                                        {
                                            for (int i = 0; i < RezerveBisiklet.Count; i++)
                                            {
                                                if (RezerveBisiklet[i].marka == marka && RezerveBisiklet[i].renk == renk)
                                                {

                                                    Toplam = Toplam - (RezerveBisiklet[i].Hesapla(RezerveBisiklet[i].getSaat()));
                                                    RezerveBisiklet.RemoveAt(i);

                                                }
                                            }
                                        }

                                        else if (ad == "motorsiklet")
                                        {
                                            for (int i = 0; i < RezerveMotor.Count; i++)
                                            {
                                                if (RezerveMotor[i].marka == marka && RezerveMotor[i].renk == renk)
                                                {
                                                    Toplam = Toplam - (RezerveMotor[i].Hesapla(RezerveMotor[i].getSaat()));
                                                    RezerveMotor.RemoveAt(i);
                                                }
                                            }
                                        }
                                        else if (ad == "araba")
                                        {
                                            for (int i = 0; i < RezerveAraba.Count; i++)
                                            {
                                                if (RezerveAraba[i].marka == marka && RezerveAraba[i].renk == renk)
                                                {
                                                    Toplam = Toplam - (RezerveAraba[i].Hesapla(RezerveAraba[i].getGun()));
                                                    RezerveAraba.RemoveAt(i);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            for (int i = 0; i < RezerveTekne.Count; i++)
                                            {
                                                if (RezerveTekne[i].marka == marka && RezerveTekne[i].renk == renk)
                                                {
                                                    Toplam = Toplam - (RezerveTekne[i].Hesapla(RezerveTekne[i].getHafta()));
                                                    RezerveTekne.RemoveAt(i);
                                                }
                                            }
                                        }

                                    }
                                    else
                                        Console.WriteLine("yazdığınız renkte bir {0} markalı {1} rezervasyonunuz bulunmamakta.", marka, ad);
                                }
                                else
                                    Console.WriteLine("yazdığınız markada bir {0} rezervasyonunuz bulunmamakta.", ad);
                            }
                            else
                                Console.WriteLine("adını yanlış girdiniz. bisiklet,motorsiklet,araba,tekne arasından giriniz");

                        }

                        break;

                    default:
                        Console.WriteLine("!!! yanlış tercih yaptınız.Tekrar deneyin !!!");
                        break;
                }
            }
            if (Toplam > 0)
            {
                Console.WriteLine("Rezervasyonunuz başarıyla gerçekleştirildi. ");
            }


        }
    }
    abstract class Arac
    {

        public string marka = "";
        public int toplam;
        protected string UretimYili = "";
        public string renk = "";
        protected string vites = "";
        protected string KisiSayisi = "";
        protected int tutar = 0;
        public string ad;
        public abstract void Tanimla();
        public abstract int Hesapla(int a);
        public Arac()
        {
            Bilgi();

            this.marka = marka;
            this.UretimYili = UretimYili;
            this.renk = renk;
            this.vites = vites;
            this.KisiSayisi = KisiSayisi;

        }
        public void Bilgi()
        {
            Console.WriteLine("markayı giriniz");
            marka = Console.ReadLine();
            Console.WriteLine("üretim yılını giriniz");
            UretimYili = Console.ReadLine();
            Console.WriteLine("rengini giriniz");
            renk = Console.ReadLine();
            Console.WriteLine("vitesi giriniz");
            vites = Console.ReadLine();
            Console.WriteLine("kişi sayısını giriniz");
            KisiSayisi = Console.ReadLine();

        }

    }

    class Bisiklet : Arac
    {
        protected int saat;
        public Bisiklet(int s)
        {
            saat = s;
        }
        public override void Tanimla()
        {
            Console.WriteLine("Marka={0}  Üretim Yılı={1}   Renk={2}    Vites={3}   Kişi Sayısı={4}", marka, UretimYili, renk, vites, KisiSayisi);
        }
        public override int Hesapla(int saat)
        {

            tutar = saat * 1000;
            toplam = tutar;
            return tutar;

        }
        public int getSaat()
        {

            return saat;
        }


    }

    class Motorsiklet : Arac
    {
        protected int saat;
        private string MotorHacmi;

        public Motorsiklet(string MotorHacmi, int s)
        {
            this.MotorHacmi = MotorHacmi;
            this.saat = s;

        }
        public override void Tanimla()
        {
            Console.WriteLine("Marka={0}  Üretim Yılı={1}   Renk={2}    Vites={3}   Kişi Sayısı={4}   Motor Hacmi={5}", marka, UretimYili, renk, vites, KisiSayisi, MotorHacmi);
        }
        public override int Hesapla(int saat)
        {

            tutar = 1500 * saat;
            toplam = tutar;
            return tutar;
        }
        public int getSaat()
        {
            return saat;
        }
    }

    class Araba : Arac
    {
        protected int gun;

        private string MotorHacmi, BagajHacmi;
        public Araba(string MotorHacmi, string BagajHacmi, int g)
        {

            this.BagajHacmi = BagajHacmi;
            this.MotorHacmi = MotorHacmi;

            this.gun = g;

        }
        public override void Tanimla()
        {
            Console.WriteLine("Marka={0}  Üretim Yılı={1}   Renk={2}    Vites={3}   Kişi Sayısı={4}   Motor Hacmi={5}   Bagaj Hacmi={6}", marka, UretimYili, renk, vites, KisiSayisi, MotorHacmi, BagajHacmi);
        }
        public override int Hesapla(int gun)
        {

            tutar = 5500 * gun;
            if (gun % 10 == 0)
                tutar = tutar * 95 / 100;
            toplam = tutar;
            return tutar;
        }
        public int getGun()
        { return gun; }
    }

    class Tekne : Arac
    {
        protected int hafta;
        private string MotorHacmi, Uzunluk;
        public Tekne(string MotorHacmi, string Uzunluk, int h)
        {
            this.MotorHacmi = MotorHacmi;
            this.Uzunluk = Uzunluk;
            this.hafta = h;

        }
        public override void Tanimla()
        {
            Console.WriteLine("Marka={0}  Üretim Yılı={1}   Renk={2}    Vites={3}   Kişi Sayısı={4}   Motor Hacmi={5}   Uzunluk={6}", marka, UretimYili, renk, vites, KisiSayisi, MotorHacmi, Uzunluk);
        }
        public override int Hesapla(int hafta)
        {

            tutar = 55000 * hafta;
            toplam = tutar;
            return tutar;
        }
        public int getHafta()
        { return hafta; }
    }

}
