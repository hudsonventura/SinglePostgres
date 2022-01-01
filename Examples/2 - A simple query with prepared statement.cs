using HudsonVentura;
using System.Data;
using Npgsql;


string stringConnection = "Server=localhost;Port=5432;Database=trade;User Id=postgres;Password=XXXXXXXXXXX;";


SinglePostgres singleton = SinglePostgres.Initialize(stringConnection);

NpgsqlCommand command = new NpgsqlCommand("select * from ativo where ativo = @teste");
command.Parameters.AddWithValue("teste", "BTCUSDT");


DataTable returnDB = singleton.query(command);
if (returnDB.Rows.Count > 0) {
    foreach (DataRow item in returnDB.Rows) {
        Console.WriteLine(item["ativo"]);
    }
}