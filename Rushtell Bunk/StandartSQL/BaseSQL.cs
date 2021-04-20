using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Rushtell_Bunk.Clients;

namespace Rushtell_Bunk
{
    /// <summary>
    /// Пример обращения к БД при помощи обычных SQL запросов не используя EntityFramework
    /// В ДАННОМ ПРИЛОЖЕНИИ ДЛЯ ПРИМЕРА, ДАННЫЙ КЛАСС ОТКЛЮЧЕН В ПРИЛОЖЕНИИ
    /// </summary>
    class BaseSQL
    {
        public static SqlConnection connect;
        public static DataTable tableW;
        public static DataTable tableVIPW;
        public static DataTable tableO;
        public static SqlDataAdapter Changer;
        public static SqlCommand command;
        public static SqlDataReader reader;

        public BaseSQL()
        {
            SqlConnectionStringBuilder sqlConnectionString = new SqlConnectionStringBuilder()
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = @"SQLDBRushtellBank",
                IntegratedSecurity = true,
                Pooling = true
            };

            connect = new SqlConnection(sqlConnectionString.ToString());
            connect.Open();
            Changer = new SqlDataAdapter();
            tableW = new DataTable();
            tableVIPW = new DataTable();
            tableO = new DataTable();

            string sql = @"SELECT * FROM Workers";
            command = new SqlCommand(sql, connect);
            Changer.SelectCommand = new SqlCommand(sql, connect);
            Changer.Fill(tableW);
            sql = @"SELECT * FROM VIPworkers";
            Changer.SelectCommand = new SqlCommand(sql, connect);
            Changer.Fill(tableVIPW);
            sql = @"SELECT * FROM Organizations";
            Changer.SelectCommand = new SqlCommand(sql, connect);
            Changer.Fill(tableO);

        }

        public static void Add(IClient client)
        {
            string sql;
            switch (client.type)
            {
                case "Worker":
                    sql = $@"
INSERT INTO Workers 
(Id, firstname, lastname, age, salary,
deposit, methodPayments, mounthCreateStandartPaymentMeth, depositType, type)
VALUES
({((Worker)Repository.db[Repository.db.Count - 1]).Id},
'{((Worker)Repository.db[Repository.db.Count - 1]).firstname}',
'{((Worker)Repository.db[Repository.db.Count - 1]).lastname}',
{((Worker)Repository.db[Repository.db.Count - 1]).age},
{((Worker)Repository.db[Repository.db.Count - 1]).salary},
{((Worker)Repository.db[Repository.db.Count - 1]).deposit.ToString().Replace(",", ".")},
{((Worker)Repository.db[Repository.db.Count - 1]).methodPayments},
{((Worker)Repository.db[Repository.db.Count - 1]).mounthCreateStandartPaymentMeth},
'{((Worker)Repository.db[Repository.db.Count - 1]).depositType}',
'{((Worker)Repository.db[Repository.db.Count - 1]).type}')
";
                    command = new SqlCommand(sql, connect);
                    command.ExecuteNonQuery();
                    break;
                case "VIPworker":
                    sql = $@"
INSERT INTO VIPworkers 
(Id, firstname, lastname, age, salary,
deposit, methodPayments, mounthCreateStandartPaymentMeth, depositType, type)
VALUES
({((VIPworker)client).Id},
'{((VIPworker)client).firstname}',
'{((VIPworker)client).lastname}',
{((VIPworker)client).age},
{((VIPworker)client).salary},
{((VIPworker)client).deposit.ToString().Replace(",", ".")},
{((VIPworker)client).methodPayments},
{((VIPworker)client).mounthCreateStandartPaymentMeth},
'{((VIPworker)client).depositType}',
'{((VIPworker)client).type}')
";
                    command = new SqlCommand(sql, connect);
                    command.ExecuteNonQuery();
                    break;
                case "Organization":
                    sql = $@"
INSERT INTO Organizations 
(Id, [name], salary,
deposit, methodPayments, mounthCreateStandartPaymentMeth, depositType, type)
VALUES
({((Organization)Repository.db[Repository.db.Count - 1]).Id},
'{((Organization)Repository.db[Repository.db.Count - 1]).name}',
{((Organization)Repository.db[Repository.db.Count - 1]).salary},
{((Organization)Repository.db[Repository.db.Count - 1]).deposit.ToString().Replace(",", ".")},
{((Organization)Repository.db[Repository.db.Count - 1]).methodPayments},
{((Organization)Repository.db[Repository.db.Count - 1]).mounthCreateStandartPaymentMeth},
'{((Organization)Repository.db[Repository.db.Count - 1]).depositType}',
'{((Organization)Repository.db[Repository.db.Count - 1]).type}')
";
                    command = new SqlCommand(sql, connect);
                    command.ExecuteNonQuery();
                    break;
                default:
                    break;
            }

        }

