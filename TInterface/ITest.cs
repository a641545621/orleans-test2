using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TInterface
{
   public interface ITest: Orleans.IGrainWithGuidKey
    {
        Task<string> GetName();
    }
}
