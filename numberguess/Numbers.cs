using System;

namespace numberguess
{
    public class Numbers
    {
        public Numbers(int firstGen, int secondGen, int correctAnswer, string messages)
        {
            NumberOne = firstGen;
            NumberTwo = secondGen;
            CorrectAnswer = correctAnswer;
            Messages = messages;
        }

        public int NumberOne { get; set; }

        public int NumberTwo { get; set; }

        public int CorrectAnswer { get; set; }
        public string Messages { get; set; }
    }
}
