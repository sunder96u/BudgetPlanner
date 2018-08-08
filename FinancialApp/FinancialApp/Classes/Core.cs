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
            string queryString = string.Format("http://sunderwoodbudgetplannerapi.azurewebsites.net:80/API/Household?householdId={0}", HouseholdId);

            string json = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            if (json != null)
            {
                return JsonConvert.DeserializeObject<HouseHold>(json);
            }
            else
            {
                return null;
            }

        }

        public static async Task<AccountDetails> GetAccountDetails(string AccountId)
        {
            string queryString = string.Format("http://sunderwoodbudgetplannerapi.azurewebsites.net:80/API/Account?accountId={0}", AccountId);

            dynamic json = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            if (json != null)
            {
                return JsonConvert.DeserializeObject<AccountDetails>(json);
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
            string queryString = string.Format("http://sunderwoodbudgetplannerapi.azurewebsites.net:80/API/Budget?householdId={0}", HouseholdId);

            dynamic json = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            if (json != null)
            {
                return JsonConvert.DeserializeObject<Budget>(json);
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

            dynamic json = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            if (json != null)
            {
                return JsonConvert.DeserializeObject<TransactionDetails>(json);
            }
            else
            {
                return null;
            }

        }

    }
}
