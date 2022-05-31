using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Algorythms.ReversePolland
{
    class ExpressionHandler
    {
        public static string Convert(string infix)
        {
            #region original
            Stack<char?> OpStack = new Stack<char?>();
            String Postfix = String.Empty;
            char? previous = 'x', current = null;   //NextOp = new Operator(infix[infix.IndexOfAny(Ops, i)]);
            char[] Ops = { '+', '-', '=', '*', '/' };
            string term = String.Empty;

            foreach (char c in infix)
            {
                if (Ops.Contains(c))                        //if the char is one of the operator chars
                {
                    Postfix += term + " ";                  //split term and add to output
                    while (OpStack.Count > 0)               //While there's actually operators in the stack  
                    {
                        current = OpStack.Pop();            //Assign the operator as current Operator
                        if (current.GetPrecedence() < previous.GetPrecedence())     //If current Op is less priority than preceding Op
                            Postfix += current.ToChar() + " ";                      //Output the character of the Op
                        else                                //If current Op priority is higher than the previous
                        {
                            previous = current;             //Store the current as previous to move on
                            OpStack.Push(current);          //Store current in stack
                            break;                          //Move to next char
                        }//else
                    }//while
                    OpStack.Push(new Operator(c));          //If stack is empty, push the operator
                    term = "";                              // and reset the term to empty
                }//if
                else if (c == ')')                          //If the char is a close paren
                {
                    Postfix += term + " ";                  //store the previous characters as a term in postfix
                    term = "";                              //establish a new term
                    previous = current;                     //Set current as the old Op
                    current = OpStack.Pop();                //Get the new current op
                    while (current.ToChar() != '(')         //Pop the stack until you get an open paren op
                    {
                        Postfix += current.ToChar() + " ";  //Add the term to the output string
                                                            //previous = current;
                        try
                        {
                            current = OpStack.Pop();        //Try to pop another operator
                        }//try
                        catch (Exception)                    //If the stack is empty
                        {
                            return "Error! Mismatched parentheses!";    //Then there is a missing/misaligned paren
                        }//catch
                    }//while
                }//else if
                else if (c == '(')                          //If the op is an open paren
                    OpStack.Push(new Operator(c));          //store it
                else if (c != ' ')                          //If it's an alphanumeric char, 
                    term += c;                              //build a term with it
            }//foreach
            Postfix += term + " ";                          //add the last term to the output
            while (OpStack.Count > 0)                        //If there are remaining ops on the stack,
            {
                current = OpStack.Pop();                    //pop them off
                if (current.ToChar() == '(' || current.ToChar() == ')') //If there is a paren remaining
                    return "Error! Mismatched parentheses!";            // it's because of missing complement or misalignment
                Postfix += current.ToChar() + " ";              //if regular op, add to output
            }//while
            return Postfix;
        }
    }
}
