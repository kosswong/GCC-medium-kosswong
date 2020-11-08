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

        static int CalculateMinimumSession(int numOfSmallers, int numOfBigger, int[][] smallerPreferencesArrOfArr, int[][] biggerPreferencesArrOfArr)
        {

            int repectTime = 0;
            bool empty = false;
            Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
            List<int> on9smaller = new List<int>();
            List<int> on9bigger = new List<int>();
            
            for(int i=1; i <= numOfSmallers; i++){
                int noton9 = 0;
                dictionary.Add(i, new List<int>());
                foreach (int item in smallerPreferencesArrOfArr[i-1]){
                    if (item > 0 && item <= numOfBigger && !dictionary[i].Contains(item)){
                        noton9++;
                        dictionary[i].Add(item);
                        Console.WriteLine("Prof: "+i+" Student: "+item);
                    }
                }
                if(noton9 == 0){
                    on9smaller.Add(i);
                }
            }
            
            for(int i=1; i <= numOfBigger; i++){
                int noton9 = 0;
                foreach (int item in biggerPreferencesArrOfArr[i-1]){
                    if (item > 0 && item <= numOfSmallers){
                        noton9++;
                        if(!dictionary[item].Contains(i)){
                            dictionary[item].Add(i);
                            Console.WriteLine("Prof: "+item+" Student: "+i);
                            on9smaller.Remove(item);
                        }
                    }
                }
                if(noton9 == 0){
                    on9bigger.Add(i);
                }
            }
            
            if(on9bigger.Count > on9smaller.Count){
                for(int i = 0; i < on9smaller.Count;i++){
                    dictionary[on9smaller[i]].Add(on9bigger[i]);
                    on9bigger.Remove(on9bigger[i]);
                    on9smaller.Remove(on9smaller[i]);
                }
            }else{
                for(int i = 0; i < on9bigger.Count;i++){
                    dictionary[on9smaller[i]].Add(on9bigger[i]);
                    on9bigger.Remove(on9bigger[i]);
                    on9smaller.Remove(on9smaller[i]);
                }
            }
            
            while(!empty){
                for(int i = 1; i <= numOfSmallers; i++){
                    if(dictionary[i].Any()){
                        dictionary[i].RemoveAt(0);
                    }else{
                        if(on9bigger.Any()){
                            on9bigger.RemoveAt(0);
                        }
                    }
                }
                repectTime++;
                
                empty = true;
                for(int i=1; i <= numOfSmallers; i++){
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

            int result;
            if(numOfBankers>numOfParticipants){
                result = CalculateMinimumSession(numOfParticipants, numOfBankers, participantsPreferencesArrOfArr, bankersPreferencesArrOfArr);
            }else{
                result = CalculateMinimumSession(numOfBankers, numOfParticipants, bankersPreferencesArrOfArr, participantsPreferencesArrOfArr);
            }

            // Please do not remove the below line.
            Console.WriteLine(result);
            // Do not print anything after this line
        }
    }
}