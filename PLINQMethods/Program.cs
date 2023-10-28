using System.Diagnostics;

Stopwatch sw = Stopwatch.StartNew();

//metohd içlerinde console yazdırmadığımız zaman 1milyodan sonra Parallel daha avantajlı olmaya başladı
var array=Enumerable.Range(1,1000000000).ToList();

var newArray=array.AsParallel().Where(x=>x%2==0);

sw.Start();

newArray.ForAll(x =>
{
    //Console.WriteLine(x + "   Kullanılan Thread : " + Thread.CurrentThread.ManagedThreadId);
});

sw.Stop();
Console.WriteLine(sw.ElapsedMilliseconds);
sw.Restart();

sw.Start();

newArray.ToList().ForEach(x =>
{
    //Console.WriteLine(x + "   Kullanılan Thread : " + Thread.CurrentThread.ManagedThreadId);

});

sw.Stop();
Console.WriteLine(sw.ElapsedMilliseconds);