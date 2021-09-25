using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GoogleSheetLoader _loader;

    public void AwakeData()
    {
        _loader.OnProcessData += InstantiateCubes;
    }

    private void InstantiateCubes(CubesData data)
    {
        Debug.Log(" OK ");
        var D = Resources.Load<CubesData>("CaracterData");
        D.MinerDataList = data.MinerDataList;
        
        // foreach (var cubeData in data.CubeOptionsList)
        // {
        //     var newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //     newCube.transform.position = cubeData.Position;
        //     newCube.transform.localScale = cubeData.LocalScale;
        //     newCube.GetComponent<MeshRenderer>().material.color = cubeData.Color;
        //
        // }
    }
}
