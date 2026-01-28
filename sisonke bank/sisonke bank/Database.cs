using System.Threading.Tasks;
using System.Collections.Generic;
using SQLite;
using System;
using System.Linq;
using sisonke_bank;

namespace Sisonke_Banking_App
{
    public class Database
    {
        private readonly SQLiteAsyncConnection conn;


        public Database(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            //in that database create a table based on the class Registration
            conn.CreateTableAsync<Registration>().Wait();
            //in that database create a table based on the class Account
            conn.CreateTableAsync<Account>().Wait();
           
        }

        public async Task<int> CreatePersonAsync(Registration Registration)
        {
            return await conn.InsertAsync(Registration);
        }

        public async Task<List<Registration>> GetAllPeopleAsync()

        {
            return await conn.Table<Registration>().ToListAsync();
        }

        public async Task<int> CreateAccount(Account Account)
        {
            return await conn.InsertAsync(Account);
        }

        public async Task<List<Account>> getAccount()

        {
            //get Accounts already in the database
            var existing_Accounts = await conn.Table<Account>().ToListAsync();
            //there is no current existing Account lets add our own sample  10 Accounts
            if (!existing_Accounts.Any())
            {
                Account[] accounts = new Account[10];

                accounts[0] = new Account();
                accounts[0].AccountNumber = 1;//first Account
                accounts[0].HolderName = "Trading Account";
                accounts[0].Surname = "Chen";
                accounts[0].Balance = 100000.00;
                accounts[0].SavingsAccountBalance = 0.00;



                //second account
                accounts[1] = new Account { AccountNumber = 2, HolderName = "Savings Account", Surname = "Maseku", Balance = 0.00, SavingsAccountBalance = 15000.00 };


                //we insert all these account into a database
                await conn.UpdateAsync(accounts);
            }
            //again we can gets the account 
            //knowing there is atleat many accounts
            existing_Accounts = await conn.Table<Account>().ToListAsync();
            return existing_Accounts;
        }

        public async Task<int> setAccount(Account Account)
        {
            //
            return await conn.InsertAsync(Account);
        }
        public async Task<Account> SelectAccount(int selectedAccountNum)
        {
            //get accoounts already in the database
            var listAllAccounts = await conn.Table<Account>().ToListAsync();
            {
                //if (!listAllAccounts.Any())
                //    DefaultAccount();
            }
            foreach (var accountFound in listAllAccounts)
            {
                if (accountFound.AccountNumber == selectedAccountNum)
                {
                    return accountFound;
                }
            }
            Account noAccFound = new Account() { AccountNumber = 0, HolderName = "Not Found", Balance = 0.00 };
            return noAccFound;
        }

        public async Task<Registration> RegistrationLogIn(string Email, string Password)
        {
            //get accoounts already in the database
            var listAllPeople = await conn.Table<Registration>().ToListAsync();
            // {
            //if (!listAllAccounts.Any())
            //    DefaultAccount();
            // }
            foreach (var personFound in listAllPeople)
            {
                if (personFound.EmailAddress.Equals(Email) && personFound.Password.Equals(Password))
                {
                    return personFound;
                }
            }
            Registration noPersonFound = new Registration() { FirstName = "Not Found", LastName = "Not Found", EmailAddress = "Not Found", Password = "Not Found" };
            return noPersonFound;
        }

        public async Task<bool> Deposit(int AccountNumber, double DepositAmount)
        {
            Account depAccount = await App.Database.SelectAccount(AccountNumber);
            double closingBal = depAccount.Balance + DepositAmount; depAccount.AccountNumber = AccountNumber;
            depAccount.Balance = closingBal; int rowAffecred = await conn.UpdateAsync(depAccount); if (rowAffecred > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Withdraw(int AccountNumber, double DepositAmount)
        {

            Account depAccount = await App.Database.SelectAccount(AccountNumber);
            if (depAccount.Balance < DepositAmount)
            {
                return false;
            }
            double closingBal = depAccount.Balance - DepositAmount; depAccount.AccountNumber = AccountNumber;
            depAccount.Balance = closingBal; int rowAffecred = await conn.UpdateAsync(depAccount);

            if (rowAffecred > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Transfer(int FromAccount, int ToAccount, double TransferAmount)
        {
            bool isWithdrawPass = await App.Database.Withdraw(FromAccount, TransferAmount);
            if (isWithdrawPass)
            {
                return await App.Database.Deposit(ToAccount, TransferAmount);
            }
            return false;
        }

        public async Task<int> TransferMoney(Transfer Transfer)
        {
            return await conn.InsertAsync(Transfer);
        }


    }
}
