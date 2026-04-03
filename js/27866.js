const readline = require('readline');

main();
async function main() {
    const inputs = await getInputs();
    const [word, i] = inputs;
    console.log(word[Number(i) - 1]);
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
