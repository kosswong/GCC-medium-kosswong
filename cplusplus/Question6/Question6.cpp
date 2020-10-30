#include <bits/stdc++.h>

using namespace std;

void swap(int *r, int *s)
{
   int temp = *r;
   *r = *s;
   *s = temp;
   return;
}

string encrypt(string words) {
    words.erase(remove(words.begin(), words.end(), ' '), words.end());
    string newWords = "";
    int c = words.size();
    int x = ceil(sqrt(c));
    int spaceToFill = x*x-c;
    
    for (int i = 0; i < spaceToFill; i++){
        words += ' ';
    }
    
    int perviousLast = 0;
    for (int i = 1; i < x; i++){
        for(int j = 1; j <= x-i; j++){
            swap(words[i+j+x*perviousLast-1], words[i+j+x*perviousLast+j*(x-1)-1]);
        }
        perviousLast++;
    }
    
    for (int i = 1; i <= x-spaceToFill; i++){
        words.insert(i*x+i-1, " "); 
    }
    
    return words;
}


int main() {
    string words;
    getline(cin, words);
    string result = encrypt(words);
    cout << result << "\n";
    return 0;
}