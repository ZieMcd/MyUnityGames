using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using UnityEngine;

public class DrawVertices : MonoBehaviour
{

    public int NumPoints = 3;

    private void OnDrawGizmos()
    {
        var vertices = GetComponent<MeshFilter>().sharedMesh.vertices;
        Gizmos.matrix = transform.localToWorldMatrix;

        var counter = 0;
        foreach (var vertex in vertices)
        {
            Gizmos.color = counter switch
            {
                0 => Color.red,
                10 => Color.blue,
                110 => Color.green,
                120 => Color.yellow,
                _ => Color.gray
            };

           // Gizmos.DrawSphere(vertex, (float)0.2);
            counter++;
        }


        var lenghtX = vertices[0].x - vertices[10].x;
        var lengthZ = vertices[0].z - vertices[110].z;

        var points = BoardCalculator.GetPoints(lenghtX, lengthZ, NumPoints);
        
        foreach (var point in points)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawSphere(new Vector3(point.X, vertices[0].y, point.Z), 0.1f);
        }
    }
}
