﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Manage_LAN.Library_Class
{
    internal static class WakeOnLan
    {
        private static string _path;
        public static string[] Lines;
        
        public static byte[] StrToMac(string macAddress)
        {
            Debug.Assert(macAddress != null, "s != null");
            List<Byte> arr = new List<Byte>( 6 );
            for (int i = 0; i < 6; i++)
            {
                arr.Add(0xff);
            }
            for (int i = 0; i < 16; i++)
            {
                arr.AddRange(macAddress.Split(' ', ':', '-').Select(byteStr => Convert.ToByte(byteStr, 16)));
            }
            return arr.ToArray();
        }

        internal static void ReadFromFile()
        {
            _path = $"{Directory.GetCurrentDirectory()}\\data\\{Form1.RoomNumber}.txt";
            Lines = File.ReadAllLines(_path);
        }
    }
}
