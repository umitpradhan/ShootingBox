using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    private Camera cam;
    private float height;
    private float width;
    [SerializeField]
    private EdgeCollider2D boundaryEdges;
    void Awake()
    {
        cam = Camera.main;
        boundaryEdges = GetComponent<EdgeCollider2D>();
    }

    void Update()
    {
        FindBoundaries();
        SetBoundaries();
        
    }

    void SetBoundaries()
    {
        Vector2 pointa = new Vector2(width / 2, height / 2);
        Vector2 pointb = new Vector2(width / 2, height / 2);
        Vector2 pointc = new Vector2(width / 2, height / 2);
        Vector2 pointd = new Vector2(width / 2, height / 2);
        Vector2[] boundPoint = new Vector2[] { pointa, pointb, pointc, pointd, pointa };
        boundaryEdges.points = boundPoint;
    }
    void FindBoundaries()
    {
        width = 1 /(cam.WorldToViewportPoint(new Vector3(1, 1, -10)).x - 0.5f);
        height = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, -10)).y - 0.5f);
    }

    
}
