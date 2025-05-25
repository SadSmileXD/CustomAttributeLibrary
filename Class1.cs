
using UnityEngine;
using UnityEditor;
using System;
using System.Linq;
using System.Reflection;
 

namespace customlibrary
{
  
    // 모든 enum 타입에 적용
    [CustomPropertyDrawer(typeof(Enum), true)]
    public class GenericEnumDisplayNameDrawer : PropertyDrawer
    {
        public override bool CanCacheInspectorGUI(SerializedProperty property) => false;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.Enum)
            {
                EditorGUI.PropertyField(position, property, label, true);
                return;
            }

            var enumType = fieldInfo.FieldType;
            var enumValues = Enum.GetValues(enumType);
            string[] displayNames = new string[enumValues.Length];

            for (int i = 0; i < enumValues.Length; i++)
            {
                var field = enumType.GetField(enumValues.GetValue(i).ToString());
                var attr = field?.GetCustomAttribute<EnumDisplayNameAttribute>();
                displayNames[i] = attr != null ? attr.DisplayName : field.Name;
            }

            int selectedIndex = property.enumValueIndex;
            selectedIndex = EditorGUI.Popup(position, label.text, selectedIndex, displayNames);
            property.enumValueIndex = selectedIndex;
        }
    }
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumDisplayNameAttribute : Attribute
    {
        public string DisplayName { get; }

        public EnumDisplayNameAttribute(string name)
        {
            DisplayName = name;
        }
    }


 
  

}

/*
 종속성->참조추가
using UnityEngine;
using UnityEditor;
UnityEngine.IMGUIModule.dll
UnityEngine.CoreModule.dll
UnityEditor.CoreModule.dll
참조해야함

 */

