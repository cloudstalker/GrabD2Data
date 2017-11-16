using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.SQLite.EF6;
using System.Data.Entity;

namespace DataCompile
{
    public class DotaMetaData : DbContext
    {
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DotaMetaData(string connectionString) : base(new SQLiteConnection() {ConnectionString = connectionString }, true)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Hero>().HasKey(x => x.HeroID);
            base.OnModelCreating(modelBuilder);
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            SQLiteConnection.CreateFile("Data.sqlite");
            string conStr = "Data Source=Data.sqlite;version=3;";
            // Start modifying the database
            var sQLiteConnection = new SQLiteConnection(conStr);
            sQLiteConnection.Open();
            // Hero stat table
            string sql = "create table Heroes (name text, basestr real, baseagi real, baseint real" +
                ",lvupstr real, lvupagi real, lvupint real, basemovspeed real, basedaysightrange real" +
                ",basenightsightrange real, basearmor real, baseatktime real, basedmglower real, basedmgupper real" +
                ",baseatkpt real)";
            SQLiteCommand command = new SQLiteCommand(sql, sQLiteConnection);
            command.ExecuteNonQuery();
            sql = "create table Items (name text, gold real, " +
                    "MovementSpeed," +
                    "SelectedAttribute,"+
                    "AttackSpeed," +
                    "Damage," +
                    "AllAttributes," +
                    "Health," +
                    "Mana," +
                    "HPRegeneration," +
                    "Strength," +
                    "Armor," +
                    "Intelligence," +
                    "Agility," +
                    "ManaRegeneration," +
                    "Evasion," +
                    "MagicResistance," +
                    "SpellAmplification," +
                    "ManacostandManalossReduction" +
                    ")";
            command = new SQLiteCommand(sql, sQLiteConnection);
            command.ExecuteNonQuery();
            // Close database connection
            sQLiteConnection.Close();

            // Read heroes & items
            List<Hero> heroList = TxtParser.ParseHeroes("HeroData.txt");
            List<Item> itemList = TxtParser.ParseItems("ItemData.txt");
            using (DotaMetaData dotaMetaData = new DotaMetaData(conStr))
            {
                foreach (var s in heroList)
                {
                    dotaMetaData.Heroes.Add(s);
                }
                foreach (var s in itemList)
                {
                    dotaMetaData.Items.Add(s);
                }
                dotaMetaData.SaveChanges();
            }
        }
    }
}
