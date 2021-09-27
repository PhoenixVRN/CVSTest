using System;
using UnityEngine;
using System.Collections;

[ExecuteInEditMode, RequireComponent(typeof(CVSLoader), typeof(SheetProcessor))]
public class GoogleSheetLoader : MonoBehaviour
{
    public event Action<MinerAllLists> OnProcessData;
    
    [SerializeField] private string _sheetId;
    [SerializeField] private string _sheetTabId;
    [SerializeField] private MinerAllLists _data;

    
    private CVSLoader _cvsLoader;
    private SheetProcessor _sheetProcessor;
    public CubeSpawner _cubeSpawner;
    

    public void DoMyWork()
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
        _cvsLoader.DownloadTable(_sheetId, _sheetTabId, OnRawCVSLoaded);
    }

    private void OnRawCVSLoaded(string rawCVSText)
    {
        _data = _sheetProcessor.ProcessData(rawCVSText);
        
        OnProcessData?.Invoke(_data);
    }
    
}
