using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebCrawler.Models;

namespace WebCrawler
{
    class Program
    {
        static async Task Main(string[] args) 
            //wprowadzone przez async, klasycznie ta metoda wygląda tak: static void Main(string[] args)
        {
            /*
             * PODSTAWY JĘZYKA:

            //iteracja:
            int count = 0;
            for (int i = 0; i < 10; i++)
            {
                count += i;
            }
            Console.WriteLine("Wynik " + count);

            //użycie gettera i settera (klasycznego) z klasy Student
            Student st = new Student();  //po utworzeniu konstruktora tutaj brakuje parametru
            st.SetImie("Tomek");
            Console.WriteLine(st.GetImie());

            //użycie gettera i settera (property) z klasy Student
            //Student st = new Student();
            st.LastNameFull = "Bogacz";
            Console.WriteLine(st.LastNameFull);

            //użycie konstruktora
            Student st2 = new Student("rb@gmail.com");
            st2.FirstName = "Magda"

            */

            string websiteUrl = "https://www.pja.edu.pl/";
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(websiteUrl); //metoda asynchroniczna oczekująca na odpowiedź. Aby zadziałała metoda main musi wyglądać tak: static async Task Main(string[] args)

            string content = await response.Content.ReadAsStringAsync(); //pobieranie zawartości strony
            Console.WriteLine(content);

            //wyszukiwanie adresów email
            MatchCollection email = Regex.Matches(content, "[a-zA-Z]+[@]+[a-zA-Z.]+");
            foreach(var r in email)
            {
                Console.WriteLine(r);
            }

            //wyszukiwanie numerów telefonu
            MatchCollection telnumber = Regex.Matches(content, "[+]+[0-9]+[0-9]+[^a-zA-Z]");
            foreach (var r in telnumber)
            {
                Console.WriteLine(r);
            }
        }
    }
}
