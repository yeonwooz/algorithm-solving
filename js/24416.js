const readline = require('readline');

main();

async function main() {
    const n = await getInputs();
    console.log(solve(n));
}

function solve(n) {
    let count1 = 0;
    let count2 = 0;

    function fib(n) {
        if (n === 1 || n === 2) {
            count1++;
            return 1;
        }
        return fib(n - 1) + fib(n - 2);
    }

    function fibonacci(n) {
        const dp = new Array(n + 1).fill(1);
        for (let i = 3; i <= n; i++) {
            count2++;
            dp[i] = dp[i - 1] + dp[i - 2];
        }
        return dp[n];
    }

    fib(n);
    fibonacci(n);

    return `${count1} ${count2}`;
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
