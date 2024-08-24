using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest.Model
{
    public enum DAOResult
    {
        Success = 0,
        NotFound = 1,
        AlreadyExist = 2,
        SqlError = 3
    }
}
