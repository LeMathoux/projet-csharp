using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheatreBO;

namespace UtilisateursBO
{
    public class Client
    {
        public int IdClient { get; set; }
        public string NomClient { get; set; }
        public string PrenomClient { get; set; }
        public string MailClient { get; set; }
        public string TelClient { get; set; }


        public Client(int Id, string Nom, string Prenom, string Mail, string Tel)
        {
            IdClient = Id;
            NomClient = Nom;
            PrenomClient = Prenom;
            MailClient = Mail;
            TelClient = Tel;
        }
    }
}
