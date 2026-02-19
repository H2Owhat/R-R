using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(BoxCollider2D))]
public class StacyGizmo : MonoBehaviour
{

    Color debugColor;
    BoxCollider2D box;

    private void Awake() {
        debugColor = Color.beige;
    }
    void OnDrawGizmos() {
        Gizmos.color = debugColor;
        box = GetComponent<BoxCollider2D>();
        Gizmos.DrawCube(transform.position + (Vector3)box.offset, box.size);
    }
}
