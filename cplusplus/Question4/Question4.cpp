#include<bits/stdc++.h>

using namespace std;

double maximumExpectedMoney(int n, int k, double p[], double x[], double y[] )
{
    double sum = 0;
    vector<double> test;
    for(int i = 0; i < n;i++){
        if(isless(p[i],0.00)) p[i] = 0;
        if(isgreater(p[i],1.00)) p[i] = 1;
        if(isless(x[i],0.00)) x[i] = 0;
        if(isless(y[i],0.00)) y[i] = 0;
        if(isgreater(x[i],100.00)) x[i] = 100;
        if(isgreater(y[i],100.00)) y[i] = 100;
        if((p[i]*x[i]-(1-p[i])*y[i]) > 0){
            test.push_back(p[i]*x[i]-(1-p[i])*y[i]);
        }else{
            test.push_back(0);
        }
    }
    std::priority_queue<std::pair<double, int>> q;
    for (int i = 0; i < test.size(); ++i) {
        q.push(std::pair<double, int>(test[i], i));
    }
    for (int i = 0; i < k; ++i) {
        double ki = q.top().first;
        sum+=ki;
        q.pop();
    }
    return sum;

}


int main(){
    int n, m;

    cin >> n >> m;
    double p[n], x[n], y[n];
    if(m < 0) m = 1;
    if(n < 0) n = 1;
    if(m > 100000) m = 100000;
    if(n > 100000) n = 100000;
    if(m > n) m = n;
    
    for(int i = 0; i < n; i++)
        cin >> p[i];
    for(int i = 0; i < n; i++)
        cin >> x[i];
    for(int i = 0; i < n; i++)
        cin >> y[i];

    double result=maximumExpectedMoney(n,m,p,x,y);

    // Do not remove below line
    cout << fixed << setprecision(2) << result << endl;
    // Do not print anything after this line

    return 0;
}