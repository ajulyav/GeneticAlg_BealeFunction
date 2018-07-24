using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.CodeDom;
using System.Collections;
namespace genal
{
  

    public class GEN
    {
       public double X_gen;
       public double min_gran,  max_gran;
    }
    public class Hrom
    {
        //public ArrayList best_fitness = new ArrayList();
        public GEN[] Gen_array; 
        public int n_GEN;
        public double fitness;
        public double Func_fitness()
        {
            double y = 0;
            GEN gen1 = new GEN();
            GEN gen2 = new GEN();
            gen1 = Gen_array[0];
            gen2 = Gen_array[1];
            
            y = Math.Pow((1.5 - gen1.X_gen + gen1.X_gen * gen2.X_gen), 2) + Math.Pow((2.25 - gen1.X_gen + gen1.X_gen * Math.Pow((gen2.X_gen), 2)), 2)
                 + Math.Pow(2.625 - gen1.X_gen + gen1.X_gen * Math.Pow((gen2.X_gen), 3), 2);
            return y;
         
        }
        public void Init_Hrom()
        { GEN gen;
            Gen_array = new GEN[2];
            for (int i = 0; i < n_GEN; i++)
            {
                gen = new GEN();
                gen.min_gran = -4.5;
                gen.max_gran = 4.5;
                gen.X_gen =  Form1.r.NextDouble() * (gen.max_gran - gen.min_gran) + gen.min_gran;
                Gen_array[i] = gen;

            }
        }
    }
    public class Popul
    {
        public int Pop_size, iteration, n_GEN;
        public ArrayList best_fitnessdouble = new ArrayList();
        public double e, mut_proba, cross_proba;
        public ArrayList Hrom_array;
        public ArrayList Init_Popul ()
        {
            Hrom h;
            ArrayList Hrom_a = new ArrayList();
            for (int i = 0; i < Pop_size; i++)
            {
                h = new Hrom();
                h.n_GEN = n_GEN;
                h.Init_Hrom();
                h.fitness = h.Func_fitness();
                Hrom_a.Add(h);

            }
            return Hrom_a;
                       }
        public Hrom[] Crossover_arifmetik(Hrom hrom1, Hrom hrom2, double w)
        {
            Hrom[] h = new Hrom[2];
            Hrom potomok1 = new Hrom();
            potomok1.Gen_array = new GEN[n_GEN];
            Hrom potomok2 = new Hrom();
            potomok2.Gen_array = new GEN[n_GEN];
            GEN g1 = new GEN();
            GEN g2 = new GEN();
            for (int i = 0; i < hrom1.n_GEN; i++)
            {
                g1 = new GEN();
                g2 = new GEN();
                g1.X_gen = w * (double)hrom1.Gen_array[i].X_gen + (1 - w) * (double)hrom2.Gen_array[i].X_gen;
                g1.min_gran = hrom1.Gen_array[i].min_gran;
                g1.max_gran = hrom1.Gen_array[i].max_gran;
                potomok1.Gen_array[i] = g1;
                g2.X_gen = w * (double)hrom2.Gen_array[i].X_gen + (1 - w) * (double)hrom1.Gen_array[i].X_gen;
                g2.min_gran = hrom2.Gen_array[i].min_gran;
                g2.max_gran = hrom2.Gen_array[i].max_gran;
                potomok2.Gen_array[i] = g2;
            }
            potomok1.fitness = potomok1.Func_fitness();
            potomok2.fitness = potomok2.Func_fitness();
            potomok1.n_GEN = hrom1.n_GEN;
            potomok2.n_GEN = hrom2.n_GEN;
            h[0] = potomok1;
            h[1] = potomok2;
            return h;
        }
     
