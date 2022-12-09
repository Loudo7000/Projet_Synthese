using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covoiturage
{
    internal class Usager
    {
        int id;
        string nom;
        string prenom;
        string adresse;
        string numTel;
        string email;
        string mdp;
        string typeUsager;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string NumTel { get => numTel; set => numTel = value; }
        public string Email { get => email; set => email = value; }
        public string Mdp { get => mdp; set => mdp = value; }
        public string TypeUsager { get => typeUsager; set => typeUsager = value; }
    }
}
