using SimpleCalculator;

using System.ComponentModel.Composition;

namespace ExtOpsGreaterThan
{
    public class ExtOpsGreaterThan
    {
        [Export(typeof(IOperation))]
        [ExportMetadata("Symbol", ">")]
        public class GreaterThan : IOperation
        {

            bool IOperation.Equality(bool left, bool right)
            {
                throw new NotImplementedException();
            }

            bool IOperation.Equality(int left, int right)
            {
                return (left > right);
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