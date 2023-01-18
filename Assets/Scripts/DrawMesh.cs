using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DrawMesh : MonoBehaviour
{
    protected int vIndex;
    protected int vIndex0;
    protected int vIndex1;
    protected int vIndex2;
    protected int vIndex3;
    protected int vIndex4;
    protected int vIndex5;
    protected int vIndex6;
    protected int vIndex7;

    public Camera _cam;
    public GameObject _path;
    public Color _color;


    public void StartDraw(InputAction.CallbackContext _context)
    {
        if(!_context.performed)
            return;
        Debug.Log("Start draw");

        StartCoroutine(Draw());
    }

    public void EndDraw(InputAction.CallbackContext _context)
    {
        if(!_context.performed)
            return;

        StopAllCoroutines();
    }

    public IEnumerator Draw()
    {
        //Created mesh define
        MeshCreate();

        Mesh mesh = new Mesh();

        List<Vector3> vertices = new List<Vector3>(new Vector3[8]);

        Vector3 startPosition = _cam.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

        Vector3 temp = new Vector3(startPosition.x, startPosition.y, 0.5f);

        for (int i = 0; i < vertices.Count; i++)
        {
            vertices[i] = temp;
        }

        List<int> triangles = new List<int>(new int[36]);

        TriangleDefining(triangles);
        

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();

        _path.GetComponent<MeshFilter>().mesh = mesh;

        SetMeshColor(_path, _color);

        Vector3 lastMousePosition = startPosition;

        while (true)
        {
            float _minDistance = 0.1f;

            float _distance = Vector3.Distance(_cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), lastMousePosition);

            while (_distance < _minDistance)
            {
                _distance = Vector3.Distance(_cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), lastMousePosition);
                yield return null;
            }

            vertices.AddRange(new Vector3[4]);
            triangles.AddRange(new int[30]);

            int vIndex = vertices.Count - 8;
            vIndex0 = vIndex + 3;
            vIndex1 = vIndex + 2;
            vIndex2 = vIndex + 1;
            vIndex3 = vIndex + 0;

            vIndex4 = vIndex + 4;
            vIndex5 = vIndex + 5;
            vIndex6 = vIndex + 6;
            vIndex7 = vIndex + 7;

            Vector3 currentMousePosition = _cam.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

            Vector3 mouseForwardVector = (currentMousePosition - lastMousePosition).normalized;


            float _lineThickness = 0.25f;


            Vector3 topRightVertex = currentMousePosition + Vector3.Cross(mouseForwardVector , Vector3.back) * _lineThickness;

            Vector3 bottomRightVertex = currentMousePosition + Vector3.Cross(mouseForwardVector , Vector3.forward) * _lineThickness;

            Vector3 topLeftVertex = new Vector3(topRightVertex.x, topRightVertex.y, 1);

            Vector3 bottomLeftVertex = new Vector3(bottomRightVertex.x, bottomRightVertex.y, 1);

            vertices[vIndex4] = topLeftVertex;
            vertices[vIndex5] = topRightVertex;
            vertices[vIndex6] = bottomRightVertex;
            vertices[vIndex7] = bottomLeftVertex;

            //COMPUTE HERE
            TriangleComputing(triangles);
            

            mesh.vertices = vertices.ToArray();
            mesh.triangles = triangles.ToArray();

            lastMousePosition = _cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

            yield return null;
        }
    }

    public void TriangleDefining(List<int> triangles)
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

    public void TriangleComputing(List<int> triangles)
    {
        int tIndex = triangles.Count - 30;

        //New top Face
            triangles[tIndex + 0] = vIndex2;
            triangles[tIndex + 1] = vIndex3;
            triangles[tIndex + 2] = vIndex4;
            triangles[tIndex + 3] = vIndex2;
            triangles[tIndex + 4] = vIndex4;
            triangles[tIndex + 5] = vIndex5;

            //New Right Face
            triangles[tIndex + 6] = vIndex1;
            triangles[tIndex + 7] = vIndex2;
            triangles[tIndex + 8] = vIndex5;
            triangles[tIndex + 9] = vIndex1;
            triangles[tIndex + 10] = vIndex5;
            triangles[tIndex + 11] = vIndex6;

            //New Left Face
            triangles[tIndex + 12] = vIndex0;
            triangles[tIndex + 13] = vIndex7;
            triangles[tIndex + 14] = vIndex4;
            triangles[tIndex + 15] = vIndex0;
            triangles[tIndex + 16] = vIndex4;
            triangles[tIndex + 17] = vIndex3;

            //New Back Face
            triangles[tIndex + 18] = vIndex5;
            triangles[tIndex + 19] = vIndex4;
            triangles[tIndex + 20] = vIndex7;
            triangles[tIndex + 21] = vIndex0;
            triangles[tIndex + 22] = vIndex4;
            triangles[tIndex + 23] = vIndex3;

            //New Bottom Face
            triangles[tIndex + 24] = vIndex0;
            triangles[tIndex + 25] = vIndex6;
            triangles[tIndex + 26] = vIndex7;
            triangles[tIndex + 27] = vIndex0;
            triangles[tIndex + 28] = vIndex1;
            triangles[tIndex + 29] = vIndex6;
    }

    public void MeshCreate()
    {
        GameObject drawing = new GameObject();
        drawing.gameObject.name = "Path";
        
        drawing.AddComponent<MeshFilter>();
        drawing.AddComponent<MeshRenderer>();

        _path = drawing;
    }

    public void SetMeshColor(GameObject _mesh, Color _desiredColor)
    {
        _mesh.GetComponent<Renderer>().material.color = _desiredColor;
    }
}
