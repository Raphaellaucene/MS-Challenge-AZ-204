using StackExchange.Redis;
using System;

string connString = "ConnectionStringsRedis";

using (var cache = ConnectionMultiplexer.Connect(connString))
{
    IDatabase db = cache.GetDatabase();

    var result = await db.ExecuteAsync("PING");
    Console.WriteLine(result);

    bool setValue = await db.StringSetAsync("name", "WareLab");
    Console.WriteLine(setValue);

    string getValue = await db.StringGetAsync("name");
    Console.WriteLine(db.StringGet("name"));
}