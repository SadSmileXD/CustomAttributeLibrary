using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEngine;
 namespace customlibrary
{
    public class InspectorNameAttribute : PropertyAttribute
    {
        public string displayName;
        public InspectorNameAttribute(string name)
        {
            displayName = name;
        }
    }
    [CustomPropertyDrawer(typeof(InspectorNameAttribute))]
    public class InspectorNameDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            InspectorNameAttribute attr = (InspectorNameAttribute)attribute;
            label.text = attr.displayName;
            EditorGUI.PropertyField(position, property, label);
        }
    }
}