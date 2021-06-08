using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datagridview
{
    class clsEmploye
    {
        public static List<clsEmploye> ListeEmployes = new List<clsEmploye>();

        private string nom;
        private string prenom;
        private string pictureFilename;
        private char sex;
        private bool marié;

        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string PictureFilename { get => pictureFilename; set => pictureFilename = value; }
        public char Sex { get => sex; set => sex = value; }
        public bool Marié { get => marié; set => marié = value; }

        public clsEmploye(string nom, string prenom, string pictureFilename,char sex, bool marie)
        {
            Nom = nom;
            Prenom = prenom;
            PictureFilename = pictureFilename;
            Sex = sex;
            Marié = marie;
        }
    }
}
