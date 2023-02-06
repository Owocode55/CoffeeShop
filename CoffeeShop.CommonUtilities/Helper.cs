using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.CommonUtilities
{
    public static class Helper
    {
        public static System.Data.DataTable ConvertToDataTable<T>(IList<T> data)

        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

            System.Data.DataTable table = new System.Data.DataTable();

            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (T item in data)

            {

                DataRow row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;

                }

                table.Rows.Add(row);
            }

            return table;

        }


        public static string GetOrderNumber()
        {
            var sessionId = DateTime.Now.ToString("yyMMddHHmmss") + GetNextRandomNumber();
            return sessionId;
        }

        public static string GetNextRandomNumber()
        {
            Random R = new Random();
            var randNum = R.Next(999999).ToString("000000") + R.Next(999999).ToString("000000");
            return randNum;
        }
        public static DataTable CreateCommunityDatatable(List<dynamic> data, long userID, int channelID, long communityDesignationID)
        {
            System.Data.DataTable table = new System.Data.DataTable();

            table.Columns.Add(new DataColumn()
            {
                ColumnName = "UserID",
                DataType = typeof(Int64)
            });
            table.Columns.Add(new DataColumn()
            {
                ColumnName = "CommunityDesignationID",
                DataType = typeof(Int64)
            });
            table.Columns.Add(new DataColumn()
            {
                ColumnName = "FullName",
                DataType = typeof(string)
            });

            table.Columns.Add(new DataColumn()
            {
                ColumnName = "Email",
                DataType = typeof(string)
            });


            table.Columns.Add(new DataColumn()
            {
                ColumnName = "PhoneNumber",
                DataType = typeof(string)
            });

            table.Columns.Add(new DataColumn()
            {
                ColumnName = "HouseAddress",
                DataType = typeof(string)
            });

            table.Columns.Add(new DataColumn()
            {
                ColumnName = "Gender",
                DataType = typeof(string)
            });

            table.Columns.Add(new DataColumn()
            {
                ColumnName = "RelationshipWithCustomer",
                DataType = typeof(string)
            });

            table.Columns.Add(new DataColumn()
            {
                ColumnName = "Occupation",
                DataType = typeof(string)
            });

            table.Columns.Add(new DataColumn()
            {
                ColumnName = "StateOfResidence",
                DataType = typeof(string)
            });

            table.Columns.Add(new DataColumn()
            {
                ColumnName = "CountryOfResidence",
                DataType = typeof(string)
            });

            table.Columns.Add(new DataColumn()
            {
                ColumnName = "BankAccountName",
                DataType = typeof(string)
            });

            table.Columns.Add(new DataColumn()
            {
                ColumnName = "BankAccountNumber",
                DataType = typeof(string)
            });

            table.Columns.Add(new DataColumn()
            {
                ColumnName = "BankName",
                DataType = typeof(string)
            });

            table.Columns.Add(new DataColumn()
            {
                ColumnName = "BankCode",
                DataType = typeof(string)
            });

            table.Columns.Add(new DataColumn()
            {
                ColumnName = "NickName",
                DataType = typeof(string)
            });

            table.Columns.Add(new DataColumn()
            {
                ColumnName = "Age",
                DataType = typeof(int)
            });

            table.Columns.Add(new DataColumn()
            {
                ColumnName = "Status",
                DataType = typeof(int)
            });

            table.Columns.Add(new DataColumn()
            {
                ColumnName = "BVN",
                DataType = typeof(string)
            });

            table.Columns.Add(new DataColumn()
            {
                ColumnName = "ChannelID",
                DataType = typeof(int)
            });

            table.Columns.Add(new DataColumn()
            {
                ColumnName = "DateCreated",
                DataType = typeof(DateTime)
            });

            table.Columns.Add(new DataColumn()
            {
                ColumnName = "DateUpdated",
                DataType = typeof(DateTime)
            });

            table.Columns.Add(new DataColumn()
            {
                ColumnName = "RetryCount",
                DataType = typeof(int)
            });

            table.Columns.Add(new DataColumn()
            {
                ColumnName = "IsNotificationSent",
                DataType = typeof(bool)
            });

            foreach (var item in data)
            {
                table.Rows.Add(new object[] { userID, communityDesignationID, item.FullName, item.Email, item.PhoneNumber, item.HouseAddress , item.Gender , item.RelationshipWithCustomer , item.Occupation
                ,item.StateOfResidence , item.CountryOfResidence,item.BankAccountName , item.BankAccountNumber , item.BankName , item.BankCode ,
                    item.NickName , item.Age , item.Status , item.BVN , channelID , DateTime.Now , null, 0, false});
            }

            return table;

        }
    }
}
