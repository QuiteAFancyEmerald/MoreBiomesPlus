﻿using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using System.Linq;

namespace MoreBiomesPlus.Biomes
{
    public class HeightExpander : ModWorld
    {

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (genIndex == -1)
            {
                return;
            }
            tasks.Insert(genIndex + 1, new PassLegacy("A little bit of dirt", delegate (GenerationProgress progress)
            {
                progress.Message = "Generating mountains...";
                for (int i = 0; i < Main.maxTilesX / 900; i++)       //900 is how many biomes. the bigger is the number = less biomes
                {
                    int X = WorldGen.genRand.Next(1, Main.maxTilesX - 250);
                    int Y = WorldGen.genRand.Next((int)Main.maxTilesY - 600);
                    int TileType = 0;     //this is the tile u want to use for the biome , if u want to use a vanilla tile then its int TileType = 56; 56 is obsidian block

                    WorldGen.TileRunner(X, Y, 200, WorldGen.genRand.Next(800, 900), TileType, false, 0f, 0f, true, true);  //350 is how big is the biome     100, 200 this changes how random it looks.

                }

            }));
        }
    }
}