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

namespace aws_lambda_crt_db_dapper
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
                context.Logger.LogLine("_connection.ConnectionString: " + _connection.ConnectionString);
                context.Logger.LogLine("_connection.ToString: " + _connection.ToString());
                context.Logger.LogLine("_connection.ServerThread: " + _connection.ServerThread);
                context.Logger.LogLine("ServerVersion Before Open: " + _connection.ServerVersion + "\nState: " + _connection.State.ToString());


                if (_connection.State == ConnectionState.Closed)  
                    _connection.Open();  
                
                context.Logger.LogLine("ServerVersion After Open: " + _connection.ServerVersion + "\nState: " + _connection.State.ToString());

                string sqlQuery = "SELECT * FROM district";
                var result = await _connection.QueryAsync<DistrictModel>(sqlQuery);
                
                return result.ToList();  
            } 
        }
    }
}
