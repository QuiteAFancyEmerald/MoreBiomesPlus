using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using System.Linq;


namespace MoreBiomesPlus
{
    public class ObsidianBiome : ModWorld
    {

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (genIndex == -1)
            {
                return;
            }
            tasks.Insert(genIndex + 1, new PassLegacy("Obsidian Cave", delegate (GenerationProgress progress)
            {
                progress.Message = "Creating obsidian caves";
                for (int i = 0; i < Main.maxTilesX / 900; i++)       //900 is how many biomes. the bigger is the number = less biomes
                {
                    int X = WorldGen.genRand.Next(1, Main.maxTilesX - 100);
                    int Y = WorldGen.genRand.Next((int)WorldGen.rockLayer - 100);
                    int TileType = 56;   //obsidian block

                    WorldGen.TileRunner(X, Y, 200, WorldGen.genRand.Next(20, 50), TileType, false, 0f, 0f, true, true);  //350 is how big is the biome     100, 200 this changes how random it looks.

                }

            }));
        }
    }
}