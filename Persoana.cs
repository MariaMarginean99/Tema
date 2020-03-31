using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidentaAgenda
{
    public enum Groups {Family,Friends,Work,TennisTeam};
    public class Persoana
    {

        enum Days { Luni, Marti, Miercuri, Joi, Vineri, Sambata, Duminica }
        

       public Groups groups;

        //preprietati auto-implemented 
        public static int IdUltimPersoana { get; set; } = 0;
        public string nume { get; set; }
        public string numar { get; set; }
        public string mail { get; set; }
        public int IdPersoana { get; set; }

        //constructor implicit(Tema laborator2)
        public Persoana()
        {

        }
        //constructor care primeste ca parametru un sir(Tema laborator3)
        public Persoana(string sir)
        {
            string[] cuvinte = sir.Split(',');
            nume = cuvinte[0];
            numar = cuvinte[1];
            mail = cuvinte[2];
            IdUltimPersoana++;
            IdPersoana= IdUltimPersoana;
        }
        //constructor cu 3 parametrii(Tema laborator2)
        public Persoana(string _nume,string _numar,string _mail)
        {
            nume = _nume;
            numar = _numar;
            mail = _mail;
            IdUltimPersoana++;
            IdPersoana = IdUltimPersoana;
        }
        //constructor cu 4 parametrii(Tema laborator5)
        public Persoana(string _nume, string _numar, string _mail,Groups _groups)
        {
            nume = _nume;
            numar = _numar;
            mail = _mail;
            groups = _groups;
            IdUltimPersoana++;
            IdPersoana = IdUltimPersoana;
        }
        public int NameCompare(Persoana p1)
        {
            return nume.CompareTo(p1.nume);
        }
        //Afiseaza datele despre o persoana(Tema laborator 4)
        public string ConversieLaSir()
        {
            string sir1;
            if (nume == null || numar == null || mail == null)
                sir1 = string.Format("Adaugati persoana in agenda prima data");
            else
                 sir1 = string.Format("\nPersoana are numele: {0}\nNumarul de telefon: {1}\nEmail-ul: {2}", nume, numar, mail);
            return sir1;
        }
        //Afisarea datelor despre o persoana plus grupul din care face parte
        public string PrintData()
        {
            string sir1;
            if (nume == null || numar == null || mail == null || groups == null)
                sir1 = string.Format("Adaugati persoana in agenda prima data");
            else
                sir1 = string.Format("\nPersoana are numele: {0}\nNumarul de telefon: {1}\nEmail-ul: {2}\nFace parte din grupul {3}", nume, numar, mail,groups);
            return sir1;
        }
        //afisare persoana(Tema laborator 2)
        public string Afisare()
        {
            if (nume == null || numar == null || mail == null)
                return string.Format("Adaugati persoana in agenda prima data");
            else
               return string.Format("\nPersoana are numele: {0}\nNumarul de telefon: {1}\nEmail-ul: {2}", nume, numar, mail);
        }
    }
}
