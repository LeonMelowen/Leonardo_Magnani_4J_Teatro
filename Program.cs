using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonardo_Magnani_4J_Teatro
{
    class Program
    {


        static void Main(string[] args)
        {

            Teatro lyceum = new Teatro("Lyceum Theatre", "21 Wellington St, Covent Garden, London WC2E 7RQ, Regno Unito");
            lyceum.AddPosto(new Posto("C", 1, "Platea"));
            lyceum.AddPosto(new Posto("A", 1, "Palco"));
            lyceum.AddPosto(new Posto("B", 1, "Loggione"));
            Compagnia disney = new Compagnia("Walt Disney Theatrical");
            Compagnia william = new Compagnia("William");
            Spettacolo lionKing = new Spettacolo("Lion King", "Musical", "The Lion King è un pluripremiato musical in due atti su libretto di Roger Allers e Irene Mecchi, diretto da Julie Taymor.", "2:00", 26.90, disney);
            Spettacolo hamlet = new Spettacolo("Hamlet", "Tragedia", "È tra le opere più frequentemente rappresentate in quasi ogni paese occidentale ed è considerata un testo cruciale per attori maturi.", "3:00", 20.50, william);
            lyceum.AddRappresentazione(new Rappresentazione(lionKing, new DateTime(2020, 03, 27), "12:30"));
            lyceum.AddRappresentazione(new Rappresentazione(hamlet, new DateTime(2020, 03, 28), "16:30"));
            disney.AddAttore(new Attore("Marco", "Jotaro", new DateTime(1999, 02, 27), "Simba"));
            william.AddAttore(new Attore("Barnette", "Orangello", new DateTime(2000, 04, 18), "Orazio"));
            Persona giulio = new Persona("Giulio", "Johannes", new DateTime(1997, 07, 21));
            Persona simone = new Persona("Simone", "Rossi", new DateTime(1995, 01, 13));
            Biglietto bigliettoGiulio = new Biglietto(giulio, lyceum.getPosto("A", 1, "Palco"),lionKing);
            Biglietto bigliettoSimone = new Biglietto(simone, lyceum.getPosto("B", 1, "Loggione"), hamlet);

            Console.Write("\n Nome teatro:\n " + lyceum.getNome() + "\n\n Indirizzo teatro:\n " + lyceum.getIndirizzo());
            Console.Write("\n\n Posti:\n");

            foreach(Posto posto in lyceum.getPosti())
            {

                Console.Write(" " + posto.getFila() + " " + posto.getNumero() + " " + posto.getTipo() + "\n");

            }

            Console.Write("\n\n Compagnia:\n " + disney.getNome());

            foreach (Attore attore in disney.getAttori())
            {

                Console.Write("\n Attori: \n Nome: " + attore.getNome() + " " + attore.getCognome() + " NATO:" + attore.getDataNascita() + " RUOLO:" + attore.getRuolo());

            }

            Console.Write("\n\n Compagnia:\n " + william.getNome());

            foreach (Attore attore in william.getAttori())
            {

                Console.Write("\n Attori: \n Nome: " + attore.getNome() + " " + attore.getCognome() + " NATO:" + attore.getDataNascita() + " RUOLO:" + attore.getRuolo());

            }

            Console.Write("\n\n Bligietti venduti:\n");
            Console.Write(" " + bigliettoGiulio.getString() + lyceum.getDataRappresentazione(lionKing) + " Prezzo: " + bigliettoGiulio.CalcolaPrezzo() + "\n");
            Console.Write(" " + bigliettoSimone.getString() + lyceum.getDataRappresentazione(hamlet) +" Prezzo: " + bigliettoSimone.CalcolaPrezzo() + "\n");

            Console.ReadKey();
        }

        /** @brief Classe Persona usata come classe madre e come cliente.

            Usata come classe madre della classe Attore e come cliente.
            */
        class Persona
        {

            protected string nome; /**< Detailed Nome persona */
            protected string cognome; /**< Detailed Cognome persona */
            protected DateTime dataNascita; /**< Detailed Data di nascita persona */

            /** Il costruttore. Inizializza gli attributi.
                */
            public Persona(string nome, string cognome, DateTime dataNascita)
            {

                this.nome = nome;
                this.cognome = cognome;
                this.dataNascita = dataNascita;

            }

            /** getNome restituisce il nome della Persona.
                @return nome
            */
            public virtual string getNome()
            {

                return this.nome;

            }

            /** getCognome restituisce il cognome della Persona.
                @return cognome
            */
            public virtual string getCognome()
            {

                return this.cognome;

            }

        }


        /** @brief Classe Attore, attore dello spettacolo.

            Sottoclasse della classe madre Persona
            */
        class Attore : Persona
        {

            string ruolo; /**< Detailed Ruolo Attore */

            /** Il costruttore. Inizializza gli attributi.
                */
            public Attore(string nome, string cognome, DateTime dataNascita,string ruolo) :base(nome,cognome,dataNascita)
            {

                this.ruolo = ruolo;

            }

            /** getNome restituisce il nome dell'Attore.
                @return nome
            */
            public override string getNome()
            {

                return this.nome;

            }

            /** getCognome restituisce il cognome dell'Attore.
                @return cognome
            */
            public override string getCognome()
            {

                return this.cognome;

            }

            /** getDataNascita restituisce la data di nascita dell'Attore.
                @return dataNascita
            */
            public DateTime getDataNascita()
            {

                return this.dataNascita;

            }

            /** getRuolo restituisce il ruolo dell'Attore.
                @return ruolo
            */
            public string getRuolo()
            {

                return this.ruolo;

            }

        }


        /** @brief Classe Compagnia, compagnia di cui fanno parte gli attori.

            
            */
        class Compagnia
        {

            private string nome; /**< Detailed Nome Compagnia */
            List<Attore> attori; /**< Detailed Attori della compagnia */

            /** Il costruttore. Inizializza gli attributi.
                */
            public Compagnia(string nome)
            {

                this.nome = nome;
                this.attori = new List<Attore>();

            }

            /** AddAttore aggiunge un attore nella lista di Attori.
                @param attore
            */
            public void AddAttore(Attore attore)
            {

                attori.Add(attore);

            }

            /** getNome restituisce il nome della Compagnia.
                @return nome 
            */
            public string getNome()
            {

                return this.nome;

            }

            /** getAttore restituisce la lista di Attori della Compagnia.
                @return attori 
            */
            public List<Attore> getAttori()
            {

                return this.attori;

            }

        }


        /** @brief Classe Spettacolo.

            
            */
        class Spettacolo
        {

            private string nome; /**< Detailed Nome Spettacolo */
            private string tipo; /**< Detailed Tipo Spettacolo */
            private string descrizione; /**< Detailed Descrizione Spettacolo */
            private string durata; /**< Detailed Durata Spettacolo */
            private double sPrezzo; /**< Detailed Prezzo Spettacolo */

            /** Il costruttore. Inizializza gli attributi.
                */
            public Spettacolo(string nome, string tipo, string descrizione, string durata,double sPrezzo, Compagnia compagnia)
            {

                this.nome = nome;
                this.tipo = tipo;
                this.descrizione = descrizione;
                this.durata = durata;
                this.sPrezzo = sPrezzo;

            }

            /** getsPrezzo restituisce il prezzo dello Spettacolo.
                @return sPrezzo
            */
            public double GetsPrezzo()
            {

                return this.sPrezzo;

            }

            /** getNome restituisce il nome dello Spettacolo.
                @return nome
            */
            public string getNome()
            {

                return this.nome;

            }

        }


        /** @brief Classe Rappresentazione.

            
            */
        class Rappresentazione
        {

            Spettacolo spettacolo; /**< Detailed Spettacolo da Rappresentare */
            DateTime giorno; /**< Detailed Giorno della Rappresentazione */
            string ora; /**< Detailed Ora della Rappresentazione */

            /** Il costruttore. Inizializza gli attributi.
                */
            public Rappresentazione(Spettacolo spettacolo, DateTime giorno, string ora)
            {

                this.spettacolo = spettacolo;
                this.giorno = giorno;
                this.ora = ora;

            }

            /** getSpettacolo restituisce lo spettacolo da Rappresentare.
                @return spettacolo
            */
            public Spettacolo getSpettacolo()
            {

                return spettacolo;

            }

            /** getGiorno restituisce il giorno della Rappresentazione.
                @return giorno
            */
            public DateTime getGiorno()
            {

                return giorno;

            }

            /** getOra restituisce l'ora della Rappresentazione.
                @return ora
            */
            public string getOra()
            {

                return ora;

            }

        }


        /** @brief Classe Teatro.

            
            */
        class Teatro
        {

            private string nome; /**< Detailed Nome del Teatro */
            private string indirizzo; /**< Detailed Indirizzo del Teatro */
            List<Posto> posti; /**< Detailed Posti nel Teatro */
            List<Rappresentazione> rappresentazioni; /**< Detailed Rappresentazioni del Teatro */

            /** Il costruttore. Inizializza gli attributi.
                */
            public Teatro(string nome, string indirizzo)
            {

                this.nome = nome;
                this.indirizzo = indirizzo;
                this.posti = new List<Posto>();
                this.rappresentazioni = new List<Rappresentazione>();

            }

            /** AddPosto aggiunge un Posto nella lista di Posti.
                @param posto
            */
            public void AddPosto(Posto posto)
            {

                posti.Add(posto);

            }

            /** AddRappresentazione aggiunge una Rappresentazione nella lista di Rappresentazioni.
                @param rappresentazione
            */
            public void AddRappresentazione(Rappresentazione rappresentazione)
            {

                rappresentazioni.Add(rappresentazione);

            }

            /** getPosto restituisce il posto scelto.
                @param fila primo parametro
                @param numero secondo parametro
                @param tipo terzo parametro
                @return posto
            */
            public Posto getPosto(string fila,int numero, string tipo)
            {

                foreach(Posto posto in posti)
                {

                    if (posto.getFila()==fila && posto.getNumero()==numero && posto.getTipo()==tipo)
                    {

                        return posto;

                    }

                }

                return null;
            }

            /** getNome restituisce il nome del Teatro.
                @return nome
            */
            public string getNome()
            {

                return this.nome;

            }

            /** getInditizzo restituisce l'indirizzo del Teatro.
                @return indirizzo
            */
            public string getIndirizzo()
            {

                return this.indirizzo;

            }

            /** getPosti restituisce i Posti del Teatro.
                @return posti
            */
            public List<Posto> getPosti()
            {

                return this.posti;

            }

            /** getDataRappresentazione restituisce la data della rappresentazione dello Spettacolo dato.
                @param spettacolo
                @return string
            */
            public string getDataRappresentazione(Spettacolo spettacolo)
            {

                foreach(Rappresentazione rappresentazione in rappresentazioni)
                {

                    if(rappresentazione.getSpettacolo() == spettacolo)
                    {
                        string stringa;
                        stringa = " Rappresentazione:" + Convert.ToString(rappresentazione.getGiorno())+ " ORE:" + rappresentazione.getOra();
                        return stringa;

                    }

                }
                return null;

            }

        }


        /** @brief Classe Biglietto.

            
            */
        class Biglietto
        {
            
            Persona cliente; /**< Detailed Cliente che à comprato il Biglietto */
            int nBiglietto = 0; /**< Detailed Numero del Biglietto */
            Posto posto; /**< Detailed Posto rappresentato dal Biglietto */
            Spettacolo spettacolo; /**< Detailed Spettacolo rappresentato dal Biglietto */

            /** Il costruttore. Inizializza gli attributi.
                */
            public Biglietto(Persona cliente, Posto posto,Spettacolo spettacolo)
            {

                this.cliente = cliente;
                nBiglietto++;
                this.posto = posto;
                this.spettacolo = spettacolo;

            }

            /** CalcolaPrezzo fa il calcolo del prezzo del Biglietto.
                @return prezzoF
            */
            public double CalcolaPrezzo()
            {

                double prezzoF;
                prezzoF = posto.GetpPrezzo() + spettacolo.GetsPrezzo();
                return prezzoF;

            }

            /** getString restituisce le informazioni del Biglietto.
                @return stringa
            */
            public string getString()
            {
                string stringa;
                stringa = "Nome: " + cliente.getNome() + " " + cliente.getCognome() + " N:" + nBiglietto + " Posto: " + posto.getFila() + " " + posto.getNumero() + " " + posto.getTipo() +  " Spettacolo: " + spettacolo.getNome();
                return stringa;
            }

            /** getSpettacolo restituisce lo spettacolo rappresentato dal Biglietto.
                @return spettacolo
            */
            public Spettacolo getSpettacolo()
            {

                return spettacolo;

            }

        }


        /** @brief Classe Posto

            
            */
        class Posto
        {

            private string fila; /**< Detailed File in cui è il Posto */
            private int numero; /**< Detailed Numero del Posto */
            private double pPrezzo; /**< Detailed Prezzo del Posto */
            private string tipo; /**< Detailed Tipo di Posto */

            /** Il costruttore. Inizializza gli attributi e scieglie il prezzo dipendendo dal tipo.
                */
            public Posto(string fila, int numero, string tipo)
            {

                this.fila = fila;
                this.numero = numero;
                this.tipo = tipo;

                if (tipo == "Platea")
                {

                    this.pPrezzo = 43.90;

                }
                if (tipo == "Palco")
                {

                    this.pPrezzo = 43.90;

                }
                if(tipo == "Loggione")
                {

                    this.pPrezzo = 9.90;

                }

            }

            /** getPrezzo restituisce il prezzo del Posto.
                @return pPrezzo
            */
            public double GetpPrezzo()
            {

                return this.pPrezzo;

            }

            /** getFila restituisce il prezzo del Posto.
                @return fila
            */
            public string getFila()
            {

                return this.fila;

            }

            /** getNumero restituisce il numero del Posto.
                @return numero
            */
            public int getNumero()
            {

                return this.numero;

            }

            /** getTipo restituisce di che tipo è il Posto.
                @return tipo
            */
            public string getTipo()
            {

                return this.tipo;

            }

        }


    }
}