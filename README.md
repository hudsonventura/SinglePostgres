# SinglePostgres
Singleton class to access PostgreSQL. Its grant that you have just a single connection to one database.
You can connect with a many databases, each one with your singleton connection.
SinglePostgres have a connection manager, and you can use this to manage your db access.

I disclame for you that SinglePostgres must be used in a simple project, or just a simple things. If you are working in a big project, I advise you to user a ORM like Entity Framework.

If you want to talk to me, for any purpose, send me an email. hudsonventura@outlook.com

<br>

### The using...

using HudsonVentura;<br>
using System.Data;<br>
using Npgsql;<br>
<br>
<br>

### To create a singleton connection to one database
```
SinglePostgres singleton = SinglePostgres.Initialize(stringConnection);
```

### To create many singletons connection to many named databases<br>
```
SinglePostgres singleton1 = SinglePostgres.Initialize(1, stringConnection);
SinglePostgres singleton2 = SinglePostgres.Initialize("Second", stringConnection);
SinglePostgres singleton3 = SinglePostgres.Initialize("Test", stringConnection);
```

### To prepare and query a statement<br>
```
SinglePostgres singleton = SinglePostgres.Initialize(stringConnection);

NpgsqlCommand command = new NpgsqlCommand("select * from ativo where ativo = @test");
command.Parameters.AddWithValue("test", "BTCUSDT");


DataTable returnDB = singleton.query(command);
if (returnDB.Rows.Count > 0) {
    foreach (DataRow item in returnDB.Rows) {
        Console.WriteLine(item["ativo"]);
    }
}
```

### To execute a non query statement<br>
```
SinglePostgres singleton = SinglePostgres.Initialize("another db", stringConnection);

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
```