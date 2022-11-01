using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    [CustomEditor(typeof(Board))]
    public class BoardEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            var board = (Board)target;
            if (GUILayout.Button("Create tiles"))
            {
                board.CreateTiles();
            }
        }
    }
}