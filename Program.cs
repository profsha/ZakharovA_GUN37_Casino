// See https://aka.ms/new-console-template for more information

using ZakharovA_GUN37_Casino.Casino;
using ZakharovA_GUN37_Casino.Services.SaveLoadService;

var casino = new Casino(new FileSystemSaveLoadService("Saves"));
casino.StartGame();