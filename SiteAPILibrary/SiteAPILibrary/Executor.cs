using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static System.Convert;
using SiteAPILibrary.Entities;

namespace SiteAPILibrary
{
    public class Executor
    {
        public Executor(string conStr)
        {
            this.conStr = conStr;
        }
        private string conStr = "";
        public DataTable GetTable(SqlParameter[] sqlParameters, string procedureName)
        {
            var cmd = new SqlCommand(procedureName);
            cmd.Parameters.AddRange(sqlParameters);
            cmd.CommandType = CommandType.StoredProcedure;
            return GetDataTable(cmd);
        }

        public DataSet GetTables(SqlParameter[] sqlParameters, string procedureName)
        {
            var cmd = new SqlCommand(procedureName);
            cmd.Parameters.AddRange(sqlParameters);
            cmd.CommandType = CommandType.StoredProcedure;
            return GetDataSet(cmd);
        }

        private DataSet GetDataSet(SqlCommand cmd)
        {
            using (SqlConnection sqlCon = new SqlConnection(conStr))
            {
                cmd.Connection = sqlCon;
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                sqlCon.Open();
                dataAdapter.Fill(dataSet);
                return dataSet;
            }
        }
        private DataTable GetDataTable(SqlCommand cmd)
        {
            var dataSet = GetDataSet(cmd);

            return dataSet.Tables[0];
        }
        /// <summary>
        /// Возвращает массив строк Json
        /// </summary>
        /// <param name="acc_number">Номер агента</param>
        /// <returns></returns>
        public string[] ExecuteGetAllContractsForAccount(SqlParameter acc_number)
        {
            var sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(acc_number);
            var table = this.GetTable(sqlParameters.ToArray(), "[site_api].[GetAllContractsForAccount]");
            string[] jsonContracts = new string[table.Rows.Count];
            Serrializator serrializator = new Serrializator();
            int i = 0;
            foreach (DataRow row in table.Rows)
            {
                var dictionary = new Dictionary<string, object>();
                for (int j = 0; j < row.ItemArray.Length; j++)
                {
                    if (row[j] == null) row[j] = "null";
                    dictionary.Add(table.Columns[j].ColumnName, row[j]);
                }
                var contract = new contract
                {
                    car = new car
                    {
                        brand = new brand
                        {
                            id = dictionary["brand_id"].ToString(),
                            name = dictionary["brand_name"].ToString()
                        },
                        model = new model
                        {
                            id = dictionary["model_id"].ToString(),
                            name = dictionary["model"].ToString()
                        },
                        reg_number = dictionary["reg_number"].ToString(),
                        vin_number = dictionary["vin_number"].ToString()
                    },
                    current_payment_amount = ToDouble(dictionary["current_payment_amount"]),
                    date = ToDateTime(dictionary["date"]),
                    current_payment_date = ToDateTime(dictionary["current_payment_date"]),
                    number = dictionary["number"].ToString(),
                    status = dictionary["status"].ToString(),
                    url = dictionary["url"].ToString(),

                };
                jsonContracts[i] = serrializator.EntToJson(contract);

                var contract1 = serrializator.JsonToEnt<contract>(jsonContracts[i]);
                i++;
            }
            return jsonContracts;
        }
    }
}
