using System;
using System.Collections.Generic;
using System.Linq;

namespace TPMoyennes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Création d'une classe
            Classe sixiemeA = new Classe("6eme A");
            // Ajout des élèves à la classe
            sixiemeA.ajouterEleve("Jean", "RAGE");
            sixiemeA.ajouterEleve("Paul", "HAAR");
            sixiemeA.ajouterEleve("Sibylle", "BOQUET");
            sixiemeA.ajouterEleve("Annie", "CROCHE");
            sixiemeA.ajouterEleve("Alain", "PROVISTE");
            sixiemeA.ajouterEleve("Justin", "TYDERNIER");
            sixiemeA.ajouterEleve("Sacha", "TOUILLE");
            sixiemeA.ajouterEleve("Cesar", "TICHO");
            sixiemeA.ajouterEleve("Guy", "DON");
            // Ajout de matières étudiées par la classe
            sixiemeA.ajouterMatiere("Francais");
            sixiemeA.ajouterMatiere("Anglais");
            sixiemeA.ajouterMatiere("Physique/Chimie");
            sixiemeA.ajouterMatiere("Histoire");
            Random random = new Random();
            // Ajout de 5 notes à chaque élève et dans chaque matière
            for (int ieleve = 0; ieleve < sixiemeA.eleves.Count(); ieleve++)
            {
                for (int matiere = 0; matiere < sixiemeA.matieres.Count(); matiere++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        sixiemeA.eleves[ieleve].ajouterNote(new Note(matiere, (float)((6.5 +
                       random.NextDouble() * 34)) / 2.0f));
                        // Note minimale = 3
                    }
                }
            }

            Eleve eleve = sixiemeA.eleves[6];
            // Afficher la moyenne d'un élève dans une matière
            Console.Write(eleve.prenom + " " + eleve.nom + ", Moyenne en " + sixiemeA.matieres[1] + " : " +
            eleve.Moyenne(1) + "\n");
            // Afficher la moyenne générale du même élève
            Console.Write(eleve.prenom + " " + eleve.nom + ", Moyenne Generale : " + eleve.Moyenne() + "\n");
            // Afficher la moyenne de la classe dans une matière
            Console.Write("Classe de " + sixiemeA.nomClasse + ", Moyenne en " + sixiemeA.matieres[1] + " : " +
            sixiemeA.Moyenne(1) + "\n");
            // Afficher la moyenne générale de la classe
            Console.Write("Classe de " + sixiemeA.nomClasse + ", Moyenne Generale : " + sixiemeA.Moyenne() + "\n");
            Console.Read();
        }
    }
}
// Classes fournies par HNI Institut
class Note
{
    public int matiere { get; private set; }
    public float note { get; private set; }
    public Note(int m, float n)
    {
        matiere = m;
        note = n;
    }
}

// Classes développées pour le TP
class Classe
{
    public string nomClasse { get; private set; }
    public Eleve[] eleves = new Eleve[30];
    public string[] matieres = new string[10];
    public int ieleve = 0;
    public int imat = 0;

    public Classe(String NOMCLASSE)
    {
        nomClasse = NOMCLASSE;
    }

    public double Moyenne(int Arg1)
    {
        double MoyM = 0;
        foreach (Eleve e in eleves)
        {
            double sum = 0;
            int nbNotes = 0;
            for (int i = 0; i < e.notes.Count(); i++)
            {
                if (e.notes[i].matiere == Arg1)
                {
                    sum += e.notes[i].note;
                    nbNotes++;
                }
            }
            MoyM += sum / nbNotes;
        }
        return MoyM;
    }
    public double Moyenne()
    {
        double MoyG = 0;
        foreach (Eleve e in eleves)
        {
            double moyg = 0;
            int NbMat = 0;
            for (int i = 0; i < 10; i++)
            {
                double sum = 0;
                int nbNotes = 0;
                for (int ii = 0; ii < e.notes.Count(); ii++)
                {
                    if (e.notes[ii].matiere == i)
                    {
                        sum += e.notes[i].note;
                        nbNotes++;
                    }
                }

                if (nbNotes != 0)
                {
                    moyg += sum / nbNotes;
                    NbMat++;
                }

            }
            MoyG += moyg / NbMat;
        }
        return MoyG;
    }
    public void ajouterEleve(String NOM, String PRENOM)
    {
        Eleve e = new Eleve(NOM, PRENOM);
        if (ieleve < eleves.Length)
        {
            eleves[ieleve] = e;
            ieleve++;
        }
    }
    public void ajouterMatiere(string MATIERE)
    {
        string m = MATIERE;
        if (imat < matieres.Length)
        {
            matieres[imat] = m;
            imat++;
        }
    }
}

class Eleve
{
    public string nom { get; private set; }
    public string prenom { get; private set; }
    public Note[] notes = new Note[200];

    public Eleve(String NOM, String PRENOM)
    {
        nom = NOM;
        prenom = PRENOM;
    }
    public void ajouterNote(Note note)
    {
      //  if (notes.Count() < notes.Length)
        {
           notes[notes.Count()+1] = note;
        }
    }
    public double Moyenne(int arg2)
    {
        double sum = 0;
        int nbNotes = 0;
        for (int i = 0; i < notes.Count(); i++)
        {
            if (notes[i].matiere == arg2)
            {
                sum += notes[i].note;
                nbNotes++;
            }
        }
        return sum / nbNotes;
    }
    public double Moyenne()
    {
        double moyg = 0;
        int NbMat = 0;
        for (int i = 0; i < 10; i++)
        {
            double sum = 0;
            int nbNotes = 0;
            for (int ii = 0; ii < notes.Count(); ii++)
            {
                if (notes[ii].matiere == i)
                {
                    sum += notes[i].note;
                    nbNotes++;
                }
            }

            if (nbNotes != 0)
            {
                moyg += sum / nbNotes;
                NbMat++;
            }

        }
        return moyg / NbMat;
    }
}

