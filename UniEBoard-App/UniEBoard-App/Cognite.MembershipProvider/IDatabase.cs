using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognite.MembershipProvider
{
    internal interface IDatabase : IDisposable
    {
        dynamic QuerySingle(string commandText, params object[] args);

        IEnumerable<dynamic> Query(string commandText, params object[] parameters);

        dynamic QueryValue(string commandText, params object[] parameters);

        int Execute(string commandText, params object[] args);
    }
}
