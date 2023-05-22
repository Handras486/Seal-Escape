// <copyright file="GameBrushes.cs" company="PlaceholderCompany">
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
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// Generates all GameBrushes.
    /// </summary>
    public class GameBrushes
    {
        private string level;
        private Dictionary<string, Brush> brushes = new Dictionary<string, Brush>();

        /// <summary>
        /// Gets or sets game level.
        /// </summary>
        public string Level
        {
            get { return this.level; }
            set { this.level = value; }
        }

        /// <summary>
        /// Gets Player brush.
        /// </summary>
        public Brush PlayerBrush
        {
            get { return this.GetBrush($"OENIK_PROG4_2020_1_QT6JAR_BN2307.Images.seal"); }
        }

        /// <summary>
        /// Gets Background brush.
        /// </summary>
        public Brush BackgroundBrush
        {
            get { return this.GetBrush($"OENIK_PROG4_2020_1_QT6JAR_BN2307.Images.background"); }
        }

        /// <summary>
        /// Gets WeakEnemy brush.
        /// </summary>
        public Brush WeakEnemyBrush
        {
            get { return this.GetBrush($"OENIK_PROG4_2020_1_QT6JAR_BN2307.Images.weakenemy"); }
        }

        /// <summary>
        /// Gets StrongEnemy brush.
        /// </summary>
        public Brush StrongEnemyBrush
        {
            get { return this.GetBrush($"OENIK_PROG4_2020_1_QT6JAR_BN2307.Images.strongenemy"); }
        }

        /// <summary>
        /// Gets WeakFood brush.
        /// </summary>
        public Brush WeakFoodBrush
        {
            get { return this.GetBrush($"OENIK_PROG4_2020_1_QT6JAR_BN2307.Images.weakfood"); }
        }

        /// <summary>
        /// Gets StrongFood brush.
        /// </summary>
        public Brush StrongFoodBrush
        {
            get { return this.GetBrush($"OENIK_PROG4_2020_1_QT6JAR_BN2307.Images.strongfood"); }
        }

        /// <summary>
        /// Gets Heart brush.
        /// </summary>
        public Brush HeartBrush
        {
            get { return this.GetBrush($"OENIK_PROG4_2020_1_QT6JAR_BN2307.Images.heart"); }
        }

        /// <summary>
        /// Gets Heart brush.
        /// </summary>
        public Brush ExtraHeartBrush
        {
            get { return this.GetBrush($"OENIK_PROG4_2020_1_QT6JAR_BN2307.Images.extraheart"); }
        }

        private Brush GetBrush(string filename)
        {
            if (!this.brushes.ContainsKey(filename + this.level))
            {
                // string[] asd = Assembly.GetExecutingAssembly().GetManifestResourceNames();
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.StreamSource = Assembly.GetExecutingAssembly().GetManifestResourceStream(filename + this.level + ".png");
                bmp.EndInit();
                ImageBrush ib = new ImageBrush(bmp);

                this.brushes.Add(filename + this.level, ib);

                // List<string> keyList = new List<string>(this.brushes.Keys);
            }

            return this.brushes[filename + this.level];
        }
    }
}
