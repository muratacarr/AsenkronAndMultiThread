using TaskMethods;

internal class Program
{
    static async Task Main(string[] args)
    {
        //6.DERS------------------------------
        //Console.WriteLine("---Başladı---");

        //var mytask = ReadFile.ReadFileAsync();

        //Console.WriteLine("Arada yapılacak işler");

        //var data = await mytask;
        //Console.WriteLine($"Data uzunluk : {data.Length}");

        //Console.WriteLine("---Bitti---");



        //7.DERS-----------------------
        Console.WriteLine("Main Thread : " + Thread.CurrentThread.ManagedThreadId);
        List<string> list = new List<string>
        {
            "https://www.google.com",
            "https://www.apple.com",
            "https://www.amazon.com",
            "https://www.microsoft.com",
            "https://www.vatanbilgisayar.com/"
        };
        List<Task<Content>> tasks = new List<Task<Content>>();
        Console.WriteLine("Murat önce işlemler yaptım");

        list.ForEach(x =>
        {
            tasks.Add(GetContentAsync(x));
        });
        Console.WriteLine("WhenAll dan önce işlemler yaptım");

        Console.WriteLine("WhenAll dan önce thread : " + Thread.CurrentThread.ManagedThreadId);

        var contents = Task.WhenAll(tasks);
        Console.WriteLine("WhenAll dan sonra işlemler yaptım");
        Console.WriteLine("contents await den önce işlemler yaptım");

        var data= await contents;
        Console.WriteLine("contents await den sonra işlemler yaptım");

        Console.WriteLine("contents await den thread : " + Thread.CurrentThread.ManagedThreadId);

        data.ToList().ForEach(x => Console.WriteLine($"{x.Site} boyut:{x.Lenght}"));

    }
    public static async Task<Content> GetContentAsync(string url)
    {
        Content content = new Content();
        Console.WriteLine("GetContentAsync1 thread : " + Thread.CurrentThread.ManagedThreadId);
        var data = await new HttpClient().GetStringAsync(url);

        content.Site = url;
        content.Lenght = data.Length;
        Console.WriteLine("GetContentAsync2 thread : "+Thread.CurrentThread.ManagedThreadId);
        return content;
    }

}