﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACRCloud_File_Scan
{
    public class SaveData//保存
    {
        public static Dictionary<int, Data> dicData = new Dictionary<int, Data>();

        public static void Save(int i, Data d)//
        {
            dicData.Add(i, d);   
        }

        public static void Clear()
        {
            dicData.Clear();
        }
    }
}
