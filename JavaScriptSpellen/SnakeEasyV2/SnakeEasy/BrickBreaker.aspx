﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BrickBreaker.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <html>

<head>
  <meta charset="UTF-8">
  <title>Brick Game</title>

  <style type="text/css">
    body {
      background-color: black;
    }
    canvas {
      border: 1px solid green;
    }
  </style>

</head>

<body>


  <canvas id="game-canvas" height="600px" width="800px" </canvas>

    <script type="text/javascript">
        var canvas = document.getElementById("game-canvas");
        // Get a 2D context for the canvas.
        var ctx = canvas.getContext("2d");


        var ballR = 10;
        var x = canvas.width / 2;
        var y = canvas.height - 30;
        var dx = 3;
        var dy = -3;
        var pongH = 15;
        var pongW = 80;
        var pongX = (canvas.width - pongW) / 2;
        var rightKey = false;
        var leftKey = false;
        var brickRows = 3;
        var brickCol = 9;
        var brickW = 75;
        var brickH = 20;
        var brickPadding = 10;
        var brickOffsetTop = 30;
        var brickOffsetLeft = 30;

        var bricks = [];
        for (c = 0; c < brickCol; c++) {
            bricks[c] = [];
            for (r = 0; r < brickRows; r++) {
                bricks[c][r] = {
                    x: 0,
                    y: 0,
                    status: 1
                };
            }
        }


        // function to draw the ball 
        function drawBall() {
            ctx.beginPath();
            ctx.arc(x, y, ballR, 0, Math.PI * 2);
            ctx.fillStyle = "red";
            ctx.fill();
            ctx.closePath();
        }

        // function draw the pong
        function drawPong() {
            ctx.beginPath();
            ctx.rect(pongX, canvas.height - pongH, pongW, pongH);
            ctx.fillStyle = "blue";
            ctx.fill();
            ctx.closePath();
        }

        // function draw the bricks
        function drawBricks() {
            for (c = 0; c < brickCol; c++) {
                for (r = 0; r < brickRows; r++) {
                    if (bricks[c][r].status == 1) {
                        var brickX = (c * (brickW + brickPadding)) + brickOffsetLeft;
                        var brickY = (r * (brickH + brickPadding)) + brickOffsetTop;
                        bricks[c][r].x = brickX;
                        bricks[c][r].y = brickY;
                        ctx.beginPath();
                        ctx.rect(brickX, brickY, brickW, brickH);
                        ctx.fillStyle = "green";
                        ctx.fill();
                        ctx.closePath();
                    }
                }
            }
        }

        function collisionDetection() {
            for (c = 0; c < brickCol; c++) {
                for (r = 0; r < brickRows; r++) {
                    var b = bricks[c][r];
                    if (b.status == 1) {
                        if (x > b.x && x < b.x + brickW && y > b.y && y < b.y + brickH) {
                            dy = -dy;
                            b.status = 0;
                        }
                    }
                }
            }
        }



        function draw() {
            ctx.clearRect(0, 0, canvas.width, canvas.height);
            drawBricks();
            drawBall();
            drawPong();
            collisionDetection();

            if (x + dx > canvas.width - ballR || x + dx < ballR) {
                dx = -dx;
            }

            if (y + dy < ballR) {
                dy = -dy;
            } else if (y + dy > canvas.height - ballR) {
                if (x > pongX && x < pongX + pongW) {
                    dy = -dy;
                } else {
                    // if the ball hits the bottom of canvas
                    // reload the game

                    document.location.reload();
                }
            }
            // when key is pressed 
            function keyDown(e) {
                if (e.keyCode == 39) {
                    rightKey = true;
                } else if (e.keyCode == 37) {
                    leftKey = true;
                }
            }

            // when key is not pressed
            function keyUp(e) {
                if (e.keyCode == 39) {
                    rightKey = false;
                } else if (e.keyCode == 37) {
                    leftKey = false;
                }
            }

            // Add an event listener to the keypress event.
            document.addEventListener("keydown", keyDown, false);
            document.addEventListener("keyup", keyUp, false);

            // move the pong right if the right key pressed
            if (rightKey && pongX < canvas.width - pongW) {
                pongX += 7;
            }
            // move the pong left if the left key pressed
            else if (leftKey && pongX > 0) {
                pongX -= 7;
            }

            x += dx;
            y += dy;
        }

        setInterval(draw, 10);
    </script>
</body>

</html>
</asp:Content>

