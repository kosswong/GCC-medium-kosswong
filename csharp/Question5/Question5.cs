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
        static int CalculateMinimumSession(int numOfBankers, int numOfParticipants, int[][] bankersPreferencesArrOfArr, int[][] participantsPreferencesArrOfArr)
        {
            // Participant's code will go here
            return -1;
        }

        private static int[][] parsePreferences(String[] preferences)
        {
            return preferences.Select(preference =>
            {
                String[] preferenceArr = preference.Split("&");
                return Array.ConvertAll(preferenceArr, sTemp => int.Parse(sTemp));
            }).ToArray();
        }

        static void Main(string[] args)
        {
            // Sample input:
            // 3 1,1,1&2
            // 3 3&2,1,1

            String[] firstLine = Console.ReadLine().Split(" ");
            String[] secondLine = Console.ReadLine().Split(" ");

            int numOfBankers = int.Parse(firstLine[0]);
            int numOfParticipants = int.Parse(secondLine[0]);
            String[] bankersPreferences = firstLine[1].Split(",");
            String[] participantsPreferences = secondLine[1].Split(",");

            int[][] bankersPreferencesArrOfArr = parsePreferences(bankersPreferences);
            int[][] participantsPreferencesArrOfArr = parsePreferences(participantsPreferences);

            int result = CalculateMinimumSession(numOfBankers, numOfParticipants, bankersPreferencesArrOfArr, participantsPreferencesArrOfArr);

            // Please do not remove the below line.
            Console.WriteLine(result);
            // Do not print anything after this line
        }
    }
}