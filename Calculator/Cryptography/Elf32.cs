// Copyright (c) Damien Guard.  All rights reserved.
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Originally published at http://damieng.com/blog/2007/11/24/calculating-elf-32-in-c-and-net

namespace DamienG.Security.Cryptography
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;

    /// <summary>
    /// Implements a 32-bit ELF hash algorithm compatible with ELF binary format.
    /// </summary>
    public sealed class Elf32 : HashAlgorithm
    {
        private uint hash;

        public Elf32()
        {
            this.hash = 0;
        }

        public override int HashSize => 32;

        public static uint Compute(byte[] buffer) => CalculateHash(0, buffer, 0, buffer.Length);

        public static uint Compute(uint seed, byte[] buffer) => CalculateHash(seed, buffer, 0, buffer.Length);

        public override void Initialize() => this.hash = 0;

        protected override void HashCore(byte[] array, int ibStart, int cbSize) => this.hash = CalculateHash(this.hash, array, ibStart, cbSize);

        protected override byte[] HashFinal()
        {
            byte[]? hashBuffer = UInt32ToBigEndianBytes(this.hash);
            this.HashValue = hashBuffer;
            return hashBuffer;
        }

        private static uint CalculateHash(uint seed, IList<byte> buffer, int start, int size)
        {
            uint hash = seed;

            for (int i = start; i < start + size; i++)
            {
                hash = (hash << 4) + buffer[i];
                uint work = hash & 0xf0000000u;
                hash ^= work >> 24;
                hash &= ~work;
            }

            return hash;
        }

        private static byte[] UInt32ToBigEndianBytes(uint uint32)
        {
            byte[]? result = BitConverter.GetBytes(uint32);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(result);
            }

            return result;
        }
    }
}
