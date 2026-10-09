using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

/// <summary>
/// Free-fly camera. Attach to your Camera. The cursor is always visible.
/// WASD = move, E/Q = up/down, Hold Right Mouse + move mouse = look,
/// Shift = boost, Scroll = change speed.
/// Works with both the new Input System and the legacy Input Manager.
/// </summary>
public class FlyCamera : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float boostMultiplier = 3f;
    [SerializeField] private float scrollSpeedStep = 1f;
    [SerializeField] private float minSpeed = 1f;
    [SerializeField] private float maxSpeed = 100f;

    [Header("Look")]
    [SerializeField] private float lookSensitivity = 0.15f;
    [SerializeField] private float maxPitch = 89f;
    [Tooltip("Freeze the cursor in place while looking (it stays visible), so you never hit the screen edge.")]
    [SerializeField] private bool freezeCursorWhileLooking = true;

    private float yaw;
    private float pitch;

        // Saved camera pose that survives scene reloads
    private static bool hasSavedPose;
    private static Vector3 savedPosition;
    private static Quaternion savedRotation;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void ResetSavedPose() => hasSavedPose = false;

    public static void SavePose(Transform cam)
    {
        hasSavedPose = true;
        savedPosition = cam.position;
        savedRotation = cam.rotation;
    }

    private void Start()
    {
        if (hasSavedPose)
        {
            transform.SetPositionAndRotation(savedPosition, savedRotation);
            hasSavedPose = false;
        }

        Vector3 e = transform.eulerAngles;
        yaw = e.y;
        pitch = e.x > 180f ? e.x - 360f : e.x;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void OnDisable()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        ReadInput(out Vector2 look, out Vector3 move, out bool boost,
                  out float scroll, out bool lookHeld);

        // Cursor is always visible; optionally freeze its position while looking
        Cursor.visible = true;
        if (freezeCursorWhileLooking)
            Cursor.lockState = lookHeld ? CursorLockMode.Locked : CursorLockMode.None;

        // Mouse look (only while right mouse button is held)
        if (lookHeld)
        {
            yaw += look.x * lookSensitivity;
            pitch -= look.y * lookSensitivity;
            pitch = Mathf.Clamp(pitch, -maxPitch, maxPitch);
            transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
        }

        // Scroll changes base speed
        if (Mathf.Abs(scroll) > 0.01f)
            moveSpeed = Mathf.Clamp(moveSpeed + Mathf.Sign(scroll) * scrollSpeedStep, minSpeed, maxSpeed);

        // Movement: forward/right follow the camera, up/down follow world Y
        float speed = moveSpeed * (boost ? boostMultiplier : 1f);
        Vector3 dir = transform.right * move.x + Vector3.up * move.y + transform.forward * move.z;
        if (dir.sqrMagnitude > 1f) dir.Normalize();

        transform.position += dir * (speed * Time.unscaledDeltaTime);
    }

    private static void ReadInput(out Vector2 look, out Vector3 move, out bool boost,
                                  out float scroll, out bool lookHeld)
    {
        look = Vector2.zero;
        move = Vector3.zero;
        boost = false;
        scroll = 0f;
        lookHeld = false;

#if ENABLE_INPUT_SYSTEM
        Keyboard kb = Keyboard.current;
        Mouse mouse = Mouse.current;
        if (kb == null || mouse == null) return;

        move.x = (kb.dKey.isPressed ? 1f : 0f) - (kb.aKey.isPressed ? 1f : 0f);
        move.y = (kb.eKey.isPressed ? 1f : 0f) - (kb.qKey.isPressed ? 1f : 0f);
        move.z = (kb.wKey.isPressed ? 1f : 0f) - (kb.sKey.isPressed ? 1f : 0f);
        boost = kb.leftShiftKey.isPressed;

        look = mouse.delta.ReadValue();
        scroll = mouse.scroll.ReadValue().y;
        lookHeld = mouse.rightButton.isPressed;
#else
        move.x = (Input.GetKey(KeyCode.D) ? 1f : 0f) - (Input.GetKey(KeyCode.A) ? 1f : 0f);
        move.y = (Input.GetKey(KeyCode.E) ? 1f : 0f) - (Input.GetKey(KeyCode.Q) ? 1f : 0f);
        move.z = (Input.GetKey(KeyCode.W) ? 1f : 0f) - (Input.GetKey(KeyCode.S) ? 1f : 0f);
        boost = Input.GetKey(KeyCode.LeftShift);

        look = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        scroll = Input.mouseScrollDelta.y;
        lookHeld = Input.GetMouseButton(1);
#endif
    }
}
