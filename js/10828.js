const readline = require('readline');

main();
async function main() {
    const inputs = await getInputs();
    const N = Number(inputs[0]);
    const cmds = inputs.slice(1);

    const answers = [];
    const arr = new Array(N);
    let topIdx = -1;
    for (let i = 0; i < N; i++) {
        const [cmd, num] = cmds[i];
        switch (cmd) {
            case 'push':
                topIdx++;
                arr[topIdx] = num;
                break;
            case 'pop':
                answers.push(topIdx === -1 ? -1 : arr[topIdx]);
                if (topIdx >= 0) {
                    topIdx--;
                } else {
                    topIdx = -1;
                }
                break;
            case 'size':
                answers.push(topIdx + 1);
                break;
            case 'empty':
                answers.push(topIdx === -1 ? 1 : 0);
                break;
            case 'top':
                answers.push(topIdx === -1 ? -1 : arr[topIdx]);
                break;
            default:
                continue;
        }
    }
    console.log(answers.join('\n'));
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
