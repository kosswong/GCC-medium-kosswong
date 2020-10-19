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
            // numOfBankers 2, 由1開始; numOfParticipants 3, 由1開始
            // How many room in 公司, 以最少numOfBankers/最少numOfParticipants為準
            int roomEachTime = (numOfBankers < numOfParticipants) ? numOfBankers : numOfParticipants;
            
            List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>();
            Dictionary<int, int> countRepect = new Dictionary<int, int>();
            
            // Add banker pair
            for(int i=0; i < numOfBankers; i++){
                foreach (int item in bankersPreferencesArrOfArr[i]){
                    if(!list.Contains(new KeyValuePair<int, int>(i, (numOfBankers-1+item)))){
                        list.Add(new KeyValuePair<int, int>(i, (numOfBankers-1+item)));
                    }
                    Console.WriteLine("Banker ID:"+i+" "+(numOfBankers-1+item));
                }
            }
            // Add pati pair
            for(int i=0; i < numOfParticipants; i++){
                foreach (int item in participantsPreferencesArrOfArr[i]){
                    if(!list.Contains(new KeyValuePair<int, int>((item-1), (numOfBankers+i))))
                        list.Add(new KeyValuePair<int, int>((item-1), (numOfBankers+i)));
                    Console.WriteLine("Pati ID:"+(numOfBankers+i)+" "+(item-1));
                }
            }
            
            // Count 
            foreach (KeyValuePair<int, int> kvp in list)
            {
                if(!countRepect.ContainsKey(kvp.Key)){
                    countRepect.Add(kvp.Key, 1);
                }else{
                    countRepect[kvp.Key]++;
                }
            }
            
            int countRR = countRepect.Values.Max() > countRepect.Keys.Max() ? countRepect.Values.Max() : countRepect.Keys.Max();
            
            return countRR;
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