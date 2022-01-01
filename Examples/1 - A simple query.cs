using HudsonVentura;
using System.Data;


string stringConnection = "Server=localhost;Port=5432;Database=trade;User Id=postgres;Password=XXXXXXXXXXX;";


SinglePostgres singleton = SinglePostgres.Initialize(stringConnection);
DataTable returnDB = singleton.query("select * from ativo");
if (returnDB.Rows.Count > 0) {
    foreach (DataRow item in returnDB.Rows) {
        Console.WriteLine(item["ativo"]);
    }
}