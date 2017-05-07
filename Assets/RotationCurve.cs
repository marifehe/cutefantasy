using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorGUICurveField : EditorWindow
{
    AnimationCurve playerRotY = AnimationCurve.Linear(0, 0, 0, 20);

    [MenuItem("Examples/Curve Field demo")]
    static void Init()
    {
        EditorWindow window = GetWindow(typeof(EditorGUICurveField));
        window.position = new Rect(0, 0, 400, 199);
        window.Show();
    }

    void OnGUI()
    {
        playerRotY = EditorGUI.CurveField(
                new Rect(3, 3, position.width - 6, 50),
                "Animation on Y", playerRotY);        

        if (GUI.Button(new Rect(3, 163, position.width - 6, 30), "Generate Curve"))
            AddCurveToSelectedGameObject();
    }

    // A GameObject with the RotatePlayerOnTurn script must be selected
    void AddCurveToSelectedGameObject()
    {
        if (Selection.activeGameObject)
        {
            RotatePlayerOnTurn comp =
                Selection.activeGameObject.GetComponent<RotatePlayerOnTurn>();
            comp.SetCurves(playerRotY);
        }
        else
        {
            Debug.LogError("No Game Object selected for adding an animation curve");
        }
    }
}
