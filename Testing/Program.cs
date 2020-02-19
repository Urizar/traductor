using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing;
namespace Testing
{
    class Program
    {
        public static class sessionStorage { 
            public static string userName = null; // can change because not const
            public static string theDate = DateTime.Now.ToString("yyyy-MM-dd");
        }
        static void Main(string[] args)
        {
            start();

        }

        public static void start(){
            try
            {
                Console.Clear();
                var mng = new UserManagement();
                var user = new User();
                //Delete the logged user
                sessionStorage.userName = null;


                Console.WriteLine("BIENVENIDO");
                Console.WriteLine("Escriba el numero correspondiente para:");
                Console.WriteLine("1) Iniciar Sesion");
                Console.WriteLine("2) Registrarse");
                var option = Console.ReadLine();

                switch (option)
                {

                    default:
                        Console.WriteLine("Ingrese un numero correcto '1' o '2'");
                        //start();
                        break;
                    case "1":
                        login();
                        break;
                    case "2":
                        Console.WriteLine("Escriba su nombre");
                        var info = Console.ReadLine();
                        var infoArray = info.Split(',');
                        user = new User(infoArray);
                        var alreadyRegistered = mng.RetrieveById(user);
                        if (alreadyRegistered == null)
                        {
                            mng.Create(user);
                            Console.WriteLine("El usuario "+user.Name+" ha sido registado exitosamente");
                        }
                        else
                        {
                            Console.Clear();
                            Console.Beep();
                            Console.WriteLine("ERROR:");
                            Console.WriteLine("El usuario '" + user.Name+"' ya esta registrado");
                            Console.WriteLine("Presionee cualquier tecla para continuar");
                            Console.ReadKey();
                        }
                        Console.Write("Presione cualquier tecla para continuar:");
                        Console.ReadKey();
                        start();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.Beep();
                Console.WriteLine("Lamentablemente se ha producido un error");
                Console.WriteLine("***************************");
                Console.WriteLine("ERROR: " + ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("***************************");
                Console.WriteLine("Presionee cualquier tecla para continuar");
                Console.ReadKey();
                start();
            }


}

        public static void login(){
            Console.Clear();
            var mng = new UserManagement();
            var user = new User();
            Console.Write("Digite su nombre de usuario: ");
            user.Name = Console.ReadLine();
            user = mng.RetrieveById(user);
            if (user != null)
            {
                //Set the logged user name
                sessionStorage.userName = user.Name;
                home();
            } else {
            Console.WriteLine("Error no se encontro el usuario");
            Console.WriteLine("Presione los numeros:");
                Console.WriteLine("1) Para intentarlo nuevamente");
                Console.WriteLine("2) Para salir al menu principal");
                var option = Console.ReadLine();
            switch (option)
            {
                default:
            Console.WriteLine("Ingrese un numero correcto '1' o '2'");
                break;
                case "1":

                login();
                break;
                case "2":
                start();
                        break;

            }
        }
}

        public static void home(){
            Console.Clear();
            //Manager y objeto de lenguage
            var mng = new LanguageManagement();
            var language = new Language();

            string name = sessionStorage.userName;
            Console.WriteLine("Bienvenido " + name);
            bool exists = true;
            var idioma = "";
            var ask = "";
            var lstLanguages = mng.RetrieveAll();
            var count = 0;
            Console.WriteLine("Ingrese el numero correspondiente a la opcion que desee:");
            Console.WriteLine("1)Menu de traducciones");
            Console.WriteLine("2)Menu de consultas");
            Console.WriteLine("3)Cerrar Sesion");
            Console.Write("Opcion:");
            var option = Console.ReadLine();

            switch (option)
            {
                default:
                    home();
                    break;
                case "1":
                    Console.Clear();
                    if (lstLanguages != null)
                    {
                        Console.WriteLine("IDIOMAS REGISTRADOS DE ESPAÑOL A:");;
                        foreach (var c in lstLanguages)
                        {
                            count++;
                            if (c.Name != "espanol")
                            {
                                Console.WriteLine("-" + c.Name.ToLower());
                            }

                        }
                        Console.WriteLine("Escriba el idioma en el cual desee traducir");
                        var text = Console.ReadLine();
                        language.Name = text;
                        language = mng.RetrieveById(language);

                        if(text == "espanol"||text == "español") {
                            Console.WriteLine("El idioma del traductor es en español, ingrese un idioma diferente");
                            Console.Write("Presione cualquier tecla para continuar:");
                            Console.ReadKey();
                            home();
                        }
                        if (language != null)//Exists
                        {
                            register(text);
                        }
                        else
                        {

                            Console.WriteLine("El idioma '" + text + "' no concuerda con ninguno que este registrado en la base de datos");
                            Console.WriteLine("Desea agregar el idioma ingresado a la lista de idiomas?");
                            Console.WriteLine("1)SI");
                            Console.WriteLine("2)NO");
                            ask = Console.ReadLine();
                            switch (ask)
                            {
                                default:
                                    Console.WriteLine("Ingrese un numero correcto '1' o '2'");
                                    break;
                                case "1":

                                    var info = text + "," + 0;
                                    var infoArray = info.Split(',');

                                    language = new Language(infoArray);
                                    mng.Create(language);
                                    Console.WriteLine("El idioma " + text + " ha sido exitosamente registrado");
                                    home();
                                    break;
                                case "2":
                                    home();
                                    break;

                            }
                        }

                    }
                    break;
                case "2":
                    getInfo();
                    break;
                case "3":
                    Console.Clear();
                    sessionStorage.userName = null;
                    start();
                    break;
            }



        }

        public static void register(string PLanguage){
            Console.Clear();
            var wordmng = new WordManagement();
            var localWord = new Word();
            var mng = new TranslatedWordManagement();
            var translatedWord = new TranslatedWord();
            var languagemng = new LanguageManagement();
            var lang = new Language();
            string user = sessionStorage.userName;
            string language = PLanguage;
            string date = sessionStorage.theDate;
            string tword;
            string translate = "";
            string popularity = "0";
            string usingApp = "1";
            do
            {
                Console.Clear();
                Console.WriteLine("Indique las palabras que desea traducir en el idioma " + language);
                string palabras = Console.ReadLine();
                string[] words = palabras.Split(' ');
                //Ciclo que por cada palabra que detecto, checkea si esta registrada o no
                foreach (var word in words)
                {
                    tword = $"{word}";
                    localWord.Name = tword;
                    localWord = wordmng.RetrieveById(localWord);

                    //Si no esta registrada
                    if (localWord == null)
                    {
                        Console.WriteLine("La palabra '" + tword + "' no esta registrada, porfavor ingrese su traduccion en el idioma " + language);
                        Console.Write(tword + " : ");
                        translate = Console.ReadLine();
                        while (translate == "")
                        {
                            Console.Write("Ingrese la traducion : ");
                            translate = Console.ReadLine();
                        }
                        string[] info = new string[2];
                        info[0] = tword;
                        info[1] = popularity;
                        localWord = new Word(info);
                        wordmng.Create(localWord);
                        string[] translated = new string[6];
                        translated[0] = user;
                        translated[1] = language;
                        translated[2] = tword;
                        translated[3] = date;
                        translated[4] = translate;
                        translated[5] = popularity;
                        translatedWord = new TranslatedWord(translated);
                        mng.Create(translatedWord);
                        Console.WriteLine("Ha sido registrado exitosamente");
                    }
                }
                //Ciclo que imprime cuando todas las palabras han sido registradas
                Console.Clear();
                Console.WriteLine("TRADUCCION");
                Console.WriteLine("Espanol: " + palabras);
                Console.WriteLine("-----------------");
                Console.Write(language + ": ");
                foreach (var word in words)
                {
                    tword = $"{word}";
                    localWord.Name = tword;
                    localWord = wordmng.RetrieveById(localWord);

                    //Actualiza la palabra y le suma +1 de popularidad cada vez que se consulta
                    translatedWord.Word = tword;
                    translatedWord = mng.RetrieveById(translatedWord);
                    Console.Write(translatedWord.Translate + " ");

                    translatedWord.Popularity = translatedWord.Popularity + 1;
                    mng.Update(translatedWord);
                }


                Console.WriteLine("");
                Console.WriteLine("-----------------");
                Console.WriteLine("Desea traducir mas frases?");
                Console.WriteLine("1)Si");
                Console.WriteLine("2)No");
                usingApp = Console.ReadLine();

            } while (usingApp == "1");
            home();
        }

        public static void getInfo()
        {
            var languagemng = new LanguageManagement();
            var language = new Language();
            var mng = new TranslatedWordManagement();
            var translatedWord = new TranslatedWord();
            Console.Clear();

            Console.WriteLine("Menu de consultas del traductor");
            Console.WriteLine("Ingrese el numero correspondiente a la opcion que desee:");
            Console.WriteLine("1)Registro de todas las traducciones que se han realizado");
            Console.WriteLine("2)Idiomas disponibles");
            Console.WriteLine("3)Diccionario completo de palabras segun el idioma");
            Console.WriteLine("4)MENU PRINCIPAL");
            var option = Console.ReadLine();
            switch (option)
            {
                default:
                    Console.WriteLine("Ingrese un numero valido entre 1 - 11");
                    getInfo();
                    break;
                case "1":
                    var lstTranslatedWords = mng.RetrieveAll();
                    var count = 0;
                    Console.WriteLine("REGISTRO DE TRADUCCIONES");
                    foreach (var c in lstTranslatedWords)
                    {
                        count++;
                        Console.WriteLine(count +"-"+c.User.ToUpper()+" registro en el idioma " + c.Language.ToUpper() + " la palabra(" + c.Word.ToUpper() + ") significa (" + c.Translate.ToUpper() + ") Su popularidad: " + c.Popularity);
                    }

                    Console.Write("Presione cualquier tecla para continuar:");
                    Console.ReadKey();
                    break;
                case "2":
                    var lstlanguages = languagemng.RetrieveAll();
                    var languagecount = 0;
                    Console.WriteLine("IDIOMAS DISPONIBLES");
                    Console.WriteLine("El idioma de referencia es el español");
                    foreach (var c in lstlanguages)
                    {
                       languagecount++;
                        Console.WriteLine(languagecount+"-"+c.Name);    
                    }

                    Console.Write("Presione cualquier tecla para continuar:");
                    Console.ReadKey();
                    break;
                case "3":
                    lstTranslatedWords = mng.RetrieveAll();
                    count = 0;
                    Console.WriteLine("Ingrese un idioma el cual desee consultar");
                    var choosenLanguage = Console.ReadLine();
                    Console.Clear();

                    language.Name = choosenLanguage;
                    language = languagemng.RetrieveById(language);
                    if (language !=null)
                    {
                        Console.WriteLine("Palabras en el idioma " + choosenLanguage);

                        foreach (var c in lstTranslatedWords)
                        {
                            count++;
                            if (c.Language == choosenLanguage)
                            {
                                Console.WriteLine("-(" + c.Translate.ToUpper() + ") del " + c.Language + " significa (" + c.Word + ")");
                            }

                        }
                    } else
                    {
                        Console.WriteLine("El idioma " + choosenLanguage + " no se encuentra registrado en el sistema");
                    }



                    Console.Write("Presione cualquier tecla para continuar:");
                    Console.ReadKey();
                    break;
                case "4":
                    home();
                    break;
            }
            getInfo();
        }
        public static void DoIt() { 
            try
            {
                var mng = new CustomerManagement();
                var customer = new Customer();

                Console.WriteLine("Customers CRUD options");
                Console.WriteLine("1.CREATE");
                Console.WriteLine("2.RETRIEVE ALL");
                Console.WriteLine("3.RETRIEVE BY ID");
                Console.WriteLine("4.UPDATE");
                Console.WriteLine("5.DELETE");

                Console.WriteLine("Choose an option: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("***************************");
                        Console.WriteLine("*****     CREATE    *******");
                        Console.WriteLine("***************************");
                        Console.WriteLine("Type the id, name, last_name and age separated by comma!!");
                        var info = Console.ReadLine();
                        var infoArray = info.Split(',');

                        customer = new Customer(infoArray);
                        mng.Create(customer);

                        Console.WriteLine("Customer was created");

                        break;
                        
                    case "2":
                        Console.WriteLine("***************************");
                        Console.WriteLine("*****  RETRIEVE ALL   *****");
                        Console.WriteLine("***************************");

                        var lstCustomers = mng.RetrieveAll();
                        var count = 0;

                        foreach (var c in lstCustomers)
                        {
                            count++;
                            Console.WriteLine( count + " ==> " + c.GetEntityInformation());
                        }

                        break;
                    case "3":
                        Console.WriteLine("Type the customer id:");
                        customer.Id = Console.ReadLine();
                        customer = mng.RetrieveById(customer);

                        if (customer != null)
                        {
                            Console.WriteLine(" ==> " + customer.GetEntityInformation());
                        }

                         break;
                    case "4":
                        Console.WriteLine("***************************");
                        Console.WriteLine("******  UPDATE  **    *****");
                        Console.WriteLine("***************************");

                        Console.WriteLine("Type the customer id:");
                        customer.Id= Console.ReadLine();
                        customer = mng.RetrieveById(customer);

                        if (customer != null)
                        {
                            Console.WriteLine(" ==> " + customer.GetEntityInformation());
                            Console.WriteLine("Type a new name, actual value is " + customer.Name);
                            customer.Name = Console.ReadLine();
                            Console.WriteLine("Type a new last name, actual value is " + customer.LastName);
                            customer.LastName = Console.ReadLine();
                            Console.WriteLine("Type a new age, actual value is " + customer.Age);
                            var textAge = Console.ReadLine();
                            customer.Age = Int32.TryParse(textAge, out int age) ? age : customer.Age;

                            mng.Update(customer);
                            Console.WriteLine("Customer was updated");
                        }
                        else
                        {
                            throw new Exception("Customer not registered");
                        }

                        break;

                    case "5":
                        Console.WriteLine("Type the customer id:");
                        customer.Id = Console.ReadLine();
                        customer = mng.RetrieveById(customer);

                        if (customer != null)
                        {
                            Console.WriteLine(" ==> " + customer.GetEntityInformation());

                            Console.WriteLine("Delete? Y/N");
                            var delete = Console.ReadLine();

                            if (delete.Equals("Y", StringComparison.CurrentCultureIgnoreCase))
                            {
                                mng.Delete(customer);
                                Console.WriteLine("Customer was deleted");
                            }
                        }
                        else
                        {
                            throw new Exception("Customer not registered");
                        }

                        break;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("***************************");
                Console.WriteLine("ERROR: " + ex.Message );
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("***************************");
            }
            finally
            {
                sessionStorage.userName = null;
                Console.WriteLine("Continue? Y/N");
                var moreActions = Console.ReadLine();

                if (moreActions.Equals("Y", StringComparison.CurrentCultureIgnoreCase))
                    DoIt();
            }

           
        }
    }

}
