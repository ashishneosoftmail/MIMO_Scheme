using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OldMutual.Scheme.Repositories;
using OldMutual.Scheme.Scheme;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace OldMutual.Scheme.EntityFrameworkCore.Repositories
{
    public class Inbound_Mimo_CustomerRepository : EfCoreRepository<SchemeDbContext, Inbound_Mimo_Customer, Guid>, IInbound_Mimo_CustomerRepository
    {
        private string connectionString;
        public Inbound_Mimo_CustomerRepository(IDbContextProvider<SchemeDbContext> dbContextProvider, IConfiguration configuration)
            : base(dbContextProvider)
        {
            connectionString = ConfigurationExtensions.GetConnectionString(configuration, "connectionString");
        }

        public Task ValidateInbound(string type)
        {
            throw new NotImplementedException();
        }

        public async Task ValidateInboundAsync(string type)
        {
            var dbContext = await GetDbContextAsync();
            await dbContext.Database.ExecuteSqlRawAsync(
                $"dbo.InsertValidationType @type = '{type}'"
            );
        }

        public async Task<Tuple<bool>> InsertSchemeAsync(DataTable dt)
        {
            bool result = false;
            try
            {

                var dbContext = await GetDbContextAsync();

                //string str = "Hi";
                //int res = await dbContext.Database.ExecuteSqlRawAsync(
                //     $"Usp_InsertScheme_Test @test = '{str}'"
                // );

                int res = await dbContext.Database.ExecuteSqlRawAsync(
                     $"dbo.Usp_InsertScheme @UserDefineTable = {dt}"
                 );

                if (res == 1)
                    result = true;
            }
            catch (Exception ex)
            {
                throw;
            }

            return new Tuple<bool>(result);
        }

        public async Task<Tuple<bool>> InsertSchemeAsync_Bulk(List<Inbound_Mimo_Customer> input)
        {
            bool result = false;
            try
            {
                var dbContext = await GetDbContextAsync();
                //var data = dbContext.BulkInsertAsync(input, o => o.BatchTimeout = 0);
                //await dbContext.BulkInsertAsync(input, o => o.BatchTimeout = 0); // ERROR_014: The current month trial is expired

                dbContext.BulkInsert(input);

                //using (var transactionScope = new TransactionScope())
                //{
                //    var dbContext = await GetDbContextAsync();
                //    dbContext.BulkInsert(input);
                //    dbContext.SaveChanges();
                //    transactionScope.Complete();

                //}

                result = true;
            }
            catch (Exception ex)
            {
                throw;
            }


            return new Tuple<bool>(result);
        }

        public async Task<Tuple<string, string, int>> InsertSchemeAsync_ADO(DataTable dt)
        {
            string schemeId = string.Empty;
            string msg = string.Empty;
            int statusCode = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("Usp_InsertScheme_AD"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserDefineTable", dt);
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        schemeId = Convert.ToString(dt.Rows[0]["SchemeId"]);
                        msg = "Scheme inserted successful";
                        statusCode = Convert.ToInt32(HttpStatusCode.OK);
                        conn.Close();
                    }
                    return new Tuple<string, string, int>(schemeId, msg, statusCode);
                }
                catch (Exception ex)
                {
                    msg = "Something went wrong";
                    statusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                    return new Tuple<string, string, int>(schemeId, msg, statusCode);
                }
            }
        }
    }
}
