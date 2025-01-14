﻿using System;

namespace Rbx2Source.Reflection.BinaryFormat
{
    public enum PropertyType
    {
        Unknown,
        String,
        Bool,
        Int,
        Float,
        Double,
        UDim,
        UDim2,
        Ray,
        Faces,
        Axes,
        BrickColor,
        Color3,
        Vector2,
        Vector3,
        Vector2int16,
        CFrame,
        Quaternion,
        Enum,
        Ref,
        Vector3int16,
        NumberSequence,
        ColorSequence,
        NumberRange,
        Rect,
        PhysicalProperties,
        Color3uint8,
        Int64
    }

    public class FileProperty
    {
        public string Name;
        public FileInstance Instance;

        public PropertyType Type;
        public object Value;

        private byte[] RawBuffer = null;
        public bool HasRawBuffer
        {
            get
            {
                if (RawBuffer == null && Value != null)
                {
                    // Improvise what the buffer should be if this is a primitive.
                    switch (Type)
                    {
                        case PropertyType.Int:
                            RawBuffer = BitConverter.GetBytes((int)Value);
                            break;
                        case PropertyType.Int64:
                            RawBuffer = BitConverter.GetBytes((long)Value);
                            break;
                        case PropertyType.Bool:
                            RawBuffer = BitConverter.GetBytes((bool)Value);
                            break;
                        case PropertyType.Float:
                            RawBuffer = BitConverter.GetBytes((float)Value);
                            break;
                        case PropertyType.Double:
                            RawBuffer = BitConverter.GetBytes((double)Value);
                            break;
                    }
                }

                return (RawBuffer != null);
            }
        }

        public override string ToString()
        {
            string typeName = Enum.GetName(typeof(PropertyType), Type);
            string valueLabel = (Value != null ? Value.ToInvariantString() : "null");

            if (Type == PropertyType.String)
                valueLabel = '"' + valueLabel + '"';

            return string.Join(" ", typeName, Name, '=', valueLabel);
        }

        internal void SetRawBuffer(byte[] buffer)
        {
            RawBuffer = buffer;
        }

        public byte[] GetRawBuffer()
        {
            return RawBuffer;
        }
    }
}