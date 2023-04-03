using MySqlBasic.MySql.Query;


Query.createQuery("cv",@"SELECT * FROM conversas;");
//Query.createQuery("data", @"SELECT NOW() as 'TIMEDATA01';");

using var rr = await Query.executeQuery("cv");
using var ss = await Query.executeQuery("data");


var aa = "s";

//using var aa = await Query.executeQuery("data");
//if (aa != null)
//{
//    aa.Read();
//    Console.WriteLine(aa.GetValue(0));
//    await aa.CloseAsync();
//}
