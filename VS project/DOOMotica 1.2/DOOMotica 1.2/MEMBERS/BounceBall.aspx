﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="BounceBall.aspx.cs" Inherits="DOOMotica_1._2.MEMBERS.BounceBall" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="game">
        <div id="square0"></div>
        <div id="square1"></div>
        <div id="notepad"></div>
        <div id="pad"></div>
    </div>

    <script lang="javascript">
        var gameHeight = 320
        var gameWidth = 360

        var intervalOne, intervalTwo, timeoutOne, x
        var angle = 2
        var tempX = 0
        var tempY = 0
        var block = 1
        var square = 0
        var squareTop = 0
        var squareLeft = 0
        var squareMotion = 1
        var speed = 80
        var getPad = 0
        var nextScore = 0
        var score = 0
        var count = 0
        var collisionOne = 0
        var collisionTwo = 0
        var collisionThree = 0


        document.body.style.margin = "0px"
        document.body.style.padding = "0px"

        function setupGame() {
            document.getElementById("game").style.borderRight = "1px solid #aaa"
            document.getElementById("game").style.borderRight = "1px solid #aaa"
            document.getElementById("game").style.borderBottom = "1px solid #aaa"
            document.getElementById("game").style.width = gameWidth + "px"
            document.getElementById("game").style.height = gameHeight + "px"
            document.getElementById("square0").style.position = "absolute"
            document.getElementById("square0").style.width = "40px"
            document.getElementById("square0").style.height = "40px"
            document.getElementById("square0").style.backgroundColor = "#444"
            document.getElementById("square0").style.display = "none"
            document.getElementById("square1").style.position = "absolute"
            document.getElementById("square1").style.width = "40px"
            document.getElementById("square1").style.height = "40px"
            document.getElementById("square1").style.backgroundColor = "#444"
            document.getElementById("square1").style.display = "none"
            document.getElementById("pad").style.position = "absolute"
            document.getElementById("pad").style.width = "60px"
            document.getElementById("pad").style.height = "30px"
            document.getElementById("pad").style.paddingTop = "10px"
            document.getElementById("pad").style.textAlign = "center"
            document.getElementById("pad").style.font = "15px Verdana, sans-serif"
            document.getElementById("pad").style.backgroundColor = "#000"
            document.getElementById("pad").style.color = "#fff"
            document.getElementById("pad").innerHTML = "<a id=\"play\" href=\"javascript:newGame()\">PLAY</a>"
            document.getElementById("play").style.color = "#fff"
            document.getElementById("play").style.textDecoration = "none"

            padTop = Math.floor(gameHeight / 2) - 20
            padLeft = Math.floor(gameWidth / 2) - 30

            document.getElementById("pad").style.top = padTop + "px"
            document.getElementById("pad").style.left = padLeft + "px"

            document.getElementById("notepad").innerHTML = "BounceGame"
            document.getElementById("notepad").style.padding = "10px"
            document.getElementById("notepad").style.textAlign = "center"
            document.getElementById("notepad").style.font = "2.0em Georgia, serif"
            document.getElementById("notepad").style.fontWeight = "normal"
            document.getElementById("notepad").style.color = "#222"

            timeoutOne = setTimeout("intervalTwo = setInterval('demoGame()', speed)", 4000)
        }

        function demoGame() {
            angle = 2
            clearTimeout(timeoutOne)
            document.getElementById("square0").style.display = "block"
            document.getElementById("square1").style.display = "block"

            if (square == 0) {
                x = document.getElementById("square0")
                square = 1
            }
            else {
                x = document.getElementById("square1")
                square = 0
            }

            bounceGame()
        }

        function newGame() {
            block = 0
            angle = 2
            tempX = 0
            tempY = 0
            square = 0
            squareTop = 0
            squareLeft = 0
            squareMotion = 1
            nextScore = 0
            score = 0
            count = 0
            collisionOne = 0
            collisionTwo = 0
            collisionThree = 0

            clearTimeout(timeoutOne)
            clearInterval(intervalOne)
            clearInterval(intervalTwo)
            document.getElementById("square0").style.left = "0px"
            document.getElementById("square0").style.top = "0px"
            document.getElementById("square0").style.display = "block"
            document.getElementById("square1").style.left = "0px"
            document.getElementById("square1").style.top = "0px"
            document.getElementById("square1").style.display = "block"
            document.getElementById("pad").style.top = (gameHeight - 40) + "px"
            document.getElementById("pad").innerHTML = ""
            document.getElementById("notepad").innerHTML = ""

            intervalOne = setInterval("playGame()", speed)
        }

        function playGame() {
            if (block) {
                return
            }

            if (square == 0) {
                x = document.getElementById("square0")
                square = 1
            }
            else {
                x = document.getElementById("square1")
                square = 0
            }

            bounceGame()
            checkCollision()
        }

        function assignM(aM) {
            squareMotion = aM
        }

        function bounceGame() {
            if (squareMotion == 1) {
                if (squareTop >= (gameHeight - 40) && squareLeft >= (gameWidth - 40)) {
                    assignM(3)
                    moveDR(-40)
                }

                if (squareTop >= (gameHeight - 40)) {
                    assignM(2)
                    moveDL(-40)
                }
                else if (squareLeft >= (gameWidth - 40)) {
                    assignM(4)
                    moveDL(40)
                }
                else {
                    moveDR(40)
                }
            }
            else if (squareMotion == 2) {
                if (squareTop <= 0 && squareLeft >= (gameWidth - 40)) {
                    assignM(4)
                    moveDL(40)
                }

                if (squareLeft >= (gameWidth - 40)) {
                    assignM(3)
                    moveDR(-40)
                }
                else if (squareTop <= 0) {
                    assignM(1)
                    moveDR(40)
                }
                else {
                    moveDL(-40)
                }
            }
            else if (squareMotion == 3) {
                if (squareTop <= 0 && squareLeft <= 0) {
                    assignM(1)
                    moveDR(40)
                }

                if (squareTop <= 0) {
                    assignM(4)
                    moveDL(40)
                }
                else if (squareLeft <= 0) {
                    assignM(2)
                    moveDL(-40)
                }
                else {
                    moveDR(-40)
                }
            }
            else if (squareMotion == 4) {
                if (squareTop >= (gameHeight - 40) && squareLeft <= 0) {
                    assignM(2)
                    moveDL(-40)
                }

                if (squareLeft <= 0) {
                    assignM(1)
                    moveDR(40)
                }
                else if (squareTop >= (gameHeight - 40)) {
                    assignM(3)
                    moveDR(-40)
                }
                else {
                    moveDL(40)
                }
            }
        }

        function moveDR(amount) {
            save = amount
            amount = Math.floor(amount / angle)

            if (angle == 0) {
                amount = 0
            }

            squareLeft += amount
            x.style.left = squareLeft + "px"
            squareTop += save
            x.style.top = squareTop + "px"
        }

        function moveDL(amount) {
            save = amount
            amount = Math.floor(amount / angle)

            if (angle == 0) {
                amount = 0
            }

            squareLeft -= amount
            x.style.left = squareLeft + "px"
            squareTop += save
            x.style.top = squareTop + "px"
        }

        function assignAngle(aa) {
            if (aa == 1) {
                angle = 0
                nextScore = 1000
            }
            if (aa == 2) {
                angle = 2
                nextScore = 100
            }

            score += nextScore

            document.getElementById("pad").innerHTML = nextScore
        }

        function flashScore() {
            if (score > 0) {
                if (nextScore == "BounceGame") {
                    nextScore = score
                }
                else {
                    nextScore = "BounceGame"
                }

                document.getElementById("notepad").innerHTML = nextScore
            }
            else {
                document.getElementById("notepad").innerHTML = "BounceGame"
            }
        }

        function countUp() {
            if (count < (Math.floor(score / 10) * 8)) {
                count += Math.floor(score / 10)
            }
            else if (count >= (Math.floor(score / 10) * 8) && count <= (Math.floor(score / 10) * 9)) {
                if ((Math.floor(score / 10) * 9) > 200) {
                    count += Math.floor(score / 10)
                }
                else {
                    count += 10
                }
            }
            else {
                if (Math.floor(score / 10) > 30) {
                    count += 10
                }
                else {
                    count += 1
                }
            }

            if (count > score) {
                count = score
                clearInterval(intervalOne)
                intervalOne = setInterval("flashScore()", 2000)
            }

            document.getElementById("notepad").innerHTML = count
        }

        function checkCollision() {
            var actualLeft = getPad - 30

            if (squareTop == 0) {
                document.getElementById("pad").innerHTML = ""
            }

            if ((squareTop + 40) == (gameHeight - 40)) {
                difference = Math.floor(squareLeft - actualLeft)

                if (difference >= (-39) && difference < 4) {
                    collisionOne++
                    collisionTwo = 0
                    collisionThree = 0

                    if (collisionOne > 3) {
                        assignM(Math.floor(Math.random() * 2) + 2)
                    }
                    else {
                        assignM(3)
                    }

                    assignAngle(2)
                }
                else if (difference >= 5 && difference < 15) {
                    collisionOne = 0
                    collisionTwo++
                    collisionThree = 0

                    if (collisionTwo > 3) {
                        assignM(Math.floor(Math.random() * 2) + 2)
                        assignAngle(2)
                    }
                    else {
                        assignM(3)
                        assignAngle(1)
                    }
                }
                else if (difference >= 15 && difference < 59) {
                    collisionOne = 0
                    collisionTwo = 0
                    collisionThree++

                    if (collisionThree > 3) {
                        assignM(Math.floor(Math.random() * 2) + 2)
                    }
                    else {
                        assignM(2)
                    }

                    assignAngle(2)
                }
            }
            else if ((squareTop + 40) == gameHeight) {
                block = 1
                clearInterval(intervalOne)
                setupGame()
                intervalOne = setInterval("countUp()", speed)
            }
        }

        function getMouseXY(e) {
            if (navigator.appName == "Netscape") {
                tempX = e.pageX
                tempY = e.pageY
            }
            else {
                tempX = event.clientX + document.body.scrollLeft
                tempY = event.clientY + document.body.scrollTop
            }

            if (tempX < 0) {
                tempX = 0
            }

            getPad = tempX

            if (getPad <= 30) {
                getPad = 30
            }

            if ((getPad - 30) > Math.floor(gameWidth - 60)) {
                getPad = Math.floor(gameWidth - 60) + 30
            }

            if (!block) {
                document.getElementById("pad").style.left = (getPad - 30) + "px"
            }

        }

        document.onmousemove = getMouseXY

        setupGame()

    </script>


</asp:Content>
