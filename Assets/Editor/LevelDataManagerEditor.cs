using HomeWork.GameSystem;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
namespace HomeWork.LevelEditor
{
    [CustomEditor(typeof(LevelDataManager))]
    public class LevelDataManagerEditor : Editor
    {
        private LevelDataManager _levelDatas;
        private ReorderableList _list;

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            _list.DoLayoutList();
            if (GUILayout.Button("CreateNewLevel"))
            {
                CreateNewLevelAsset();
            }
            serializedObject.ApplyModifiedProperties();
        }

        private void OnEnable()
        {
            var prop = serializedObject.FindProperty("_levels");
            _list = new ReorderableList(serializedObject, prop,
                draggable: true, displayHeader: true,
                displayAddButton: true, displayRemoveButton: true);

            _list.drawHeaderCallback = rect =>
            {
                EditorGUI.LabelField(new Rect(rect.width/2, rect.y, rect.width/2, rect.height), "LevelList");
            };

            _list.drawElementCallback = (rect, index, isActive, isFocused) =>
            {
                var element = prop.GetArrayElementAtIndex(index);
                rect.y += 2;

                EditorGUI.PropertyField(
                    new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight),
                    element,
                    new GUIContent($"Level {index + 1}"));
               
            };
        }
        private void CreateNewLevelAsset()
        {
            _levelDatas = (LevelDataManager)target;
            var newLevel = ScriptableObject.CreateInstance<LevelData>();
            const string folder = "Assets/LevelData";
            string fileName = $"Level_{_levelDatas.MaxCount + 1}.asset";
            string path = AssetDatabase.GenerateUniqueAssetPath($"{folder}/{fileName}");
            if (string.IsNullOrEmpty(path))
            {
                Debug.LogError($"路徑無效!請檢查{folder}路徑是否存在!");
                return;
            }
            AssetDatabase.CreateAsset(newLevel, path);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = newLevel;
            _levelDatas.AddLevelData(newLevel);
            EditorUtility.SetDirty(_levelDatas);
        }
    }
}