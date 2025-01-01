using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceIntroTerje
{
    internal class SingleAnswerQuestion : IQuestion
    {
        private readonly string _question;
        private readonly string _correctAnswer;

        public SingleAnswerQuestion(string question, string correctAnswer)
        {
            _question = question;
            _correctAnswer = correctAnswer;
        }

        public bool Run()
        {
            Console.WriteLine(_question + " ");
            var answer = Console.ReadLine();
            return answer == _correctAnswer;
        }
    }
}
