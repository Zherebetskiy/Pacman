using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using PacmanLibrary;
using PacmanLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PacmanWeb
{
    public class PacmanHub : Hub
    {
        IGame game;

        public PacmanHub(IGame game)
        {
            this.game = game;
        }

        public async Task Play()
        {
            if (!game.SaveScore)
            {
                game.PlayGame(null);

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                };

                string strJson = JsonConvert.SerializeObject(game.Field, settings);

                await Clients.All.SendAsync("UpdatePosition", strJson, game.Score, game.Lifes, game.Points);
            }
            else
            {
                await GameEnded();
                game.SaveScore = false;
            }
        }

        public void NewGame()
        {
            game.GameOver();
        }

        public async Task GameEnded()
        {
            await Clients.All.SendAsync("GameEnded");
        }

        public void ChangeDirection(string key)
        {
            game.ChangeDirection(key);
        }
    }
}
