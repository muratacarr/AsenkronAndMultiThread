using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMethods
{
    public class ReadFile
    {
        public async static Task<string> ReadFileAsync()
        {
            var mytask = await new HttpClient().GetStringAsync("https://www.google.com/");


            return mytask;
        }
    }
}
