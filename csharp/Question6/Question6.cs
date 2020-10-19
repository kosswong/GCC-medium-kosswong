using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace Solution
{
    class Solution
    {

        // You may change this function parameters
        static String Encrypt(String words)
        {
            // Participant's code will go here
            words = String.Concat(words.Where(c => !Char.IsWhiteSpace(c)));
            String newWords = "";
            int count = words.Length;
            int sq = (int) Math.Ceiling(Math.Sqrt(count));
            for (int j = 0; j < sq; j++){
                for (int i = j; i < words.Length; i+=sq){
                    newWords = newWords + words[i];
                }
                newWords = newWords + " ";
            }
            return newWords;
        }

        static void Main(string[] args)
        {
            String words = Console.ReadLine();

            String result = Encrypt(words);

            // Please do not remove the below line.
            Console.WriteLine(result);
            // Do not print anything after this line
        }
    }
}
