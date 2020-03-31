using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidentaAgenda
{
    class Agenda
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A. Adaugare persoane in agenda\n" +
                "P. Afiseaza agenda\n" +
                "C. Citirea unei persoane de la tastatura\n" +
                "N. Compararea a doua persoane dupa nume si afisarea alfabetic\n" +
                "E. Afisarea grupului din care face parte persoana\n"+
                "L. Citirea din linia de comanda si afisarea sub forma de matrice alfabetica");
            string optiune;
            Persoana[] persoane=new Persoana[15];
            int nrPersoane=0;
            bool ok = true;
            do
            {
                Console.WriteLine("\nAlegeti o optiune: ");
                optiune = Console.ReadLine();
                switch (optiune.ToUpper())
                {
                    case "A":
                        persoane[0] = new Persoana("Gumina Sebastian,0751702564,sebastian.gumina@student.usv.ro");
                        nrPersoane++;
                        persoane[1] = new Persoana("Marginean Maria", "0742765664", "maria.marginean@student.usv.ro");
                        nrPersoane++;
                        break;
                    case "P":
                        AfisarePersoana(persoane, nrPersoane);
                        break;
                    case "C":
                        persoane[nrPersoane] = CitirePersoanaTastatura();
                        nrPersoane++;
                        break;
                    case "N":
                        int compare = persoane[0].NameCompare(persoane[1]);
                        if (compare == 1)
                            Console.WriteLine("{1}\n{0}", persoane[0].nume, persoane[1].nume);
                        else
                            if (compare == -1)
                            Console.WriteLine("{0}\n{1}", persoane[0].nume, persoane[1].nume);
                        else
                            Console.WriteLine("Numele este identic {0}", persoane[0].nume);
                        break;
                    case "E":
                        nrPersoane = 0;
                        persoane[nrPersoane] = new Persoana("Popescu Ion", "0753674287", "ion.popescu@gmail.com",Groups.Family);
                        nrPersoane++;
                        persoane[nrPersoane] = new Persoana("Antonescu Cristina", "0753656787", "cristina.antonescu@gmail.com", Groups.Friends);
                        nrPersoane++;
                        Afisare(persoane, nrPersoane);
                        break;
                    case "L":
                        int i;
                        string[,] matLiniaComanda = new string[26,26];
                        int[] aparitii = new int[26];
                        for (int k = 0; k <= 25; k++)
                            aparitii[k] = 0;
                        if (args.Length == 0)
                            Console.WriteLine("Linia de comanda nu contine argumente");
                        else
                        {
                            Console.WriteLine("Linia de comanda contine :");
                            foreach (string param in args)
                            {
                                string sir = param;
                                string[] cuvinte = sir.Split(' ');
                                foreach (string val in cuvinte)
                                {
                                    if (val[0] >= 'a' && val[0] <= 'z')
                                    {
                                        i = (int)val[0] - 'a';
                                        matLiniaComanda[i, aparitii[i]] = val;
                                        aparitii[i]++;
                                    }
                                    else
                                        if (val[0] >= 'A' && val[0] <= 'Z')
                                        {
                                            i = (int)val[0] - 'A';
                                            matLiniaComanda[i, aparitii[i]]= val;
                                            aparitii[i]++;
                                        }
                                }
                                bool success;
                                for (int row = 0; row <= 25; row++)
                                {
                                   success=false;
                                    for (int col = 0; col < aparitii[row]; col++)
                                    {
                                        Console.Write(matLiniaComanda[row, col] + " ");
                                        success = true;
                                    }
                                    if(success)
                                        Console.WriteLine();
                                }
                            }

                        }
                        break;
                    case "X":
                        ok = false;
                        break;
                    default:
                        Console.WriteLine("Optiune invalida");
                        break;
                }
            } while (ok == true);

            Console.ReadKey();
        }
        //citirea de la tastatura
        public static Persoana CitirePersoanaTastatura()
        {
            Console.WriteLine("Introduceti numele si prenumele separate prin spatiu: ");
            string nume = Console.ReadLine();

            Console.WriteLine("Introduceti numarul de telefon: ");
            string numar = Console.ReadLine();

            Console.WriteLine("Introduceti mail-ul: ");
            string mail = Console.ReadLine();
            Persoana p = new Persoana(nume, numar,mail);
            return p;
        }
        //afisarea persoanelor din agenda
        public static void AfisarePersoana(Persoana[] persoane, int nrPersoane)
        {
            Console.WriteLine("Persoanele din agenda sunt: ");
            for (int i = 0; i < nrPersoane; i++)
            {
                Console.WriteLine(persoane[i].ConversieLaSir());
            }
        }
        //afisarea persoanelor din agenda care fac parte dintr-un grup
        public static void Afisare(Persoana[] persoane, int nrPersoane)
        {
            Console.WriteLine("Persoanele din agenda sunt: ");
            for (int i = 0; i < nrPersoane; i++)
            {
                Console.WriteLine(persoane[i].PrintData());
            }
        }
    }
}
