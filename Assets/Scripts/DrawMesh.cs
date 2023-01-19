using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Voxelity.Extensions;

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

    private List<Vector3> vertices = new List<Vector3>(new Vector3[8]);
    private List<int> triangles = new List<int>(new int[36]);

    public PhysicMaterial _pathPhysics;
    public Camera _cam;
    public GameObject _path;
    public GameObject _oldPath;

    private Vector3 _startPos;
    
    [Range(0.01f, 0.1f)]
    public float _pathThickness;


    public void StartDraw(InputAction.CallbackContext _context)
    {
        if(!_context.performed)
            return;

        Draw();
    }

    public void EndDraw(InputAction.CallbackContext _context)
    {
        if(!_context.performed)
            return;

        StopAllCoroutines();

        //It because old meshes destroyed for new ones
        _oldPath = _path;

        MeshAdjustments(_path);

    }

    public void Draw()
    {
        if (_oldPath)
            Destroy(_oldPath.gameObject);

        _startPos = GetStartPosition();

        Mesh mesh = new Mesh();

        MeshCreate(mesh);

        MeshTriangles.TriangleDefining(triangles);

        ConvertToArray(mesh);

        SetMeshColor(_path);

        StartCoroutine(CallTasks(mesh, GetStartPosition(), 0.1f));
    }

    public Vector3 GetStartPosition()
    {
        Vector3 startPosition = _cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

        return startPosition;
    }

    public Vector3 GetTemporaryIndex()
    {
        Vector3 temp = new Vector3(GetStartPosition().x, GetStartPosition().y, 0.5f);

        return temp;
    }

    private void ConvertToArray(Mesh _mesh)
    {
        _mesh.vertices = vertices.ToArray();
        _mesh.triangles = triangles.ToArray();
    }

    private void MeshAdjustments(GameObject _path)
    {
        if (Vector3.Distance(_startPos, GetStartPosition()) >= 0 &&
            Vector3.Distance(_startPos, GetStartPosition()) <= 0.2)
            return;

        var collider = _path.AddComponent<MeshCollider>();
        collider.material = _pathPhysics;
    }

    private void TriangleComputing(List<int> triangles)
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

    private void MeshCreate(Mesh _mesh)
    {
        GameObject drawing = new GameObject();
        drawing.gameObject.name = "Path";
        drawing.gameObject.tag = "Path";

        drawing.AddComponent<MeshFilter>();
        drawing.AddComponent<MeshRenderer>();

        _path = drawing;
        _path.GetComponent<MeshFilter>().mesh = _mesh;

        for (int i = 0; i < vertices.Count; i++)
        {
            vertices[i] = GetTemporaryIndex();
        }
    }

    private void SetMeshColor(GameObject _mesh)
    {
        _mesh.GetComponent<Renderer>().material.color = ColorExtensions.random;
    }

    private void MeshThickness(Vector3 _mousePosition, float _thickness)
    {
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

            Vector3 mouseForwardVector = (currentMousePosition - _mousePosition).normalized;


            float _lineThickness = _thickness;

            Vector3 topRightVertex = currentMousePosition + Vector3.Cross(mouseForwardVector , Vector3.back) * _lineThickness;

            Vector3 bottomRightVertex = currentMousePosition + Vector3.Cross(mouseForwardVector , Vector3.forward) * _lineThickness;

            Vector3 topLeftVertex = new Vector3(topRightVertex.x, topRightVertex.y, 1);

            Vector3 bottomLeftVertex = new Vector3(bottomRightVertex.x, bottomRightVertex.y, 1);

            vertices[vIndex4] = topLeftVertex;
            vertices[vIndex5] = topRightVertex;
            vertices[vIndex6] = bottomRightVertex;
            vertices[vIndex7] = bottomLeftVertex;
    }

    private IEnumerator CallTasks(Mesh _mesh, Vector3 _mousePosition, float _meshProduceRate)
    {
        while (true)
        {
            //DRAW RATE HERE
            float _minDistance = _meshProduceRate;

            float _distance = Vector3.Distance(_cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), _mousePosition);

            while (_distance < _minDistance)
            {
                _distance = Vector3.Distance(_cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), _mousePosition);
                yield return null;
            }

            //SET THICKNESS
            MeshThickness(_mousePosition, _pathThickness);

            //COMPUTE HERE
            TriangleComputing(triangles);

            _mesh.vertices = vertices.ToArray();
            _mesh.triangles = triangles.ToArray();

            _mousePosition = _cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

            yield return null;
        }
    }
}
