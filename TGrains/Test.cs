using Orleans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TInterface;

namespace TGrains
{
    public class Test : Orleans.Grain, ITest
    {
        public Task<string> GetName()
        {
            Console.WriteLine("success");
            return Task.FromResult("aabbcc");
        }
    }
}
