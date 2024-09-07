const canvas = document.getElementById('gameCanvas');
const ctx = canvas.getContext('2d');

const dinoImage = new Image();
dinoImage.src = '/images/dino.png';

const cactusImage = new Image();
cactusImage.src = '/images/cactus.png';

const dino = { x: 50, y: 150, width: 30, height: 30, dy: 0, gravity: 0.8, jumpPower: -15 };
const obstacles = [];
let score = 0;
let highScore = localStorage.getItem('highScore') || 0;
let gameOver = false;
const obstacleSpeed = 5; // Скорость препятствий

document.addEventListener('keydown', e => {
    if (e.key === ' ') jump();
});

function jump() {
    if (dino.y === 150) {
        dino.dy = dino.jumpPower;
    }
}

function createObstacle() {
    if (canvas.width - (obstacles.length > 0 ? obstacles[obstacles.length - 1].x : 0) > 300) {
        obstacles.push({ x: canvas.width, y: 150, width: 30, height: 30 });
    }
}

function update() {
    if (gameOver) return;

    dino.dy += dino.gravity;
    dino.y += dino.dy;

    if (dino.y > 150) {
        dino.y = 150;
        dino.dy = 0;
    }

    obstacles.forEach((obstacle, index) => {
        obstacle.x -= obstacleSpeed;

        if (obstacle.x + obstacle.width < 0) {
            obstacles.splice(index, 1);
            score++;
        } else if (checkCollision(dino, obstacle)) {
            gameOver = true;
            submitScore();
        }
    });

    if (Math.random() < 0.02) createObstacle();
    draw();
}

function checkCollision(dino, obstacle) {
    return (
        dino.x < obstacle.x + obstacle.width &&
        dino.x + dino.width > obstacle.x &&
        dino.y < obstacle.y + obstacle.height &&
        dino.y + dino.height > obstacle.y
    );
}

function draw() {
    ctx.clearRect(0, 0, canvas.width, canvas.height);

    ctx.drawImage(dinoImage, dino.x, dino.y, dino.width, dino.height);

    obstacles.forEach(obstacle => {
        ctx.drawImage(cactusImage, obstacle.x, obstacle.y, obstacle.width, obstacle.height);
    });

    ctx.font = '16px Arial';
    ctx.fillText(`Score: ${score}`, 700, 50);
    ctx.fillText(`High Score: ${highScore}`, 700, 80);

    if (gameOver) {
        document.getElementById('gameOverMessage').style.display = 'block';
        document.getElementById('restartButton').style.display = 'block';
    }
}

function submitScore() {
    fetch('/api/scores', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ score })
    }).then(() => {
        if (score > highScore) {
            highScore = score;
            localStorage.setItem('highScore', highScore);
        }
    });
}

function restartGame() {
    dino.y = 150;
    dino.dy = 0;
    obstacles.length = 0;
    score = 0;
    gameOver = false;
    document.getElementById('gameOverMessage').style.display = 'none';
    document.getElementById('restartButton').style.display = 'none';
}

setInterval(update, 1000 / 60);

document.getElementById('restartButton').addEventListener('click', restartGame);
