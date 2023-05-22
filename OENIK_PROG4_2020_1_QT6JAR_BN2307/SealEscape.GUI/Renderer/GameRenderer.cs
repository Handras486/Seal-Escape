// <copyright file="GameRenderer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OENIK_PROG4_2020_1_QT6JAR_BN2307.Renderer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using OENIK_PROG4_2020_1_QT6JAR_BN2307.Renderer;
    using SealEscape.Model;
    using SealEscape.Model.OtherModels;

    /// <summary>
    /// Renders the GameModel class.
    /// </summary>
    public class GameRenderer
    {
        private readonly IGameModel model;

        private int oldfish;
        private int oldlives;
        private string oldlevel;
        private Drawing oldBackground;

        private Brush oldPlayerBrush;
        private Brush oldHeartBrush;
        private Brush oldWeakFoodBrush;
        private Brush oldStrongFoodBrush;
        private Brush oldWeakEnemyBrush;
        private Brush oldStrongEnemyBrush;
        private Brush oldExtraHeartBrush;

        private GameBrushes gameBrushes;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameRenderer"/> class.
        /// </summary>
        /// <param name="model">The model to manipulate.</param>
        public GameRenderer(IGameModel model)
        {
            this.model = model;
            this.gameBrushes = new GameBrushes();
            this.gameBrushes.Level = this.model.Level.ToString();

            this.oldfish = this.model.FishCollected;
            this.oldlives = this.model.Player.LivesTotal;
            this.oldPlayerBrush = this.gameBrushes.PlayerBrush;
            this.oldHeartBrush = this.gameBrushes.HeartBrush;
            this.oldStrongFoodBrush = this.gameBrushes.StrongFoodBrush;
            this.oldWeakFoodBrush = this.gameBrushes.WeakFoodBrush;
            this.oldStrongEnemyBrush = this.gameBrushes.StrongEnemyBrush;
            this.oldWeakEnemyBrush = this.gameBrushes.WeakEnemyBrush;
            this.oldExtraHeartBrush = this.gameBrushes.ExtraHeartBrush;
    }

        /// <summary>
        /// Resets all cached values.
        /// </summary>
        public void Reset()
        {
            this.oldBackground = null;
            this.oldPlayerBrush = null;
            this.oldWeakFoodBrush = null;
            this.oldStrongFoodBrush = null;
            this.oldWeakEnemyBrush = null;
            this.oldStrongEnemyBrush = null;
            this.oldHeartBrush = null;
            this.oldlevel = null;
            this.oldfish = 0;
            this.oldlives = 0;
        }

        /// <summary>
        /// Draws all Renderer Drawings.
        /// </summary>
        /// <returns>DrawingGroup of all Drawings.</returns>
        public Drawing BuildDrawing()
        {
            DrawingGroup dg = new DrawingGroup();
            this.gameBrushes.Level = this.model.Level.ToString();
            dg.Children.Add(this.GetBackground());

            foreach (Drawing enemy in this.GetEnemies())
            {
                dg.Children.Add(enemy);
            }

            foreach (Drawing food in this.GetFood())
            {
                dg.Children.Add(food);
            }

            dg.Children.Add(this.GetPlayer());

            foreach (Drawing item in this.GetOverlay())
            {
                dg.Children.Add(item);
            }

            return dg;
        }

        /// <summary>
        /// Draws game over text.
        /// </summary>
        /// <returns>text.</returns>
        public Drawing GameOver()
        {
            FormattedText gameovertext = new FormattedText(
                "Game Over",
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface("Rockwell"),
                170,
                Brushes.Black);
            return new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 0.5), gameovertext.BuildGeometry(new Point(this.model.GameWidth / 5, this.model.GameHeight / 4)));
        }

        private List<Drawing> GetOverlay()
        {
            List<Drawing> overlays = new List<Drawing>();

            this.oldlives = this.model.Player.LivesLeft;
            for (int i = 0; i < this.oldlives; i++)
            {
                if (i < 3)
                {
                    overlays.Add(new GeometryDrawing(this.oldHeartBrush, null, new RectangleGeometry(new Rect(i * 60, 0, 50, 50))));
                }
                else
                {
                    overlays.Add(new GeometryDrawing(this.oldExtraHeartBrush, null, new RectangleGeometry(new Rect(i * 60, 0, 50, 50))));
                }
            }

            FormattedText scoretext = new FormattedText(
                this.model.Score.ToString() + "(" + this.model.Highscore + ")",
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface("Rockwell"),
                40,
                Brushes.Black);
            overlays.Add(new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 0.5), scoretext.BuildGeometry(new Point(0, 55))));

            overlays.Add(new GeometryDrawing(this.oldWeakFoodBrush, null, new RectangleGeometry(new Rect(0, 110, 40, 40))));
            if (this.oldfish != this.model.FishCollected)
            {
                FormattedText fishtext = new FormattedText(
                    this.model.FishCollected.ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface("Rockwell"),
                    40,
                    Brushes.Black);
                overlays.Add(new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 0.5), fishtext.BuildGeometry(new Point(40, 105))));
            }

            return overlays;
        }

        private Drawing GetPlayer()
        {
            if (this.gameBrushes.Level != this.oldlevel)
            {
                this.oldPlayerBrush = this.gameBrushes.PlayerBrush;
                return new GeometryDrawing(this.oldPlayerBrush, null, this.model.Player.RealArea);
            }
            else
            {
                return new GeometryDrawing(this.oldPlayerBrush, null, this.model.Player.RealArea);
            }
        }

        private List<Drawing> GetFood()
        {
            List<Drawing> foodmodels = new List<Drawing>();
            foreach (var item in this.model.FoodOnScreen)
            {
                if (item.Name == "strong" && this.gameBrushes.Level != this.oldlevel)
                {
                    this.oldStrongFoodBrush = this.gameBrushes.StrongFoodBrush;
                    foodmodels.Add(new GeometryDrawing(this.oldStrongFoodBrush, null, item.RealArea));
                }
                else if (item.Name == "strong")
                {
                    foodmodels.Add(new GeometryDrawing(this.oldStrongFoodBrush, null, item.RealArea));
                }

                if (item.Name == "weak" && this.gameBrushes.Level != this.oldlevel)
                {
                    this.oldWeakFoodBrush = this.gameBrushes.WeakFoodBrush;
                    foodmodels.Add(new GeometryDrawing(this.oldWeakFoodBrush, null, item.RealArea));
                }
                else if (item.Name == "weak")
                {
                    foodmodels.Add(new GeometryDrawing(this.oldWeakFoodBrush, null, item.RealArea));
                }
            }

            return foodmodels;
        }

        private List<Drawing> GetEnemies()
        {
            List<Drawing> enemymodels = new List<Drawing>();
            foreach (var item in this.model.EnemiesOnScreen)
            {
                if (item.Name == "strong" && this.gameBrushes.Level != this.oldlevel)
                {
                    this.oldStrongEnemyBrush = this.gameBrushes.StrongEnemyBrush;
                    enemymodels.Add(new GeometryDrawing(this.oldStrongEnemyBrush, null, item.RealArea));
                }
                else if (item.Name == "strong")
                {
                    enemymodels.Add(new GeometryDrawing(this.oldStrongEnemyBrush, null, item.RealArea));
                }

                if (item.Name == "weak" && this.gameBrushes.Level != this.oldlevel)
                {
                    this.oldWeakEnemyBrush = this.gameBrushes.WeakEnemyBrush;
                    enemymodels.Add(new GeometryDrawing(this.oldWeakEnemyBrush, null, item.RealArea));
                }
                else if (item.Name == "weak")
                {
                    enemymodels.Add(new GeometryDrawing(this.oldWeakEnemyBrush, null, item.RealArea));
                }
            }

            return enemymodels;
        }

        private Drawing GetBackground()
        {
            if (this.oldBackground == null || this.gameBrushes.Level != this.oldlevel)
            {
                Geometry g = new RectangleGeometry(new Rect(0, 0, this.model.GameWidth, this.model.GameHeight));
                this.oldBackground = new GeometryDrawing(this.gameBrushes.BackgroundBrush, null, g);
            }

            return this.oldBackground;
        }
    }
}
