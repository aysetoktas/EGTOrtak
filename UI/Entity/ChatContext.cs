using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class chatContext : DbContext
    {
        public DbSet<Sohbet> Sohbet { get; set; }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<ChatMesajlari> ChatMesajlari { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sohbet>().ToTable("Sohbet");
            modelBuilder.Entity<Chat>().ToTable("Chat");
            modelBuilder.Entity<ChatMesajlari>().ToTable("ChatMesajlari");
        }
    }
    

    public class Sohbet
    {
        [Key]
        public int sohbetID { get; set; }
        public string sohbetKonusu { get; set; }
        public virtual Student ogrenci { get; set; }
        public virtual Teacher ogretmen { get; set; }

    }

    public class Chat
    {
        [Key]
        public int chatID { get; set; }
        public virtual Sohbet sohbet { get; set; }
        public virtual Student ogrenci { get; set; }
        public virtual Teacher ogretmen { get; set; }
        public DateTime sonMesajZamani { get; set; }
    }
    public class ChatMesajlari
    {
        [Key]
        public int mesajID { get; set; }
        public DateTime mesajTarihi { get; set; }
        public string mesaj { get; set; }
        public virtual Chat chat { get; set; }
        public virtual Teacher ogrenci { get; set; }
        public virtual Student ogretmen { get; set; }
        [DefaultValue(false)]
        public bool okunduMu { get; set; }
    }
}
