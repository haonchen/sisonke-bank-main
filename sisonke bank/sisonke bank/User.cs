using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Sisonke_Banking_App
{
    public class Registration
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        [MaxLength(10)]
        public string EmailAddress { get; set; }
        public string Password { get; set; }

    }

    public class Account
    {
        [PrimaryKey, AutoIncrement]
        public int AccountNumber { get; set; }
        public string HolderName { get; set; }
        public string Surname { get; set; }
        public double Balance { get; set; }
        public double SavingsAccountBalance { get; set; }


    }

    

}
