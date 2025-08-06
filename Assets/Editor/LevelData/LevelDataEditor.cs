using UnityEditor;
using HomeWork.GameSystem;
namespace HomeWork.LevelEditor
{
    [CustomEditor(typeof(LevelData))]
    public class LevelDataEditor : Editor
    {
        private LevelDataInspector _inspector;
        private LevelDataSceneGUI _sceneGUI;
        private LevelDataPathAnalyzer _analyzer;
        private IPathFinder _pathFinder;

        private LevelData Data => (LevelData)target;

        private void OnEnable()
        {
            
            _inspector = new LevelDataInspector(serializedObject, Data);

            IBlockLogic blockLogic = new CuboidBlock();
            _pathFinder = new BFSPathFinder(new GameLogic(blockLogic), blockLogic);

            _analyzer = new LevelDataPathAnalyzer(Data, _pathFinder);
            _sceneGUI = new LevelDataSceneGUI(Data, _inspector, _analyzer);

            _sceneGUI.Enable();
            _sceneGUI.ShowAll();
            _analyzer.Calculate();
        }

        private void OnDisable()
        {
            _sceneGUI.Disable();
            _sceneGUI.Clear();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            _inspector.DrawFields();
            _inspector.DrawTileList();
            _inspector.DrawEditButton();

            _analyzer.DrawResult();
        }
    }
    
}