        public static void Delete(int Id)
        {
            string sql = $@"
DELETE FROM Workers
WHERE Id = {Id}";
            command = new SqlCommand(sql, connect);
            command.ExecuteNonQuery();
            sql = $@"
DELETE FROM VIPworkers
WHERE Id = {Id}";
            command = new SqlCommand(sql, connect);
            command.ExecuteNonQuery();
            sql = $@"
DELETE FROM Organizations
WHERE Id = {Id}";
            command = new SqlCommand(sql, connect);
            command.ExecuteNonQuery();
        }

        public static void LowDelete(int Id)
        {
            string sql = $@"
UPDATE Workers SET [type] = 'DELETED'
WHERE Id = {Id}";
            command = new SqlCommand(sql, connect);
            command.ExecuteNonQuery();
            sql = $@"
UPDATE VIPworkers SET [type] = 'DELETED'
WHERE Id = {Id}";
            command = new SqlCommand(sql, connect);
            command.ExecuteNonQuery();
            sql = $@"
UPDATE Organizations SET [type] = 'DELETED'
WHERE Id = {Id}";
            command = new SqlCommand(sql, connect);
            command.ExecuteNonQuery();
        }

        public static void Change(IClient client)
        {
            string sql;
            switch (client.type)
            {
                case "Worker":
                    sql = $@"
UPDATE Workers
SET
firstname = '{((Worker)client).firstname}',
lastname = '{((Worker)client).lastname}',
age = {((Worker)client).age},
salary = {((Worker)client).salary},
deposit = {((Worker)client).deposit.ToString().Replace(",",".")},
methodPayments = {((Worker)client).methodPayments},
mounthCreateStandartPaymentMeth = {((Worker)client).mounthCreateStandartPaymentMeth},
depositType = '{((Worker)client).depositType}',
type = '{((Worker)client).type}'
WHERE Id = {((Worker)client).Id}
";
                    command = new SqlCommand(sql, connect);
                    command.ExecuteNonQuery();
                    break;
                case "VIPworker":
                    sql = $@"
UPDATE VIPworkers
SET
firstname = '{((VIPworker)client).firstname}',
lastname = '{((VIPworker)client).lastname}',
age = {((VIPworker)client).age},
salary = {((VIPworker)client).salary},
deposit = {((VIPworker)client).deposit.ToString().Replace(",", ".")},
methodPayments = {((VIPworker)client).methodPayments},
mounthCreateStandartPaymentMeth = {((VIPworker)client).mounthCreateStandartPaymentMeth},
depositType = '{((VIPworker)client).depositType}',
type = '{((VIPworker)client).type}'
WHERE Id = {((VIPworker)client).Id}
";
                    command = new SqlCommand(sql, connect);
                    command.ExecuteNonQuery();
                    break;
                case "Organization":
                    sql = $@"
UPDATE Organizations
SET
name = '{((Organization)client).name}',
salary = {((Organization)client).salary},
deposit = {((Organization)client).deposit.ToString().Replace(",", ".")},
methodPayments = {((Organization)client).methodPayments},
mounthCreateStandartPaymentMeth = {((Organization)client).mounthCreateStandartPaymentMeth},
depositType = '{((Organization)client).depositType}',
type = '{((Organization)client).type}'
WHERE Id = {((Organization)client).Id}
";
                    command = new SqlCommand(sql, connect);
                    command.ExecuteNonQuery();
                    break;
                default:
                    break;
            }
        }

