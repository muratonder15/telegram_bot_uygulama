using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
namespace TelegramFormTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static readonly TelegramBotClient Bot = new TelegramBotClient("1204315203:AAELD11cMEoKQijJze85IPAttdHh1Hj3_9E");

        TestDBEntities db = new TestDBEntities();
        public static string[] anahtar = new string[21];
        private void Form1_Load(object sender, EventArgs e)
        {
            Bot.OnMessage += Bot_OnMessage;
            Bot.StartReceiving();
            for (int i = 1; i <= 20; i++)
            {
                //if (anahtar[i] == null)
                {
                    anahtar[i] = i.ToString() + "-)";
                }
            }
            CevapListesi();
            //Console.ReadLine();
            //Bot.StopReceiving();
            button1.Enabled = false;
        }

        private void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            string toplam = "";

            for (int i = 1; i <= 20; i++)
            {
                if (anahtar[i] == null)
                {
                    anahtar[i] = i.ToString() + "-)";
                }
            }
            //CevapListesi();
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                  
                int test_no = 1;
                //veritabanından
                for (int j = 1; j <= 20; j++)
                {
                    if (e.Message.Text == ("/cevap " + j + " a"))
                    {

                        var kullanici_id = (from a in db.kullanicilar where a.telegram_id.ToString() == e.Message.From.Id.ToString() select a.id).FirstOrDefault();
                        if (kullanici_id==0)
                        {
                            kullanicilar modelKullanicilar = new kullanicilar();
                            modelKullanicilar.telegram_id = e.Message.From.Id.ToString();
                            modelKullanicilar.ad = e.Message.From.FirstName;
                            modelKullanicilar.soyad = e.Message.From.LastName;
                            db.kullanicilar.Add(modelKullanicilar);db.SaveChanges();
                        }
                        var soru = (from a in db.testler where a.soru_no == j && a.test_no == test_no && a.kullanici_id==kullanici_id && a.aktif_mi== true select a).FirstOrDefault();
                        var soru_v2 = (from a in db.testler_v2 where a.soru_no == j && a.test_no == test_no && a.kullanici_id == kullanici_id && a.aktif_mi == true select a).FirstOrDefault();
                        if (soru_v2==null)
                        {
                            //testler test = new testler();
                            //test.test_no = test_no;
                            //test.soru_no = j;
                            //test.kullanici_id = kullanici_id;
                            //test.a = 1;                            
                            //test.aktif_mi = true;                          
                            //db.testler.Add(test);

                            //test v2

                            testler_v2 test_v2 = new testler_v2();
                            test_v2.test_no = test_no;
                            test_v2.soru_no = j;
                            test_v2.kullanici_id = kullanici_id;
                            test_v2.cevap = "a";
                            test_v2.aktif_mi = true;
                            db.testler_v2.Add(test_v2);

                        db.SaveChanges();
                            Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " cevap:a");
                            break;
                        }
                        else
                        {
                            Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " daha önceden işaretlediniz");
                            break;
                        }
                        
                                             
                        //anahtar[j] = anahtar[j] + " a";
                        

                    }
                    else if (e.Message.Text == ("/cevap " + j + " b"))
                    {
                        var kullanici_id = (from a in db.kullanicilar where a.telegram_id.ToString() == e.Message.From.Id.ToString() select a.id).FirstOrDefault();
                        if (kullanici_id == 0)
                        {
                            kullanicilar modelKullanicilar = new kullanicilar();
                            modelKullanicilar.telegram_id = e.Message.From.Id.ToString();
                            modelKullanicilar.ad = e.Message.From.FirstName;
                            modelKullanicilar.soyad = e.Message.From.LastName;
                            db.kullanicilar.Add(modelKullanicilar); db.SaveChanges();
                        }
                        var soru = (from a in db.testler where a.soru_no == j && a.test_no == test_no && a.kullanici_id == kullanici_id && a.aktif_mi == true select a).FirstOrDefault();
                        var soru_v2 = (from a in db.testler_v2 where a.soru_no == j && a.test_no == test_no && a.kullanici_id == kullanici_id && a.aktif_mi == true select a).FirstOrDefault();
                        if (soru_v2==null)
                        {
                            //testler test = new testler();
                            //test.test_no = test_no;
                            //test.soru_no = j;
                            //test.kullanici_id = kullanici_id;
                            //test.b = 1;
                            //test.aktif_mi = true;
                            //db.testler.Add(test);

                            //test v2

                            testler_v2 test_v2 = new testler_v2();
                            test_v2.test_no = test_no;
                            test_v2.soru_no = j;
                            test_v2.kullanici_id = kullanici_id;
                            test_v2.cevap = "b";
                            test_v2.aktif_mi = true;
                            db.testler_v2.Add(test_v2);

                            db.SaveChanges();
                            Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " cevap:b");
                            break;
                        }
                        else
                        {
                            Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " daha önceden işaretlediniz");
                            break;
                        }
                        //anahtar[j] = anahtar[j] + " b";
                        

                    }
                    else if (e.Message.Text == ("/cevap " + j + " c"))
                    {
                        var kullanici_id = (from a in db.kullanicilar where a.telegram_id.ToString() == e.Message.From.Id.ToString() select a.id).FirstOrDefault();
                        if (kullanici_id == 0)
                        {
                            kullanicilar modelKullanicilar = new kullanicilar();
                            modelKullanicilar.telegram_id = e.Message.From.Id.ToString();
                            modelKullanicilar.ad = e.Message.From.FirstName;
                            modelKullanicilar.soyad = e.Message.From.LastName;
                            db.kullanicilar.Add(modelKullanicilar); db.SaveChanges();
                        }
                        var soru = (from a in db.testler where a.soru_no == j && a.test_no == test_no && a.kullanici_id == kullanici_id && a.aktif_mi == true select a).FirstOrDefault();
                        var soru_v2 = (from a in db.testler_v2 where a.soru_no == j && a.test_no == test_no && a.kullanici_id == kullanici_id && a.aktif_mi == true select a).FirstOrDefault();
                        if (soru_v2==null)
                        {
                            //testler test = new testler();
                            //test.test_no = test_no;
                            //test.soru_no = j;
                            //test.kullanici_id = kullanici_id;
                            //test.c = 1;
                            //test.aktif_mi = true;
                            //db.testler.Add(test);

                            testler_v2 test_v2 = new testler_v2();
                            test_v2.test_no = test_no;
                            test_v2.soru_no = j;
                            test_v2.kullanici_id = kullanici_id;
                            test_v2.cevap = "c";
                            test_v2.aktif_mi = true;
                            db.testler_v2.Add(test_v2);

                            db.SaveChanges();
                            Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " cevap:c");
                            break;
                        }
                        else
                        {
                            Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " daha önceden işaretlediniz");
                            break;
                        }
                        //anahtar[j] = anahtar[j] + " c";
                        

                    }
                    else if (e.Message.Text == ("/cevap " + j + " d"))
                    {
                        var kullanici_id = (from a in db.kullanicilar where a.telegram_id.ToString() == e.Message.From.Id.ToString() select a.id).FirstOrDefault();
                        if (kullanici_id == 0)
                        {
                            kullanicilar modelKullanicilar = new kullanicilar();
                            modelKullanicilar.telegram_id = e.Message.From.Id.ToString();
                            modelKullanicilar.ad = e.Message.From.FirstName;
                            modelKullanicilar.soyad = e.Message.From.LastName;
                            db.kullanicilar.Add(modelKullanicilar); db.SaveChanges();
                        }
                        var soru = (from a in db.testler where a.soru_no == j && a.test_no == test_no && a.kullanici_id == kullanici_id && a.aktif_mi == true select a).FirstOrDefault();
                        var soru_v2 = (from a in db.testler_v2 where a.soru_no == j && a.test_no == test_no && a.kullanici_id == kullanici_id && a.aktif_mi == true select a).FirstOrDefault();
                        if (soru_v2==null)
                        {
                            //testler test = new testler();
                            //test.test_no = test_no;
                            //test.soru_no = j;
                            //test.kullanici_id = kullanici_id;
                            //test.d = 1;
                            //test.aktif_mi = true;
                            //db.testler.Add(test);

                            testler_v2 test_v2 = new testler_v2();
                            test_v2.test_no = test_no;
                            test_v2.soru_no = j;
                            test_v2.kullanici_id = kullanici_id;
                            test_v2.cevap = "d";
                            test_v2.aktif_mi = true;
                            db.testler_v2.Add(test_v2);

                            db.SaveChanges();
                            Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " cevap:d");
                            break;
                        }
                        else
                        {
                            Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " daha önceden işaretlediniz");
                            break;
                        }

                        //anahtar[j] = anahtar[j] + " d";
                        

                    }
                    else if (e.Message.Text == ("/cevap " + j + " e"))
                    {
                        var kullanici_id = (from a in db.kullanicilar where a.telegram_id.ToString() == e.Message.From.Id.ToString() select a.id).FirstOrDefault();
                        if (kullanici_id == 0)
                        {
                            kullanicilar modelKullanicilar = new kullanicilar();
                            modelKullanicilar.telegram_id = e.Message.From.Id.ToString();
                            modelKullanicilar.ad = e.Message.From.FirstName;
                            modelKullanicilar.soyad = e.Message.From.LastName;
                            db.kullanicilar.Add(modelKullanicilar); db.SaveChanges();
                        }

                        var soru = (from a in db.testler where a.soru_no == j && a.test_no == test_no && a.kullanici_id == kullanici_id && a.aktif_mi == true select a).FirstOrDefault();
                        var soru_v2 = (from a in db.testler_v2 where a.soru_no == j && a.test_no == test_no && a.kullanici_id == kullanici_id && a.aktif_mi == true select a).FirstOrDefault();
                        if (soru_v2==null)
                        {
                            //testler test = new testler();
                            //test.test_no = test_no;
                            //test.soru_no = j;
                            //test.kullanici_id = kullanici_id;
                            //test.e = 1;
                            //test.aktif_mi = true;
                            //db.testler.Add(test);

                            testler_v2 test_v2 = new testler_v2();
                            test_v2.test_no = test_no;
                            test_v2.soru_no = j;
                            test_v2.kullanici_id = kullanici_id;
                            test_v2.cevap = "e";
                            test_v2.aktif_mi = true;
                            db.testler_v2.Add(test_v2);

                            db.SaveChanges();
                            Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " cevap:e");
                            break;
                        }
                        else
                        {
                            Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " daha önceden işaretlediniz");
                            break;
                        }
                        //anahtar[j] = anahtar[j] + " e";
                        

                    }
                    else if (e.Message.Text == ("/sil " + j + " a"))
                    {
                        var kullanici_id = (from a in db.kullanicilar where a.telegram_id.ToString() == e.Message.From.Id.ToString() select a.id).FirstOrDefault();

                        var soru = (from a in db.testler where a.soru_no == j && a.test_no == test_no && a.a>0 && a.kullanici_id ==kullanici_id && a.aktif_mi==true select a).FirstOrDefault();
                        var soru_v2 = (from a in db.testler_v2 where a.soru_no == j && a.test_no == test_no && a.kullanici_id == kullanici_id && a.cevap=="a" && a.aktif_mi == true select a).FirstOrDefault();
                        if (soru_v2 != null)
                        {
                            //soru.a -= 1;

                            soru_v2.aktif_mi = false;

                            db.SaveChanges();
                            Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " silindi:a");
                            break;
                        }
                        else
                        {
                            Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName  + j + ". soruyu işaretlemediğiniz için silemezsiniz");
                            break;
                        }
                        //anahtar[j] = anahtar[j] + " e";
                        

                    }
                    else if (e.Message.Text == ("/sil " + j + " b"))
                    {
                        var kullanici_id = (from a in db.kullanicilar where a.telegram_id.ToString() == e.Message.From.Id.ToString() select a.id).FirstOrDefault();
                        var soru = (from a in db.testler where a.soru_no == j && a.test_no == test_no && a.b > 0 && a.kullanici_id == kullanici_id && a.aktif_mi == true select a).FirstOrDefault();
                        var soru_v2 = (from a in db.testler_v2 where a.soru_no == j && a.test_no == test_no && a.kullanici_id == kullanici_id && a.cevap == "b" && a.aktif_mi == true select a).FirstOrDefault();
                        if (soru_v2 != null)
                        {
                            //soru.b -= 1;
                            soru_v2.aktif_mi = false;
                            db.SaveChanges();
                            Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " silindi:b");
                            break;
                        }
                        else
                        {
                            Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName  + j + ". soruyu işaretlemediğiniz için silemezsiniz");
                            break;
                        }
                        //anahtar[j] = anahtar[j] + " e";


                    }
                    else if (e.Message.Text == ("/sil " + j + " c"))
                    {
                        var kullanici_id = (from a in db.kullanicilar where a.telegram_id.ToString() == e.Message.From.Id.ToString() select a.id).FirstOrDefault();
                        var soru = (from a in db.testler where a.soru_no == j && a.test_no == test_no && a.c > 0 && a.kullanici_id == kullanici_id && a.aktif_mi == true select a).FirstOrDefault();
                        var soru_v2 = (from a in db.testler_v2 where a.soru_no == j && a.test_no == test_no && a.kullanici_id == kullanici_id && a.cevap == "c" && a.aktif_mi == true select a).FirstOrDefault();
                        if (soru_v2 != null)
                        {
                            //soru.c -= 1;
                            soru_v2.aktif_mi = false;
                            db.SaveChanges();
                            Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " silindi:c");
                            break;
                        }
                        else
                        {
                            Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName  + j + ". soruyu işaretlemediğiniz için silemezsiniz");
                            break;
                        }
                        //anahtar[j] = anahtar[j] + " e";


                    }
                    else if (e.Message.Text == ("/sil " + j + " d"))
                    {
                        var kullanici_id = (from a in db.kullanicilar where a.telegram_id.ToString() == e.Message.From.Id.ToString() select a.id).FirstOrDefault();
                        var soru = (from a in db.testler where a.soru_no == j && a.test_no == test_no && a.d > 0 && a.kullanici_id == kullanici_id && a.aktif_mi == true select a).FirstOrDefault();
                        var soru_v2 = (from a in db.testler_v2 where a.soru_no == j && a.test_no == test_no && a.kullanici_id == kullanici_id && a.cevap == "d" && a.aktif_mi == true select a).FirstOrDefault();
                        if (soru_v2 != null)
                        {
                            //soru.d -= 1;
                            //if (soru.d == 0) soru.d = null;
                            soru_v2.aktif_mi = false;
                            db.SaveChanges();
                            Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " silindi:d");
                            break;
                        }
                        else
                        {
                            Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName  + j + ". soruyu işaretlemediğiniz için silemezsiniz");
                            break;
                        }
                        //anahtar[j] = anahtar[j] + " e";


                    }
                    else if (e.Message.Text == ("/sil " + j + " e"))
                    {
                        var kullanici_id = (from a in db.kullanicilar where a.telegram_id.ToString() == e.Message.From.Id.ToString() select a.id).FirstOrDefault();
                        var soru = (from a in db.testler where a.soru_no == j && a.test_no == test_no && a.e > 0 && a.kullanici_id == kullanici_id && a.aktif_mi == true select a).FirstOrDefault();
                        var soru_v2 = (from a in db.testler_v2 where a.soru_no == j && a.test_no == test_no && a.kullanici_id == kullanici_id && a.cevap == "e" && a.aktif_mi == true select a).FirstOrDefault();
                        if (soru_v2 != null)
                        {
                            //soru.e -= 1;
                            soru_v2.aktif_mi = false;
                            //if (soru.e == 0) soru.e = null;
                            db.SaveChanges();
                            Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " silindi:e");
                            break;
                        }
                        else
                        {
                            Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + j + ". soruyu işaretlemediğiniz için silemezsiniz");
                            break;
                        }
                        //anahtar[j] = anahtar[j] + " e";
                       

                    }
                    else if(e.Message.Text == "/anahtar")
                    {
                        for (int i = 1; i <= 20; i++)
                        {

                            toplam = toplam + "\n" + anahtar[i];

                        }
                        Bot.SendTextMessageAsync(e.Message.Chat.Id, toplam);
                        break;
                    }

                    else if (e.Message.Text == "/rapor")
                    {
                        var cevap_listesi_group = (from a in db.testler_v2 where a.test_no == test_no && a.aktif_mi == true group a by a.kullanici_id into grp select new { krt = grp.Key, cnt = grp.Count() }).ToList();

                        if (cevap_listesi_group.Count > 0)
                        {
                            foreach (var x in cevap_listesi_group)
                            {


                                string kullanici = x.krt.ToString();
                                int cevap_sayisi = Convert.ToInt32(x.cnt);

                                var kullanici_adi = (from a in db.kullanicilar where a.id.ToString() == kullanici select a).FirstOrDefault();
                                Bot.SendTextMessageAsync(e.Message.Chat.Id, kullanici_adi.ad+" "+kullanici_adi.soyad+" cevaplanan soru:"+cevap_sayisi);
                                
                            }
                            break;
                        }
                    }
                    else
                    {

                        if (j >= 20)
                        {

                            Bot.SendTextMessageAsync(e.Message.Chat.Id, @"Hatalı Format!!
Kullanım: /cevap soru_no şık
Örnek   : /cevap 1 a");
                        }
                    }

                }
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //Bot.OnMessage += Bot_OnMessage;
            Bot.StartReceiving();
            button1.Enabled = false;
            button2.Enabled = true;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bot.StopReceiving();
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //string toplam = "";
            CevapListesi();
            
            
        }

        public void CevapListesi()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            int test_no = 1;
            for (int i = 1; i <= 20; i++)
            {
                
                    anahtar[i] = i.ToString() + "-)";
                
            }
            //var cevap_listesi = (from a in db.testler where a.test_no == test_no && a.aktif_mi == true orderby a.soru_no select a).ToList();

            //var cevap_listesi_v2 = (from a in db.testler_v2 where a.test_no == 1 && a.aktif_mi == true orderby a.soru_no select a).ToList();

            //var cevap_listesi_group = (from a in db.testler_v2 where a.test_no == 1 && a.aktif_mi == true group a by a.cevap into grp select new { krt = grp.Key, cnt = grp.Count() }).ToList();

            //if (cevap_listesi_group.Count > 0)
            //{
            //    foreach (var a in cevap_listesi_group)
            //    {


            //        string cevap = a.krt;
            //        int cevap_sayisi = Convert.ToInt32(a.cnt);

            //        listBox2.Items.Add()
            //    }
            //}

            
                for (int i = 1; i <= 20; i++)
                {
                    var cevap_listesi_group = (from a in db.testler_v2 where a.test_no == 1 && a.soru_no==i && a.aktif_mi == true group a by a.cevap into grp select new { krt = grp.Key, cnt = grp.Count() }).ToList();

                    if (cevap_listesi_group.Count > 0)
                    {
                        foreach (var a in cevap_listesi_group)
                        {


                            string cevap_sikki = a.krt;
                            int cevap_sayisi = Convert.ToInt32(a.cnt);

                            anahtar[i] = anahtar[i] +cevap_sikki + "(" + cevap_sayisi + ")";

                            
                        }
                    }
                }
            
            for (int i = 1; i <= 20; i++)
            {
                listBox2.Items.Add(anahtar[i]);
            }

            //foreach (var cevap in cevap_listesi)
            //{
                
            //    string cevapa = "", cevapb = "", cevapc = "", cevapd = "", cevape = "";
            //    if (cevap.a != null && cevap.a!=0 ) 
            //    { 
            //        cevapa = "A(" + cevap.a.ToString() + ")";
            //        anahtar[Convert.ToInt32(cevap.soru_no)] = anahtar[Convert.ToInt32(cevap.soru_no)] + cevapa;
            //    }
            //    if (cevap.b != null && cevap.b != 0)
            //    { 
            //    cevapb = "B(" + cevap.b.ToString() + ")";
            //        anahtar[Convert.ToInt32(cevap.soru_no)] = anahtar[Convert.ToInt32(cevap.soru_no)] + cevapb;
            //    }
                    
            //    if (cevap.c != null && cevap.c != 0)
            //    {
            //    cevapc = "C(" + cevap.c.ToString() + ")";
            //        anahtar[Convert.ToInt32(cevap.soru_no)] = anahtar[Convert.ToInt32(cevap.soru_no)] + cevapc;
            //    }
                    
            //    if (cevap.d != null && cevap.d != 0)
            //    {
            //    cevapd = "D(" + cevap.d.ToString() + ")";
            //        anahtar[Convert.ToInt32(cevap.soru_no)] = anahtar[Convert.ToInt32(cevap.soru_no)] + cevapd;
            //    }
                    
            //    if (cevap.e != null && cevap.e != 0)
            //    {
            //    cevape = "E(" + cevap.e.ToString() + ")";
            //        anahtar[Convert.ToInt32(cevap.soru_no)] = anahtar[Convert.ToInt32(cevap.soru_no)] + cevape;
            //    }
                    
                
            //    //listBox1.Items.Add(cevap.soru_no + "-) " +
            //    //    cevapa +
            //    //    cevapb +
            //    //    cevapc +
            //    //    cevapd +
            //    //    cevape
            //    //    );
               
                
            //}
            for (int i = 1; i <= 20; i++)
            {
                listBox1.Items.Add(anahtar[i]);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            
        }
    }
}