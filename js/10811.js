const readline = require('readline');
main();
async function main() {
    const inputs = await getInputs();
    const [N, M] = inputs[0];
    const targets = inputs.slice(1);
    const arr = solve(N, M, targets);
    console.log(arr.join(' '));
}

function solve(N, M, targets) {
    const arr = new Array(N).fill(0).map((_, i) => i + 1);
    for (let idx = 0; idx < M; idx++) {
        const [i, j] = targets[idx];
        for (let k = 0; k < Math.floor((j - i + 1) / 2); k++) {
            [arr[i - 1 + k], arr[j - 1 - k]] = [arr[j - 1 - k], arr[i - 1 + k]];
        }
    }
    return arr;
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
