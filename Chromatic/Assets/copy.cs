using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copy : MonoBehaviour
{
    public Terrain terrain;
    public GameObject copyToObject;

    void Start(){
        var bounds = terrain.terrainData.bounds;
        var mf  = copyToObject.GetComponent<MeshFilter>();
        var m = mf.mesh;
        List<Vector3> newVerts = new List <Vector3>();
        foreach (var vert in m.vertices){
            var wPos = copyToObject.transform.localToWorldMatrix * vert;
            var newVert = vert;

            newVert.z = terrain.SampleHeight(wPos);
            newVerts.Add(newVert);
        }

        m.SetVertices(newVerts.ToArray());

        m.RecalculateNormals();
        m.RecalculateTangents();
        m.RecalculateBounds();
    }
}
