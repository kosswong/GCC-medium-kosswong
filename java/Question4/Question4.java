import java.io.*;
import java.util.*;
import java.util.stream.Stream;

class Solution {

    // You may change this function parameters
    public static double maximumExpectedMoney(int n, int m, double[] p, double[] x, double[] y)  {
        // Participant's code will go here
        return -1;
    }

    private static final Scanner scanner = new Scanner(System.in);

    public static void main(String[] args) throws IOException  {
        Scanner in = new Scanner(System.in);

        int n = in.nextInt();
        int m = in.nextInt();

        double[] p = new double[n];
        double[] x = new double[n];
        double[] y = new double[n];
        double result = 0;

        //get input
        for(int i = 0; i < n; i++)
            p[i] = in.nextDouble();
        for(int i = 0; i < n; i++)
            x[i] = in.nextDouble();
        for(int i = 0; i < n; i++)
            y[i] = in.nextDouble();

        result = maximumExpectedMoney(n,m,p,x,y);

        // Do not remove below line
        System.out.println(result);
        // Do not print anything after this line

        in.close();
    }
}