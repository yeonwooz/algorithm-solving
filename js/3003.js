const readline = require('readline');

main();
async function main() {
    const inputs = await getInputs();
    const arr = inputs[0];
    const expected = [1, 1, 2, 2, 2, 8];
    const answer = expected.map((e, i) => e - arr[i]);
    console.log(answer.join(' '));
}

async function getInputs() {
    return new Promise((resolve) => {
        const rl = readline.createInterface({ input: process.stdin });
        const arr = [];
        rl.on('line', (line) => {
            arr.push(line.trim().split(' ').map(Number));
        });
        rl.on('close', () => {
            resolve(arr);
        });
    });
}
