using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler.Models
{
    public class Student
    {
        private string imie;
        private string nazwisko;

        //tworzenie gettera i settera klasycznie:
        public string GetImie()
        {
            return imie;
        }

        public void SetImie(string imie)
        {
            if(imie == null)
            {
                throw new System.Exception("Imie nie moze byc nullem");
            };
            this.imie = imie;
        }

        //tworzenie gettera i settera poprzez Auto-Property prop:
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //tworzenie gettera i settera poprzez Full-Property propfull:
        private string _lastName;

        public string LastNameFull
        {
            get { return _lastName; }
            set { 
                if(value == null)
                {
                    throw new ArgumentException("Lastname cannot be null");
                }
                   _lastName = value;
            }
        }

        public string Address { get; set; }
        public string Email { get; set; }

        //konstruktor
        public Student (string email)
        {
            this.Email = email;
        }



    }
}
