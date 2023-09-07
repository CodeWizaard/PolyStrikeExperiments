using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class BuildMesh : MonoBehaviour
{
    public NavMeshSurface surfaces;
    void Start()
    {
       
    }

    private void ClearNavigationData() {
        NavMesh.RemoveAllNavMeshData();
    }

    private void CreateNavigationData()
    {
        surfaces.BuildNavMesh();
    }


} 
