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
        public string NomCient { get; set; }
        public string PrenomCient { get; set; }
        public string MailClient { get; set; }
        public string TelClient { get; set; }


        public Client(int Id, string Nom, string Prenom, string Mail, string Tel)
        {
            IdClient = Id;
            NomCient = Nom;
            PrenomCient = Prenom;
            MailClient = Mail;
            TelClient = Tel;
        }
    }
}
