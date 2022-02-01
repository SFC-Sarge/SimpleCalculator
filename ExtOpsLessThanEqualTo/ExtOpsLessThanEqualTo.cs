using SimpleCalculator;

using System.ComponentModel.Composition;

namespace ExtOpsLessThanEqualTo
{
    public class ExtOpsLessThanEqualTo
    {
        [Export(typeof(IOperation))]
        [ExportMetadata("Symbol", "<=")]
        public class LessThanEqualTo : IOperation
        {

            bool IOperation.Equality(bool left, bool right)
            {
                throw new NotImplementedException();
            }

            bool IOperation.Equality(int left, int right)
            {
                return (left <= right);
            }

            bool IOperation.Equality(object left, object right)
            {
                throw new NotImplementedException();
            }

            int IOperation.Operate(int left, int right)
            {
                throw new NotImplementedException();
            }
        }

    }
}