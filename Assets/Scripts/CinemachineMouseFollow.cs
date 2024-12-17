using UnityEngine;
using Cinemachine;

public class CinemachineMouseOffset : MonoBehaviour
{
    [SerializeField] private float followSpeed = 0.1f; // Rychlost, jakou se kamera bude pohybovat
    [SerializeField] private float maxOffset = 2.0f; // Maximální vzdálenost, kterou se kamera může posunout

    private CinemachineVirtualCamera virtualCamera;
    private CinemachineFramingTransposer framingTransposer;

    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        if (virtualCamera != null)
        {
            framingTransposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
            if (framingTransposer == null)
            {
                Debug.LogError("CinemachineFramingTransposer component not found on this CinemachineVirtualCamera.");
            }
        }
        else
        {
            Debug.LogError("CinemachineVirtualCamera component not found on this GameObject.");
        }
    }

    void Update()
    {
        if (framingTransposer == null) return;

        Vector3 mousePosition = Input.mousePosition;
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        Vector3 offset = mousePosition - screenCenter;

        // Omezit maximální posun kamery
        offset.x = Mathf.Clamp(offset.x, -maxOffset, maxOffset);
        offset.y = Mathf.Clamp(offset.y, -maxOffset, maxOffset);
        offset.z = 0; // Udržení původní z-ové pozice kamery

        framingTransposer.m_TrackedObjectOffset = offset;
    }
}