using System.ComponentModel.Composition;

namespace SimpleCalculator
{
    [Export(typeof(IOperation))]
    [ExportMetadata("Symbol", "/")]
    public class Division : IOperation
    {
        public bool Equality(bool left, bool right)
        {
            throw new NotImplementedException();
        }

        public bool Equality(int left, int right)
        {
            throw new NotImplementedException();
        }

        public bool Equality(object left, object right)
        {
            throw new NotImplementedException();
        }

        public int Operate(int left, int right)
        {
            return left / right;
        }
    }
}
