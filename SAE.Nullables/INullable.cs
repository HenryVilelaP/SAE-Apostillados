using System;
using System.Text;

namespace SAE.Nullables
{
    public interface INullable
    {
        bool HasValue { get; }
        object DBNullable { get; }
        string UINullable { get; }
        string ToString();
    }
}