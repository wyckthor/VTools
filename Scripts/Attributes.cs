using System;
using UnityEngine;
using UnityEditor;

// [Line]
// [Spacer]
// [ReadOnly]
// [Block("Label")]

// ------------------------------------------------------------------------------------------------------------------------
public class LineAttribute : PropertyAttribute { }

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(LineAttribute))]
public class LineDrawer : DecoratorDrawer
{
    public override void OnGUI(Rect position)
    {
        Rect lineRect = new(position.x, position.y + EditorGUIUtility.singleLineHeight * 1, position.width * 0.98f, 1f);

        float gray = 0.36f;
        EditorGUI.DrawRect(lineRect, new Color(gray, gray, gray));
    }

    public override float GetHeight() => base.GetHeight() + EditorGUIUtility.singleLineHeight * 0.5f;
}
#endif

// ------------------------------------------------------------------------------------------------------------------------
public class SpacerAttribute : PropertyAttribute { }

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(SpacerAttribute))]
public class SpacerDrawer : DecoratorDrawer
{
    public override void OnGUI(Rect position)
    {
        Rect lineRect = new(position.x, position.y + EditorGUIUtility.singleLineHeight * 1, 1, 1f);
        EditorGUI.DrawRect(lineRect, new Color(0, 0, 0, 0));
    }
}
#endif

// ------------------------------------------------------------------------------------------------------------------------
public class ReadOnlyAttribute : PropertyAttribute { }

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnly : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginDisabledGroup(true);
        EditorGUI.PropertyField(position, property, label);
        EditorGUI.EndDisabledGroup();
    }
}
#endif

// ------------------------------------------------------------------------------------------------------------------------
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
public class BlockAttribute : PropertyAttribute
{
    public string title;
    public BlockAttribute(string _title) => title = _title;
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(BlockAttribute))]
public class BlockDrawer : DecoratorDrawer
{
    public override void OnGUI(Rect position)
    {
        BlockAttribute blockAttribute = (BlockAttribute)attribute;

        Rect titleRect = new(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight * 2.1f);
        Rect lineRect = new(position.x, position.y + EditorGUIUtility.singleLineHeight * 1.7f, position.width * 0.98f, 1f);

        float gray = 0.36f;
        EditorGUI.DrawRect(lineRect, new Color(gray, gray, gray));

        GUIStyle style = new(GUI.skin.label) { fontStyle = FontStyle.Bold };
        float gray2 = 0.46f;
        style.normal.textColor = new Color(gray2, gray2, gray2);
        EditorGUI.LabelField(titleRect, blockAttribute.title, style);
    }

    public override float GetHeight() => base.GetHeight() + EditorGUIUtility.singleLineHeight * 1.1f;
}
#endif

// ------------------------------------------------------------------------------------------------------------------------
    // #if UNITY_EDITOR        
    // [CustomEditor(typeof(PlayerSO))]
    // public class ButtonEditor : Editor
    // {
    //     public override void OnInspectorGUI()
    //     {
    //         base.OnInspectorGUI();                
    //         if (GUILayout.Button("Init")) ((PlayerSO)target).Init();
    //         if (GUILayout.Button("Reset")) ((PlayerSO)target).Reset();
    //     }
    // }
    // #endif
// ------------------------------------------------------------------------------------------------------------------------        