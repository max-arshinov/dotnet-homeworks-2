using Hw8.Common;

namespace Hw8.Parser;

public interface IParser
{
    void ParseCalcArguments(string arg1,
        string arg2,
        string arg3,
        out double val1,
        out Operation operation,
        out double val2);
}