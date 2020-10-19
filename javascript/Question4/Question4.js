
function maximumExpectedMoney(tradesAvailable,tradesAllowed,probProfit,possibleProfit,possibleLoss) {

    // Complete the maximumExpectedMoney function below.
    return -1;
}



function processData(input) {

    var lines = input.split('\n');
    var tradesAvailable = parseInt(lines[0].split(' ')[0]);
    var tradesAllowed   = parseInt(lines[0].split(' ')[1]);

    var probProfit      = lines[1].split(' ').map(function(char){return parseFloat(char);});
    var possibleProfit  = lines[2].split(' ').map(function(char){return parseFloat(char);});
    var possibleLoss    = lines[3].split(' ').map(function(char){return parseFloat(char);});


    var answer = maximumExpectedMoney(tradesAvailable,tradesAllowed,probProfit,possibleProfit,possibleLoss);
    // Do not remove below line
    console.log(answer);
    // Do not print anything after this line
}

process.stdin.resume();
process.stdin.setEncoding("ascii");
_input = "";
process.stdin.on("data", function (input) {
    _input += input;
});

process.stdin.on("end", function () {
    processData(_input);
});