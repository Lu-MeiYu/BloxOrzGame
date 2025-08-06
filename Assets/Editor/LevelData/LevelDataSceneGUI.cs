using System.Collections.Generic;
using HomeWork.GameSystem;
using UnityEditor;
using UnityEngine;
namespace HomeWork.LevelEditor
{
    /// <summary>
    /// 處理 Scene View 上的互動繪製
    /// </summary>
    internal class LevelDataSceneGUI
    {
        private const string _editorUsePlanePath = "EditorUsePlane.prefab";
        private const float _hintRadius = 0.5f;
        private Vector3 _tileSize = new Vector3(1, 0.1f, 1);
        private Vector3 _hintLabelOffset = new Vector3(-0.1f, 0, 0);
        private Vector3 _editorPlaneSize = new Vector3(50, 0.1f, 50);
        private Vector3 _cameraLookTarget = Vector3.zero;
        private LevelData _data;
        private LevelDataInspector _inspector;
        private LevelDataPathAnalyzer _analyzer;
        private Dictionary<Vector2, GameObject> _views = new();
        private GUIStyle _labelStyle;
        private GameObject _editorPlane;
        private GUIStyle LabelStyle
        {
            get
            {
                if (_labelStyle == null)
                {
                    _labelStyle = new GUIStyle(EditorStyles.label)
                    {
                        fontSize = 12,
                        normal = { textColor = Color.blue }
                    };
                }
                return _labelStyle;
            }
        }

        public LevelDataSceneGUI(LevelData data, LevelDataInspector inspector, LevelDataPathAnalyzer analyzer)
        {
            _data = data;
            _inspector = inspector;
            _analyzer = analyzer;
        }

        public void Enable()
        {
            SceneView.duringSceneGui += OnSceneGUI;

            SetCameraPivot();

            CreateEditPlane();
        }
        public void Disable()
        {
            SceneView.duringSceneGui -= OnSceneGUI;

            DestoryEditPlane();
        }

        public void ShowAll()
        {
            foreach (var p in _data.Tiles)
            {
                Create(p);
            }
        }

        public void Add(Vector2 point)
        {
            _data.Tiles.Add(point);
            Create(point);
        }

        public void Remove(Vector2 point)
        {
            _data.Tiles.Remove(point);
            if (_views.TryGetValue(point, out var go))
            {
                Object.DestroyImmediate(go);
            }
            _views.Remove(point);
        }

        public void Clear()
        {
            foreach (var go in _views.Values) Object.DestroyImmediate(go);
            {
                _views.Clear();
            }
        }

        private void SetCameraPivot()
        {
            var sv = SceneView.lastActiveSceneView;
            sv.pivot = _cameraLookTarget;
            sv.Repaint();
        }

        private void CreateEditPlane()
        {
            _editorPlane = GameObject.Instantiate(EditorGUIUtility.Load(_editorUsePlanePath) as GameObject);
            if (_editorPlane == null)
            {
                Debug.LogError($"無法找到編輯器用偵測物件，請確認物件路徑是否為{_editorUsePlanePath}");
            }
            _editorPlane.layer = 1 << LayerMask.NameToLayer("Editor");
            _editorPlane.transform.localScale = _editorPlaneSize;
            _editorPlane.hideFlags = HideFlags.HideAndDontSave;
        }
        private void DestoryEditPlane()
        {
            if (_editorPlane != null)
            {
                GameObject.DestroyImmediate(_editorPlane);
            }
        }

        private void Create(Vector2 point)
        {
            if (_views.ContainsKey(point))
            {
                Debug.LogWarning($"{nameof(LevelDataEditor)}已經有{point}這個地磚了!");
                return;
            }
            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.transform.position = new Vector3(point.x, 0, point.y);
            go.transform.localScale = _tileSize;
            go.hideFlags = HideFlags.HideAndDontSave;
            _views[point] = go;
        }

        private void OnSceneGUI(SceneView sceneView)
        {
            DrawHint(Vector3.zero, "(0,0)", Color.black);
            DrawHint(_data.StartPoint, "Start", Color.green);
            DrawHint(_data.EndPoint, "End", Color.red);

            if (!_inspector.IsEditing)
            {
                return;
            }

            DrawHandle(ref _data.StartPoint, "Move Start");
            DrawHandle(ref _data.EndPoint, "Move End");

            Handles.color = Color.blue;
            foreach (var point in _data.Tiles)
            {
                Handles.DrawWireCube(new Vector3(point.x, 0, point.y), _tileSize);
            }

            HandleClicks();
        }

        private void DrawHint(Vector2 point, string label, Color color)
        {
            Handles.color = color;
            var position = new Vector3(point.x, 0, point.y);
            Handles.DrawWireDisc(position, Vector3.up, _hintRadius);
            Handles.Label(position + _hintLabelOffset, label, LabelStyle);
        }

        private void DrawHandle(ref Vector2 field, string undoName)
        {
            EditorGUI.BeginChangeCheck();
            var newPos = Handles.PositionHandle(
                new Vector3(field.x, 0, field.y),
                Quaternion.identity
            );
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(_data, undoName);
                field = new Vector2(Mathf.Round(newPos.x), Mathf.Round(newPos.z));
                EditorUtility.SetDirty(_data);
                _analyzer.Calculate();
            }
        }

        private void HandleClicks()
        {
            int id = GUIUtility.GetControlID(FocusType.Passive);
            HandleUtility.AddDefaultControl(id);

            var currentEvent = Event.current;
            if ((currentEvent.type == EventType.MouseDown) && (currentEvent.button == 0) && (!currentEvent.alt))
            {
                var ray = HandleUtility.GUIPointToWorldRay(currentEvent.mousePosition);
                if (Physics.Raycast(ray, out var hit))
                {
                    Vector2 point = new Vector2(
                        Mathf.Round(hit.point.x),
                        Mathf.Round(hit.point.z)
                    );
                    Undo.RecordObject(_data, "Toggle Tile");
                    if (_data.Tiles.Contains(point))
                    {
                        Remove(point);
                    }
                    else
                    {
                        Add(point);
                    }
                    EditorUtility.SetDirty(_data);
                    _analyzer.Calculate();
                    currentEvent.Use();
                }
            }
        }
    }
}
