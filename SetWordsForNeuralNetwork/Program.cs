﻿using SchoolChatGPT_v1._0.NeuralNetworkClasses;
using System;
using System.Collections.Generic;

namespace SetWordsForNeuralNetwork
{
    public class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите число:\n0 - ввести новые слова\n1 - ввести новые предложения для обучения нейросети");
                    int num = int.Parse(Console.ReadLine());
                    if (num != 0 || num != 1) { ElseError(); }
                    if (num == 0)
                    { SetWords(); break; }
                    if (num == 1)
                    { SetSentences(); break; }
                }
                catch
                {
                    ElseError();
                }
            }
        }

        private static void ElseError()
        {
            Console.WriteLine("Введити целое ЧИСЛО 1 ИЛИ 0");
        }

        private static void SetWords()
        {
            Console.WriteLine("Введите слова:");
            Words words = new Words();
            words.SetWords(Console.ReadLine());
        }

        private static void SetSentences()
        {
           
            Console.WriteLine("Введите предложения и выходной результат в виде: предложение$1 или 0,:");
            string input = Console.ReadLine();
            Sentences sentences = new Sentences();
            sentences.SetSentences(input);
            
        }
    }
}