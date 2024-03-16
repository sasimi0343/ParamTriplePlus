using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamTriplePlus.Params
{
    public class Condition
    {
        public Condition() { }
        public List<IConditionPattern> patterns = new List<IConditionPattern>();
    }

    public class IConditionPattern : ParamList //元インターフェース
    {
    }

    public class ANDCondition : IConditionPattern
    {
        public List<IConditionPattern> patterns = new List<IConditionPattern>();
    }

    public class ORCondition : IConditionPattern
    {
        public List<IConditionPattern> patterns = new List<IConditionPattern>();
    }

    public class ObjectIndexCondition : IConditionPattern
    {
        public Param<int> index = new Param<int>(0, 9999, 0, true, "インデックス");
    }

    public class ObjectIndexRangeCondition : IConditionPattern
    {
        public Param<int> index = new Param<int>(0, 9999, 0, true, "開始インデックス");
        public Param<int> range = new Param<int>(1, 9999, 0, true, "個数");
    }
}