        public Hrom[] Crossover_lineyniy(Hrom hrom1, Hrom hrom2)
        {
            Hrom[] h = new Hrom[2];
            Hrom potomok1 = new Hrom();
            potomok1.Gen_array = new GEN[n_GEN];
            Hrom potomok2 = new Hrom();
            potomok2.Gen_array = new GEN[n_GEN];
            Hrom potomok3 = new Hrom();
            potomok3.Gen_array = new GEN[n_GEN];
            GEN g1 = new GEN();
            GEN g2 = new GEN();
            GEN g3 = new GEN();
            for (int i = 0; i < hrom1.n_GEN; i++)
            {
                g1 = new GEN();
                g2 = new GEN();
                g3 = new GEN();
                g1.X_gen = 0.5 * (double)hrom1.Gen_array[i].X_gen + 0.5 * (double)hrom2.Gen_array[i].X_gen;
                g1.max_gran = hrom1.Gen_array[i].max_gran;
                g1.min_gran = hrom1.Gen_array[i].min_gran;
                if (g1.min_gran > g1.X_gen)
                {
                    g1.X_gen = g1.max_gran;
                }
                    
                if (g1.max_gran < g1.X_gen)
                {
                    g1.X_gen = g1.max_gran;
                }
                    potomok1.Gen_array[i] = g1;
              
                g2.X_gen = 1.5 * (double)hrom1.Gen_array[i].X_gen - 0.5 * (double)hrom2.Gen_array[i].X_gen;
                g2.min_gran = hrom1.Gen_array[i].min_gran;

                g2.max_gran = hrom1.Gen_array[i].max_gran;
                if (g2.min_gran > g2.X_gen)
                {
                    g2.X_gen = g2.max_gran;
                }

                if (g2.max_gran < g2.X_gen)
                {
                    g2.X_gen = g2.max_gran;
                }
                potomok2.Gen_array[i] = g2;
                g3.X_gen = - 0.5 * (double)hrom1.Gen_array[i].X_gen + 1.5 * (double)hrom2.Gen_array[i].X_gen;
                g3.min_gran = hrom1.Gen_array[i].min_gran;
                g3.max_gran = hrom1.Gen_array[i].max_gran;
                if (g3.min_gran > g1.X_gen)
                {
                    g3.X_gen = g3.max_gran;
                }

                if (g3.max_gran < g3.X_gen)
                {
                    g3.X_gen = g3.max_gran;
                }
                potomok3.Gen_array[i] = g3;
            }
            potomok1.fitness = potomok1.Func_fitness();
            potomok2.fitness = potomok2.Func_fitness();
            potomok3.fitness = potomok3.Func_fitness();
            Hrom buf = new Hrom();
            int k = 1;
            potomok1.n_GEN = hrom1.n_GEN;
            potomok2.n_GEN = hrom2.n_GEN;
            potomok3.n_GEN = hrom2.n_GEN;
            if (potomok1.fitness > potomok2.fitness)
            {
                buf = potomok1;
                k = 1;
                h[0] = potomok2;
            }
            else
            {
                buf = potomok2;
                k = 2;
                h[0] = potomok1;
            }
            if (buf.fitness < potomok3.fitness)
            {
                h[1] = buf;
            }
            else
            {
                h[1] = potomok3;
            }


            return h;
                       
        }

        public Hrom Mutat_Random(Hrom Parents)
        {

            Random rnumber = new Random();

            Hrom hrom = new Hrom();
            hrom.Gen_array = new GEN[n_GEN];

            Hrom h1 = new Hrom();

            Hrom h2 = new Hrom();


            GEN g1 = new GEN();


            double min = -4.5;
            double max = 4.5;
            
            double result = rnumber.NextDouble() * (max - min) + min;

            //int randcreature = rnumber.Next(0, Pop_size);

            int randgen = rnumber.Next(0, 2);

            //ArrayList trimArray = new ArrayList();

            //trimArray.Add(Hrom_array[randcreature]);


            
            //h1 = (Hrom)Hrom_array[randcreature];

            g1.X_gen = Parents.Gen_array[randgen].X_gen;

            g1.X_gen = result;

            Parents.Gen_array[randgen].X_gen = g1.X_gen;

            hrom.Gen_array = Parents.Gen_array;

            hrom.n_GEN = n_GEN;

            hrom.fitness = Parents.Func_fitness();

            //Hrom_array.RemoveAt(randcreature);
            Hrom_array.Remove(Parents);

            return hrom;

        }

        public Hrom Mutant_Vesh (Hrom hrom1)
        {
            Hrom hrom = new Hrom();
            hrom.Gen_array = new GEN[n_GEN];
            int Hi = Form1.r.Next(0, 2);
            double r = Form1.r.NextDouble();
            GEN g1 = new GEN();
            if (Hi == 0)
            {
                for (int i = 0; i < n_GEN; i++)
                {
                    g1 = new GEN();
                    g1.X_gen = hrom1.Gen_array[i].X_gen + Hi * r * (hrom1.Gen_array[i].max_gran - hrom1.Gen_array[i].X_gen);
                    g1.min_gran = hrom1.Gen_array[i].min_gran;
                    g1.max_gran = hrom1.Gen_array[i].max_gran;
                    hrom.Gen_array[i] = g1;
                }
                
            }
            else
            {
                for (int i = 0; i < n_GEN; i++)
                {
                    g1 = new GEN();
                    g1.X_gen = hrom1.Gen_array[i].X_gen - Hi * r * (hrom1.Gen_array[i].min_gran - hrom1.Gen_array[i].X_gen);
                    g1.min_gran = hrom1.Gen_array[i].min_gran;
                    g1.max_gran = hrom1.Gen_array[i].max_gran;
                    hrom.Gen_array[i] = g1;
                }
                
            }
            hrom.n_GEN = hrom1.n_GEN;
            hrom.fitness = hrom.Func_fitness();
            return hrom;
        }

