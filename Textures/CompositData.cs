﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

using Rbx2Source.DataTypes;
using Rbx2Source.Geometry;
using Rbx2Source.Web;

namespace Rbx2Source.Textures
{
    public enum DrawMode
    {
        Guide,
        Rect
    }

    public enum DrawType
    {
        Texture,
        Color,
    }

    public class TextureAllocation
    {
        public MemoryStream Stream;
        public Bitmap Texture;
    }

    public class CompositData : IComparable
    {
        public object Texture;
        public Color DrawColor;

        public int Layer;
        public Mesh Guide;

        public Rectangle Rect;
        public RotateFlipType FlipMode = RotateFlipType.RotateNoneFlipNone;

        public readonly DrawMode DrawMode;
        public readonly DrawType DrawType;

        private static Dictionary<long, TextureAllocation> TextureAlloc = new Dictionary<long, TextureAllocation>();

        public CompositData(DrawMode drawMode, DrawType drawType)
        {
            DrawMode = drawMode;
            DrawType = drawType;

            Rect = new Rectangle();
        }

        public void SetGuide(string guideName, Rectangle guideSize, AvatarType avatarType)
        {
            string avatarTypeName = Rbx2Source.GetEnumName(avatarType);

            string guidePath = "AvatarData/" + avatarType + "/Compositing/" + guideName + ".mesh";
            Asset guideAsset = Asset.FromResource(guidePath);

            Guide = Mesh.FromAsset(guideAsset);
            Rect = guideSize;
        }

        public void SetOffset(Point offset)
        {
            Rect.Location = offset;
        }

        public bool SetDrawColor(int brickColorId)
        {
            BrickColor bc;

            if (BrickColor.TryFromNumber(brickColorId, out bc))
            {
                DrawColor = bc.Color;
                return true;
            }

            return false;
        }

        public int CompareTo(object other)
        {
            if (other is CompositData)
            {
                CompositData otherComp = other as CompositData;
                return (Layer - otherComp.Layer);
            }

            throw new NotImplementedException();
        }

        public Vertex[] GetGuideVerts(int faceIndex)
        {
            return Guide.Faces[faceIndex]
                .Select((face) => Guide.Verts[face])
                .ToArray();
        }

        public void UseBrush(Action<Brush> handler)
        {
            using (Brush brush = new SolidBrush(DrawColor))
            {
                handler(brush);
            }
        }

        public Bitmap GetTextureBitmap()
        {
            if (Texture is Asset)
            {
                Asset asset = Texture as Asset;
                long assetId = asset.Id;

                if (!TextureAlloc.ContainsKey(assetId))
                {
                    byte[] buffer = asset.GetContent();

                    var alloc = new TextureAllocation();
                    alloc.Stream = new MemoryStream(buffer);

                    try
                    {
                        alloc.Texture = Image.FromStream(alloc.Stream) as Bitmap;
                    }
                    catch
                    {
                        alloc.Texture = new Bitmap(512, 512);
                    }

                    TextureAlloc.Add(assetId, alloc);
                }

                return TextureAlloc[assetId].Texture;
            }
            else if (Texture is Bitmap)
            {
                return Texture as Bitmap;
            }
            else
            {
                throw new InvalidDataException("The Texture of this CompositData was assigned a garbage value.");
            }
        }

        public static void FreeAllocatedTextures()
        {
            long[] assetIds = TextureAlloc.Keys.ToArray();

            foreach (long assetId in assetIds)
            {
                TextureAllocation alloc = TextureAlloc[assetId];
                TextureAlloc.Remove(assetId);

                alloc.Texture.Dispose();
                alloc.Texture = null;

                alloc.Stream.Dispose();
                alloc.Stream = null;
            }
        }
    }
}
