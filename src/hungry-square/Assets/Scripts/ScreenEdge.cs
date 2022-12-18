using UnityEngine;

public class ScreenEdge : MonoBehaviour
{
    // public float borderWidth = 0.1f;
    // private LineRenderer _border;
    private Camera _cam;
    private EdgeCollider2D _edgeCollider;
    private Vector2[] _edgePoints;

    private void Awake()
    {
        if (Camera.main == null) Debug.LogError("Camera.main not found, failed to create edge colliders");
        else _cam = Camera.main;

        if (!_cam.orthographic) Debug.LogError("Camera.main is not Orthographic, failed to create edge colliders");

        // add or use existing EdgeCollider2D
        _edgeCollider = GetComponent<EdgeCollider2D>() == null
            ? gameObject.AddComponent<EdgeCollider2D>()
            : GetComponent<EdgeCollider2D>();

        // _border = GetComponent<LineRenderer>() == null
        //     ? gameObject.AddComponent<LineRenderer>()
        //     : GetComponent<LineRenderer>();

        _edgeCollider.sharedMaterial = Resources.Load<PhysicsMaterial2D>("Material");
        _edgePoints = new Vector2[5];

        // _border.loop = true;
        // _border.positionCount = 0;
        // _border.widthMultiplier = borderWidth;
        // _border.material = new Material(Shader.Find("Unlit/Texture"));
        // _border.startColor = Color.white;
        // _border.endColor = Color.white;

        AddColliderAndBorder();
    }

    //Use this if you're okay with using the global fields and code in Awake() (more efficient)
    //You can just ignore/delete StandaloneAddCollider() if thats the case
    private void AddColliderAndBorder()
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
        _edgeCollider.points = _edgePoints;
        
        // _border.positionCount = 4;
        // _border.SetPosition(0, bottomLeft);
        // _border.SetPosition(1, topLeft);
        // _border.SetPosition(2, topRight);
        // _border.SetPosition(3, bottomRight);
    }
}