using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FCxLabs.TechLibraryAPI.Exception.ExceptionsBase
{
    public class UnauthorizedException : TechLibraryException
    {

        public override int StatusCode => throw new NotImplementedException();

        public override List<string> GetErrors()
        {
            throw new NotImplementedException();
        }


        
    }
}
