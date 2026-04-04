const readline = require('readline');

main();
async function main() {
    const inputs = await getInputs();
    const N = Number(inputs[0]);
    const cmds = inputs.slice(1);

    const arr = [];
    for (let i = 0; i < N; i++) {
        const [cmd, num] = cmds[i];
        switch (cmd) {
            case 'push':
                arr.push(num);
                break;
            case 'pop':
                if (arr.length === 0) {
                    console.log(-1);
                } else {
                    console.log(arr.pop(num));
                }
                break;
            case 'size':
                console.log(arr.length);
                break;
            case 'empty':
                const isEmpty = arr.length === 0;
                console.log(isEmpty ? 1 : 0);
                break;
            case 'top':
                const len = arr.length;
                console.log(len === 0 ? -1 : arr[len - 1]);
                break;
            default:
                continue;
        }
    }
}

async function getInputs() {
    return new Promise((resolve) => {
        const rl = readline.createInterface({ input: process.stdin });
        const lines = [];
        rl.on('line', (l) => {
            const input = l.trim().split(' ');
            lines.push(
                input.map((i) => {
                    const num = parseInt(i);
                    return isNaN(num) ? i : num;
                }),
            );
        });
        rl.on('close', () => {
            resolve(lines);
        });
    });
}
