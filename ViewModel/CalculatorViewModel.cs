using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;

namespace MRK_NoteBook.ViewModel
{
    public partial class CalculatorViewModel
    {
        public CalculatorViewModel(INavigation navigation)
        {

        }


        public static double DxecCalculation(double val1, double val2, string operatorMath)
        {
            double result = 0;

            switch (operatorMath)
            {
                case "/":
                    result = val1 / val2;
                    break;
                case "-":
                    result = val1 - val2;
                    break;
                case "*":
                    result = val1 * val2;
                    break;
                case "+":
                    result = val1 + val2;
                    break;
                default:
                    break;
            }

            return result;
        }
    }



}
