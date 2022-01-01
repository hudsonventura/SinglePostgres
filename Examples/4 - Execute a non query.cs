using HudsonVentura;
using Npgsql;


string stringConnection = "Server=localhost;Port=5432;Database=trade;User Id=postgres;Password=XXXXXXXXXXX;";


SinglePostgres singleton = SinglePostgres.Initialize(stringConnection);

NpgsqlCommand command = new NpgsqlCommand("INSERT INTO public.fusos (id, defasagem, timezone) VALUES (@first, @second, @third)");
command.Parameters.AddWithValue("first", 1);
command.Parameters.AddWithValue("second", -3);
command.Parameters.AddWithValue("third", "America/Sao_Paulo");

try
{
    int row_affecteds = singleton.execute(command);
    if (row_affecteds >= 1)
    {
        Console.WriteLine("ok");
    }
}
catch (Exception err)
{
    Console.WriteLine($"Error generated on connection or on execute command by Npgsql. {err.Message}");
}