namespace SimpleCalculator
{
    public interface IOperation
    {
        int Operate(int left, int right);
        bool Equality(bool left, bool right);
        bool Equality(int left, int right);
        bool Equality(object left, object right);
    }
}