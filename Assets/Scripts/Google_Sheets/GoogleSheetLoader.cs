using System;
using UnityEngine;
using System.Collections;

[ExecuteInEditMode, RequireComponent(typeof(CVSLoader), typeof(SheetProcessor))]
public class GoogleSheetLoader : MonoBehaviour
{
    public event Action<CubesData> OnProcessData;
    
    [SerializeField] private string _sheetId;
    [SerializeField] private CubesData _data;
//    [SerializeField] private MinerStats Mdata;
    
    private CVSLoader _cvsLoader;
    private SheetProcessor _sheetProcessor;
    public CubeSpawner _cubeSpawner;
    
    public bool UpDate = false;

    private void Update()
    {
        if (UpDate)
        {
            DoMyWork();
            UpDate = false;
        }
    }

    private void DoMyWork()
    {
        Debug.Log("Start Edit");
        StartData();
        _cubeSpawner.AwakeData();
    }

//    private void Start()
    private void StartData()
    {
        _cvsLoader = GetComponent<CVSLoader>();
        _sheetProcessor = GetComponent<SheetProcessor>();
        DownloadTable();
    }

    private void DownloadTable()
    {
        _cvsLoader.DownloadTable(_sheetId, OnRawCVSLoaded);
    }

    private void OnRawCVSLoaded(string rawCVSText)
    {
        _data = _sheetProcessor.ProcessData(rawCVSText);
        
        OnProcessData?.Invoke(_data);
    }
    
}
