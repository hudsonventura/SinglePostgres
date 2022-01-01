# SinglePostgres
Singleton class to access PostgreSQL. Its grant that you have just a single connection to one database.<br>
You can connect with a many databases, each one with your singleton connection.<br>
SinglePostgres have a connection manager, and you can use this to manage your db access.<br>
<br>
I disclame for you that SinglePostgres must be used in a simple project, or just a simple things. If you are working in a big project, I advise you to user a ORM like Entity Framework.<br>
<br>
<br>
###The using...<br>
using HudsonVentura;<br>
using System.Data;<br>
using Npgsql;<br>
<br>
<br>
###To create a singleton connection to one database<br>
```
SinglePostgres singleton = SinglePostgres.Initialize(stringConnection);
```
<br>
<br>
###To create many singletons connection to many named databases<br>
```
SinglePostgres singleton1 = SinglePostgres.Initialize(1, stringConnection);
SinglePostgres singleton2 = SinglePostgres.Initialize("Second", stringConnection);
SinglePostgres singleton3 = SinglePostgres.Initialize("Test", stringConnection);
```
<br>
<br>
###To create many singleton connection to many databases<br>
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