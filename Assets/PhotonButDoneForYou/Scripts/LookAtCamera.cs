using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class LookAtCamera : MonoBehaviour
{
    enum Mode
    {
        LookAt,
        LookAtInverted,
        CameraForward,
        CameraForwardInverted,
    }

    [SerializeField] private Mode mode;

    private void LateUpdate()
    {
        Camera targetCamera = Camera.main;

#if UNITY_EDITOR
        // If no main camera, use the SceneView camera
        if (targetCamera == null && SceneView.lastActiveSceneView != null)
        {
            targetCamera = SceneView.lastActiveSceneView.camera;
        }
#endif

        if (targetCamera == null)
        {
            Debug.LogWarning("No camera found to look at.");
            return;
        }

        switch (mode)
        {
            case Mode.LookAt:
                transform.LookAt(targetCamera.transform);
                break;

            case Mode.LookAtInverted:
                Vector3 dirFromCamera = transform.position - targetCamera.transform.position;
                transform.LookAt(transform.position + dirFromCamera);
                break;

            case Mode.CameraForward:
                transform.forward = targetCamera.transform.forward;
                break;

            case Mode.CameraForwardInverted:
                transform.forward = -targetCamera.transform.forward;
                break;
        }
    }
}
