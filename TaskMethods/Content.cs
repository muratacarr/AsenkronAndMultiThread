using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMethods
{
    public class Content
    {
        public Content()
        {
            Console.WriteLine("Content thread : " + Thread.CurrentThread.ManagedThreadId);
        }
        public string Site { get; set; }
        public int Lenght { get; set; }
    }
}
