﻿using System;
using System.Collections.Generic;
using System.Data;
using WebApiDemo.DAL;
using WebApiDemo.Data;

namespace WebApiDemo.BLL
{
    public class TransactionService : ITransactionService
    {
        private ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public List<Transaction> GetTransactions()
        {
            var list = new List<Transaction>();
            var datatable = _transactionRepository.GetTransactions();

            if (null == datatable || datatable.Rows.Count == 0)
                return list;

            foreach (DataRow row in datatable.Rows)
            {
                list.Add(new Transaction {
                    TransactionId = Convert.ToInt32(row["id"]),
                    TransactionAmount = Convert.ToDecimal(row["amount"]),
                    TransactionDate = Convert.ToDateTime(row["date"])
                });
            }

            return list;
        }
    }
}
