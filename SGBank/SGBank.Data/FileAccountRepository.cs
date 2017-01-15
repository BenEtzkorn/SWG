using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Responses;
using System.IO;
using System.Runtime;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    { 

        private Account _account;
        private string _AccountNumber;
        private decimal _balance;
        

        //create and populate column names if file does not yet exist
        
        public Account LoadAccount(string AN)
        { 
           
            _AccountNumber = AN;
                                                      
            using (StreamReader sr = new StreamReader(Settings.FilePath))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {

                    _account = new Account();

                    string[] columns = line.Split(',');

                    _account.AccountNumber = columns[0];
                    _account.Name = columns[1];
                    _account.Balance = decimal.Parse(columns[2]);
                    string temp = columns[3];

                    if (temp == "F")
                    {
                        _account.Type = AccountType.Free;
                    }

                    else if (temp == "B")
                    {
                        _account.Type = AccountType.Basic;
                    }

                    else
                    {
                        _account.Type = AccountType.Premium;
                    }

                    if (_account.AccountNumber == _AccountNumber)
                    {
                        return _account;
                    }

                }

            }

                return null;
        }  
           
        public void SaveAccount(Account account)
        {

            _balance = account.Balance;

            _AccountNumber = account.AccountNumber;

            List<string> _row = new List<string>();

            _row.Add("AccountNumber,Name,Balance,Type");

            using (StreamReader sr = new StreamReader(Settings.FilePath))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {

                    _account = new Account();

                    string[] columns = line.Split(',');

                    _account.AccountNumber = columns[0];
                    _account.Name = columns[1];
                    _account.Balance = decimal.Parse(columns[2]);
                    string temp = columns[3];

                    if (_account.AccountNumber == _AccountNumber)
                    {
                        _account.Balance = _balance;
                    }

                    _row.Add($"{_account.AccountNumber},{_account.Name},{_account.Balance},{temp}");

                }


            }

            File.Delete(Settings.FilePath);

            using (StreamWriter sw = new StreamWriter(Settings.FilePath))
            {

                foreach (string row in _row)
                {
                    sw.WriteLine(row);
                }

            }
        }
    
    }
}
