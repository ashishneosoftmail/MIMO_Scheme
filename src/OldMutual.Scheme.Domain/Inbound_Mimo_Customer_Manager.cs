using OldMutual.Scheme.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace OldMutual.Scheme
{
    public class Inbound_Mimo_Customer_Manager : DomainService
    {
        private readonly IInbound_Mimo_CustomerRepository _IInbound_Mimo_CustomerRepository;

        public Inbound_Mimo_Customer_Manager(IInbound_Mimo_CustomerRepository iInbound_Mimo_CustomerRepository)
        {
            _IInbound_Mimo_CustomerRepository = iInbound_Mimo_CustomerRepository;
        }


        //public async Task<Inbound_Mimo_Customer> CreateAsync(
        //      string schemeid
        //    , string system
        //    , string systemCompanyId
        //    , string systemUniqueId
        //    , string customerGroupId
        //    , string primaryEmailAddress
        //    , string pinNumber
        //    , string currencyCode
        //    , string partyType
        //    , string primaryPhoneNumber
        //    , string addressDefaultRoles
        //    , string addressCountryCode
        //    , bool billGroupCombinedCollection
        //    , string brokerCode
        //    , bool isBillGroup
        //    , string billGroupNo
        //    , string billGroupName
        //    , bool brokerCombinedCollection
        //    , string customerBankAccountHolder
        //    , string customerBankAccountNumber
        //    , string customerBankBranchCode
        //    , string customerBankName
        //    , string customerCellularAccountNumber
        //    , string customerExternalMethodOfPayment
        //    , string iBanNo
        //    , string addressDescription
        //    )
        //{

        //    try
        //    {
        //        var objInbound = new Inbound_Mimo_Customer(
        //               GuidGenerator.Create()
        //                , schemeid
        //                , system
        //                , systemCompanyId
        //                , systemUniqueId
        //                , customerGroupId
        //                , primaryEmailAddress
        //                , pinNumber
        //                , currencyCode
        //                , partyType
        //                , primaryPhoneNumber
        //                , addressDefaultRoles
        //                , addressCountryCode
        //                , billGroupCombinedCollection
        //                , brokerCode
        //                , isBillGroup
        //                , billGroupNo
        //                , billGroupName
        //                , brokerCombinedCollection
        //                , customerBankAccountHolder
        //                , customerBankAccountNumber
        //                , customerBankBranchCode
        //                , customerBankName
        //                , customerCellularAccountNumber
        //                , customerExternalMethodOfPayment
        //                , iBanNo
        //                , addressDescription

        //       );

        //        var oInbouound = await _IInbound_Mimo_CustomerRepository.InsertAsync(objInbound, autoSave: true);
        //        //await _InboundRepository.ValidateInboundAsync(objInbound.System);
        //        return oInbouound;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }

        //}

        //public async Task<Inbound_Mimo_Customer> CreateAsync_Bulk(List<Inbound_Mimo_Customer> input)
        //{
        //    var objInbound = new Inbound_Mimo_Customer();

        //    DataTable dt = ListToDataTable(input);
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        row["Id"] = Convert.ToString(Guid.NewGuid());
        //    }

        //    //DataTable test = CreateTestTable();
        //    var tuple = await _IInbound_Mimo_CustomerRepository.InsertSchemeAsync(dt);
        //    bool isSuccess = tuple.Item1;
        //    return objInbound;
        //}





        //Bulk Insert


        public async Task<Tuple<bool, int>> InsertSchemeAsync_Bulk(List<Inbound_Mimo_Customer> input)
        {
            var tuple = await _IInbound_Mimo_CustomerRepository.InsertSchemeAsync_Bulk(input);

            return new Tuple<bool, int>(tuple.Item1, tuple.Item2);
        }


        //ADO-Bulk Insert
        public async Task<Tuple<string, int, string, string>> InsertSchemeAsync_ADO(List<Inbound_Mimo_Customer> input)
        {
            DataTable dt = ListToDataTable(input);
            foreach (DataRow row in dt.Rows)
            {
                row["Id"] = Convert.ToString(Guid.NewGuid());
            }

            var tuple = await _IInbound_Mimo_CustomerRepository.InsertSchemeAsync_ADO(dt);

            return new Tuple<string , int, string, string>(tuple.Item1,tuple.Item2, tuple.Item3, tuple.Item4);
        }


        //Creating ListTodataTable
        public static DataTable ListToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties

            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //if (prop.Name != "Id")
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
               
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
              
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        //Creating TestTable
        private DataTable CreateTestTable()
        {
            DataTable custTable = new DataTable("Inbound_Mimo_Customer_Test");
            DataColumn dtColumn;
            DataRow myDataRow;

            // Create Name column.
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "schemeId";
            custTable.Columns.Add(dtColumn);

            // Create Address column.
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "system";
            custTable.Columns.Add(dtColumn);

            myDataRow = custTable.NewRow();
            myDataRow["schemeId"] = "111";
            myDataRow["system"] = "test";

            custTable.Rows.Add(myDataRow);

            return custTable;
        }

        //Creating CreateList
        private List<Inbound_Mimo_Customer> CreateList(DataTable dt)
        {
            List<Inbound_Mimo_Customer> lstInbound_Mimo_Customer = new List<Inbound_Mimo_Customer>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Inbound_Mimo_Customer inbound_Mimo_Customer = new Inbound_Mimo_Customer();
                inbound_Mimo_Customer.system = Convert.ToString(dt.Rows[i]["system"]);
                inbound_Mimo_Customer.schemeId = Convert.ToString(dt.Rows[i]["schemeId"]);
                inbound_Mimo_Customer.systemCompanyId = Convert.ToString(dt.Rows[i]["systemCompanyId"]);
                inbound_Mimo_Customer.systemUniqueId = Convert.ToString(dt.Rows[i]["systemUniqueId"]);
                inbound_Mimo_Customer.customerGroupId = Convert.ToString(dt.Rows[i]["customerGroupId"]);
                inbound_Mimo_Customer.primaryEmailAddress = Convert.ToString(dt.Rows[i]["primaryEmailAddress"]);
                inbound_Mimo_Customer.pinNumber = Convert.ToString(dt.Rows[i]["pinNumber"]);
                inbound_Mimo_Customer.currencyCode = Convert.ToString(dt.Rows[i]["currencyCode"]);
                inbound_Mimo_Customer.partyType = Convert.ToString(dt.Rows[i]["partyType"]);
                inbound_Mimo_Customer.primaryPhoneNumber = Convert.ToString(dt.Rows[i]["primaryPhoneNumber"]);
                inbound_Mimo_Customer.addressDefaultRoles = Convert.ToString(dt.Rows[i]["addressDefaultRoles"]);
                inbound_Mimo_Customer.addressCountryCode = Convert.ToString(dt.Rows[i]["addressCountryCode"]);
                inbound_Mimo_Customer.brokerCombinedCollection = Convert.ToBoolean(dt.Rows[i]["brokerCombinedCollection"]);
                inbound_Mimo_Customer.brokerCode = Convert.ToString(dt.Rows[i]["brokerCode"]);
                inbound_Mimo_Customer.isBillGroup = Convert.ToBoolean(dt.Rows[i]["isBillGroup"]);
                inbound_Mimo_Customer.billGroupNo = Convert.ToString(dt.Rows[i]["billGroupNo"]);
                inbound_Mimo_Customer.billGroupName = Convert.ToString(dt.Rows[i]["billGroupName"]);
                inbound_Mimo_Customer.billGroupCombinedCollection = Convert.ToBoolean(dt.Rows[i]["StudentId"]);
                inbound_Mimo_Customer.customerBankAccountHolder = Convert.ToString(dt.Rows[i]["customerBankAccountHolder"]);
                inbound_Mimo_Customer.customerBankAccountNumber = Convert.ToString(dt.Rows[i]["customerBankAccountNumber"]);
                inbound_Mimo_Customer.customerBankBranchCode = Convert.ToString(dt.Rows[i]["customerBankBranchCode"]);
                inbound_Mimo_Customer.customerBankName = Convert.ToString(dt.Rows[i]["customerBankName"]);
                inbound_Mimo_Customer.customerCellularAccountNumber = Convert.ToString(dt.Rows[i]["customerCellularAccountNumber"]);
                inbound_Mimo_Customer.customerExternalMethodOfPayment = Convert.ToString(dt.Rows[i]["customerExternalMethodOfPayment"]);
                inbound_Mimo_Customer.iBanNo = Convert.ToString(dt.Rows[i]["iBanNo"]);
                inbound_Mimo_Customer.addressDescription = Convert.ToString(dt.Rows[i]["addressDescription"]);



                lstInbound_Mimo_Customer.Add(inbound_Mimo_Customer);
            }
            return lstInbound_Mimo_Customer;
        }
    }
}
