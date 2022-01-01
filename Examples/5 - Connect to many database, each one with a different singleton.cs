using HudsonVentura;
using System.Data;
using Npgsql;


string stringConnection = "Server=localhost;Port=5432;Database=trade;User Id=postgres;Password=XXXXXXXXXXX;";

/* The first parameter, you can set an identification to singleton. It can be a int or string. Behind we have a dotnet Dictionary.
 * if you just pass the string connection, it will set for you the id 0 (zero)
 */
SinglePostgres singleton = SinglePostgres.Initialize(1, stringConnection);

NpgsqlCommand command = new NpgsqlCommand("select * from ativo where ativo = @teste");
command.Parameters.AddWithValue("teste", "BTCUSDT");


DataTable returnDB = singleton.query(command);
if (returnDB.Rows.Count > 0) {
    foreach (DataRow item in returnDB.Rows) {
        Console.WriteLine(item["ativo"]);
    }
}







//to connect to another db, you have to set another string connection
string stringConnection2 = "Server=localhost2;Port=5432;Database=trade;User Id=postgres;Password=XXXXXXXXXXX;";

//the first parameter, you can set an identification to singleton. It can be a int or string. Behind we have a dotnet Dictionary
SinglePostgres singleton2 = SinglePostgres.Initialize("second db", stringConnection2);

NpgsqlCommand commands2 = new NpgsqlCommand("select * from ativo where ativo = @teste");
commands2.Parameters.AddWithValue("teste", "BTCUSDT");


DataTable returnDBs = singleton2.query(commands2);
if (returnDBs.Rows.Count > 0)
{
    foreach (DataRow item in returnDBs.Rows)
    {
        Console.WriteLine(item["ativo"]);
    }
}





//if you want to reuse the first db
SinglePostgres singletonAgain = SinglePostgres.Initialize(1);

//if you want to reuse the second db
SinglePostgres singletonAgain2 = SinglePostgres.Initialize("second db");

/*
    If you repeat the string connection, it will return the singleton that you have started
*/
SinglePostgres singletonX = SinglePostgres.Initialize(stringConnection); //the same object that first one