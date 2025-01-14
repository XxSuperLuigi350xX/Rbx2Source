﻿using System.Collections.Generic;

namespace Rbx2Source.Reflection.BinaryFormat
{
    public class META
    {
        public int NumEntries;
        public Dictionary<string, string> Entries;

        public META(RobloxBinaryChunk chunk)
        {
            using (RobloxBinaryReader reader = chunk.GetReader("META"))
            {
                NumEntries = reader.ReadInt32();
                Entries = new Dictionary<string, string>(NumEntries);

                for (int i = 0; i < NumEntries; i++)
                {
                    string key = reader.ReadString();
                    string value = reader.ReadString();
                    Entries.Add(key, value);
                }
            }
        }
    }
}
