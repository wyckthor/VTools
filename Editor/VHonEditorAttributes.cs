using UnityEngine;
using UnityEditor;

// ------------------------------------------------------------------------------------------------------------------------ 
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

// ------------------------------------------------------------------------------------------------------------------------
[CustomPropertyDrawer(typeof(LineAttribute))]
public class LineDrawer : DecoratorDrawer
{
    public override void OnGUI(Rect position)
    {
        Rect lineRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * 1, position.width * 0.98f, 1f);

        float gray = 0.36f;
        EditorGUI.DrawRect(lineRect, new Color(gray, gray, gray));
    }

    public override float GetHeight() => base.GetHeight() + EditorGUIUtility.singleLineHeight * 0.5f;
}

// ------------------------------------------------------------------------------------------------------------------------
[CustomPropertyDrawer(typeof(BlockAttribute))]
public class BlockDrawer : DecoratorDrawer
{
    public override void OnGUI(Rect position)
    {
        BlockAttribute lineAttribute = (BlockAttribute)attribute;

        Rect titleRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight * 2.1f);
        Rect lineRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * 1.7f, position.width * 0.98f, 1f);

        float gray = 0.36f;
        EditorGUI.DrawRect(lineRect, new Color(gray, gray, gray));

        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontStyle = FontStyle.Bold;
        float gray2 = 0.46f;
        style.normal.textColor = new Color(gray2, gray2, gray2);
        EditorGUI.LabelField(titleRect, lineAttribute.title, style);
    }

    public override float GetHeight() => base.GetHeight() + EditorGUIUtility.singleLineHeight * 1.1f;
}
// ------------------------------------------------------------------------------------------------------------------------