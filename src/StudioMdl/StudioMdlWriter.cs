﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rbx2Source.Assembler;
using Rbx2Source.Geometry;
using Rbx2Source.Reflection;

namespace Rbx2Source.StudioMdl
{
    /// <summary>
    /// Half-baked implementation of a writer for Source's StudioMdl Data format.
    /// See: https://developer.valvesoftware.com/wiki/Studiomdl_Data
    /// </summary>

    class StudioMdlWriter
    {
        public List<Node> Nodes;
        public List<BoneKeyframe> Skeleton;
        public List<Triangle> Triangles;
        public Dictionary<string, Material> Materials;

        private List<object> Categories;

        public string BuildFile()
        {
            StringWriter buffer = new StringWriter();
            buffer.WriteLine("// Generated by CloneTrooper1019's Rbx2Source tool!");
            buffer.WriteLine("// Please do not edit this file while the program is running.");
            buffer.WriteLine("// The file was set to read-only for a reason ;)\n");
            buffer.WriteLine("version 1");
            foreach (object rawArray in Categories)
            {
                IList array = rawArray as IList;
                if (array.Count > 0)
                {
                    for (int i = 0; i < array.Count; i++)
                    {
                        IStudioMdlEntity entity = array[i] as IStudioMdlEntity;
                        if (i == 0) buffer.WriteLine("\n" + entity.GroupName);
                        entity.Write(buffer, array, array[i]);
                    }
                    buffer.WriteLine("end");
                }
            }
            return buffer.ToString();
        }

        public StudioMdlWriter()
        {
            Nodes = new List<Node>();
            Skeleton = new List<BoneKeyframe>();
            Triangles = new List<Triangle>();
            Materials = new Dictionary<string, Material>();
            Categories = new List<object>() { Nodes, Skeleton, Triangles };
        }
    }
}