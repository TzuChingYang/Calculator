using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class m_stack
    {   
        private const int stacksize=100 ;
        private string postfix ="";

        private string prefix = "";

        int top ;
        char[] items = new char[stacksize];

        int top_num;
        int[] items_num = new int[stacksize];

        private void Initialize() {
            postfix = "";
            prefix = "";
            top = -1;
            top_num = -1;

            for (int i = 0; i < stacksize; i++) {
                items[i] = '\0';
                items_num[i] = '\0';
            }
        }
        public m_stack() {
            //Initialize 
            Initialize();
        }

        public bool isEmpty() {
            if (top == -1)
            {
                return true;
            }
            else {
                return false;
            }
        }
        public bool isEmpty_num() {
            if (top_num == -1)
            {
                return true;
            }
            else {
                return false;
            }
        }
        public bool isFull() {
            if (top == stacksize - 1)
            {
                return true;
            }
            else {
                return false;
            }
        }

        public bool isFull_num() {
            if (top_num == stacksize - 1)
            {
                return true;
            }
            else {
                return false;
            }
        }
        public void push(char character) {
            if (isFull() == true)
            {
                Console.WriteLine("Stack is full, Can't push");
                Console.ReadKey();
            }
            else {
                top++;
                items[top] = character;
            }
        }
        public void push_num(int number) {
            if (isFull_num() == true)
            {
                Console.WriteLine("Stack is full, Can't push");
                Console.ReadKey();
            }
            else {
                top_num++;
                items_num[top_num] = number;
            }
        }

        public char pop() {
            if (isEmpty() == true)
            {
                Console.WriteLine("Stack is empty , Can't pop");
                Console.ReadKey();
                return 'E';
            }
            else {
                char result = items[top];
                top--;

                return result;
            }
        }
        public int pop_num() {
            if (isEmpty_num() == true)
            {
                Console.WriteLine("Stack is empty , Can't pop");
                Console.ReadKey();
                return -1;
            }
            else {
                int result = items_num[top_num];
                top_num--;

                return result;
            }
        }
        // ISP
        public int ISP() {
            switch (items[top]) {
                case '+':
                    return 12;
                    break;
                case '-':
                    return 12;
                    break;
                case '*':
                    return 13;
                    break;
                case '/':
                    return 13;
                    break;
                default:
                    return -1; 
            }
        }
        // ICP
        public int ICP(char token)
        {
            switch (token)
            {
                case '+':
                    return 12;
                    break;
                case '-':
                    return 12;
                    break;
                case '*':
                    return 13;
                    break;
                case '/':
                    return 13;
                    break;
                default:
                    return -1;
            }
        }

        // Start Implement
        public string GetPostfix(string source) {
            // Data to be uesd
            int LengthOfSource = source.Length;
            //
            for (int i = 0; i < LengthOfSource; i++) {
                // if number
                if (source[i] - '0' >= 0 && source[i] - '9' <= 0)
                {
                    postfix += source[i];
                }
                else {  // if operation
                    if (isEmpty()) // if stack is empty -> push it
                    {
                        push(source[i]);
                    }
                    else {
                        if (ISP()<ICP(source[i])) // PUSH
                        {
                            push(source[i]);
                        }
                        else{ // POP then PUSH
                            while (ISP() >= ICP(source[i])) {
                                postfix += pop();
                                if (isEmpty()) {
                                    break;
                                }
                            }
                            push(source[i]);
                        }
                    }
                }
            }
            // Is not Empty -> POP it
            while (isEmpty() == false) {
                postfix += pop();
            }

            return postfix;
        }

        public string GetPrefix(string source) {
            // Data need ;
            int LengthOfSource = source.Length;

            for (int i = LengthOfSource - 1; i >= 0; i--) {
                // if number
                if (source[i] - '0' >= 0 && source[i] - '9' <= 0)
                {
                    prefix += source[i];
                }
                else { // if Operation
                    if (isEmpty())
                    {
                        push(source[i]);
                    }
                    else {
                        if (ISP() < ICP(source[i]))
                        { // PUSH
                            push(source[i]);
                        }
                        else { // POP and PUSH
                            while (ISP() > ICP(source[i])) {
                                prefix += pop();
                                if (isEmpty()) {
                                    break;
                                }
                            }
                            push(source[i]);
                        }
                    }
                }
            }
            // Is not Empty -? POP it
            while (isEmpty() == false) {
                prefix += pop();
            }

            // Need to reverse
            char[] RevArray = prefix.ToCharArray();
            Array.Reverse(RevArray);
            prefix = new string(RevArray);

            return prefix;
        }

        public int PostfixToDecimal() {
            // Data need
            int answer = 0;
            int LengthOfPostfix = postfix.Length;

            for (int i = 0; i < LengthOfPostfix; i++) {
                if (postfix[i] - '0' >= 0 && postfix[i] - '9' <= 0)
                { // Number push
                    int number = postfix[i] - '0';
                    push_num(number);
                }
                else { // Operation
                    int number_result = 0;
                    int number_2 = pop_num();
                    int number_1 = pop_num();

                    switch (postfix[i]) {
                        case '+':
                            number_result = number_1 + number_2;
                            push_num(number_result);
                            break;

                        case '-':
                            number_result = number_1 - number_2;
                            push_num(number_result);
                            break;

                        case '*':
                            number_result = number_1 * number_2;
                            push_num(number_result);
                            break;

                        case '/':
                            number_result = number_1 / number_2;
                            push_num(number_result);
                            break;

                        default:
                            break;
                            

                    }
                }
            }
            // POP answer 
            answer = pop_num();

            return answer;
        }
    }
}
