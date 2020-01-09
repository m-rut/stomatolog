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

        public void genHarm(int[] pi, List<CDesc> Lst, int[] C)

        {
            DataTable harmTable = new DataTable("Harmonogram");
            harmTable.Columns.Add("Lp.", typeof(string));
            harmTable.Columns.Add("Nazwisko", typeof(string));
            harmTable.Columns.Add("Usluga", typeof(string));
            harmTable.Columns.Add("Czas zakończenia", typeof(string));
            harmTable.Columns.Add("Dzień i godzina", typeof(string));
            double[] Dzien = new double[C.Length];
            double[] Godzina = new double[C.Length];
            for (int i=1; i < pi.Length-1; i++)
            {
                Dzien[pi[i]] = Math.Ceiling((double)C[pi[i]] / (60 * 8));
                Godzina[pi[i]] = ((double)C[pi[i]] / (60 * 8)+1 - Dzien[pi[i]]) * 8;
                DataRow DR = harmTable.NewRow();
                DR["Lp."] = i;
                DR["Nazwisko"] = Lst[pi[i]-1].nazwisko;
                DR["Usluga"] = Lst[pi[i] - 1].usluga;
                DR["Czas zakończenia"] = C[pi[i]];
                DR["Dzień i godzina"] = "Dzień: "+ Dzien[pi[i]] +" Godzina: "+ String.Format("{0:0.00}", Godzina[pi[i]]);
                harmTable.Rows.Add(DR);
            }

            harmTable.Select();
            GWHarmonogram.DataSource = harmTable;
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
            public string nazwisko;
            public string usluga;
        }
        public class cp
        {
            public int nst;
            public int w;

        }
        public int harm(int Lp, List<CDesc> Lst, List<cp>[] Pop, List<cp>[] Nast, int[] C, int [] S)
{
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
            for (int i = 0; i <= Lp; i++)
            {
                C[i] = 0;
            }
            
            for (int i = 0; i <= Lp; i++)
            {
                S[i] = 0;
            }
            int iter = 0;
            while (Q.Count>0)
            {
                iter++;
                int node = Q.Dequeue();
                C[node] = S[node] + (int) (Lst[node - 1].czasusl);
                foreach(var ns in Nast[node])
                {
                    if (--LP[ns.nst] == 0)
                        Q.Enqueue(ns.nst);
                }
                foreach (var ns in Nast[node])
                {
                    if (ns.nst != 0)
                        S[ns.nst]=Math.Max(S[ns.nst], C[node]+ns.w);
                }
            }
            if (iter < Lp) return 0;
            return 1;
    }

        public void createGraph(int Lp, List<CDesc> Lst, int [] pi, out List<cp>[]  Nast, out List<cp>[] Pop)
        {
           Nast = new List<cp>[Lp + 2];
           Pop = new List<cp>[Lp + 2];
            for (int i = 0; i<Lp + 1; i++)
            {
                Nast[i] = new List<cp>();
                Pop[i] = new List<cp>();
            }
            for(int s=0; s<Lst.Count - 1; s++)
            {
                int nst = Lst[s].nast + 1;
                int w = (int)(Lst[s].przerwa);
                if (Lst[s].nast == 0)
                    continue;
                cp ee = new cp(); ee.nst = nst; ee.w = w;
                Nast[s + 1].Add(ee);
                cp p = new cp(); p.nst = s+1; p.w = w;
                Pop[nst].Add(p);

}
            for (int s = 0; s<Lp+1; s++)
            {
                int node = pi[s];
                int nst = pi[s + 1];
                if (node == 0) continue;
                if (nst == 0) continue;
                int w = 0;

                cp ee = new cp(); ee.nst = nst; ee.w = w;
                Nast[node].Add(ee);
                cp p = new cp(); p.nst =node; p.w = w;
                Pop[nst].Add(p);

            }
        }

        public int cmax(int Lp, int [] C)
        {

            int Cmax = 0;
            for (int i=0; i<=Lp; i++)
            {

                if (C[i] > Cmax)
                    Cmax = C[i];
            }
            return Cmax;
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
                    var rec1 = DR2[i];
                    CDesc el1 = new CDesc();
                    el1.czasusl = double.Parse(rec1["czas trwania"].ToString());
                    el1.przerwa = double.Parse(rec1["minOdstep"].ToString()) * 8 * 60;
                    el1.nazwisko = row["Dane Klienta"].ToString();
                    el1.usluga = rec1["Usluga"].ToString();
                    el1.nast = Lp+1;
                    Lst.Add(el1);
                    Lp++;
                }

                var rec = DR2[DR2.Length - 1];
                CDesc el = new CDesc();
                el.czasusl = double.Parse(rec["czas trwania"].ToString());
                el.przerwa = double.Parse(rec["minOdstep"].ToString())*8*60;
                el.nazwisko = row["Dane Klienta"].ToString();
                el.usluga = rec["Usluga"].ToString();
                el.nast = 0;
                Lst.Add(el);
                Lp++;

            }
            int []pi = new int[Lp + 2];
            for(int i=0;i<=Lp;i++)
            {
                pi[i] = i;

            }
            pi[0] = pi[Lp + 1] = 0;
            //pi[3] = 2;
            //pi[2] = 3;

            List<cp>[] Nast = new List<cp>[Lp + 2];
            List<cp>[] Pop = new List<cp>[Lp + 2];
            et:;
            createGraph(Lp, Lst, pi, out Nast, out Pop);
            int[] C = new int[Lp + 1];
            int[] S = new int[Lp + 1];
            int res = harm(Lp, Lst, Pop, Nast, C, S);
            int Cmax0=cmax(Lp, C);
            int bps = 0;
            int bCmax = 1000000;
            for ( int ps =1; ps<Lp-1;ps++)
            {
                int sw = pi[ps]; pi[ps] = pi[ps + 1];  pi[ps + 1] = sw;
                createGraph(Lp, Lst, pi, out Nast, out Pop);
               
                if(harm(Lp, Lst, Pop, Nast, C, S)==1)
                {
                    int Cmax = cmax(Lp, C);
                    if(Cmax<bCmax)
                    {
                        bCmax = Cmax;
                        bps = ps;
                        
                    }
                }

                sw = pi[ps]; pi[ps] = pi[ps + 1]; pi[ps + 1] = sw;
            }
            if(bCmax < Cmax0)
            {
               int sw = pi[bps]; pi[bps] = pi[bps + 1]; pi[bps + 1] = sw;
                goto et;
            }
            //----------dotąd na zajęciach
            createGraph(Lp, Lst, pi, out Nast, out Pop);
            harm(Lp, Lst, Pop, Nast, C, S);
            genHarm(pi, Lst, C);
        }

        private void Klienci_Click(object sender, EventArgs e)
        {

        }

        private void Harmonogram_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void GWHarmonogram_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
