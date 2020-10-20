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

        static int CalculateMinimumSession(int numOfBankers, int numOfParticipants, int[][] bankersPreferencesArrOfArr, int[][] participantsPreferencesArrOfArr)
        {
            
            Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
            
            for(int i=0; i < numOfBankers; i++){
                foreach (int item in bankersPreferencesArrOfArr[i]){
                    if (!dictionary.ContainsKey(i))
                        dictionary.Add(i, new List<int>());
                    if (!dictionary[i].Contains((numOfBankers-1+item)))
                    dictionary[i].Add((numOfBankers-1+item));
                }
            }
            
            for(int i=0; i < numOfParticipants; i++){
                foreach (int item in participantsPreferencesArrOfArr[i]){
                    if (!dictionary.ContainsKey((item-1)))
                        dictionary.Add((item-1), new List<int>());
                    if (!dictionary[(item-1)].Contains((numOfBankers+i)))
                    dictionary[(item-1)].Add((numOfBankers+i));
                }
            }
            
            // Start meeting
            int repectTime = 0;
            bool empty = false;
            
            while(!empty){
                List<int> currentTeamPairedStudent = new List<int>();
                for(int i=0; i < numOfBankers; i++){
                    foreach (int item in dictionary[i]){
                        if (!currentTeamPairedStudent.Contains(item)){
                            currentTeamPairedStudent.Add(item);
                            dictionary[i].Remove(item);
                            break;
                        }
                    }
                }
                repectTime++;
                empty = true;
                for(int i=0; i < numOfBankers; i++){
                    if(dictionary[i].Any()) empty = false;
                }
            }
            return repectTime;
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