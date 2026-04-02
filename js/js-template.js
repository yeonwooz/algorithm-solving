const readline = require('readline');

main();

async function main() {
    const inputs = await getInputs();
    console.log(inputs);
}

function getInputs() {
    return new Promise((resolve) => {
        const rl = readline.createInterface({ input: process.stdin });

        const lines = [];
        rl.on('line', (line) => {
            lines.push(line);
        });
        rl.on('close', () => {
            resolve(lines);
        });
    });
}