        public static void FillDB()
        {
            string sql;
            int maxId = 0;
            sql = @"SELECT MAX (Id) FROM Workers";
            command = new SqlCommand(sql, connect);
            reader = command.ExecuteReader();
            reader.Read();
            try
            {
                maxId = reader.GetInt32(0);
            }
            catch (Exception)
            {

            }
            reader.Close();
            sql = @"SELECT MAX (Id) FROM VIPworkers";
            command = new SqlCommand(sql, connect);
            reader = command.ExecuteReader();
            reader.Read();
            try
            {
                if (reader.GetInt32(0) > maxId) maxId = reader.GetInt32(0);
            }
            catch (Exception)
            {

            }
            reader.Close();
            sql = @"SELECT MAX (Id) FROM Organizations";
            command = new SqlCommand(sql, connect);
            reader = command.ExecuteReader();
            reader.Read();
            try
            {
                if (reader.GetInt32(0) > maxId) maxId = reader.GetInt32(0);
            }
            catch (Exception)
            {

            }
            reader.Close();


            for (int i = 0; i <= maxId; i++)
            {
                bool check = false;
                sql = $@"SELECT Id FROM Workers WHERE Id = {i}";
                command = new SqlCommand(sql, connect);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    reader.Close();
                    sql = $@"SELECT firstname,
lastname, age, salary, methodPayments, mounthCreateStandartPaymentMeth, 
deposit, depositType, type FROM Workers WHERE Id = {i}";
                    command = new SqlCommand(sql, connect);
                    reader = command.ExecuteReader();
                    reader.Read();
                    if (reader.GetString(8) == "DELETED")
                    {
                        Repository.db.Add(default);
                        check = true;
                    }
                    else
                    {
                        Repository.db.Add(new Worker(reader.GetString(0),
                        reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3),
                        reader.GetInt32(4), reader.GetInt32(5), reader.GetDouble(6),
                        reader.GetString(7), i, reader.GetString(8)));
                        check = true;
                    }
                }
                reader.Close();
                if (check) continue;
                reader.Close();
                sql = $@"SELECT Id FROM VIPworkers WHERE Id = {i}";
                command = new SqlCommand(sql, connect);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    reader.Close();
                    sql = $@"SELECT firstname,
lastname, age, salary, methodPayments, mounthCreateStandartPaymentMeth, 
deposit, depositType, type FROM VIPworkers WHERE Id = {i}";
                    command = new SqlCommand(sql, connect);
                    reader = command.ExecuteReader();
                    reader.Read();
                    if (reader.GetString(8) == "DELETED")
                    {
                        Repository.db.Add(default);
                        check = true;
                    }
                    else
                    {
                        Repository.db.Add(new VIPworker(reader.GetString(0),
                        reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3),
                        reader.GetInt32(4), reader.GetInt32(5), reader.GetDouble(6),
                        reader.GetString(7), i, reader.GetString(8)));
                        check = true;
                    }
                }
                reader.Close();
                if (check) continue;
                reader.Close();
                sql = $@"SELECT Id FROM Organizations WHERE Id = {i}";
                command = new SqlCommand(sql, connect);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    reader.Close();
                    sql = $@"SELECT name, salary,
methodPayments, mounthCreateStandartPaymentMeth, 
deposit, depositType, type FROM Organizations WHERE Id = {i}";
                    command = new SqlCommand(sql, connect);
                    reader = command.ExecuteReader();
                    reader.Read();
                    if (reader.GetString(6) == "DELETED")
                    {
                        Repository.db.Add(default);
                        check = true;
                    }
                    else
                    {
                        Repository.db.Add(new Organization(reader.GetString(0),
                        reader.GetInt32(1), reader.GetInt32(2),
                        reader.GetInt32(3), reader.GetDouble(4),
                        reader.GetString(5), i, reader.GetString(6)));
                        check = true;
                    }
                }
                reader.Close();
            }
        }
    }
}
