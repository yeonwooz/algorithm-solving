const readline = require('readline');

main();

async function main() {
    const n = await getInputs();
    console.log(solve(n));
}

function solve(n) {
    const dp = new Array(n + 1).fill(1);
    for (let i = 3; i <= n; i++) {
        dp[i] = dp[i - 1] + dp[i - 2];
    }

    return `${dp[n]} ${n - 2}`;
}

function getInputs() {
    return new Promise((resolve) => {
        const rl = readline.createInterface({ input: process.stdin });

        let n;
        rl.on('line', (l) => {
            n = Number(l.trim());
        });
        rl.on('close', () => {
            resolve(n);
        });
    });
}
