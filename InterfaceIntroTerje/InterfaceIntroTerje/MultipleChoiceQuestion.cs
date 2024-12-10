using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceIntroTerje
{
    internal class MultipleChoiceQuestion : IQuestion
    {
        private readonly string _question;
        private readonly string[] _answers;
        private readonly int _correctAnswerNo;

        public MultipleChoiceQuestion(string question, int correctAnswerNo,params string[] answers)
        {
            _question = question;
            _answers = answers;
            _correctAnswerNo = correctAnswerNo;
        }
        public bool Run()
        {
            Console.WriteLine(_question);
            Console.WriteLine("Svaralternativer:");
            for (int i = 0; i < _answers.Length; i++)
            {
                Console.WriteLine($"{i+1}: {_answers[i]}");
            }

            Console.WriteLine("Velg svaralternativ: ");
            var selectedAnswer = Convert.ToInt32(Console.ReadLine());
            return selectedAnswer == _correctAnswerNo;
        }
    }
}
