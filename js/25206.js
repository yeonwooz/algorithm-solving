const readline = require('readline');

main();

async function main() {
    const reports = await getInputs();
    const values = Object.values(reports);
    const totalVolume = values.reduce((acc, cur) => acc + cur[0], 0);
    const totalScore = values.reduce((acc, cur) => acc + cur[0] * cur[1], 0);
    console.log((totalScore / totalVolume).toFixed(6));
}

function getInputs() {
    return new Promise((resolve) => {
        const rl = readline.createInterface({ input: process.stdin });

        const gradeTable = {
            'A+': 4.5,
            A0: 4.0,
            'B+': 3.5,
            B0: 3.0,
            'C+': 2.5,
            C0: 2.0,
            'D+': 1.5,
            D0: 1.0,
            F: 0.0,
        };

        const report = {};
        rl.on('line', (line) => {
            const [course, volume, grade] = line.trim().split(' ');
            if (grade !== 'P') {
                const score = gradeTable[grade];
                report[course] = [Number(volume), score];
            }
        });
        rl.on('close', () => {
            resolve(report);
        });
    });
}
