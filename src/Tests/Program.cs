using HudsonVentura;
using Npgsql;
using NpgsqlTypes;
using System.Data;


string stringConnection1 = "Server=localhost;Port=5432;Database=trade;User Id=postgres;Password=XXXXXXXXXXX;";
string stringConnection2 = "Server=localhost;Port=5433;Database=trade;User Id=postgres;Password=XXXXXXXXXXX;";


SinglePostgres singleton = SinglePostgres.Initialize(1, stringConnection1);
DataTable returnDB = singleton.query("select * from ativo");
if (returnDB.Rows.Count > 0) {
    foreach (DataRow item in returnDB.Rows) {
        Console.WriteLine(item["ativo"]);
    }
}


for (int i = 0; i < 1000; i++)
{
    SinglePostgres singleton2 = SinglePostgres.Initialize(stringConnection2);

    if (!singleton2.IsDataDabaseOnline())
    {
        Console.WriteLine("Database is offline");
        return;
    }

    NpgsqlCommand command = new NpgsqlCommand("select * from ativo where ativo = @teste");
    command.Parameters.AddWithValue("teste", "BTCUSDT");

    DataTable returnDB2 = singleton2.query(command);
    if (returnDB2.Rows.Count > 0)
    {
        foreach (DataRow item in returnDB2.Rows)
        {
            Console.WriteLine(item["horario"].ToString());
        }
    }
}


