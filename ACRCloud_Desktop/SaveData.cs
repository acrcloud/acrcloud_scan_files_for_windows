using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACRCloud_Desktop
{
    public class SaveData//保存
    {
        public static Dictionary<int, Data> dicData = new Dictionary<int, Data>();

        public static void Save(int i, Data d)//
        {
            dicData.Add(i, d);   
        }

    }

    public class SaveCustomData
    {
        public static Dictionary<int, CustomData> dicData = new Dictionary<int, CustomData>();
        public static void Save(int i, CustomData d)//
        {
            dicData.Add(i, d);
        }
 
    }
}
