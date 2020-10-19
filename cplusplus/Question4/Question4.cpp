#include<bits/stdc++.h>
using namespace std;
double maximumExpectedMoney(int n, int m, double p[], double x[], double y[] )
{
    //Complete the maximumExpectedMoney function.
    return -1.0;

}


int main(){
    int n, m;

    cin >> n >> m;
    double p[n], x[n], y[n];

    for(int i = 0; i < n; i++)
        cin >> p[i];
    for(int i = 0; i < n; i++)
        cin >> x[i];
    for(int i = 0; i < n; i++)
        cin >> y[i];

    double result=maximumExpectedMoney(n,m,p,x,y);

    // Do not remove below line
    cout << result << endl;
    // Do not print anything after this line

    return 0;
}