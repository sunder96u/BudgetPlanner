using FinancialApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace FinancialApp.Classes
{
    class Core
    {
        public static async Task<HouseHold> GetLandingPage(string HouseholdId)
        {
            string queryString = string.Format("http://sunderwoodbudgetplannerapi.azurewebsites.net:80/API/Household/Json?householdId={0}", HouseholdId);

            string json = await DataService.getDataFromService(queryString).ConfigureAwait(false);
            if (json != null)
            {
                return JsonConvert.DeserializeObject<HouseHold>(json);
            }
            else
            {
                return null;
            }


          
            //dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);
            //if (results["household"] != null)
            //{
            //    Debug.WriteLine("Yay there is a results[Household...]");

            //    var household = new HouseHold();
            //    household.Name = (string)results["Name"];
            //    household.Description = (string)results["Description"];
            //    return household;
            //}
            //else
            //{
            //    return null;
            //}
        }

        public static async Task<AccountDetails> GetAccountDetails(string AccountId)
        {
            string queryString = string.Format("http://sunderwoodbudgetplannerapi.azurewebsites.net:80/API/Account/Json?accountId={0}", AccountId);

            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            if (results["accountDetails"] != null)
            {
                var accountDetails = new AccountDetails();
                accountDetails.Name = (string)results["Name"];
                accountDetails.Description = (string)results["Description"];
                accountDetails.Created = (string)results["Created"];
                accountDetails.CurrentBalance = "$" + (string)results["CurrentBalance"];
                accountDetails.AccountTypeId = (string)results["AccountTypeId"];
                accountDetails.AccountNumber = (string)results["AccountNumber"];
                accountDetails.RoutingNumber = (string)results["RoutingNumber"];
                return accountDetails;
            }
            else
            {
                return null;
            }
        }

        public static async Task<List<Accounts>> GetAccounts (string BankId)
        {
            string queryString = string.Format("http://sunderwoodbudgetplannerapi.azurewebsites.net:80/API/AllAccounts?bankId={0}", BankId);

            string results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            if (results != null)
            {
                return JsonConvert.DeserializeObject<List<Accounts>>(results);
            }
            else
            {
                return null;
            }
        }

        public static async Task<List<Banks>> GetBanks (string HouseholdId)
        {
            string queryString = string.Format("http://sunderwoodbudgetplannerapi.azurewebsites.net:80/API/AllBanks?householdId={0}", HouseholdId);

            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            if (results != null)
            {
                return JsonConvert.DeserializeObject<List<Banks>>(results);
            }
            else
            {
                return null;
            }
        }

        public static async Task<Budget> GetBudget (string HouseholdId)
        {
            string queryString = string.Format("http://sunderwoodbudgetplannerapi.azurewebsites.net:80/API/Budget/Json?householdId={0}", HouseholdId);

            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            if (results["budget"] != null)
            {
                var budget = new Budget();
                budget.Name = (string)results["Name"];
                budget.Description = (string)results["Description"];
                budget.SpendingTarget = "$" + (string)results["SpendingTarget"];
                budget.CurrentBalance = "$" + (string)results["CurrentBalance"];
                return budget;
            }
            else
            {
                return null;
            }
        }

        public static async Task<List<Transactions>> GetTransactions (string AccountId)
        {
            string queryString = string.Format("http://sunderwoodbudgetplannerapi.azurewebsites.net:80/API/AllTransactions?accountId={0}", AccountId);

            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            if (results != null)
            {
                return JsonConvert.DeserializeObject<List<Transactions>>(results);
            }
            else
            {
                return null;
            }
        }

        public static async Task<TransactionDetails> GetTransactionsDetails (string TransactionId)
        {
            string queryString = string.Format("http://sunderwoodbudgetplannerapi.azurewebsites.net:80/API/Transaction/Json?transactionId={0}", TransactionId);

            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            if (results["transactionDetails"] != null)
            {
                var transactionDetails = new TransactionDetails();
                transactionDetails.Amount = "$" + (string)results["Amount"];
                transactionDetails.Type = (string)results["Type"];
                transactionDetails.Memo = (string)results["Memo"];
                transactionDetails.Created = (string)results["Created"];
                return transactionDetails;
            }
            else
            {
                return null;
            }
        }

    }
}
