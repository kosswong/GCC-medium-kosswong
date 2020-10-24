#include<bits/stdc++.h>
using namespace std;

void swap(float* a, float* b)  
{  
    float t = *a;  
    *a = *b;  
    *b = t;  
}  
  
int partition (float arr[], int low, int high)  
{  
    float pivot = arr[high];
    int i = (low - 1);
  
    for (int j = low; j <= high - 1; j++)  
    {  
        if (isless(arr[j],pivot))  
        {  
            i++; 
            swap(&arr[i], &arr[j]);  
        }  
    }
    swap(&arr[i + 1], &arr[high]);  
    return (i + 1);  
}  
  
void quickSort(float arr[], int low, int high)  
{  
    if (low < high)  
    {  
        int pi = partition(arr, low, high);  
        quickSort(arr, low, pi - 1);  
        quickSort(arr, pi + 1, high);
    }  
}  

double maximumExpectedMoney(int n, int m, float p[], float x[], float y[] )
{
    if(n < 2) n = 1;
    if(n > 100000) n = 100000;
    if(m < 2) m = 1;
    if(m > 100000) m = 100000;
    float outcome = 0;
    float store[n];
    
    for(int i = 0; i < n; i++){
        if(isless(p[i],0.00)) p[i] = 0;
        if(isgreater(p[i],1.00)) p[i] = 1;
        if(isless(x[i],0.00)) x[i] = 0;
        if(isless(y[i],0.00)) y[i] = 0;
        if(isgreater(x[i],100.00)) x[i] = 100;
        if(isgreater(y[i],100.00)) y[i] = 100;
        store[i] = p[i]*x[i]-(1-p[i])*y[i];
    }
    quickSort(store, 0, n - 1);
    for (int i = n-1; i > n-1-m; i--)
        if(isgreaterequal(outcome + store[i], outcome))
            outcome += store[i];
    return outcome;
}

int main(){
    int n, m;

    cin >> n >> m;
    float p[n], x[n], y[n];

    for(int i = 0; i < n; i++)
        cin >> p[i];
    for(int i = 0; i < n; i++)
        cin >> x[i];
    for(int i = 0; i < n; i++)
        cin >> y[i];

    float result=maximumExpectedMoney(n,m,p,x,y);=
    cout << fixed << setprecision(2) << result << endl;
    // Do not print anything after this line

    return 0;
}