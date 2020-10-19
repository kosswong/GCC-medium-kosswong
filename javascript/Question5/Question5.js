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

// You may change this function parameters
function calculateMinimumSession(numOfBankers, numOfParticipants, bankersPreferences, participantsPreferences){
    // Participant's code
    return -1;
}

function parsePreferences(preferences){
    const preferenceArrOfArr = preferences.map(preference => {
        const preferenceArr = preference.split("&");
        const preferenceIntArr = preferenceArr.map(x => parseInt(x, 10));
        return preferenceIntArr;
    });

    return preferenceArrOfArr;
}

function main() {
    const firstLine = readLine().split(" ");
    const secondLine = readLine().split(" ");
    // Sample input:
    // 3 1,1,1&2
    // 3 3&2,1,1

    const numOfBankers = parseInt(firstLine[0], 10)
    const numOfParticipants = parseInt(secondLine[0], 10)

    const bankersPreferences = firstLine[1].split(",")
    const participantsPreferences = secondLine[1].split(",")

    const bankersPreferencesArrOfArr = parsePreferences(bankersPreferences)
    const participantsPreferencesArrOfArr = parsePreferences(participantsPreferences)

    const result = calculateMinimumSession(numOfBankers, numOfParticipants, bankersPreferencesArrOfArr, participantsPreferencesArrOfArr);

    // Please do not remove the below line.
    console.log(result)
    // Do not print anything after this line
}