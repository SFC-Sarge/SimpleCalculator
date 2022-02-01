using SimpleCalculator;

using System.ComponentModel.Composition;

namespace ExtOpsEquality
{
    public class ExtOpsEquality
    {
        [Export(typeof(IOperation))]
        [ExportMetadata("Symbol", "==")]
        public class Equality : IOperation
        {

            bool IOperation.Equality(bool left, bool right)
            {
                throw new NotImplementedException();
            }

            bool IOperation.Equality(int left, int right)
            {
                return (left == right);
            }

            bool IOperation.Equality(object left, object right)
            {
                return (left == right);
            }

            int IOperation.Operate(int left, int right)
            {
                throw new NotImplementedException();
            }
        }

    }
}