// <copyright file="Control.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OENIK_PROG4_2020_1_QT6JAR_BN2307
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Threading;
    using OENIK_PROG4_2020_1_QT6JAR_BN2307.Navigation;
    using OENIK_PROG4_2020_1_QT6JAR_BN2307.Renderer;
    using SealEscape.Logic;
    using SealEscape.Logic.OtherLogics;
    using SealEscape.Model;
    using SealEscape.Model.OtherModels.Interfaces;

    /// <summary>
    /// Initalizes game instance and refreshes screen.
    /// </summary>
    public class Control : FrameworkElement
    {
        private IGameLogic gamelogic;
        private IGameModel model;
        private GameRenderer gameRenderer;
        private DispatcherTimer timer;
        private DispatcherTimer maptimer;
        private bool isKeyDown = false;
        private bool isGameOver = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="Control"/> class.
        /// </summary>
        public Control()
        {
            this.Loaded += this.Control_Loaded;
        }

        /// <summary>
        /// Gets or sets Gamesave.
        /// </summary>
        public static string GameSave { get; set; }

        /// <summary>
        /// Saves current gamestate.
        /// </summary>
        public void SaveGame()
        {
            string date = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString();
            this.gamelogic.SaveMap(PlayerModel.PlayerName + this.model.Score.ToString() + date);
        }

        /// <summary>
        /// Loads existing gamestate.
        /// </summary>
        /// <param name="mapname">Name of msp.</param>
        public void LoadGame(string mapname)
        {
            this.gamelogic.LoadMap(mapname);
        }

        /// <summary>
        /// Returns saved maps.
        /// </summary>
        /// <returns>List of maps.</returns>
        public List<string> LoadMaps()
        {
            return this.gamelogic.ListSavedMaps();
        }

        /// <inheritdoc/>
        protected override void OnRender(DrawingContext drawingContext)
        {
            if (this.gameRenderer != null)
            {
                drawingContext.DrawDrawing(this.gameRenderer.BuildDrawing());
            }

            if (this.isGameOver)
            {
                drawingContext.DrawDrawing(this.gameRenderer.GameOver());
            }
        }

        private void Control_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.model == null)
            {
                this.model = new GameModel(this.ActualHeight, this.ActualWidth, 0, 1);
                this.gamelogic = new GameLogic(this.model);
                this.gameRenderer = new GameRenderer(this.model);
            }

            Window win = Window.GetWindow(this);
            if (win != null)
            {
                this.StartGame();
            }

            this.InvalidateVisual();
        }

        private void StartGame()
        {
            this.gamelogic.GenerateMap();
            this.gamelogic.SetPlayerName(PlayerModel.PlayerName);
            if (GameSave != null)
            {
                this.gamelogic.LoadMap(GameSave);
                GameSave = null;
            }

            this.InvalidateVisual();

            Window win = Window.GetWindow(this);
            if (win != null)
            {
                this.timer = new DispatcherTimer
                {
                    Interval = TimeSpan.FromMilliseconds(20),
                };
                this.timer.Tick += this.GameTick;
                this.timer.Start();

                this.maptimer = new DispatcherTimer
                {
                    Interval = TimeSpan.FromMilliseconds(2000),
                };
                this.maptimer.Tick += this.GenerateMap;
                this.maptimer.Start();

                this.gamelogic.GameOver += this.GameOver;
                win.KeyDown += this.Win_KeyDown;
                win.KeyUp += this.Win_KeyUp;
            }
        }

        private void GameOver(object sender, EventArgs e)
         {
            this.timer.Stop();
            this.maptimer.Stop();
            this.isGameOver = true;
            this.InvalidateVisual();

            Window win = Window.GetWindow(this);
            if (win != null)
            {
                win.KeyDown += this.GameOverKeyDown;
            }
        }

        private void GameOverKeyDown(object sender, KeyEventArgs e)
        {
            Window win = Window.GetWindow(this);
            if (win != null && e.Key == Key.Escape)
            {
                win.Content = new MenuPage();
            }
        }

        private void GenerateMap(object sender, EventArgs e)
        {
            this.gamelogic.GenerateMap();
            this.gamelogic.Cleanup();
        }

        private void Win_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Window win = Window.GetWindow(this);
                if (win != null)
                {
                    this.timer.Stop();
                    this.maptimer.Stop();
                    this.gamelogic.SaveHighscore();
                    this.gamelogic.StoreFoodCollected();
                    win.Content = new EscapePage(this);
                }
            }
            else
            {
                this.isKeyDown = true;
            }
        }

        private void Win_KeyUp(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyUp(Key.Space))
            {
                this.isKeyDown = false;
            }
        }

        private void GameTick(object sender, EventArgs e)
        {
            this.gamelogic.ApproachAll();
            if (this.isKeyDown)
            {
                this.gamelogic.AscendPlayer();
            }
            else
            {
                this.gamelogic.DescendPlayer();
            }

            this.InvalidateVisual();
        }
    }
}
