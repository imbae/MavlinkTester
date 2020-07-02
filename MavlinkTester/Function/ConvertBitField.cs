using System;

namespace MavlinkTester.Function
{
    public static class ConvertBitField
    {
        public static T GetBitField<T>(byte data, byte offset, byte length)
        {
            byte mask = 1;
            byte exMask = 0;

            for (int i = 0; i < length; i++)
            {
                mask |= (byte)(1 << i);
            }

            exMask ^= (byte)(mask << offset);

            return (T)Convert.ChangeType(((data & exMask) >> offset), typeof(T));
        }

        public static T GetBitField<T>(int data, byte offset, byte length)
        {
            int mask = 1;
            int exMask = 0;

            for (int i = 0; i < length; i++)
            {
                mask |= (1 << i);
            }

            exMask ^= (mask << offset);

            return (T)Convert.ChangeType(((data & exMask) >> offset), typeof(T));
        }

        public static int SetBitField(int data, int result, byte offset, byte length)
        {
            int mask = 1;
            uint exMask = 0xFFFFFFFF;

            for (int i = 0; i < length; i++)
            {
                mask |= (1 << i);
            }

            exMask ^= (uint)(mask << offset);
            result &= (int)exMask;

            result |= (data & mask) << offset;

            return result;
        }

        public static byte SetBitField(short data, byte result, byte offset, byte length)
        {
            byte mask = 1;
            byte exMask = 0xFF;

            for (int i = 0; i < length; i++)
            {
                mask |= (byte)(1 << i);
            }

            exMask ^= (byte)(mask << offset);
            result &= exMask;

            result |= (byte)((data & mask) << offset);

            return result;
        }

        public static byte SetBitField(ushort data, byte result, byte offset, byte length)
        {
            byte mask = 1;
            byte exMask = 0xFF;

            for (int i = 0; i < length; i++)
            {
                mask |= (byte)(1 << i);
            }

            exMask ^= (byte)(mask << offset);
            result &= exMask;

            result |= (byte)((data & mask) << offset);

            return result;
        }

        public static byte SetBitField(sbyte data, byte result, byte offset, byte length)
        {
            sbyte mask = 1;
            byte exMask = 0xFF;

            for (int i = 0; i < length; i++)
            {
                mask |= (sbyte)(1 << i);
            }

            exMask ^= (byte)(mask << offset);
            result &= exMask;

            result |= (byte)((data & mask) << offset);

            return result;
        }

        public static ushort SetBitField(ushort data, ushort result, byte offset, byte length)
        {
            ushort mask = 1;
            ushort exMask = 0xFFFF;

            for (int i = 0; i < length; i++)
            {
                mask |= (ushort)(1 << i);
            }

            exMask ^= (ushort)(mask << offset);
            result &= exMask;

            result |= (ushort)((data & mask) << offset);

            return result;
        }

        public static ushort SetBitField(sbyte data, ushort result, byte offset, byte length)
        {
            ushort mask = 1;
            ushort exMask = 0xFFFF;

            for (int i = 0; i < length; i++)
            {
                mask |= (ushort)(1 << i);
            }

            exMask ^= (ushort)(mask << offset);
            result &= exMask;

            result |= (ushort)((data & mask) << offset);

            return result;
        }


        public static short SetBitField(short data, short result, byte offset, byte length)
        {
            short mask = 1;
            ushort exMask = 0xFFFF;

            for (int i = 0; i < length; i++)
            {
                mask |= (short)(1 << i);
            }

            exMask ^= (ushort)(mask << offset);
            result &= (short)exMask;

            result |= (short)((data & mask) << offset);

            return result;
        }
    }
}
