const readline = require('readline');
main();
async function main() {
    const inputs = await getInputs();
    const word = inputs[0];
    let isPal = true;
    const n = word.length;

    for (let i = 0; i <= Math.floor(n / 2); i++) {
        if (word[i] !== word[n - 1 - i]) {
            isPal = false;
            break;
        }
    }
    console.log(isPal ? 1 : 0);
}

async function getInputs() {
    return new Promise((resolve) => {
        const rl = readline.createInterface({ input: process.stdin });
        const arr = [];
        rl.on('line', (line) => {
            arr.push(line.trim());
        });
        rl.on('close', () => {
            resolve(arr);
        });
    });
}
