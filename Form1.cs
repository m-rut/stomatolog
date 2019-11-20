using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Stomatolog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<string> LoadToList(string name)

        {

            try

            {

                string[] al = File.ReadAllLines(name);

                List<string> L = new List<string>();

                foreach (var s in al) L.Add(s);

                return L;

            }

            catch

            {

               

                return null;

            }



        }





        public DataTable CSV2DT(string name, string path, DataSet DS)

        {

            DataTable DT = DS.Tables.Add(name);

            List<string> LS = LoadToList(path);

            if (LS == null) return null;

            try

            {

                string[] fields = LS[0].Split(';');

                LS.RemoveAt(0);

                foreach (var s in fields)

                    DT.Columns.Add(s, typeof(string));



                foreach (var s in LS)

                {

                    if (s.Replace(';', ' ').Trim() == "") continue;

                    string[] sp = s.Split(';');

                    DataRow DR = DT.NewRow();

                    int l = Math.Min(sp.Length, fields.Length);

                    for (int i = 0; i < fields.Length; i++) DR[i] = "";

                    for (int i = 0; i < l; i++) DR[i] = sp[i];

                    DT.Rows.Add(DR);

                }

            }

            catch (Exception ex) { }

            return DT;

        }




        private void plikToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void zakończToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        DataSet DS = new DataSet();
        DataTable DTuslugi = new DataTable();
        DataTable DTklienci = new DataTable();
               
        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DS = new DataSet();
            DTuslugi = CSV2DT("uslugi", "D:\\cennik_uslug.csv", DS);
            DTuslugi.Select();
            GWuslugi.DataSource = DTuslugi;
            
        }

        private void GWuslugi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void klienciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DS = new DataSet();
            DTklienci = CSV2DT("uslugi", "D:\\klienci.csv", DS);
            DTklienci.Select();
            GWklienci.DataSource = DTklienci;

        }
        public class CDesc
        {
            public double czasusl = 0;
            public double przerwa = 0;
            public int nast = 0;
        }
        private void obliczToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var DR = DTklienci.Select();
            int Lp = 0;
            List<CDesc> Lst = new List<CDesc>();

    
        
            foreach(var row in DR)
            {
                string sLP = row["Lp"].ToString();
                string sNruslugi = row["numeruslugi"].ToString();
                var DR2 = DTuslugi.Select("Lp = '"+sNruslugi+"'");
                
                for (int i=0;i<=DR2.Length-2;i++)
                {
                    var rec1 = DR2[DR2.Length - 1];
                    CDesc el1 = new CDesc();
                    el1.czasusl = double.Parse(rec1["czas trwania"].ToString());
                    el1.przerwa = double.Parse(rec1["minOdstep"].ToString());
                    el1.nast = Lp+2;
                    Lst.Add(el1);
                    Lp++;
                }

                var rec = DR2[DR2.Length - 1];
                CDesc el = new CDesc();
                el.czasusl = double.Parse(rec["czas trwania"].ToString());
                el.przerwa = double.Parse(rec["minOdstep"].ToString());
                el.nast = 0;
                Lst.Add(el);
                Lp++;

            }


        }

        private void Klienci_Click(object sender, EventArgs e)
        {

        }
    }
}
