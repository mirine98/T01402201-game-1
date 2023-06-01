using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetris_box_colider : MonoBehaviour
{
    [SerializeField] private CompositeCollider2D compositeCollider;
    [SerializeField] private float size_row;
    [SerializeField] private float size_col;
    [SerializeField] private float offset_row;
    [SerializeField] private float offset_col;

    // Start is called before the first frame update
    void Start()
    {
        {
            // ù ��° BoxCollider2D ����
            BoxCollider2D firstBoxCollider = gameObject.AddComponent<BoxCollider2D>();

            // �� ��° BoxCollider2D ����
            BoxCollider2D secondBoxCollider = gameObject.AddComponent<BoxCollider2D>();
            secondBoxCollider.size = new Vector2(size_row, size_col);
            secondBoxCollider.offset = new Vector2(offset_row, offset_col);
            compositeCollider.geometryType = CompositeCollider2D.GeometryType.Polygons; // CompositeCollider2D ����
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