        public Hrom [] selection_random(int n)
        {
            Hrom[] h = new Hrom[n];
            int []a = new int[n];
            int k, Proverka = 0;
            for (int i = 0; i < n; i++)
            {
                k = Form1.r.Next(0, Hrom_array.Count - 1);
                
                if(i != 0)
                {
                    for (int j =i; j > 0; j--)
                    {
                        if (a[j] == k)
                        {
                            k = Form1.r.Next(0, Hrom_array.Count - 1);
                            j = i;
                        }
                    }
                }
                a[i] = k;
                h[i] = (Hrom)Hrom_array[k];
            }
            return h;
        }
        public Hrom[] selection_roulet(int n)
        {
            double sum_fitness = 0;
            Hrom k = new Hrom();
            Hrom [] p = new Hrom[n];
            ArrayList a = new ArrayList();
            for (int i = 0; i < Hrom_array.Count; i++)
            {
                k = (Hrom)Hrom_array[i];
                sum_fitness += Math.Abs(1/k.fitness);
            }
            int j = 0;
            while (j < n)
            {
                double slice = Form1.r.NextDouble() * sum_fitness;
                double curFitness = 0.0;
                int l = 0;
                foreach (Hrom ind in Hrom_array)
                {
                    curFitness += 1 / ind.fitness;
                    if (curFitness >= slice)
                    {
                        if (a.Contains(l))
                        {
                            j--;
                            break;
                        }
                        else 
                        {
                            p[j] = ind;
                            a.Add(l);
                            break;

                        }
                                        
                                 
                    }
                
                    l++; 
                }
                j++;
            }
                                        
            return p;
        }

        public void Sort()
        {
            Hrom buf = new Hrom();
            Hrom h1 = new Hrom();
            Hrom h2 = new Hrom();
            for (int i = 0; i < Hrom_array.Count - 1; i++)
            {
                for (int j = i+1; j < Hrom_array.Count; j++)
                {
                    h1 = new Hrom();
                    h2 = new Hrom();
                    h1 = (Hrom)Hrom_array[i];
                    h2 = (Hrom)Hrom_array[j];
                    if (h1.fitness > h2.fitness)
                    {
                       buf = new Hrom();
                        buf = h2;
                        Hrom_array[j] = h1;
                        Hrom_array[i] = buf;
                        
                    }

                }

            }
        }

        public Hrom Start(string c_value, string m_value, string s_value)
        {
            ArrayList best_fitness = new ArrayList();
            Form1 form = new Form1();
            Hrom h = new Hrom();
            Hrom htry = new Hrom();
            Hrom htry2 = new Hrom();
            Hrom_array = new ArrayList();
            Hrom[] Parents;
            Hrom[] Potomki;

            Hrom_array = Init_Popul();
            for (int i = 0; i < iteration; i++)
            {
                Parents = new Hrom[2];
                Parents = selection_random(2);
                Potomki = new Hrom[2];

                if (c_value=="arif")
                {
                    Potomki = Crossover_arifmetik(Parents[0], Parents[1], 0.7);
                }
                else
                {
                    Potomki = Crossover_lineyniy(Parents[0], Parents[1]);
                }


                this.Hrom_array.Add(Potomki[0]);
                this.Hrom_array.Add(Potomki[1]);
                Parents = new Hrom[1];

                if (s_value=="rand")
                {
                    Parents = selection_random(1);
                }
                else
                {
                    Parents = selection_roulet(1);
                }


                h = new Hrom();
                if (m_value == "rand")
                {
                    h = Mutat_Random(Parents[0]);
                }
                else
                {
                    h = Mutant_Vesh(Parents[0]);
                }
                this.Hrom_array.Add(h);
                Sort();
                Hrom_array.RemoveRange(Pop_size, Hrom_array.Count - Pop_size);

                

                h = (Hrom)Hrom_array[0];
                best_fitness.Add(h.fitness);
                //best_fitness.Add(Hrom_array[0]);

                
                Hrom exit = new Hrom();
                exit = (Hrom)Hrom_array[0];
                if (exit.fitness < this.e)
                {
                    break;
                }
            }
            h = (Hrom)Hrom_array[0];
            best_fitnessdouble.AddRange(best_fitness);
            return h;
  
        }


    }
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
