using Entity;
using PusherServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class chatController : Controller
    {
        EduContext context = new EduContext();
        bool oturumAcanOgrenciMi = false;
        Student oturumAcanOgrenci = null;
        Teacher oturumAcanOgretmen = null;

        int oturumAcanID = -1;
        bool oturumKapaliMi()
        {
            if (Session["currentUsers"] != null)
            {
                oturumAcanOgrenciMi = true;
                oturumAcanOgrenci = Session["currentUsers"] as Student;
                oturumAcanID = oturumAcanOgrenci.ID;
                ViewBag.sahipId = oturumAcanID;
                ViewBag.oturumAcanEmail = oturumAcanOgrenci.Email;
                return false;
            }
            if (Session["currentTeacher"] != null)
            {
                oturumAcanOgrenciMi = false;
                oturumAcanOgretmen = Session["currentTeacher"] as Teacher;
                oturumAcanID = oturumAcanOgretmen.ID;
                ViewBag.sahipId = oturumAcanID;
                ViewBag.oturumAcanEmail = oturumAcanOgretmen.Email;
                return false;
            }
            /*
             
            
             */
            return true;
        }

        public ActionResult Sohbetlerim()
        {
            if (oturumKapaliMi())
                return RedirectToAction("login", "account");


            foreach (var item in context.Chats.Where(x => oturumAcanOgrenciMi ? x.ownerIsStudent && x.Student.ID == oturumAcanID : !x.ownerIsStudent && x.Teacher.ID == oturumAcanID).OrderByDescending(x => x.lastMessageTime))
            {
                int okunmamisMesaj = context.Messages.Count(x => x.Chat.ID == item.ID && (oturumAcanOgrenciMi ? x.Student.ID == oturumAcanID : x.Teacher.ID == oturumAcanID) && !x.isRead);

                string sonMesajZamani = "";
                if (item.lastMessageTime.ToString("dd.MM.yyyy") == DateTime.Now.ToString("dd.MM.yyyy"))
                    sonMesajZamani = item.lastMessageTime.ToString("HH:mm");
                else if (item.lastMessageTime.ToString("dd.MM.yyyy") == DateTime.Now.AddDays(-1).ToString("dd.MM.yyyy"))
                    sonMesajZamani = "Dün";
                else
                    sonMesajZamani = item.lastMessageTime.ToString("dd.MM.yyyy");

                ViewBag.Kullanicilar +=
                 "<div class='row mr-2 ml-2'>" +
                     "<div class='col-md-12 mb-3'>" +
                         "<div class='sohbet' id='" + item.ID + "'>" +
                             "<img src='/assets/img/new_logo.png' />" +
                             "<h4>" + (HttpContext.Request.Browser.ScreenPixelsWidth < 350 ? (oturumAcanOgrenciMi ? item.Student.FirstName : item.Teacher.FirstName).Substring(0, 10) + "..." : (oturumAcanOgrenciMi ? item.Student.FirstName : item.Teacher.FirstName)) + "</h4>" +
                             "<h5 class='d-none d-sm-block'>" + item.chatSubject + "</h5>" +
                             "<a id='" + item.ID + "' class='sil' href='#'><i class='material-icons'>delete</i></a>" +
                             "<h6 class='d-none d-md-block'>" + sonMesajZamani + "</h6>" +
                             (okunmamisMesaj != 0 ? "<h3  class='d-none d-sm-block'>" + okunmamisMesaj + "</h3>" : "") +
                         "</div>" +
                     "</div>" +
                 "</div>";
            }

            return View();
        }

        public ActionResult YeniSohbet()
        {
            if (oturumKapaliMi())
                return RedirectToAction("login", "account");


            if (oturumAcanOgrenciMi)
                return RedirectToAction("sohbetlerim", "chat");


            Random rnd = new Random();
            int i = 0;

            string kullaniciListesi = "";


            foreach (var item in context.Students)
            {
                if (i % 2 == 0)
                    ViewBag.Kullanicilar +=
                        "<div class='row mr-2 ml-2'>";
                string veri =
                    "<div class='col-md-6 mb-3'>" +
                        "<div class='kullanici' id='" + item.ID + "'  >" +
                            "<img src='/assets/img/new_logo.png' />" +
                            "<h4>" + item.FirstName + " " + item.LastName + "</h4>" +
                        "</div>" +
                    "</div>";
                kullaniciListesi += (kullaniciListesi == "" ? "" : ",") + "[\"" + item.FirstName + " " + item.LastName + "\",\"" + veri + "\"]";
                ViewBag.Kullanicilar += veri;

                if (i % 2 != 0)
                    ViewBag.Kullanicilar +=
                         "</div>";
                i++;
            }

            ViewBag.kullaniciListesi = kullaniciListesi;
            return View();
        }

        [Route("chat/chat/{chatId}")]
        public ActionResult chat(int chatId)
        {
            if (oturumKapaliMi())
                return RedirectToAction("login", "account");

            Chat chat = context.Chats.FirstOrDefault(x => x.ID == chatId && (oturumAcanOgrenciMi ? x.ownerIsStudent && x.Student.ID == oturumAcanID : !x.ownerIsStudent && x.Teacher.ID == oturumAcanID));
            if (chat == null)
                return RedirectToAction("sohbetlerim", "chat");

            ViewBag.Title = (oturumAcanOgrenciMi ? chat.Teacher.FirstName : chat.Student.FirstName) + " ile sohbet.";
            ViewBag.guncelChatId = chat.ID;

            Message[] mesajlar = context.Messages.Where(x => x.Chat.ID == chat.ID).ToArray();
            foreach (var item in mesajlar)
            {
                if (oturumAcanOgrenciMi ? (item.Student.ID == oturumAcanID && item.fromStudent) : (item.Teacher.ID == oturumAcanID && !item.fromStudent))
                    item.isRead = true;
                string yon = oturumAcanOgrenciMi ? item.fromStudent ? "giden" : "gelen" : item.fromStudent ? "gelen" : "giden",
                    mesaj = item.message,
                    zaman = "";
                if (item.date.ToString("ddMMyyyy") == DateTime.Now.ToString("ddMMyyyy"))
                {
                    zaman = item.date.ToString("HH:mm");
                }
                else if (item.date.ToString("ddMMyyyy") == DateTime.Now.AddDays(-1).ToString("ddMMyyyy"))
                {
                    zaman = "Dün " + item.date.ToString("HH:mm");
                }
                else
                {
                    zaman = item.date.ToString("dd.MM.yy HH:mm");
                }
                ViewBag.mesajlar +=
                    "<div class='col-md-12 " + (yon == "gelen" ? "sol" : "sag") + "'>" +
                        "<div class='mesajKutusu " + yon + "'>" +
                            mesaj +
                            "<i>" + zaman + "</i>" +
                        "</div>" +
                    "</div>";
            }
            context.SaveChanges();
            ViewBag.sohbetId = chat.ID;

            return View();
        }

        [Route("chat/sohbetOlustur/{kullaniciID}-{sohbetKonusu}")]
        public ActionResult sohbetOlustur(int kullaniciID, string sohbetKonusu)
        {
            if (oturumKapaliMi())
                return RedirectToAction("login", "account");


            if (oturumAcanOgrenciMi)
                return RedirectToAction("sohbetlerim", "chat");


            Student chatKullanici = context.Students.FirstOrDefault(x => x.ID == kullaniciID);
            if (chatKullanici == null)
                return RedirectToAction("sohbetlerim", "chat");


            Chat[] sohbetList = context.Chats.Where(x => x.Student.ID == chatKullanici.ID && x.Teacher.ID == oturumAcanID).ToArray();

            Chat myChat = null;
            Chat chat = null;

            if (sohbetList.Length > 0)
            {
                foreach (var item in sohbetList)
                {
                    if (item.chatSubject.ToLower() == sohbetKonusu.ToLower())
                    {
                        if (item.ownerIsStudent)
                            chat = item;
                        else
                            myChat = item;
                    }
                }
            }

            if (myChat == null)
            {
                myChat = new Chat();
                myChat.Student = chatKullanici;
                myChat.Teacher = context.Teachers.FirstOrDefault(x => x.ID == oturumAcanOgretmen.ID);
                myChat.lastMessageTime = DateTime.Now;
                myChat.ownerIsStudent = false;
                myChat.chatSubject = sohbetKonusu;
            }
            if (chat == null)
            {
                chat = new Chat();
                chat.Student = chatKullanici;
                chat.Teacher = context.Teachers.FirstOrDefault(x => x.ID == oturumAcanOgretmen.ID);
                chat.lastMessageTime = DateTime.Now;
                chat.ownerIsStudent = true;
                chat.chatSubject = sohbetKonusu;
            }

            context.Chats.Add(chat);
            context.Chats.Add(myChat);
            context.SaveChanges();


            return Redirect("/chat/chat/" + myChat.ID);
        }

        [Route("chat/chatSil/{chatID}")]
        public ActionResult chatSil(int chatID)
        {
            if (oturumKapaliMi())
                return RedirectToAction("login", "account");

            Chat chat = context.Chats.FirstOrDefault(x => x.ID == chatID && (oturumAcanOgrenciMi ? x.ownerIsStudent && x.Student.ID == oturumAcanID : !x.ownerIsStudent && x.Teacher.ID == oturumAcanID));
            if (chat != null)
            {
                context.Messages.RemoveRange(context.Messages.Where(x => x.Chat.ID == chat.ID));
                context.Chats.Remove(chat);
                context.SaveChanges();
            }
            return RedirectToAction("sohbetlerim", "chat");
        }

        [Route("chat/mesajSil/{mesajID}")]
        public ActionResult mesajSil(int mesajID)
        {
            if (oturumKapaliMi())
                return RedirectToAction("login", "account");

            Message mesaj = context.Messages.FirstOrDefault(x => x.ID == mesajID && (oturumAcanOgrenciMi ? x.Chat.ownerIsStudent && x.Chat.Student.ID == oturumAcanID : !x.Chat.ownerIsStudent && x.Chat.Teacher.ID == oturumAcanID));
            if (mesaj != null)
            {
                context.Messages.Remove(mesaj);
                context.SaveChanges();
                return Redirect("/chat/chat/" + mesaj.Chat.ID);
            }
            return Redirect("/chat/sohbetlerim");
        }

        public async Task<ActionResult> MesajGonder(string[] veri)
        {
            if (oturumKapaliMi())
                return RedirectToAction("login", "account");

            var options = new PusherOptions
            {
                Cluster = "eu",
                Encrypted = true
            };

            var pusher = new Pusher(
              "1130001",
              "9c428fba897224950404",
              "308302a31c69a0305f3c",
              options);
            if (veri == null)
            {
                var sonuc2 = await pusher.TriggerAsync(
                    oturumAcanOgrenciMi ? oturumAcanOgrenci.Email :
                  oturumAcanOgretmen.Email,
                  "hata",
                  new { mesaj = "Veri alınırken hata oluştu." });
            }
            else
            {
                if (veri.Length != 3)
                {
                    var sonuc2 = await pusher.TriggerAsync(
                    oturumAcanOgrenciMi ? oturumAcanOgrenci.Email :
                  oturumAcanOgretmen.Email,
                      "hata",
                      new { mesaj = "Veri alınırken hata oluştu." });

                    return new HttpStatusCodeResult((int)HttpStatusCode.OK);
                }
            }

            string mesaj = veri[0];
            int sahipId = Convert.ToInt32(veri[1]);
            int sohbetId = Convert.ToInt32(veri[2]);

            Chat chatSahip = null;
            Chat chatKonusulan = null;

            Chat temp = context.Chats.FirstOrDefault(x => x.ID == sohbetId);

            if (temp == null)
                return null;

            if (oturumAcanOgrenciMi ? temp.ownerIsStudent : !temp.ownerIsStudent)
            {
                chatSahip = temp;
                chatKonusulan = context.Chats.FirstOrDefault(x => x.Student.ID == chatSahip.Student.ID && x.Teacher.ID == chatSahip.Teacher.ID && x.ownerIsStudent != chatSahip.ownerIsStudent && x.chatSubject == chatSahip.chatSubject);
            }
            else
            {
                chatKonusulan = temp;
                chatSahip = context.Chats.FirstOrDefault(x => x.Student.ID == chatKonusulan.Student.ID && x.Teacher.ID == chatKonusulan.Teacher.ID && x.ownerIsStudent != chatKonusulan.ownerIsStudent && x.chatSubject == chatKonusulan.chatSubject);
            }


            Message chatMesajSahip = new Message();
            chatMesajSahip.Student = chatSahip.Student;
            chatMesajSahip.Teacher = chatSahip.Teacher;
            chatMesajSahip.date = DateTime.Now;
            chatMesajSahip.message = mesaj;
            chatMesajSahip.Chat = chatSahip;
            chatMesajSahip.fromStudent = oturumAcanOgrenciMi;


            if ((oturumAcanOgrenciMi ? chatSahip.Student.ID : chatSahip.Teacher.ID) == sahipId)
            {
                Message[] mesajList = context.Messages.Where(x => (oturumAcanOgrenciMi ? !x.fromStudent : x.fromStudent) && (oturumAcanOgrenciMi ? chatSahip.Student.ID : chatSahip.Teacher.ID) == sahipId && x.Chat.ID == chatSahip.ID && !x.isRead).ToArray();
                foreach (var item in mesajList)
                    item.isRead = true;

            }



            if (chatKonusulan == null)
            {
                chatKonusulan = chatSahip;
                chatKonusulan.ownerIsStudent = !chatSahip.ownerIsStudent;
                context.Chats.Add(chatKonusulan);
                context.SaveChanges();
            }

            Message chatMesajKonusulan = new Message();
            chatMesajKonusulan = chatMesajSahip;
            chatMesajKonusulan.Chat = chatKonusulan;
            context.Messages.Add(chatMesajSahip);
            context.Messages.Add(chatMesajKonusulan);
            context.SaveChanges();



            string clientId1 = "", clientId2 = "", yon1 = "", yon2 = "", oturumAcanChatId = "", konusulanChatId = "";
            if (sahipId == (oturumAcanOgrenciMi ? chatSahip.Student.ID : chatSahip.Teacher.ID))
            {
                yon1 = "giden";
                yon2 = "gelen";
                clientId1 = (chatSahip.ownerIsStudent ? chatSahip.Student.Email : chatSahip.Teacher.Email);
                oturumAcanChatId = chatSahip.ID.ToString();
                konusulanChatId = chatKonusulan.ID.ToString();
                clientId1 = clientId1 == null ? "" : clientId1;
                clientId2 = (chatKonusulan.ownerIsStudent ? chatSahip.Student.Email : chatSahip.Teacher.Email);
                clientId2 = clientId2 == null ? "" : clientId2;
                var sonuc2 = await pusher.TriggerAsync(
                  clientId2,
                  "bildirimGonder",
                  new { mesaj = mesaj, ad = (chatSahip.ownerIsStudent ? chatSahip.Student.FirstName + " " + chatSahip.Student.LastName : chatSahip.Teacher.FirstName + " " + chatSahip.Teacher.LastName), resim = "/assets/img/new_logo.png", gelenChatId = konusulanChatId });
            }
            else
            {
                yon1 = "gelen";
                yon2 = "giden";
                oturumAcanChatId = chatKonusulan.ID.ToString();
                konusulanChatId = chatSahip.ID.ToString();
                clientId2 = (chatSahip.ownerIsStudent ? chatSahip.Student.Email : chatSahip.Teacher.Email);
                clientId2 = clientId2 == null ? "" : clientId2;
                clientId1 = (!chatSahip.ownerIsStudent ? chatSahip.Student.Email : chatSahip.Teacher.Email);
                clientId1 = clientId1 == null ? "" : clientId1;

            }
            string tarih = chatMesajKonusulan.date.ToString("HH:mm");

            var sonuc = await pusher.TriggerAsync(
              clientId1,
              "mesajGeldi",
              new { yon = yon1, mesaj = mesaj, zaman = tarih });

            sonuc = await pusher.TriggerAsync(
              clientId2,
              "mesajGeldi",
              new { yon = yon2, mesaj = mesaj, zaman = tarih });


            return new HttpStatusCodeResult((int)HttpStatusCode.OK);
        }
    }
}