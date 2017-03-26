using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Util
{
    public class CollectionUtil
    {
        public static IList<T> AsList<T>(params T[] source)
        {
            return source;
        }
    }
}
