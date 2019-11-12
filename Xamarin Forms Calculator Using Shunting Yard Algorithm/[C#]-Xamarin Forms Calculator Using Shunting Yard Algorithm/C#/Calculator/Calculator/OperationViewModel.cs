using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Calculator
{
    public class OperationViewModel: ViewModelBase
    {
        private string resultString = "";
        private string historyString = "";

        //private string currentEntry = "";
        private bool ifResultDisplayed = false;
        private bool ifDecimal = true;
        private bool ifOperators = false;
        private bool ifZero = false;
        public string ResultString
        {
            private set { SetProperty(ref resultString, value); }
            get { return resultString; }
        }

        public string HistoryString
        {
            private set { SetProperty(ref historyString, value); }
            get { return historyString; }
        }

        public ICommand ClearCommand { private set; get; }
        public ICommand BackspaceCommand { private set; get; }
        public ICommand NumericCommand { private set; get; }
        public ICommand DecimalCommand { private set; get; }
        public ICommand OperatorCommand { private set; get; }
        public ICommand EqualCommand { private set; get; }

        public OperationViewModel ()
        {
            ClearCommand = new Command(
                execute: () =>
                {
                    HistoryString = "";
                    ResultString = "";
                    ifResultDisplayed = false;
                    ifDecimal = true;
                    ifOperators = false;
                    ifZero = false;

                    RefreshCanExecutes();
                });

            BackspaceCommand = new Command(
                execute: () =>
                {

                    if (ifResultDisplayed)
                    {
                        ResultString = "";
                    }

                    if (HistoryString.Length > 1)
                    {
                        if (HistoryString.Substring(HistoryString.Length-1) == " ")
                        {
                            HistoryString = HistoryString.Substring(0, HistoryString.Length - 3);
                        }
                        else
                        {
                            HistoryString = HistoryString.Substring(0, HistoryString.Length - 1);
                        }
                    }
                    else
                    {
                        HistoryString = "";
                        ifResultDisplayed = false;
                        ifDecimal = true;
                        ifOperators = false;
                        ifZero = false;
                    }

                    if (HistoryString.Length > 0)
                    {
                        string last = HistoryString.Substring(HistoryString.Length-1);

                        if (last == " ")
                        {
                            ifResultDisplayed = false;
                            ifDecimal = true;
                            ifOperators = false;
                            ifZero = false;
                        }
                        else if (last == ".")
                        {
                            ifResultDisplayed = false;
                            ifDecimal = false;
                            ifOperators = false;
                            ifZero = true;
                        }
                        else // last is a digit
                        {
                            ifResultDisplayed = false;
                            ifDecimal = HistoryString.LastIndexOf(".") 
                                <= HistoryString.LastIndexOfAny("+-*/".ToCharArray());
                            ifOperators = true;
                            ifZero = true;
                        }
                    }

                    RefreshCanExecutes();
                },
                canExecute: () => HistoryString.Length > 0
                );

            NumericCommand = new Command<string>(
                execute: (string parameter) =>
                {
                    HistoryString += parameter;

                    if (ifResultDisplayed)
                    {
                        ResultString = "";
                    }

                    ifResultDisplayed = false;
                    ifOperators = true;
                    ifZero = true;

                    RefreshCanExecutes();
                },
                canExecute: (string parameter) =>{
                    if (parameter == "0")
                    {
                        return ifZero && HistoryString.Length
                                  - HistoryString.LastIndexOfAny("+-*/".ToCharArray())
                                  <= 18; 
                    }

                    return HistoryString.Length
                           - HistoryString.LastIndexOfAny("+-*/".ToCharArray())
                           <= 18; // max length of a number is 16
                }
                    );
            DecimalCommand = new Command(
                execute: () =>
                {
                    HistoryString += ".";

                    if (ifResultDisplayed)
                    {
                        ResultString = "";
                    }

                    ifResultDisplayed = false;
                    ifDecimal = false;
                    ifOperators = false;
                    ifZero = true;

                    RefreshCanExecutes();
                },
                canExecute: ()=>ifDecimal
                );

            OperatorCommand = new Command<string>(
                execute: (string parameter) =>
                {
                    if (HistoryString.Length == 0 && parameter == "-")
                    {
                        HistoryString += parameter;
                    }
                    else
                    {
                        HistoryString += " " + parameter + " ";
                    }

                    if (ifResultDisplayed)
                    {
                        ResultString = "";
                    }

                    ifResultDisplayed = false;
                    ifDecimal = true;
                    ifOperators = false;
                    ifZero = false;

                    RefreshCanExecutes();
                },
                canExecute: (string parameter) =>
                {
                    if (HistoryString.Length == 0 && parameter == "-")
                    {
                        return true;
                    }
                    else
                    {
                        return ifOperators;
                    }
                }
                );
            EqualCommand = new Command(
                execute: () =>
                {

                    ResultString = ComputeResult(HistoryString);

                    ifResultDisplayed = true;
                    ifDecimal = true;
                    ifOperators = true;
                    ifZero = true;

                    RefreshCanExecutes();
                },
                canExecute: () =>
                {
                    if (HistoryString.Length == 0)
                    {
                        return false;
                    }

                    if (HistoryString[HistoryString.Length-1].ToString() == ".")
                    {
                        return false;
                    }

                    int index = HistoryString.LastIndexOfAny("+-*/".ToCharArray());

                    if (index == -1)
                    {
                        return true;
                    }

                    if (index == 0 ) 
                    {
                        if (HistoryString.Length == 1)
                        {
                            return false;
                        }
                        return true;
                    } 

                    if (index < HistoryString.Length - 2)
                    {
                        return true;
                    }

                    return false;
                }
                );
        }

        string ComputeResult(string input)
        {
            string[] expression = input.Split(' ');

            string[] rpn = GetRpn(expression);
            //return string.Join(" ", rpn);
            return ComputeRpn(rpn).ToString();
        }

        double ComputeBasic( double operand1, double operand2, string operation)
        {
            switch (operation)
            {
                case "+":
                    return operand1 + operand2;
                case "-":
                    return operand1 - operand2;
                case "*":
                    return operand1 * operand2;
                case "/":
                    return operand1 / operand2;
                default:
                    return -0.0000; // error
            }
        }

        Dictionary<string, int> operators = new Dictionary<string, int>
        {
            { "+", 0 }, { "-", 0 }, {"*", 1 }, { "/", 1 }
        };

        bool IsOperator(string input)
        {
            return operators.ContainsKey(input);
        }

        int ComparePrecedence(string operator1, string operator2)
        {
            return operators[operator1] - operators[operator2];
        }

        string[] GetRpn(string[] inputs)
        {
            List<string> rpn = new List<string>();
            Stack<string> postOperators = new Stack<string>();

            foreach (string input in inputs)
            {
                if (IsOperator(input))
                {
                    while ( postOperators.Count >0 )
                    {
                        if (ComparePrecedence(postOperators.Peek(), input) >= 0)
                        {
                            rpn.Add(postOperators.Pop());
                        }
                        else
                        {
                            break;
                        }
                    }
                    postOperators.Push(input);
                }
                else
                {
                    rpn.Add(input);
                }
            }

            while (postOperators.Count > 0)
            {
                rpn.Add(postOperators.Pop());
            }

            return rpn.ToArray();
        }

        double ComputeRpn(string[] rpn)
        {
            Stack<double> numbers = new Stack<double>();
            double operand1, operand2;

            foreach (string input in rpn)
            {
                if (IsOperator(input))
                {
                    operand2 = numbers.Pop();
                    operand1 = numbers.Pop();
                    numbers.Push(ComputeBasic(operand1, operand2, input));
                }
                else
                {
                    numbers.Push(double.Parse(input));
                }
            }

            if (numbers.Count == 1)
            {
                return numbers.Pop();
            }
            return -0.0000;
        }

        void RefreshCanExecutes()
        {
            ((Command)BackspaceCommand).ChangeCanExecute();
            ((Command)DecimalCommand).ChangeCanExecute();
            ((Command)NumericCommand).ChangeCanExecute();
            ((Command)OperatorCommand).ChangeCanExecute();
            ((Command)EqualCommand).ChangeCanExecute();
        }

        public void SaveState(IDictionary<string, object> dictionary)
        {
            dictionary["ResultString"] = ResultString;
            dictionary["HistoryString"] = HistoryString;
            dictionary["ifResultDisplayed"] = ifResultDisplayed;
            dictionary["ifOperators"] = ifOperators;
            dictionary["ifDecimal"] = ifDecimal;
            dictionary["ifZero"] = ifZero;
        }

        public void RestoreState(IDictionary<string, object> dictionary)
        {
            ResultString = GetDictionaryEntry(dictionary, "ResultString", "");
            HistoryString = GetDictionaryEntry(dictionary, "HistoryString", "");
            ifResultDisplayed = GetDictionaryEntry(dictionary, "ifResultDisplayed", false);
            ifDecimal = GetDictionaryEntry(dictionary, "ifDecimal", true);
            ifOperators = GetDictionaryEntry(dictionary, "ifOperators", false);
            ifZero = GetDictionaryEntry(dictionary, "ifZero", false);

            RefreshCanExecutes();
        }

        public T GetDictionaryEntry<T>(IDictionary<string, object> dictionary,
            string key, T defaultValue)
        {
            if (dictionary.ContainsKey(key))
            {
                return (T) dictionary[key];
            }

            return defaultValue;
        }
    }
}
