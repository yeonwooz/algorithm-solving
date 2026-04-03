const readline = require('readline');

main();

async function main() {
    const inputs = await getInputs();
    const [a, b, c, d, e, f] = inputs[0];
    const [x, y] = solve(a, b, c, d, e, f);
    console.log(`${x} ${y}`);
}

function solve(a, b, c, d, e, f) {
    for (let x = -999; x <= 999; x++) {
        for (let y = -999; y <= 999; y++) {
            if (a * x + b * y === c && d * x + e * y === f) {
                return [x, y];
            }
        }
    }
}

function getInputs() {
    return new Promise((resolve) => {
        const rl = readline.createInterface({ input: process.stdin });

        const lines = [];
        rl.on('line', (line) => {
            lines.push(line.trim().split(' ').map(Number));
        });
        rl.on('close', () => {
            resolve(lines);
        });
    });
}
