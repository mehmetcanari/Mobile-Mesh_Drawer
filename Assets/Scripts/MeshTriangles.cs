using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MeshTriangles
{
    public static void TriangleDefining(List<int> triangles)
    {
        //Front Face
        triangles[0] = 0;
        triangles[1] = 2;
        triangles[2] = 1;
        triangles[3] = 0;
        triangles[4] = 3;
        triangles[5] = 2;

        //Top Face
        triangles[6] = 2;
        triangles[7] = 3;
        triangles[8] = 4;
        triangles[9] = 2;
        triangles[10] = 4;
        triangles[11] = 5;

        //Right Face
        triangles[12] = 1;
        triangles[13] = 2;
        triangles[14] = 5;
        triangles[15] = 1;
        triangles[16] = 5;
        triangles[17] = 6;

        //Left Face
        triangles[18] = 0;
        triangles[19] = 7;
        triangles[20] = 4;
        triangles[21] = 0;
        triangles[22] = 4;
        triangles[23] = 3;

        //Back Face
        triangles[24] = 5;
        triangles[25] = 4;
        triangles[26] = 7;
        triangles[27] = 5;
        triangles[28] = 7;
        triangles[29] = 6;

        //Bottom Face
        triangles[30] = 0;
        triangles[31] = 6;
        triangles[32] = 7;
        triangles[33] = 0;
        triangles[34] = 1;
        triangles[35] = 6;
    }
}
