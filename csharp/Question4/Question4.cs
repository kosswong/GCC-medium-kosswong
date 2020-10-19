using System;
using System.Collections.Generic;
using System.IO;

class Solution
{

    public static double maximumExpectedMoney(int n, int m, double[] p, double[] x, double[] y)
    {
        //Participants will add code here
        return -1;
    }


    static void Main(String[] args)
    {
        //Reading Input
        string[] str = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(str[0]);
        int m = Convert.ToInt32(str[1]);
        double[] p = new double[n];
        double[] x = new double[n];
        double[] y = new double[n];
        string[] s1 = Console.ReadLine().Split(' ');
        p = Array.ConvertAll(s1, Double.Parse);
        string[] s2 = Console.ReadLine().Split(' ');
        x = Array.ConvertAll(s2, Double.Parse);
        string[] s3 = Console.ReadLine().Split(' ');
        y = Array.ConvertAll(s3, Double.Parse);

        double result = maximumExpectedMoney(n,m,p,x,y);
        
        // Do not remove below line
        Console.WriteLine(result);
        // Do not print anything after this line
    }
}