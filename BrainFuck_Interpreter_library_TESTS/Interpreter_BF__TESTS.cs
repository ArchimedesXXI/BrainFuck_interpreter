using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using BrainFuck_Interpreter_library;

namespace BrainFuck_Interpreter_library_TESTS
{
    [TestClass]
    public class Interpreter_BF__TESTS
    {
        [TestMethod]
        public void Add_Two_one_digit_numbers_in_BF()
        {
            string BF_code = ",>++++++[<-------->-],[<+>-]<.";
            string Inputs = "35";

            Interpreter_BF interpreter = new Interpreter_BF(BF_code, Inputs);
            interpreter.Interpret();

            string ActualOutput = interpreter.Outputs;
            string ExpectedOutput = "8";

            Debug.WriteLine(ActualOutput);

            Assert.AreEqual(ExpectedOutput, ActualOutput, true);
        }

        [TestMethod]
        public void Multiply_Two_one_digit_numbers_in_BF()
        {
            string BF_code = ",>,>++++++++[<------<------>>-] <<[>[> +> +<< -] >>[<< +>> -] <<< -] >>> ++++++[< ++++++++> -] <.";
            string Inputs = "23";

            Interpreter_BF interpreter = new Interpreter_BF(BF_code, Inputs);
            interpreter.Interpret();

            string ActualOutput = interpreter.Outputs;
            string ExpectedOutput = "6";

            Debug.WriteLine(ActualOutput);

            Assert.AreEqual(ExpectedOutput, ActualOutput, true);
        }

        [TestMethod]
        public void Devide_Two_one_digit_numbers_in_BF_andIgnoreComments()
        {
            string BF_code = @" ,>,>++++++[-<--------<-------->>] przechowuje dwie cyfry w (0) i (1) od obu odejmujemy 48
                                <<[                               powtarzaj dopóki dzielna jest niezerowa
                                >[->+>+<<]                        kopiuj dzielnik z (1) do (2) i (3) (1) się zeruje
                                >[-<<-                            odejmujemy 1 od dzielnej (0) i dzielnika (2) dopóki (2) nie jest 0
                                [>]>>>[<[>>>-<<<[-]]>>]<<]        jeżeli dzielna jest zerem wyjdź z pętli
                                >>>+                              dodaj jeden do ilorazu w (5)
                                <<[-<<+>>]                        kopiuj zapisany dzielnik z (3) do (1)
                                <<<]                              przesuń wskaźnik na (0) i powtórz pętlę
                                >[-]>>>>[-<<<<<+>>>>>]            kopiuj iloraz z (5) do (0)
                                <<<<++++++[-<++++++++>]<.         dodaj 48 i drukuj wynik";
            string Inputs = "82";

            Interpreter_BF interpreter = new Interpreter_BF(BF_code, Inputs);
            interpreter.Interpret();

            string ActualOutput = interpreter.Outputs;
            string ExpectedOutput = "4";

            Debug.WriteLine(ActualOutput);

            Assert.AreEqual(ExpectedOutput, ActualOutput, true);
        }

        [TestMethod]
        public void Read_input_and_print_in_BF()
        {
            string BF_code = ">>++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++.-.<<<<--,<,";
            string Inputs = "asdefghtjidkoekldmwujfdjncnxoskhowkfndmnowkcxo";

            Interpreter_BF interpreter = new Interpreter_BF(BF_code, Inputs);
            interpreter.Interpret();

            string ActualOutput = interpreter.Outputs;
            string ExpectedOutput = "LK";

            Debug.WriteLine(ActualOutput);

            Assert.AreEqual(ExpectedOutput, ActualOutput, true);
        }

        [TestMethod]
        public void Print_HelloWorld_in_BF()
        {
            string BF_code = "++++++++++ [ > +++++++> ++++++++++> +++> +<<<< - ] > ++. > +. ++++++ +. . ++ +.  > ++.  << +++++++++++++++.  >.  ++ +.  ------.  --------.  > +.  >.";
            string Inputs = "";

            Interpreter_BF interpreter = new Interpreter_BF(BF_code, Inputs);
            interpreter.Interpret();

            string ActualOutput = interpreter.Outputs;
            string ExpectedOutput = "Hello World!\n";

            Debug.WriteLine(ActualOutput);

            Assert.AreEqual(ExpectedOutput, ActualOutput, true);
        }

        [TestMethod]
        public void Print_HelloWorld_in_BF_andIgnoreComments()
        {
            string BF_code = @"
                                ++++++++++
                                [
                                >+++++++>++++++++++>+++>+<<<<-
                                ]                       Na początek ustawiamy kilka przydatnych później wartości
                                >++.                    drukuje 'H'
                                > +.                    drukuje 'e'
                                ++++++ +.               drukuje 'l'
                                .                       drukuje 'l'
                                ++ +.                   drukuje 'o'
                                > ++.                   spacja
                                << +++++++++++++++.     drukuje 'W'
                                >.                      drukuje 'o'
                                ++ +.                   drukuje 'r'
                                ------.                 drukuje 'l'
                                --------.               drukuje 'd'
                                > +.                    drukuje '!'
                                >.  ";
            string Inputs = "";

            Interpreter_BF interpreter = new Interpreter_BF(BF_code, Inputs);
            interpreter.Interpret();

            string ActualOutput = interpreter.Outputs;
            string ExpectedOutput = "Hello World!\n";

            Debug.WriteLine(ActualOutput);

            Assert.AreEqual(ExpectedOutput, ActualOutput, true);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void NoInputProvidedWhenNeeded()
        {
            string BF_code = ">>++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++.-.<<<<--,<,";
            string Inputs = "";

            Interpreter_BF interpreter = new Interpreter_BF(BF_code, Inputs);
            interpreter.Interpret();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void MissingSomeInput()
        {
            string BF_code = ">>++>,>+++++,++,+++++++---++++.-.<<<<--,<,>>,<<,.";
            string Inputs = "abcde";

            Interpreter_BF interpreter = new Interpreter_BF(BF_code, Inputs);
            interpreter.Interpret();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void MissingClosingBracket()
        {
            string BF_code = "<<<[>>>>";
            string Inputs = "";

            Interpreter_BF interpreter = new Interpreter_BF(BF_code, Inputs);
            interpreter.Interpret();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MissingOpeningBracket()
        {
            string BF_code = ",>++++++[<-------->-],<+>-]<.";
            string Inputs = "35";

            Interpreter_BF interpreter = new Interpreter_BF(BF_code, Inputs);
            interpreter.Interpret();
        }


    }
}
