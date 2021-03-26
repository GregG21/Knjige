using System;
using System.IO;
using System.Linq;

namespace seminarskaNaloga
//"Izjavljam, da sem nalogo opravil samostojno in da sem njen avtor. Zavedam se, da v primeru, če izjava prvega stavka ni resnična, kršim disciplinska pravila."
{
    class Books
    {

        string naslov;
        string avtor;
        double povprecnaOcena;
        string jezikKoda;
        int steviloStrani;
        int steviloOcen;
        DateTime datumIzdaje;
        string zaloznik;


        public Books() { }
        public Books(string naslov, string avtor, double povprecnaOcena, string jezikKoda, int steviloStrani, DateTime datumIzdaje, string zaloznik)
        {
            
            this.naslov = naslov;
            this.avtor = avtor;
            this.povprecnaOcena = povprecnaOcena;
            this.jezikKoda = jezikKoda;
            this.steviloStrani = steviloStrani;
            steviloOcen = 1;
            this.datumIzdaje = datumIzdaje;
            this.zaloznik = zaloznik;
        }

        public Books(string naslov, string avtor, double povprecnaOcena, string jezikKoda,int steviloStrani, int steviloOcen, DateTime datumIzdaje, string zaloznik)
        {
            this.naslov = naslov;
            this.avtor = avtor;
            this.povprecnaOcena = povprecnaOcena;
            this.jezikKoda = jezikKoda;
            this.steviloStrani = steviloStrani;
            this.steviloOcen = steviloOcen;
            this.datumIzdaje = datumIzdaje;
            this.zaloznik = zaloznik;
        }

        public override string ToString()
        {
            return $"Naslov knjige: {naslov}\nAvtor Knjige: { avtor}\nOcena Knjige: { povprecnaOcena}";
        }

        public static Books[] ustvariTabelo()
        {
            string pot = Path.Combine(Directory.GetCurrentDirectory(), "books.txt");
            if (!File.Exists(pot))
            {
                string vsebina = "Harry Potter and the Half - Blood Prince(Harry Potter  #6)\tJ.K. Rowling/Mary GrandPrĂ©\t4.57\teng\t652\t2095690\t9/16/2006\tScholastic Inc.\nHarry Potter and the Chamber of Secrets(Harry Potter  #2)\tJ.K. Rowling\t4.42\teng\t352\t6333\t11/1/2003\tScholastic\nHarry Potter and the Prisoner of Azkaban(Harry Potter  #3)\tJ.K. Rowling/Mary GrandPrĂ©\t4.56\teng\t435\t2339585\t5/1/2004\tScholastic Inc.\nHarry Potter Boxed Set  Books 1 - 5(Harry Potter  #1-5)\tJ.K. Rowling/Mary GrandPrĂ©\t4.78\teng\t2690\t41428\t9/13/2004\tScholastic\nHarry Potter Collection(Harry Potter  #1-6)\tJ.K. Rowling\t4.73\teng\t3342\t28242\t9/12/2005\tScholastic\nThe Hitchhiker's Guide to the Galaxy (Hitchhiker's Guide to the Galaxy  #1)\tDouglas Adams/Stephen Fry\t4.22\teng\t6\t1266\t3/23/2005\tRandom House Audio\nThe Ultimate Hitchhiker's Guide (Hitchhiker's Guide to the Galaxy  #1-5)\tDouglas Adams\t4.38\teng\t815\t2877\t1/17/1996\tWings Books\nA Short History of Nearly Everything\tBill Bryson\t4.21\teng\t544\t248558\t9 / 14 / 2004\tBroadway Books\n";
                File.WriteAllText("books.txt", vsebina);
            }
            string[] readText = File.ReadAllLines(pot);
            int steviloVrstic = readText.Length;
            Books[] tabKnjig = new Books[steviloVrstic];
            int i = 0;
            foreach (var line in readText)
           {
                try
                {
                    var splitLine = line.Split("\t");
                        tabKnjig[i] = new Books(
                        naslov: splitLine[0],
                        avtor: splitLine[1],
                        povprecnaOcena: Convert.ToDouble(splitLine[2]),
                        jezikKoda: splitLine[3],
                        steviloStrani: Convert.ToInt32(splitLine[4]),
                        steviloOcen: Convert.ToInt32(splitLine[5]),
                        datumIzdaje: Convert.ToDateTime(splitLine[6]),
                        zaloznik: splitLine[7]);
                    i++;
                }
                catch(Exception) {
                    Console.WriteLine(line);
                }
            }
            return tabKnjig;
        }

        public static Books[] tabKnjig = ustvariTabelo();

        public static void AddBookToArray(Books book)
        {
            Array.Resize(ref tabKnjig, tabKnjig.Length + 1);
            tabKnjig[tabKnjig.Length - 1] = book;
        }
        //public static void RemoveBookFromArray(Books book)
        //{
        //    // Odsranimo knjigo iz seznama
        //   tabKnjig = Array.FindAll(tabKnjig, index => index != book).ToArray();
        //   Array.Resize(ref tabKnjig, tabKnjig.Length - 1);

        //}
        public static void RemoveBookFromArray()
        {
            izpis();
            Console.WriteLine("Izberite indeks knjige, ki jo zelite izbrisati");

            int index = Convert.ToInt32(Console.ReadLine());
            if(tabKnjig[index] != null)
            {
                tabKnjig[index] = null;
                //preiscemo tabelo in najdemo knjige, ki nimajo vrednost nul(vse razen te, ki smo jo odsranili)
                //in jih ponovno dodamo v tabelo, posledicno zbrisemo iz tabele knjigo,ki je dobila vrednost null
                tabKnjig = Array.FindAll(tabKnjig, index => index != null).ToArray();
                
                moznosti();
            } else
            {
                Console.WriteLine("Knjiga, ki ste jo zeleli izbrisati NE obstaja");
            }
            
        }

        static void title()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(@"  _  __      _ _           _           ");
            Console.WriteLine(@" | |/ /     (_|_)         (_)          ");
            Console.WriteLine(@" | ' / _ __  _ _ _____ __  _  ___ __ _ ");
            Console.WriteLine(@" |  < | '_ \| | |_  / '_ \| |/ __/ _` |");
            Console.WriteLine(@" | . \| | | | | |/ /| | | | | (_| (_| |");
            Console.WriteLine(@" |_|\_\_| |_| |_/___|_| |_|_|\___\__,_|");
            Console.WriteLine(@"           _/ |                        ");
            Console.WriteLine(@"          |__/                         ");
            Console.ForegroundColor = ConsoleColor.White;

        }
        static void vnos()
        {
            Console.WriteLine();
            Console.Write("Vnesite naslov knjige:\n");
            string naslov = Console.ReadLine();

            
            Console.Write("Vnesite avtorja knjige:\n");
            string avtor = Console.ReadLine();
  


            string povprecnaOcena_string;
            double povprecnaOcena_double;
            // preverimo ce je vnos pravilen, ce ni, ponovimo
            do
            {
                Console.Write("Vnesite oceno knjige:\n");
                povprecnaOcena_string = Console.ReadLine();
            } while (!double.TryParse(povprecnaOcena_string, out povprecnaOcena_double));
            


            Console.Write("Vnesite jezikovno kodo knjige:\n");
            string jezikKoda = Console.ReadLine();
            int steviloStrani_int;
            string steviloStrani_string;
            // preverimo ce je vnos pravilen, ce ni, ponovimo
            do
            {
                Console.Write("Vnesite stevilo strani knjige:\n");
                steviloStrani_string = Console.ReadLine();
            } while (!int.TryParse(steviloStrani_string, out steviloStrani_int));

            DateTime datum_Izdaje_value;
            string datum_Izdaje;
            do
            {
                Console.Write("Vnesite datum izdaje knjige:");
                Console.WriteLine("Primer: 01/01/2021");
                datum_Izdaje = Console.ReadLine();
            } while (!DateTime.TryParseExact(datum_Izdaje, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.None, out datum_Izdaje_value));
            
            Console.WriteLine();

            Console.Write("Vnesite zaloznika knjige: ");
            string zaloznik = Console.ReadLine();
            Console.WriteLine();
            
                Books novaKnjiga = new Books(naslov, avtor, povprecnaOcena_double, jezikKoda, steviloStrani_int, datum_Izdaje_value, zaloznik);
                
                if (novaKnjiga != null)
                {
                    AddBookToArray(novaKnjiga);
                    Console.WriteLine($"Dodali ste knjigo:\n {novaKnjiga}\n");
                    Console.WriteLine("Uspesno ste vnesli novo knjigo\n");
                
                }
                else
                {
                    Console.WriteLine("Knjige ni bilo mozno dodati\n");
                    Console.WriteLine("Zelite poskusiti ponovno");
                    Console.WriteLine("y) Ce zelite ponovno poskusiti dodati knjigo");
                    Console.WriteLine("n) Ce NE zelite ponovno poskusiti dodati knjigo");
                    switch (Console.ReadLine())
                    {
                        case "y":
                            vnos();
                            break;
                        case "n":
                            break;
                        default:
                            Console.WriteLine("Izberite pravilno komando");
                            break;
                    }
                }
                moznosti();
            
        }
        
        static void ureditev()
        {
            izpis();
            Console.WriteLine("S stevilko izberite knjigo\n");
            Console.Write("Stevilka Knjige: ");
            int index = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Urediti zelite naslednjo knjigo\n");
            
            Console.WriteLine(tabKnjig[index].ToString()+ "\n");
            Console.WriteLine("y) Ce je knjiga pravilna");
            Console.WriteLine("n) Ce knjiga NI pravilna\n");
            var editingBook = tabKnjig[index];
            switch (Console.ReadLine())
            {
                case "y":
                    uredi();
                    break;
                case "n":
                    moznosti();
                    break;
                default:
                    Console.WriteLine("Vnesite pravilni ukaz");
                    break;
            }
            void uredi()
            {
                Console.WriteLine("Izberite kaj zelite urediti\n");
                Console.WriteLine("a) Ce zelite urediti AVTORJA knjige");
                Console.WriteLine("k) Ce zelite urediti JEZIKOVNO KODO knjige");
                Console.WriteLine("s) Ce zelite urediti STEVILO STRANI knjige");
                Console.WriteLine("d) Ce zelite urediti DATUM IZDAJE knjige");
                Console.WriteLine("z) Ce zelite urediti ZALOZNIKA knjige");
                switch (Console.ReadLine())
                {
                    case "a":
                        Console.WriteLine("Vpisite AVTORJA knjige");
                        var avtor = Console.ReadLine();
                        editingBook.avtor = avtor;
                        break;
                    case "k":
                        Console.WriteLine("Vpisite JEZIKOVNO KODO knjige");
                        var koda = Console.ReadLine();
                        editingBook.jezikKoda = koda;
                        break;
                    case "s":
                        Console.WriteLine("Vpisite STEVILO STRANI knjige");
                        var new_stevilo_strani = Console.ReadLine();
                        editingBook.steviloStrani = Convert.ToInt32(new_stevilo_strani);
                        break;
                    case "d":
                        Console.WriteLine("Vpisite DATUM IZDAJE knjige");
                        var datum = Console.ReadLine();
                        editingBook.datumIzdaje = Convert.ToDateTime(datum);
                        break;
                    case "z":
                        Console.WriteLine("Vpisite ZALOZNIKA knjige");
                        var zaloznik = Console.ReadLine();
                        editingBook.zaloznik = zaloznik;
                        break;
                }
                Console.WriteLine("Novo urejena knjiga\n");
                Console.WriteLine(tabKnjig[index].ToString() + "\n");

            }
        }
        static void moznosti()
        {
                     
            Console.WriteLine();
            Console.WriteLine("1) Za izpis vseh knjig");
            Console.WriteLine("2) Za vnos knjige");
            Console.WriteLine("3) Za iskanje knjige");
            Console.WriteLine("4) Za ureditev knjige");
            Console.WriteLine("5) Za odstranitev knjige");
            Console.WriteLine("s) Shranite svoje delo");
            Console.WriteLine("q) Za izhod iz programa");

        }
        static void izpis()
        {
            
                foreach(var book in tabKnjig){
                Console.WriteLine($"{Array.IndexOf(tabKnjig, book)} - {book}");
                Console.WriteLine();
              
            }
            moznosti();
        }
        static void iskanjeKnjige()
        {
            Console.WriteLine();
            Console.WriteLine("Vpisite niz, ki ga knjiga vsebuje\n");
            string iskalniNiz = Console.ReadLine().Trim().ToLower();
            Console.WriteLine(iskalniNiz);
            foreach (var book in tabKnjig)
            {
                if(book.naslov.ToLower().Contains(iskalniNiz))
                {
                    Console.WriteLine($"{Array.IndexOf(tabKnjig, book)} - {book}");
                    Console.WriteLine();
                }
              
            }
            Console.WriteLine();
            moznosti();

        }

        public static void shrani() {
            using (StreamWriter sw = new StreamWriter("books.txt"))
            {
                foreach(var book in tabKnjig)
                {
                    if(book != null)
                    {
                        sw.WriteLine($"{book.naslov}\t{book.avtor}\t{book.povprecnaOcena}\t{book.jezikKoda}\t{book.steviloStrani}\t{book.steviloOcen}\t{book.datumIzdaje}\t{book.zaloznik}");

                    }
                    }
            }

        }





        static void Main(string[] args)
        {

            Books peterPan = new Books("Peter Pan", "James Matthew Barrie", 5, "SLO", 208, 50, new DateTime(10 / 05 / 2005), "Barnes & Noble");
            ////RemoveBookFromArray(0);
            ////RemoveBookFromArray(1);
            
            title();
            moznosti();
           
            //AddBookToArray(peterPan);
            //Console.WriteLine("[{0}]", string.Join(", ", tabKnjig[tabKnjig.Length - 1]));
            ////RemoveBookFromArray(peterPan);
            //Console.WriteLine("[{0}]", string.Join(", ", tabKnjig[tabKnjig.Length - 1]));
            
            //Console.WriteLine("HELLO");
            while(true)
            {
                switch (Console.ReadLine().Trim())
                {
                    // izpis knjig
                    case "1":
                        izpis();
                        break;
                    // vnos knjig
                    case "2":
                        vnos();
                        break;
                    case "3":
                        iskanjeKnjige();
                        break;
                    case "4":
                        ureditev();
                        break;
                    case "5":
                        RemoveBookFromArray();
                        break;
                    case "s":
                        shrani();
                        break;
                    case "q":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Vnesli ste napacno komadno, poskusite ponovno");
                        break;

                }
            }
            


        }
    } 
}
