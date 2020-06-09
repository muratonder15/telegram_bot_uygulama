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


//                for (int j = 1; j <= 20; j++)
//                {
//                    if (e.Message.Text == ("/cevap " + j + " a"))
//                    {
//                        //var cevap=from a in db.testler where 
//                        anahtar[j] = anahtar[j] + " a";
//                        Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " cevap:a");
//                        break;
//                    }
//                    else if (e.Message.Text == ("/cevap " + j + " b"))
//                    {

//                        anahtar[j] = anahtar[j] + " b";
//                        Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " cevap:b");
//                        break;
//                    }
//                    else if (e.Message.Text == ("/cevap " + j + " c"))
//                    {

//                        anahtar[j] = anahtar[j] + " c";
//                        Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " cevap:c");
//                        break;
//                    }
//                    else if (e.Message.Text == ("/cevap " + j + " d"))
//                    {

//                        anahtar[j] = anahtar[j] + " d";
//                        Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " cevap:d");
//                        break;
//                    }
//                    else if (e.Message.Text == ("/cevap " + j + " e"))
//                    {

//                        anahtar[j] = anahtar[j] + " e";
//                        Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " cevap:e");
//                        break;
//                    }
//                    else if (e.Message.Text == "/anahtar")
//                    {
//                        for (int i = 1; i <= 20; i++)
//                        {

//                            toplam = toplam + "\n" + anahtar[i];

//                        }
//                        Bot.SendTextMessageAsync(e.Message.Chat.Id, toplam);
//                        break;
//                    }
//                    else
//                    {

//                        if (j >= 20)
//                        {

