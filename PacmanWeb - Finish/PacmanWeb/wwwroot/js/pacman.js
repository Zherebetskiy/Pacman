


var canvas = document.getElementById("field");
canvas.style.visibility = "hidden";
var ctx = canvas.getContext("2d");   
var dx = canvas.width / 28;
var dy = canvas.height / 31;

var blinky = new Image();
var pinky = new Image();
var inky = new Image();
var clyde = new Image();
var fright = new Image();
var pacman = new Image();

pacman.src = '/images/pacman.png';
blinky.src = '/images/Blinky.png';
pinky.src = '/images/Pinky.png';
inky.src = '/images/Inky.png';
clyde.src = '/images/Clyde.png';
fright.src = '/images/Frightened.png';
    
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/pacmanHub")
    .build();

var Score;

connection.on("UpdatePosition", (mtr, score, lifes, points) => {
    Score = score;
    var s = document.getElementById("score").innerHTML = "Score : " + score;
    var l = document.getElementById("lifes").innerHTML = "Lifes : " + lifes;
    var p = document.getElementById("points").innerHTML = "Points : " + points;

    var matrix = JSON.parse(mtr);
    ctx.clearRect(0, 0, 700, 600); 

    for (var i = 0; i < 28; i++) {
        for (var j = 0; j < 31; j++) {
            if (matrix[j][i].$type === "PacmanLibrary.Ghosts.Clyde, PacmanLibrary") {
                if (matrix[j][i].behavior === 2) {
                    ctx.drawImage(fright, dx * i, dy * j, dx, dy);
                }
                else {
                    ctx.drawImage(clyde, dx * i, dy * j, dx, dy);
                }
                
            } else if (matrix[j][i].$type === "PacmanLibrary.Ghosts.Inky, PacmanLibrary") {
                if (matrix[j][i].behavior === 2) {
                    ctx.drawImage(fright, dx * i, dy * j, dx, dy);
                }
                else {
                    ctx.drawImage(inky, dx * i, dy * j, dx, dy);
                }
                
            } else if (matrix[j][i].$type === "PacmanLibrary.Ghosts.Pinky, PacmanLibrary") {
                if (matrix[j][i].behavior === 2) {
                    ctx.drawImage(fright, dx * i, dy * j, dx, dy);
                }
                else {
                    ctx.drawImage(pinky, dx * i, dy * j, dx, dy);
                }
                
            } else if (matrix[j][i].$type === "PacmanLibrary.Ghosts.Blinky, PacmanLibrary") {
                if (matrix[j][i].behavior === 2) {
                    ctx.drawImage(fright, dx * i, dy * j, dx, dy);
                }
                else {
                    ctx.drawImage(blinky, dx * i, dy * j, dx, dy);
                }
              
            }
            else if (matrix[j][i].$type === "PacmanLibrary.Pacman, PacmanLibrary") {
                ctx.drawImage(pacman, dx * i, dy * j, dx, dy);
            }
            else if (matrix[j][i].$type === "PacmanLibrary.Foods.EasyFood, PacmanLibrary") {
                ctx.beginPath();
                ctx.arc(dx * i + (dx / 2), dy * j + (dy / 2), 3, 0, 2 * Math.PI);
                ctx.fillStyle = 'yellow';
                ctx.fill();
            }
            else if (matrix[j][i].$type === "PacmanLibrary.Foods.SuperFood, PacmanLibrary") {
                ctx.beginPath();
                ctx.arc(dx * i + (dx / 2), dy * j + (dy / 2), 5, 0, 2 * Math.PI);
                ctx.fillStyle = 'yellow';
                ctx.fill();
            }
            else if (matrix[j][i].$type === "PacmanLibrary.EmptyBlock, PacmanLibrary") {
                ctx.rect(dx * i, dy * j, dx, dy);
            }
            else if (matrix[j][i].$type === "PacmanLibrary.Wall, PacmanLibrary") {
                ctx.fillStyle = "#0000ff";
                ctx.fillRect(dx * i, dy * j, dx, dy);
            }
        }
    }
});

connection.start().catch(err => console.error(err.toString()));

function ConnectToServer() {
    connection.invoke("Play").catch(err => console.error(err.toString()));
}

connection.on("GameEnded", function () {
    var path = "https://localhost:44360/Users/Create?score=" + Score;
    window.location.href = path;
});

var keepGoing = true;

function Pause() {
    document.getElementById("continue").style.visibility = "visible";
    keepGoing = false;
}

var tock = 200;

function Start() {
    canvas.style.visibility = "visible";
    keepGoing = true;

    setTimeout(function tick() {
        if (keepGoing) {
            ConnectToServer();
            timerId = setTimeout(tick, tock);
        }
            }, tock);   
}

function Continue() {
    keepGoing = true;
    Start();
}

function NewGame() {
    connection.invoke("NewGame").catch(err => console.error(err.toString()));
    keepGoing = true;
    var n = 3;
    var timeoutID = window.setInterval(function () {
        var element = document.getElementById("timer");
        element.innerHTML = "Are you ready? " + n;
        n--;
        if (n === 0) {
           
            window.clearTimeout(timeoutID);
            element.parentNode.removeChild(element);
            Start();
        }
    }, 1000);
}

document.onkeydown = function (evt) {
    evt = evt || window.event;
    connection.invoke("ChangeDirection", evt.key).catch(err => console.error(err.toString()));   
};

var arrow_keys_handler = function (e) {
    switch (e.keyCode) {
        case 37: case 39: case 38: case 40: 
        case 32: e.preventDefault(); break; 
        default: break;
    }
};
window.addEventListener("keydown", arrow_keys_handler, false);

function BeforeStart() {
    var n = 3;
    var timeoutID = window.setInterval(function () {
        var t = document.getElementById("timer").innerHTML = "Game Startet in " + n + " second";
        n--;
        if (n === 0) {
            window.clearTimeout(timeoutID);
            Start();
        }
    }, 1000);

  

  
}