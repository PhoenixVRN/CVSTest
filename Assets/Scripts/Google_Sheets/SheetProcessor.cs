using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SheetProcessor : MonoBehaviour
{
    [SerializeField]
    private int dataStartRawIndex = 1;
    [SerializeField]
    private int _countLev = 10;
    [SerializeField]
    private int _countEntity = 6;
    
    // a1,b1,c1,d1
    // a2,b2,c2,d2
    // a3,b3,c3,d3
    
    private const int _id = 0;
    private const int _levUpgrade = 1;
    private const int _work_efficiency = 2;
    private const int _speed = 3;
    private const int _carried_speed = 4;
    private const int _critical_power = 5;
    private const int _critical_chance = 6;
    private const int _max_carried_resources = 7;
    private const int _working_speed_x_multiplier = 8;
    private const int _upgrade_price_soft_currency = 9;

    private const char _cellSeporator = ',';
    private const char _inCellSeporator = ';';
   

    private Dictionary<string, Color> _colors = new Dictionary<string, Color>()
    {
        {"white", Color.white},
        {"black", Color.black},
        {"yellow", Color.yellow},
        {"red", Color.red},
        {"green", Color.green},
        {"blue", Color.blue},
    };
    
    public MinerAllLists ProcessData(string cvsRawData)
    {
        char lineEnding = GetPlatformSpecificLineEnd();
        string[] rows = cvsRawData.Split(lineEnding);
        CubesData data = new CubesData();
        data.MinerDataList = new List<MinersData>();
        
        MinerAllLists minerAllLists = new MinerAllLists();
        minerAllLists.MinerAllList = new List<CubesData>();
//        mData.MinerStat = new List<CubesData>();
       
      


//            for (int i = dataStartRawIndex; i < rows.Length; i++)
            for (int i = dataStartRawIndex; i < _countEntity; i++)
            {
                for (int b = _countLev; b > 0; b--)
                {
                string[] cells = rows[i].Split(_cellSeporator);

                string id = ParseString(cells[_id]);
                int levUpgrade = ParseInt(cells[_levUpgrade]);
                float work_efficiency = ParseFloat(cells[_work_efficiency]);
                float speed = ParseFloat(cells[_speed]);
                float carried_speed = ParseFloat(cells[_carried_speed]);
                float critical_power = ParseFloat(cells[_critical_power]);
                float critical_chance = ParseFloat(cells[_critical_chance]);
                float max_carried_resources = ParseFloat(cells[_max_carried_resources]);
                float working_speed_x_multiplier = ParseFloat(cells[_working_speed_x_multiplier]);
                float upgrade_price_soft_currency = ParseFloat(cells[_upgrade_price_soft_currency]);


                data.MinerDataList.Add(new MinersData()
                {
                    Unit_Id = id + " Lev " + levUpgrade,
                    Level_Upgrade = levUpgrade,
                    Work_Efficiency = work_efficiency,
                    Speed = speed,
                    Carried_Speed = carried_speed,
                    Critical_Power = critical_power,
                    Critical_Chance = critical_chance,
                    Max_Carried_Resources = max_carried_resources,
                    Working_Speed_X_Multiplier = working_speed_x_multiplier,
                    Upgrade_Price_Soft_Currency = upgrade_price_soft_currency
                });
                i++;
                } 
                minerAllLists.MinerAllList.Add(data);
       
        }
      

//        Debug.Log(data.MinerDataList.ToString());
        return minerAllLists;

    }

    private string ParseString(string s)
    {
        string result = s;
        return result;
    }
    private Color ParseColor(string color)
    {
        color = color.Trim();
        Color result = default;
        if (_colors.ContainsKey(color))
        {
            result = _colors[color];
        }
        
        return result;
    }
    
    private Vector3 ParseVector3(string s)
    {
        string[] vectorComponents = s.Split(_inCellSeporator);
        if (vectorComponents.Length < 3)
        {
            Debug.Log("Can't parse Vector3. Wrong text format");
            return default;
        }

        float x = ParseFloat(vectorComponents[0]);
        float y = ParseFloat(vectorComponents[1]);
        float z = ParseFloat(vectorComponents[2]);
        return new Vector3(x, y, z);
    }
    
    private int ParseInt(string s)
    {
        int result = -1;
        if (!int.TryParse(s, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.GetCultureInfo("en-US"), out result))
        {
            Debug.Log("Can't parse int, wrong text");
        }

        return result;
    }
    
    private float ParseFloat(string s)
    {
        float result = -1;
        if (!float.TryParse(s, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.GetCultureInfo("en-US"), out result))
        {
            Debug.Log("Can't pars float,wrong text ");
        }

        return result;
    }
    
    private char GetPlatformSpecificLineEnd()
    {
        char lineEnding = '\n';
#if UNITY_IOS
        lineEnding = '\r';
#endif
        return lineEnding;
    }
}
