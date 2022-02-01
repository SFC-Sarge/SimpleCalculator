using System.ComponentModel.Composition;


namespace SimpleCalculator
{
    [Export(typeof(ICalculator))]
    class MySimpleCalculator : ICalculator
    {
        [ImportMany]
        IEnumerable<Lazy<IOperation, IOperationData>>? operations;
        string operation = "";

        public String Calculate(string input)
        {
            int left;
            int right;
            // Finds the operator.
            operation = FindNonDigitOperator(input);
            int fn = operation.Length;
            if (fn < 0) return "Could not parse command.";

            try
            {
                // Separate out the operands.
                int operandsLength = fn;
                if (operandsLength == 2)
                {
                    left = Convert.ToInt32(input.Substring(0, fn - 1));
                    right = Convert.ToInt32(input.Substring(fn + 1));

                }
                else
                {
                    left = Convert.ToInt32(input.Substring(0, fn));
                    right = Convert.ToInt32(input.Substring(fn + 1));
                }
            }
            catch
            {
                return "Could not parse command.";
            }

            foreach (Lazy<IOperation, IOperationData> i in operations)
            {
                if (i.Metadata.Symbol.ToString().Equals(operation))
                {
                    if (fn == 2)
                    {
                        return i.Value.Equality(left, right).ToString();

                    }
                    else
                    {
                        return i.Value.Operate(left, right).ToString();
                    }
                }
            }
            return "Operation Not Found!";
        }
        private static string FindNonDigitOperator(string s)
        {
            string operation = null;
            Char[] found = s.Where(c => !Char.IsDigit(c)).ToArray();
            if (found.Length > 1)
            {
                operation = found[0].ToString() + found[1].ToString();
            }
            else
            {
                operation = found[0].ToString();
            }
            return operation;
        }
    }

}