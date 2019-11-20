﻿using System;
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
            DTuslugi = CSV2DT("uslugi", "C:\\Users\\Przemek\\Desktop\\Git\\stomatolog\\Stomatolog\\cennik_uslug.csv", DS);
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
            DTklienci = CSV2DT("uslugi", "C:\\Users\\Przemek\\Desktop\\Git\\stomatolog\\Stomatolog\\klienci.csv", DS);
            DTklienci.Select();
            GWklienci.DataSource = DTklienci;

        }
        public class CDesc
        {
            public double czasusl = 0;
            public double przerwa = 0;
            public int nast = 0;
        }
        public class cp
        {
            public int nst;
            public int w;

        }
        private void obliczToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var DR = DTklienci.Select();
            int Lp = 0;
            List<CDesc> Lst = new List<CDesc>();



            foreach (var row in DR)
            {
                string sLP = row["Lp"].ToString();
                string sNruslugi = row["numeruslugi"].ToString();
                var DR2 = DTuslugi.Select("Lp = '" + sNruslugi + "'");

                for (int i = 0; i <= DR2.Length - 2; i++)
                {
                    var rec1 = DR2[i];
                    CDesc el1 = new CDesc();
                    el1.czasusl = double.Parse(rec1["czas trwania"].ToString());
                    el1.przerwa = double.Parse(rec1["minOdstep"].ToString()) * 8 * 60;
                    el1.nast = Lp + 1;
                    Lst.Add(el1);
                    Lp++;
                }

                var rec = DR2[DR2.Length - 1];
                CDesc el = new CDesc();
                el.czasusl = double.Parse(rec["czas trwania"].ToString());
                el.przerwa = double.Parse(rec["minOdstep"].ToString()) * 8 * 60;
                el.nast = 0;
                Lst.Add(el);
                Lp++;

            }
            int[] pi = new int[Lp + 2];
            for (int i = 0; i <= Lp; i++)
            {
                pi[i] = i;

            }
            pi[0] = pi[Lp + 1] = 0;



            List<cp>[] Nast = new List<cp>[Lp + 2];
            List<cp>[] Pop = new List<cp>[Lp + 2];
            for (int i = 0; i < Lp + 1; i++)
            {
                Nast[i] = new List<cp>();
                Pop[i] = new List<cp>();
            }
            for (int s = 0; s < Lst.Count - 1; s++)
            {
                int nst = Lst[s].nast + 1;
                int w = (int)(Lst[s].przerwa);
                if (Lst[s].nast == 0)
                    continue;
                cp ee = new cp(); ee.nst = nst; ee.w = w;
                Nast[s + 1].Add(ee);
                cp p = new cp(); p.nst = s + 1; p.w = w;
                Pop[nst].Add(p);



            }
            for (int s = 0; s < Lp + 1; s++)
            {
                int node = pi[s];
                int nst = pi[s + 1];
                if (node == 0) continue;
                if (nst == 0) continue;
                int w = 0;

                cp ee = new cp(); ee.nst = nst; ee.w = w;
                Nast[node].Add(ee);
                cp p = new cp(); p.nst = node; p.w = w;
                Pop[nst].Add(p);



            }
            int[] LP = new int[Lp + 1];
            for (int i = 1; i <= Lp; i++)
            {
                LP[i] = Pop[i].Count;
            }

            Queue<int> Q = new Queue<int>();

            for (int i = 1; i <= Lp; i++)
            {
                if (LP[i] == 0)
                    Q.Enqueue(i);
            }
            int[] C = new int[Lp + 1];
            for (int i = 0; i <= Lp; i++)
            {
                C[i] = 0;
            }
            int[] S = new int[Lp + 1];
            for (int i = 0; i <= Lp; i++)
            {
                S[i] = 0;
            }
            while (Q.Count > 0)
            {
                int node = Q.Dequeue();
                C[node] = S[node] + (int)(Lst[node - 1].czasusl);
                foreach (var ns in Nast[node])
                {
                    if (--LP[ns.nst] == 0)
                        Q.Enqueue(ns.nst);
                }
                foreach (var ns in Nast[node])
                {
                    if (ns.nst != 0)
                        S[ns.nst] = Math.Max(S[ns.nst], C[node] + ns.w);
                }
            }




        }


        private void Klienci_Click(object sender, EventArgs e)
        {

        }
    }
}