using HudsonVentura;
using System.Data;
using Npgsql;


string stringConnection = "Server=localhost;Port=5432;Database=trade;User Id=postgres;Password=XXXXXXXXXXX;";


SinglePostgres singleton = SinglePostgres.Initialize(stringConnection);

if(!singleton.IsConnected()){
    //connection is not open
    if (!singleton.IsDataDabaseOnline())
    {
        //database is not online
        Console.WriteLine("Database is offline");
        return;
    }
} 