//                            Bot.SendTextMessageAsync(e.Message.Chat.Id, @"Kullanım : 
///cevap soru numarası harf ");
//                        }
//                    }
//                }
                
                int test_no = 1;
                //veritabanından
                for (int j = 1; j <= 20; j++)
                {
                    if (e.Message.Text == ("/cevap " + j + " a"))
                    {
                        
                        var kullanici_id = (from a in db.kullanicilar where a.id.ToString() == e.Message.From.ToString() select a.id).FirstOrDefault();
                        if (kullanici_id.ToString()==null)
                        {
                            kullanicilar modelKullanicilar = new kullanicilar();
                            modelKullanicilar.telegram_id = e.Message.From.ToString();
                            modelKullanicilar.ad = e.Message.From.FirstName;
                            modelKullanicilar.soyad = e.Message.From.LastName;
                            db.kullanicilar.Add(modelKullanicilar);db.SaveChanges();
                        }
                        var soru = (from a in db.testler where a.soru_no == j && a.test_no == test_no && a.kullanici_id==kullanici_id && a.aktif_mi== true select a).FirstOrDefault();
                        if (soru==null)
                        {
                            testler test = new testler();
                            test.test_no = test_no;
                            test.soru_no = j;
                            test.kullanici_id = kullanici_id;
                            test.a = 1;                            
                            test.aktif_mi = true;                          
                        db.testler.Add(test);
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
                        var kullanici_id = (from a in db.kullanicilar where a.id.ToString() == e.Message.From.ToString() select a.id).FirstOrDefault();
                        if (kullanici_id.ToString() == null)
                        {
                            kullanicilar modelKullanicilar = new kullanicilar();
                            modelKullanicilar.telegram_id = e.Message.From.ToString();
                            modelKullanicilar.ad = e.Message.From.FirstName;
                            modelKullanicilar.soyad = e.Message.From.LastName;
                            db.kullanicilar.Add(modelKullanicilar); db.SaveChanges();
                        }
                        var soru = (from a in db.testler where a.soru_no == j && a.test_no == test_no && a.kullanici_id == kullanici_id && a.aktif_mi == true select a).FirstOrDefault();
                        if (soru == null)
                        {
                            testler test = new testler();
                            test.test_no = test_no;
                            test.soru_no = j;
                            test.kullanici_id = kullanici_id;
                            test.b = 1;
                            test.aktif_mi = true;
                            db.testler.Add(test);
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
                        var kullanici_id = (from a in db.kullanicilar where a.id.ToString() == e.Message.From.ToString() select a.id).FirstOrDefault();
                        if (kullanici_id.ToString() == null)
                        {
                            kullanicilar modelKullanicilar = new kullanicilar();
                            modelKullanicilar.telegram_id = e.Message.From.ToString();
                            modelKullanicilar.ad = e.Message.From.FirstName;
                            modelKullanicilar.soyad = e.Message.From.LastName;
                            db.kullanicilar.Add(modelKullanicilar); db.SaveChanges();
                        }
                        var soru = (from a in db.testler where a.soru_no == j && a.test_no == test_no && a.kullanici_id == kullanici_id && a.aktif_mi == true select a).FirstOrDefault();
                        if (soru == null)
                        {
                            testler test = new testler();
                            test.test_no = test_no;
                            test.soru_no = j;
                            test.kullanici_id = kullanici_id;
                            test.c = 1;
                            test.aktif_mi = true;
                            db.testler.Add(test);
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
                        var kullanici_id = (from a in db.kullanicilar where a.id.ToString() == e.Message.From.ToString() select a.id).FirstOrDefault();
                        if (kullanici_id.ToString() == null)
                        {
                            kullanicilar modelKullanicilar = new kullanicilar();
                            modelKullanicilar.telegram_id = e.Message.From.ToString();
                            modelKullanicilar.ad = e.Message.From.FirstName;
                            modelKullanicilar.soyad = e.Message.From.LastName;
                            db.kullanicilar.Add(modelKullanicilar); db.SaveChanges();
                        }
                        var soru = (from a in db.testler where a.soru_no == j && a.test_no == test_no && a.kullanici_id == kullanici_id && a.aktif_mi == true select a).FirstOrDefault();
                        if (soru == null)
                        {
                            testler test = new testler();
                            test.test_no = test_no;
                            test.soru_no = j;
                            test.kullanici_id = kullanici_id;
                            test.d = 1;
                            test.aktif_mi = true;
                            db.testler.Add(test);
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
                        var kullanici_id = (from a in db.kullanicilar where a.id.ToString() == e.Message.From.ToString() select a.id).FirstOrDefault();
                        if (kullanici_id.ToString() == null)
                        {
                            kullanicilar modelKullanicilar = new kullanicilar();
                            modelKullanicilar.telegram_id = e.Message.From.ToString();
                            modelKullanicilar.ad = e.Message.From.FirstName;
                            modelKullanicilar.soyad = e.Message.From.LastName;
                            db.kullanicilar.Add(modelKullanicilar); db.SaveChanges();
                        }

                        var soru = (from a in db.testler where a.soru_no == j && a.test_no == test_no && a.kullanici_id == kullanici_id && a.aktif_mi == true select a).FirstOrDefault();
                        if (soru == null)
                        {
                            testler test = new testler();
                            test.test_no = test_no;
                            test.soru_no = j;
                            test.kullanici_id = kullanici_id;
                            test.e = 1;
                            test.aktif_mi = true;
                            db.testler.Add(test);
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
                        var kullanici_id = (from a in db.kullanicilar where a.id.ToString() == e.Message.From.ToString() select a.id).FirstOrDefault();
                        var soru = (from a in db.testler where a.soru_no == j && a.test_no == test_no && a.a>0 && a.kullanici_id ==kullanici_id && a.aktif_mi==true select a).FirstOrDefault();
                        if (soru != null)
                        {
                            soru.a -= 1;
                            db.SaveChanges();
                            Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " silindi:a");
                            break;
                        }
                        else
                        {
                            Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " soru işaretlemediğiniz için silemezsiniz");
                            break;
                        }
                        //anahtar[j] = anahtar[j] + " e";
                        

                    }
                    else if (e.Message.Text == ("/sil " + j + " b"))
                    {
                        var kullanici_id = (from a in db.kullanicilar where a.id.ToString() == e.Message.From.ToString() select a.id).FirstOrDefault();
                        var soru = (from a in db.testler where a.soru_no == j && a.test_no == test_no && a.b > 0 && a.kullanici_id == kullanici_id && a.aktif_mi == true select a).FirstOrDefault();
                        if (soru != null)
                        {
                            soru.b -= 1;
                            db.SaveChanges();
                            Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " silindi:b");
                            break;
                        }
                        else
                        {
                            Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " soru işaretlemediğiniz için silemezsiniz");
                            break;
                        }
                        //anahtar[j] = anahtar[j] + " e";


                    }
                    else if (e.Message.Text == ("/sil " + j + " c"))
                    {
                        var kullanici_id = (from a in db.kullanicilar where a.id.ToString() == e.Message.From.ToString() select a.id).FirstOrDefault();
                        var soru = (from a in db.testler where a.soru_no == j && a.test_no == test_no && a.c > 0 && a.kullanici_id == kullanici_id && a.aktif_mi == true select a).FirstOrDefault();
                        if (soru != null)
                        {
                            soru.c -= 1;
                            db.SaveChanges();
                            Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " silindi:c");
                            break;
                        }
                        else
                        {
                            Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " soru işaretlemediğiniz için silemezsiniz");
                            break;
                        }
                        //anahtar[j] = anahtar[j] + " e";


                    }
                    else if (e.Message.Text == ("/sil " + j + " d"))
                    {
                        var kullanici_id = (from a in db.kullanicilar where a.id.ToString() == e.Message.From.ToString() select a.id).FirstOrDefault();
                        var soru = (from a in db.testler where a.soru_no == j && a.test_no == test_no && a.d > 0 && a.kullanici_id == kullanici_id && a.aktif_mi == true select a).FirstOrDefault();
                        if (soru != null)
                        {
                            soru.d -= 1;
                            //if (soru.d == 0) soru.d = null;
                            db.SaveChanges();
                            Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " silindi:d");
                            break;
                        }
                        else
                        {
                            Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " soru işaretlemediğiniz için silemezsiniz");
                            break;
                        }
                        //anahtar[j] = anahtar[j] + " e";


                    }
                    else if (e.Message.Text == ("/sil " + j + " e"))
                    {
                        var kullanici_id = (from a in db.kullanicilar where a.id.ToString() == e.Message.From.ToString() select a.id).FirstOrDefault();
                        var soru = (from a in db.testler where a.soru_no == j && a.test_no == test_no && a.e > 0 && a.kullanici_id == kullanici_id && a.aktif_mi == true select a).FirstOrDefault();
                        if (soru != null)
                        {
                            soru.e -= 1;
                            //if (soru.e == 0) soru.e = null;
                            db.SaveChanges();
                            Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " silindi:e");
                            break;
                        }
                        else
                        {
                            Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " soru işaretlemediğiniz için silemezsiniz");
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

            for (int i = 1; i <= 20; i++)
            {
                
                    anahtar[i] = i.ToString() + "-)";
                
            }
            var cevap_listesi = (from a in db.testler where a.test_no == 1 && a.aktif_mi == true orderby a.soru_no select a).ToList();


            foreach (var cevap in cevap_listesi)
            {
                
                string cevapa = "", cevapb = "", cevapc = "", cevapd = "", cevape = "";
                if (cevap.a != null && cevap.a!=0 ) 
                { 
                    cevapa = "A(" + cevap.a.ToString() + ")";
                    anahtar[Convert.ToInt32(cevap.soru_no)] = anahtar[Convert.ToInt32(cevap.soru_no)] + cevapa;
                }
                if (cevap.b != null && cevap.b != 0)
                { 
                cevapb = "B(" + cevap.b.ToString() + ")";
                    anahtar[Convert.ToInt32(cevap.soru_no)] = anahtar[Convert.ToInt32(cevap.soru_no)] + cevapb;
                }
                    
                if (cevap.c != null && cevap.c != 0)
                {
                cevapc = "C(" + cevap.c.ToString() + ")";
                    anahtar[Convert.ToInt32(cevap.soru_no)] = anahtar[Convert.ToInt32(cevap.soru_no)] + cevapc;
                }
                    
                if (cevap.d != null && cevap.d != 0)
                {
                cevapd = "D(" + cevap.d.ToString() + ")";
                    anahtar[Convert.ToInt32(cevap.soru_no)] = anahtar[Convert.ToInt32(cevap.soru_no)] + cevapd;
                }
                    
                if (cevap.e != null && cevap.e != 0)
                {
                cevape = "E(" + cevap.e.ToString() + ")";
                    anahtar[Convert.ToInt32(cevap.soru_no)] = anahtar[Convert.ToInt32(cevap.soru_no)] + cevape;
                }
                    
                
                //listBox1.Items.Add(cevap.soru_no + "-) " +
                //    cevapa +
                //    cevapb +
                //    cevapc +
                //    cevapd +
                //    cevape
                //    );
               
                
            }
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