#include<bits/stdc++.h>

using namespace std;

double maximumExpectedMoney(int n, int k, double p[], double x[], double y[] )
{
    vector<double> test;
    for(int i = 0; i < n;test.push_back(((p[i]*x[i]-(1-p[i])*y[i]) > 0) ? (p[i]*x[i]-(1-p[i])*y[i]) : 0), i++){}
    std::priority_queue<std::pair<double, int>> q;
    for (int i = 0; i < test.size(); q.push(std::pair<double, int>(test[i], i)), ++i){}
    p[0] = 0;
    for (int i = 0; i < k; ++i) {
        double ki = q.top().first;
        p[0]+=ki;
        q.pop();
    }
    return p[0];
}


int main(){
    int n, m;
    cin >> n >> m;
    double p[n], x[n], y[n];
    for(int i = 0; i < n; i++) cin >> p[i];
    for(int i = 0; i < n; i++) cin >> x[i];
    for(int i = 0; i < n; i++) cin >> y[i];
    cout << fixed << setprecision(2) << maximumExpectedMoney(n,m,p,x,y) << endl;
    return 0;
}