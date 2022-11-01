using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int NumPoints = 3;
    private List<Vector3> _vertices;
    private Transform _transform;

    public void CreateTiles()
    {
        _vertices = GetComponent<MeshFilter>().sharedMesh.vertices.ToList();
        _transform = GetComponent<Transform>();

        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }

        var lenghtX = _vertices[0].x - _vertices[10].x;
        var lengthZ = _vertices[0].z - _vertices[110].z;
        
        var tilePositions = BoardCalculator.GetPoints(lenghtX, lengthZ, NumPoints);

        foreach (var tilePosition in tilePositions)
        {
            var plane  = GameObject.CreatePrimitive(PrimitiveType.Plane);
            plane.transform.SetParent(_transform);
            plane.transform.localPosition = new Vector3(tilePosition.X,  _transform.position.y + 0.2f, tilePosition.Z);

            var scaleX = (_transform.localScale.x / NumPoints) / _transform.localScale.x;
            var scaleZ = (_transform.localScale.z / NumPoints) / _transform.localScale.z;
            
            plane.transform.localScale = new Vector3(scaleX , _transform.localScale.y, scaleZ );
        }
    }
}
