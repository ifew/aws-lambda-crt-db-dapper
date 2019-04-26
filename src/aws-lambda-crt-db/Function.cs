using Amazon.Lambda.Core;
using Amazon.Lambda.RuntimeSupport;
using Amazon.Lambda.Serialization.Json;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace aws_lambda_crt_db
{
    public class Function
    {
        private static async Task Main(string[] args)
		{
            Func<ILambdaContext, Task<List<DistrictModel>>> func = FunctionHandler;
			using(var handlerWrapper = HandlerWrapper.GetHandlerWrapper(func, new JsonSerializer()))
			{
				using(var lambdaBootstrap = new LambdaBootstrap(handlerWrapper))
				{
					await lambdaBootstrap.RunAsync();
				}
			}
		}

        public static async Task<List<DistrictModel>> FunctionHandler(ILambdaContext context)
        {
            using (MySqlConnection _connection = new MySqlConnection(LambdaConfiguration.Instance["DB_CONNECTION"].ToString()))  
            {  
                if (_connection.State == ConnectionState.Closed)  
                    _connection.Open();  
  
                string sqlQuery = "SELECT * FROM district";
                var result = await _connection.QueryAsync<DistrictModel>(sqlQuery);

                return result.ToList();  
            } 
        }
    }
}
