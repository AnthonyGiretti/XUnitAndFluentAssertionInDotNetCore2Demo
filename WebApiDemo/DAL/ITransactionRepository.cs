using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.DAL
{
    public interface ITransactionRepository
    {
        DataTable GetTransactions();
    }
}
