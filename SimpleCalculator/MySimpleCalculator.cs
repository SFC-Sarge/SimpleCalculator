using System.ComponentModel.Composition;


namespace SimpleCalculator
{
    [Export(typeof(ICalculator))]
    class MySimpleCalculator : ICalculator
    {
        [ImportMany]
        IEnumerable<Lazy<IOperation, IOperationData>>? operations;
        string[] operation = { "0", "" };

        public String Calculate(string input)
        {
            int left;
            int right;
            // Finds the operator.
            operation = FindNonDigitOperator(input);
            int fn = Convert.ToInt32(operation[0]);
            if (fn < 0) return "Could not parse command.";

            try
            {
                // Separate out the operands.
                if (operation[1].Length == 2)
                {
                    left = Convert.ToInt32(input.Substring(0, fn));
                    right = Convert.ToInt32(input.Substring(fn + 2));

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
                if (i.Metadata.Symbol.ToString().Equals(operation[1]))
                {
                    if (operation[1].Length == 2)
                    {
                        return i.Value.Equality(left, right).ToString();

                    }
                    else if (operation[1].Length == 1 && operation[1] == "<" || operation[1] == ">")
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
        private static string[] FindNonDigitOperator(string s)
        {
            string[] operation = { "0", "" };
            Char[] found = s.Where(c => !Char.IsDigit(c)).ToArray();
            operation[0] = s.IndexOf(found[0]).ToString();

            if (found.Length > 1)
            {
                operation[1] = found[0].ToString() + found[1].ToString();
            }
            else
            {
                operation[1] = found[0].ToString();
            }
            return operation;
        }
    }

}