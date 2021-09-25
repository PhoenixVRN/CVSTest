using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "CaracterData", menuName = "Caracter / Caracter Data", order = 51)]
//[System.Serializable]
public class CubesData : ScriptableObject
{
    [Header("Miner")]
    public List<MinersData> MinerDataList;
    

    public override string ToString()
    {
        string result = "";
        MinerDataList.ForEach(o =>
        {
            result += o.ToString();
        });
        return result;
    }
}

// [System.Serializable, CreateAssetMenu(fileName = "CaracterData", menuName = "Caracter / Caracter Data", order = 51)]
// public class MinerStats: ScriptableObject
// {
//     public List<CubesData> MinerStat;
// }

[System.Serializable]
public class MinersData
{
    
    public string Unit_Id;
    public int Level_Upgrade;
    public float Work_Efficiency;
    public float Speed;
    public float Carried_Speed;
    public float Critical_Power;
    public float Critical_Chance;
    public float Max_Carried_Resources;
    public float Working_Speed_X_Multiplier;
    public float Upgrade_Price_Soft_Currency;

    
    public override string ToString()
    {
        return $"Id {Unit_Id} \nPosition {Level_Upgrade} \nLocalScale {Work_Efficiency} \nSpeed {Speed} \nCarried_Speed {Carried_Speed} \nCritical_Power{Critical_Power}" +
               $"\nCritical_Chance {Critical_Chance} \nMax_Carried_Resources {Max_Carried_Resources} \nWorking_Speed_X_Multiplier {Working_Speed_X_Multiplier}" +
               $" \nUpgrade_Price_Soft_Currency {Upgrade_Price_Soft_Currency}";
    }
}