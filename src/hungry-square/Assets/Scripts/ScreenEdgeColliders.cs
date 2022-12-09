using UnityEngine;

public class ScreenEdgeColliders : MonoBehaviour
{
    private Camera _cam;
    private EdgeCollider2D _edge;
    private Vector2[] _edgePoints;

    private void Awake()
    {
        if (Camera.main == null) Debug.LogError("Camera.main not found, failed to create edge colliders");
        else _cam = Camera.main;

        if (!_cam.orthographic) Debug.LogError("Camera.main is not Orthographic, failed to create edge colliders");

        // add or use existing EdgeCollider2D
        _edge = GetComponent<EdgeCollider2D>() == null
            ? gameObject.AddComponent<EdgeCollider2D>()
            : GetComponent<EdgeCollider2D>();

        _edge.sharedMaterial = Resources.Load<PhysicsMaterial2D>("Material");
        // _edge.name = "EdgeCollider";
        _edgePoints = new Vector2[5];

        AddCollider();
    }

    //Use this if you're okay with using the global fields and code in Awake() (more efficient)
    //You can just ignore/delete StandaloneAddCollider() if thats the case
    private void AddCollider()
    {
        //Vector2's for the corners of the screen
        Vector2 bottomLeft = _cam.ScreenToWorldPoint(new Vector3(0, 0, _cam.nearClipPlane));
        Vector2 topRight = _cam.ScreenToWorldPoint(new Vector3(_cam.pixelWidth, _cam.pixelHeight, _cam.nearClipPlane));
        var topLeft = new Vector2(bottomLeft.x, topRight.y);
        var bottomRight = new Vector2(topRight.x, bottomLeft.y);

        //Update Vector2 array for edge collider
        _edgePoints[0] = bottomLeft;
        _edgePoints[1] = topLeft;
        _edgePoints[2] = topRight;
        _edgePoints[3] = bottomRight;
        _edgePoints[4] = bottomLeft;

        _edge.points = _edgePoints;
    }
}