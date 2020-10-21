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
            // Reassign ID, id of newNumOfParticipants+=numOfBankers
            // 0 Banker 1
            // 1 Banker 2
            // 2 Banker 3
            // 3 Pati 1
            
            List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>();
            Dictionary<int, int> countRepect = new Dictionary<int, int>();
            
            // Add banker pair
            for(int bankerID=1; bankerID <= numOfBankers; bankerID++){
                foreach (int patiID in bankersPreferencesArrOfArr[bankerID-1]){
                    if(patiID > 0 && patiID <= numOfParticipants){
                        if(!list.Contains(new KeyValuePair<int, int>(bankerID, patiID))){
                            list.Add(new KeyValuePair<int, int>(bankerID, patiID));
                            Console.WriteLine("Banker ID:"+bankerID+" "+patiID);
                        }
                    }
                }
            }
            // Add pati pair
            for(int patiID=1; patiID <= numOfParticipants; patiID++){
                foreach (int bankerID in participantsPreferencesArrOfArr[patiID-1]){
                    if(bankerID > 0 && bankerID <= numOfBankers){
                        if(!list.Contains(new KeyValuePair<int, int>(bankerID, patiID))){
                            list.Add(new KeyValuePair<int, int>(bankerID, patiID));
                        }
                        Console.WriteLine("Pati ID:"+patiID+" "+bankerID);
                    }
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
            
            return countRepect.Values.Max() > countRepect.Keys.Max() ? countRepect.Values.Max() : countRepect.Keys.Max();
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