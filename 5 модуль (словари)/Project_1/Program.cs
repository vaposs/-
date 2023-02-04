﻿using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security;

namespace Project_1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const string Add = "add";
            const string PrintAll = "printall";
            const string PrintWord = "printone";
            const string Exit = "exit";

            string command;
            bool isExitProgram = false;
            Dictionary<string, string> glossary = new Dictionary<string, string>();

            while (!isExitProgram)
            {
                Console.WriteLine("\nвыбирите действие:");
                Console.WriteLine($"1.{Add}");
                Console.WriteLine($"2.{PrintWord}");
                Console.WriteLine($"3.{PrintAll}");
                Console.WriteLine($"4.{Exit}");
                Console.Write("Введите команду - ");
                command = Console.ReadLine();
                
                switch (command.ToLower())
                {
                    case Add:
                        AddWord(glossary);
                        break;

                    case PrintWord:
                        PrintOneWord(glossary);
                        break;

                    case PrintAll:
                        PrintDictionary(glossary);
                        break;

                    case Exit:
                        isExitProgram = true;
                        break;
                }
            }
        }

        static string TakeWord()
        {
            string templWord;

            Console.Write("Введите слово - ");
            templWord = Console.ReadLine();

            return templWord;
        }

        static void AddWord(Dictionary<string, string> glossary)
        {
            string word = TakeWord();
            bool repeat = FindWord(glossary, word);

            if (repeat)
            {
                Console.Write("\nПовтор, такое слово уже есть.");
            }
            else
            {
                Console.Write("Введите значение слова - ");
                glossary.Add(word, Console.ReadLine());
            }
        }

        static bool FindWord(Dictionary<string,string> glossary, string word)
        {
            bool repeat = false;

            foreach (var item in glossary)
            {
                if (item.Key == word)
                {
                    repeat = true;
                }
            }
            return repeat;
        }

        static void PrintDictionary(Dictionary<string,string> glossary)
        {
            foreach (var item in glossary)
            {
                Console.WriteLine($"слово {item.Key} означает {item.Value}");
            }
            Console.Write("\n");
        }

        static void PrintOneWord(Dictionary<string, string> glossary)
        {
            string word;

            if(glossary.Count == 0)
            {
                Console.WriteLine("Словарь пустой");
            }
            else
            {
                word = TakeWord();

                if (glossary.ContainsKey(word))
                {
                    Console.WriteLine($"слово {word} означает {glossary[word]}");
                }
                else
                {
                    Console.WriteLine("Такого слова нету в словаре.");
                }
            }
        }
    }
}