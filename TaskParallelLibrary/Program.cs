using System.Diagnostics;
using System.Drawing;

class Program
{
    private static void Main(string[] args)
    {
        Stopwatch sw = Stopwatch.StartNew();

        sw.Start();

        string path = @"C:\Users\murat\Desktop\pictures";

        var files= Directory.GetFiles(path);

        Parallel.ForEach(files, x =>
        {
            Console.WriteLine("Thread no : " + Thread.CurrentThread.ManagedThreadId);
            Image img = new Bitmap(x);

            var thumbnail = img.GetThumbnailImage(50, 50, () => false, IntPtr.Zero);

            thumbnail.Save(Path.Combine(path, "thumbnail", Path.GetFileName(x)));

        });

        sw.Stop();

        Console.WriteLine("Islem bitti : "+sw.ElapsedMilliseconds);

        sw.Restart();

        sw.Start();

        files.ToList().ForEach(x =>
        {
            Console.WriteLine("Thread no : " + Thread.CurrentThread.ManagedThreadId);
            Image img = new Bitmap(x);

            var thumbnail = img.GetThumbnailImage(50, 50, () => false, IntPtr.Zero);

            thumbnail.Save(Path.Combine(path, "thumbnail", Path.GetFileName(x)));
        });

        sw.Stop();

        Console.WriteLine("Islem bitti : " + sw.ElapsedMilliseconds);

        sw.Stop();


        /*Çıktı Parallel.Foreach
         * 
         * Thread no : 17
Thread no : 4
Thread no : 15
Thread no : 12
Thread no : 7
Thread no : 13
Thread no : 18
Thread no : 14
Thread no : 10
Thread no : 16
Thread no : 1
Thread no : 11
Thread no : 20
Thread no : 21
Thread no : 22
Thread no : 19
Thread no : 24
Thread no : 26
Thread no : 25
Thread no : 23
Islem bitti : 802
Thread no : 1
Thread no : 1
Thread no : 1
Thread no : 1
Thread no : 1
Thread no : 1
Thread no : 1
Thread no : 1
Thread no : 1
Thread no : 1
Thread no : 1
Thread no : 1
Thread no : 1
Thread no : 1
Thread no : 1
Thread no : 1
Thread no : 1
Thread no : 1
Thread no : 1
Thread no : 1
Islem bitti : 4687
         * 
         */



        int deger = 0;

        Parallel.ForEach(Enumerable.Range(1, 100000).ToList(), x =>
        {
            deger = x;
        });
        Console.WriteLine(deger);
    }
}