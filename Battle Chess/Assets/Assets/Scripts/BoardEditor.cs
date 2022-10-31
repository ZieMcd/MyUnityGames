using UnityEditor;

namespace Assets.Scripts
{
    [CustomEditor(typeof(Board))]
    public class BoardEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var board = (Board)target;
        }
    }
}