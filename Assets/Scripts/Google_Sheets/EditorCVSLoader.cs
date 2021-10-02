using System.Collections;

using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GoogleSheetLoader))]
public class EditorCVSLoader : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GoogleSheetLoader myScript = (GoogleSheetLoader)target;
        if(GUILayout.Button("Load Data"))
        {
            myScript.DoMyWork();;
        }
    }
}
