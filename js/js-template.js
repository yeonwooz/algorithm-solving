import fs from 'fs';

function getInputs() {
    const input = fs.readFileSync('./input.txt', 'utf-8');
    const lines = input.split('\r\n');
    const firstLine = lines.shift();

    let arr1 = [];
    let arr2 = [];

    const [n, m] = firstLine.split(' ').map(Number);
    const firstElements = lines.slice(0, n);
    const secondElements = lines.slice(n);

    const aMatrix = makeMatrix(n, m, firstElements);
    const bMatrix = makeMatrix(n, m, secondElements);
}

function makeMatrix(n, m, arr) {
    const matrix = [];
    for (let i = 0; i < n; i++) {
        const elements = arr[i].split(' ').map(Number);
        matrix.push(elements);
    }
    return matrix;
}

getInputs();
