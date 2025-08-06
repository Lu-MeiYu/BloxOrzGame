using HomeWork.GameSystem;
using UnityEditor;
using UnityEngine;
namespace HomeWork.LevelEditor
{
    /// <summary>
    /// 負責在 Inspector 畫面上顯示 Start/End、Tile List 以及編輯開關
    /// </summary>
internal class LevelDataInspector
    {
        private SerializedObject _so;
        private LevelData _data;
        private SerializedProperty _startProp;
        private SerializedProperty _endProp;
        private GUIStyle _labelStyle;
        private bool _tilesExpanded;
        public bool IsEditing { get; private set; }
        private GUIStyle LabelStyle
        {
            get
            {
                if (_labelStyle == null)
                {
                    _labelStyle = new GUIStyle(EditorStyles.label)
                    {
                        fontSize = 12,
                        normal = { textColor = Color.red }
                    };
                }
                return _labelStyle;
            }
        }

        public LevelDataInspector(SerializedObject so, LevelData data)
        {
            _so = so;
            _data = data;
            _startProp = so.FindProperty("StartPoint");
            _endProp = so.FindProperty("EndPoint");
        }

        public void DrawFields()
        {
            EditorGUILayout.LabelField("Start / End Points", EditorStyles.boldLabel);
            EditorGUI.BeginChangeCheck();

            EditorGUILayout.PropertyField(_startProp);
            if (!_data.Tiles.Contains(_data.StartPoint))
            {
                EditorGUILayout.LabelField("StartPoint is invalid!", LabelStyle);
            }

            EditorGUILayout.PropertyField(_endProp);
            if (!_data.Tiles.Contains(_data.EndPoint))
            {
                EditorGUILayout.LabelField("EndPoint is invalid!", LabelStyle);
            }

            if (EditorGUI.EndChangeCheck() && IsEditing)
            {
                _data.StartPoint = Round(_startProp.vector2Value);
                _data.EndPoint = Round(_endProp.vector2Value);
                EditorUtility.SetDirty(_data);
                SceneView.lastActiveSceneView?.Repaint();
            }
        }

        public void DrawTileList()
        {
            _tilesExpanded = EditorGUILayout.Foldout(_tilesExpanded, "Tiles", true);
            if (!_tilesExpanded)
            {
                return;
            }

            int i = 1;
            foreach (var point in _data.Tiles)
            {
                EditorGUILayout.Vector2Field($"Tile {i++}", point);
            }
        }

        public void DrawEditButton()
        {
            if (GUILayout.Button(IsEditing ? "Stop Edit" : "Edit"))
            {
                IsEditing = !IsEditing;
                SceneView.lastActiveSceneView?.Repaint();
            }
        }
        private static Vector2 Round(Vector2 value) => new Vector2(Mathf.Round(value.x), Mathf.Round(value.y));
    }
}
