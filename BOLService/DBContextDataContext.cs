using System;
using System.Data.Linq.Mapping;

namespace BOLService
{
    public partial class DBContextDataContext
    {
        [Function(Name = "NEWID", IsComposable = true)]
        public Guid Random()
        { // to prove not used by our C# code... 
            throw new NotImplementedException();
        }
    }
}