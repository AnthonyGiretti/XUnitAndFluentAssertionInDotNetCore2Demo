using System;
using System.Collections.Generic;
using WebApiDemo.Data;

namespace WebApiDemo.BLL
{
    public interface ITransactionService
    {
        List<Transaction> GetTransactions();
    }
}
