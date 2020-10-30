#include <bits/stdc++.h>

using namespace std;

string encrypt(string words) {
    words.erase(remove(words.begin(), words.end(), ' '), words.end());
    string newWords = "";
    int c = words.size();
    for (int j = 0, x = ceil(sqrt(c)); j < x; j++, newWords+= " ")
        for (int i = j; i < c; newWords+=words[i], i+=x){}
    return newWords;
}


int main() {
    string words;
    getline(cin, words);
    string result = encrypt(words);
    cout << result << "\n";
    return 0;
}