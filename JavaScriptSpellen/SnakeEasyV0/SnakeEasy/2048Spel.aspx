﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="2048Spel.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
  </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" src="2048.js"></script>
    <link rel="stylesheet" type="text/css" href="2048.css" />
  <div class="container">
  <div class="heading">
    <h1 class="title">2048</h1>
    <div class="score-container">0</div>
  </div>
  <p class="game-intro">Join the numbers and get to the <strong>2048 tile!</strong></p>

  <div class="game-container">
    <div class="game-message">
      <p></p>
      <div class="lower">
        <a class="retry-button">Try again</a>
      </div>
    </div>

    <div class="grid-container">
      <div class="grid-row">
        <div class="grid-cell"></div>
        <div class="grid-cell"></div>
        <div class="grid-cell"></div>
        <div class="grid-cell"></div>
      </div>
      <div class="grid-row">
        <div class="grid-cell"></div>
        <div class="grid-cell"></div>
        <div class="grid-cell"></div>
        <div class="grid-cell"></div>
      </div>
      <div class="grid-row">
        <div class="grid-cell"></div>
        <div class="grid-cell"></div>
        <div class="grid-cell"></div>
        <div class="grid-cell"></div>
      </div>
      <div class="grid-row">
        <div class="grid-cell"></div>
        <div class="grid-cell"></div>
        <div class="grid-cell"></div>
        <div class="grid-cell"></div>
      </div>
    </div>

    <div class="tile-container">

    </div>
  </div>

  <p class="game-explanation">
    <strong class="important">How to play:</strong> Use your <strong>arrow keys</strong> to move the tiles. When two tiles with the same number touch, they <strong>merge into one!</strong>
  </p>
  <hr>
  <p>
  Created by <a href="http://gabrielecirulli.com" target="_blank">Gabriele Cirulli.</a> Based on <a href="https://itunes.apple.com/us/app/1024!/id823499224" target="_blank">1024 by Veewo Studio</a> and conceptually similar to <a href="http://asherv.com/threes/" target="_blank">Threes by Asher Vollmer.</a>
  </p>
</div>
</asp:Content>
