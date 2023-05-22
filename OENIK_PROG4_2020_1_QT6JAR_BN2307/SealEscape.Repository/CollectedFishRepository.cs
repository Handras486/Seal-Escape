// <copyright file="CollectedFishRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SealEscape.Repository
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Repository to store number of collected fish.
    /// </summary>
    public class CollectedFishRepository
    {
        /// <summary>
        /// File containing number of collected fish.
        /// </summary>
        private readonly string fishRepoPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            + "\\SealEscape\\CollectedFish\\";

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectedFishRepository"/> class.
        /// </summary>
        public CollectedFishRepository()
        {
            Directory.CreateDirectory(this.fishRepoPath);
        }

        /// <summary>
        /// Increases number of fish stored.
        /// </summary>
        /// <param name="fish">Number of fish to add.</param>
        public virtual void Add(int fish)
        {
            int current = fish + this.Read();

            StreamWriter sw = new StreamWriter(this.fishRepoPath + "fish.txt");
            sw.WriteLine(current.ToString());
            sw.Close();
        }

        /// <summary>
        /// Get current number of fish collected.
        /// </summary>
        /// <returns>The number of fish.</returns>
        public virtual int Read()
        {
            if (File.Exists(this.fishRepoPath + "fish.txt"))
            {
                StreamReader sr = new StreamReader(this.fishRepoPath + "fish.txt");
                string value = sr.ReadToEnd();
                sr.Close();
                if (value == string.Empty)
                {
                    return 0;
                }

                return int.Parse(value);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Decreases number of fish stored.
        /// </summary>
        /// <param name="fish">Number of fish to remove.</param>
        public void Remove(int fish)
        {
            if (File.Exists(this.fishRepoPath + "fish.txt"))
            {
                int currentfish = this.Read();
                StreamWriter sw = new StreamWriter(this.fishRepoPath + "fish.txt");
                sw.WriteLine((currentfish - fish).ToString());
                sw.Close();
            }
        }
    }
}
