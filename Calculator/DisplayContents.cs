using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class DisplayContents
    {
        public delegate void StringChangedHandler(string displayString);
        public event StringChangedHandler HistoryChanged;
        private string _history;
        public string History
        {
            get => _history;
            set
            {
                _history = value;
                HistoryChanged?.Invoke(History);
            }
        }

        public event StringChangedHandler CurrentInputChanged;
        private string _currentInput;
        public string CurrentInput
        {
            get => _currentInput;
            set
            {
                _currentInput = value;
                CurrentInputChanged?.Invoke(CurrentInput);
            }
        }

        public string Contents
        {
            get => History + CurrentInput;
        }

        public DisplayContents()
        {
            Reset();
        }
        public void Add(char ch)
        {
            CurrentInput += ch;
        }
        public void AddLeftBracket()
        {
            History += '(';
        }
        public void AddRightBracket()
        {
            bool canAddRightBracket = (History.Count((ch) => ch == '(') - History.Count((ch) => ch == ')')) > 0;

            if (canAddRightBracket)
            {
                AddCurrentInputToHistory();
                History += ')';
            }
        }
        public void AddOp(char op)
        {
            AddCurrentInputToHistory();
            History += op;
        }
        private void AddCurrentInputToHistory()
        {
            History += CurrentInput;
            CurrentInput = "";
        }
        private static bool IsEndsWithOp(string str)
        {
            if (str.Length == 0)
            {
                return false;
            }
            return IsOp(str[^1]);
        }
        private static bool IsOp(char ch)
        {
            return "+-*/".Contains(ch);
        }
        public void PopLast()
        {
            if (CurrentInput.Length == 0) { return; }
            CurrentInput = CurrentInput[0..^1];
        }
        public void Reset()
        {
            History = "";
            CurrentInput = "";
        }
    }
}
