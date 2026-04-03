const readline = require('readline');

main();
async function main() {
    const inputs = await getInputs();
    const [N, M] = inputs[0];
    const swapTargets = inputs.slice(1);
    const arr = solve(N, M, swapTargets);
    console.log(arr.join(' '));
}

function solve(N, M, swapTargets) {
    const arr = new Array(N).fill(0).map((_, i) => i + 1);
    for (let idx = 0; idx < M; idx++) {
        const [i, j] = swapTargets[idx];
        const temp = arr[i - 1];
        arr[i - 1] = arr[j - 1];
        arr[j - 1] = temp;
    }
    return arr;
}

async function getInputs() {
    return new Promise((resolve) => {
        const rl = readline.createInterface({ input: process.stdin });

        const arr = [];
        rl.on('line', (line) => {
            arr.push(line.split(' ').map(Number));
        });
        rl.on('close', () => {
            resolve(arr);
        });
    });
}
