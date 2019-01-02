using ExpectedObjects;
using Newtonsoft.Json;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WebApiDemo.BLL;
using WebApiDemo.DAL;
using WebApiDemo.Data;
using Xunit;

namespace UnitTests
{
    public class TransactionServiceTests
    {
        [Fact]
        public void WhenGetTransactionsRepositoryReturnAFilledDataTable_GetTransactionsServiceReturnsAListOfTransactions()
        {
            // Arrange
            ITransactionRepository transactionRepositoryMock = Substitute.For<ITransactionRepository>();

            //DataTable table = new DataTable("MyTable");
            //DataColumn idColumn = new DataColumn("id", typeof(int));
            //DataColumn amountColumn = new DataColumn("amount", typeof(decimal));
            //DataColumn dateColumn = new DataColumn("date", typeof(DateTime));

            //table.Columns.Add(idColumn);
            //table.Columns.Add(amountColumn);
            //table.Columns.Add(dateColumn);

            //DataRow newRow = table.NewRow();
            //newRow["id"] = 1;
            //newRow["amount"] = 10.3m;
            //newRow["date"] = new DateTime(2018, 10, 20);
            //table.Rows.Add(newRow);

            //newRow = table.NewRow();
            //newRow["id"] = 2;
            //newRow["amount"] = 42.1m;
            //newRow["date"] = new DateTime(2018, 04, 12);
            //table.Rows.Add(newRow);

            //newRow = table.NewRow();
            //newRow["id"] = 2;
            //newRow["amount"] = 5.6;
            //newRow["date"] = new DateTime(2018, 07, 2);
            //table.Rows.Add(newRow);

            var datatable = EmbeddedJsonFileHelper.GetContent<DataTable>(@"Files\datatable.transactions");
            var expectedResult = EmbeddedJsonFileHelper.GetContent<List<Transaction>>(@"Files\list.transactions").ToExpectedObject();

            transactionRepositoryMock.GetTransactions().Returns(x => datatable);

            // Act
            var service = new TransactionService(transactionRepositoryMock);
            var result = service.GetTransactions();

            // Assert
            expectedResult.ShouldEqual(result);
        }
    }
}
