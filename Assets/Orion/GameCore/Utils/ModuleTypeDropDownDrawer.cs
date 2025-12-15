using System;
using System.Linq;
using Orion.GameCore.Modules;
using Orion.GameCore.Utils.Attributes;
using UnityEditor;
using UnityEngine;

namespace Orion.GameCore.Utils
{
    [CustomPropertyDrawer(typeof(ModuleTypeAttribute))]
    public class ModuleTypeDropDownDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                EditorGUI.LabelField(position, label.text, "Use ModuleType with string.");
                return;
            }

            // Получаем все типы, реализующие IModule
            var moduleTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => typeof(IFunctionalModule).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                .ToArray();

            string[] typeNames = moduleTypes.Select(t => t.FullName).ToArray();
        
            int selectedIndex = Array.IndexOf(typeNames, property.stringValue);
            if (selectedIndex < 0) selectedIndex = 0;

            selectedIndex = EditorGUI.Popup(position, label.text, selectedIndex, typeNames);
        
            if (selectedIndex >= 0 && selectedIndex < typeNames.Length)
            {
                property.stringValue = typeNames[selectedIndex];
            }
        }
    }
}