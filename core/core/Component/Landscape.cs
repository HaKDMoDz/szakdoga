using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTV3D65;

namespace core.Component
{
    public class Landscape:DrawableGameComponent
    {
        private static TVLandscape land;

        private int IDDiff;
        private int IDMat;

        public TV_3DVECTOR Position
        {
            get { return land.GetPosition(); }
        }

        public Landscape(Game game)
            : base(game)
        {
        }

        public override void Load()
        {
            
            IDDiff = Game.Textures.LoadTexture("Landscape/texture.dds", "LandTexture", 2048, 2048);
            IDMat = Game.Materials.CreateLightMaterial(1, 1, 1, 1, 0.25f, 1, "LandLightMaterial");


            land = Game.Scene.CreateLandscape("Land");
            land.GenerateTerrain("Landscape/landHM.png", CONST_TV_LANDSCAPE_PRECISION.TV_PRECISION_BEST, 8, 8, -0, 0, -0);
            land.SetCullMode(CONST_TV_CULLING.TV_DOUBLESIDED);
            land.ExpandTexture(Game.Globals.GetTex("LandTexture"), 0, 0, 8, 8);
            land.SetMaterial(IDMat);
            land.SetTexture(IDDiff);
            land.SetPosition(-0, 0, -0);
            land.EnableLOD(true);
        }

        public override void Draw(GameTime time)
        {
            land.Render();
        }

        public float GetHeight(float positionX, float positionZ)
        {
            return land.GetHeight(positionX, positionZ);
        }
    }
}
