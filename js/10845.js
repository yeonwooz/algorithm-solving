const readline = require('readline');

main();
async function main() {
    const inputs = await getInputs();
    const N = Number(inputs[0]);
    const cmds = inputs.slice(1);

    const answers = [];
    const arr = new Array(N);
    let headIdx = 0; // 꺼낼 위치
    let tailIdx = 0; // 넣을 위치

    for (let i = 0; i < N; i++) {
        const [cmd, num] = cmds[i];
        const isEmpty = headIdx === tailIdx;
        switch (cmd) {
            case 'push':
                arr[tailIdx] = num;
                tailIdx++;
                break;
            case 'pop':
                answers.push(isEmpty ? -1 : arr[headIdx++]);
                break;
            case 'size':
                answers.push(tailIdx - headIdx);
                break;
            case 'empty':
                answers.push(isEmpty ? 1 : 0);
                break;
            case 'front':
                answers.push(isEmpty ? -1 : arr[headIdx]);
                break;
            case 'back':
                answers.push(isEmpty ? -1 : arr[tailIdx - 1]);
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
