using Game;

var game = new Game.Game();
var eventLoop = new EventLoop();
eventLoop.Run(
new ArrowHandler(game.playerMoveLeft),
new ArrowHandler(game.playerMoveRight),
new ArrowHandler(game.playerMoveUp),
new ArrowHandler(game.playerMoveDown)
);
