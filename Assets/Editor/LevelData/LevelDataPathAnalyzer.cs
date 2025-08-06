using HomeWork.GameSystem;
using UnityEditor;
namespace HomeWork.LevelEditor
{
    /// <summary>
    /// 找最短路徑並在 Inspector 顯示結果
    /// </summary>
    internal class LevelDataPathAnalyzer
    {
        private LevelData _data;
        private IPathFinder _finder;
        private string _result;

        public LevelDataPathAnalyzer(LevelData data, IPathFinder finder)
        {
            _data = data;
            _finder = finder;
        }

        public void Calculate()
        {
            if ((!_data.Tiles.Contains(_data.StartPoint)) || (!_data.Tiles.Contains(_data.EndPoint)))
            {
                _result = string.Empty;
                return;
            }
            _finder.SetData(_data);
            if (_finder.FindPath(out var path))
            {
                _result = path.Count > 0 ? $"{path.Count} steps to solve" : "Start == End";
            }
            else
            {
                _result = "No solution";
            }
        }

        public void DrawResult()
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField(_result);
        }
    }
}