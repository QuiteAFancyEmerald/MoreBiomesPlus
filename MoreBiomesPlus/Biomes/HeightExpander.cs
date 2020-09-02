using System.IO;
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
            int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Terrain")); //modified gen pass
            if (genIndex == -1)
            {
                return;
            }
            tasks.Insert(genIndex + 1, new PassLegacy("A little bit of dirt", delegate (GenerationProgress progress)
            {
                progress.Message = "A little bit of dirt";
                for (int i = 0; i < Main.maxTilesX / 500; i++)       //900 is how many biomes. The bigger is the number = less biomes.
                {
                    int X = WorldGen.genRand.Next(1, Main.maxTilesX - 500);
                    int Y = WorldGen.genRand.Next((int)Main.maxTilesY - 1000);
                    int TileType = 0;     //Standard number equals vanilla tiles/

                    WorldGen.TileRunner(X, Y, 900, WorldGen.genRand.Next(900, 1000), TileType, false, 0f, 0f, true, true); 

                }

            }));
        }
    }
}
