﻿using System.Drawing;
using Rbx2Source.DataTypes;

namespace Rbx2Source.Geometry
{
    // 3D Geometry components of the Vertex class
    // The 2D Texture components are defined in Textures/Vertex2D.cs

    public partial class Vertex
    {
        public Vector3 Position;
        public Vector3 Normal;
        public Vector3 UV;

        public bool HasColor = false;
        public Color Color;

        public string WriteStudioMdl()
        {
            var scale = Rbx2Source.MODEL_SCALE;

            return Format.FormatFloats
            (
                Position.X * scale,
                Position.Y * scale,
                Position.Z * scale,

                Normal.X,
                Normal.Y,
                Normal.Z,

                UV.X,
                1 - UV.Y
            );
        }
    }
}
