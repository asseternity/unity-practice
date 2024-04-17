using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Camera))]
public class OrbitCamera : MonoBehaviour
{
    [SerializeField] Transform focus = default;
    [SerializeField, Range(1f, 20f)] float distance = 5f;
    [SerializeField, Min(0f)] float focusRadius = 1f;
    [SerializeField, Range(0f, 1f)] float focusCentering = 0.5f;
    [SerializeField, Range(0f, 360f)] float rotationSpeed = 90f;
    Vector2 orbitAngles = new Vector2(45f, 0f);
    Vector2 input = Vector2.zero;
    Vector3 focusPoint;
    public GameObject ObjectToSpawn;
    public InputAction cameraControls;
    public InputAction spawner;
    Camera regularCamera;
    private void OnEnable() { cameraControls.Enable(); spawner.Enable(); }
    private void OnDisable() { cameraControls.Disable(); spawner.Disable(); }
    void Awake() { focusPoint = focus.position; regularCamera = GetComponent<Camera>(); }

    void LateUpdate()
    {
        UpdateFocusPoint();
        ManualRotation();
        Quaternion lookRotation = Quaternion.Euler(orbitAngles);
        Vector3 lookDirection = lookRotation * Vector3.forward;
        Vector3 lookPosition = focusPoint - lookDirection * distance;

        if (Physics.BoxCast(focusPoint, CameraHalfExtends, -lookDirection, out RaycastHit hit, lookRotation, distance - regularCamera.nearClipPlane))
        {
            lookPosition = focusPoint - lookDirection * (hit.distance + regularCamera.nearClipPlane);
        }

        transform.SetPositionAndRotation(lookPosition, lookRotation);
        SpawnCube();
    }

    void UpdateFocusPoint()
    {
        Vector3 targetPoint = focus.position;
        if (focusRadius > 0f) {
            float distance = Vector3.Distance(targetPoint, focusPoint);
            float t = 1f;
            if (distance > 0.01f && focusCentering > 0f) { t = Mathf.Pow(1f - focusCentering, Time.unscaledDeltaTime); }
            if (distance > focusRadius) { t = Mathf.Min(t, focusRadius / distance); }
            focusPoint = Vector3.Lerp(targetPoint, focusPoint, t);
        } else { focusPoint = targetPoint; }
    }

    void ManualRotation()
    {
        input = cameraControls.ReadValue<Vector2>();
        float hori = -input.y;
        float vert = input.x;
        const float minimalInput = 0.001f;
        if (hori < -minimalInput || hori > minimalInput || vert < -minimalInput || vert > minimalInput)
        { orbitAngles += rotationSpeed * Time.unscaledDeltaTime * new Vector2(hori, vert); }
    }

    Vector3 CameraHalfExtends
    {
        get {
            Vector3 halfExtends;
            halfExtends.y = regularCamera.nearClipPlane * Mathf.Tan(0.5f * Mathf.Deg2Rad * regularCamera.fieldOfView);
            halfExtends.x = halfExtends.y * regularCamera.aspect;
            halfExtends.z = 0f;
            return halfExtends;
        }
    }
    void SpawnCube()
    {
        float spawnButton = spawner.ReadValue<float>();
        if (spawnButton > 0)
        {
            Debug.Log("button pressed");
            Instantiate(ObjectToSpawn, new Vector3(focus.position.x + 1f, focus.position.y, focus.position.z), Quaternion.identity);
        }
    }
}