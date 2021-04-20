using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using Rushtell_Bunk.Clients;

namespace Rushtell_Bunk
{
    /// <summary>
    /// Парсер Json файлов и добавления данных в локальный репозиторий, не используется так как данные берутся из базы данных
    /// </summary>
    public class Parser
    {
        public Parser (object e)
        {
            string parsedstring = e.ToString();
            var obj = JArray.Parse(parsedstring);
            int i = 0;
            foreach (var item in obj)
            {
                try
                {
                    if (obj[i]["type"].ToString() == "Worker")
                    {
                        Repository.db.Add(new Worker(obj[i]["firstname"].ToString(),
                            obj[i]["lastname"].ToString(), Convert.ToInt32(obj[i]["age"]),
                            Convert.ToInt32(obj[i]["salary"]), Convert.ToInt32(obj[i]["methodPayments"]),
                            Convert.ToInt32(obj[i]["mounthCreateStandartPaymentMeth"]),
                            Convert.ToDouble(obj[i]["deposit"]), obj[i]["depositType"].ToString(),
                            Convert.ToInt32(obj[i]["Id"]), obj[i]["type"].ToString()));
                    }
                    else if (obj[i]["type"].ToString() == "VIPworker")
                    {
                        Repository.db.Add(new VIPworker(obj[i]["firstname"].ToString(),
                            obj[i]["lastname"].ToString(), Convert.ToInt32(obj[i]["age"]),
                            Convert.ToInt32(obj[i]["salary"]), Convert.ToInt32(obj[i]["methodPayments"]),
                            Convert.ToInt32(obj[i]["mounthCreateStandartPaymentMeth"]),
                            Convert.ToDouble(obj[i]["deposit"]), obj[i]["depositType"].ToString(),
                            Convert.ToInt32(obj[i]["Id"]), obj[i]["type"].ToString()));
                    }
                    else if (obj[i]["type"].ToString() == "Organization")
                    {
                        Repository.db.Add(new Organization(obj[i]["name"].ToString(),
                            Convert.ToInt32(obj[i]["salary"]), Convert.ToInt32(obj[i]["methodPayments"]),
                            Convert.ToInt32(obj[i]["mounthCreateStandartPaymentMeth"]),
                            Convert.ToDouble(obj[i]["deposit"]), obj[i]["depositType"].ToString(),
                            Convert.ToInt32(obj[i]["Id"]), obj[i]["type"].ToString()));
                    }
                }
                catch (InvalidOperationException)
                {
                    Repository.db.Add(default);
                }
                i++;
            }
            //SystemPayments.Refresh();
        }
    }
}
