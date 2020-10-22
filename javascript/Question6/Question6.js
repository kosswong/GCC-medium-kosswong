'use strict';

const fs = require('fs');

process.stdin.resume();
process.stdin.setEncoding('utf-8');

let inputString = '';
let currentLine = 0;

process.stdin.on('data', inputStdin => {
    inputString += inputStdin;
});

process.stdin.on('end', function() {
    inputString = inputString.replace(/\s*$/, '')
        .split('\n')
        .map(str => str.replace(/\s*$/, ''));

    main();
});

function readLine() {
    return inputString[currentLine++];
}

function encrypt(words){
    // Participant's code
    let str = words.replace(/\s+/g, '');
    let newWords = "";
    let count = str.length;
    let sq = Math.ceil(Math.sqrt(count));
    for (let j = 0; j < sq; j++){
        for (let i = j; i < count; i+=sq){
            newWords = newWords + str.charAt(i);
        }
        newWords = newWords + " ";
    }
    return newWords;
}

function main() {
    const words = readLine();

    const result = encrypt(words);

    // Please do not remove the below line.
    console.log(result)
    // Do not print anything after this line
}