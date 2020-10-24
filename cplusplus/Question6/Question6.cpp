#include <bits/stdc++.h>

using namespace std;

string encrypt(string words) {
    words.erase(remove(words.begin(), words.end(), ' '), words.end());
    string newWords = "";
    int c = words.size();
    int x = ceil(sqrt(c));
    for (int j = 0; j < x; j++, newWords+= " ")
        for (int i = j; i < c; i+=x)
            newWords += words[i];
    return newWords;
}


int main() {
    string words;
    getline(cin, words);
    string result = encrypt(words);
    cout << result << "\n";
    return 0;
}