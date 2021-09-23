const statusDisplay = document.querySelector('.game--status');
const currentPlayerTurn = () => `It's ${currentPlayer}'s turn`;
const drawMessage = () => `Game ended in a draw!`;
const winningMessage = () => `Player ${currentPlayer} has won!`;

function handleCellPlayed(clickedCell, clickedCellIndex) {
    boardState[clickedCellIndex] = currentPlayer;
    clickedCell.innerHTML = currentPlayer;
}

function handlePlayerChange() {
    currentPlayer = currentPlayer === "X" ? "O" : "X";
    statusDisplay.innerHTML = currentPlayerTurn();
}

function handleResultValidation(cellIndex) {
    const winLines = [
        [[1, 2], [4, 8], [3, 6]],
        [[0, 2], [4, 7]],
        [[0, 1], [4, 6], [5, 8]],
        [[4, 5], [0, 6]],
        [[3, 5], [0, 8], [2, 6], [1, 7]],
        [[3, 4], [2, 8]],
        [[7, 8], [2, 4], [0, 3]],
        [[6, 8], [1, 4]],
        [[6, 7], [0, 4], [2, 5]]];

    for (let i = 0; i < winLines[cellIndex].length; i++) {
        let line = winLines[cellIndex][i];

        if (currentPlayer === boardState[line[0]] && currentPlayer === boardState[line[1]]) {
            statusDisplay.innerHTML = winningMessage();
            isGameActive = false;
            return;
        }
    }

    if (!boardState.includes("")) {
        statusDisplay.innerHTML = drawMessage();
        isGameActive = false;
        return;
    }

    handlePlayerChange();
}

function handleCellClick(clickedCellEvent) {
    const clickedCell = clickedCellEvent.target;
    const clickedCellIndex = parseInt(clickedCell.getAttribute('data-cell-index'));

    if (boardState[clickedCellIndex] !== "" || !isGameActive) {
        return;
    }

    handleCellPlayed(clickedCell, clickedCellIndex);
    handleResultValidation(clickedCellIndex);
}

function handleStartNewGame() {
    isGameActive = true;
    currentPlayer = "X";
    boardState = new Array(9).fill("");
    statusDisplay.innerHTML = currentPlayerTurn();
    document.querySelectorAll('.cell').forEach(cell => cell.innerHTML = "");
}

document.querySelectorAll('.cell').forEach(cell => cell.addEventListener('click', handleCellClick));
document.querySelector('.game--restart').addEventListener('click', handleStartNewGame);
handleStartNewGame();