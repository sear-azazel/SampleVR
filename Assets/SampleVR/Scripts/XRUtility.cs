using System.Collections;
using UnityEngine;
using UnityEngine.XR;

public class XRUtility : MonoBehaviour
{
    private const string DeviceNone = "None";
    private const string DeviceCardboard = "Cardboard";

    [SerializeField] private GvrReticlePointer reticlePointer;
    private static XRUtility instance;

    public static bool IsEnabled
    {
        get => XRSettings.enabled;
        set => instance.StartCoroutine(instance.ChangeEnable(value));
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Input.backButtonLeavesApp = false;
        this.reticlePointer.gameObject.SetActive(false);
    }

    private IEnumerator ChangeEnable(bool enabled)
    {
        if (XRSettings.enabled == enabled) { yield break; }
        XRSettings.LoadDeviceByName(enabled ? DeviceCardboard : DeviceNone);
        yield return null;
        XRSettings.enabled = enabled;
        this.reticlePointer.gameObject.SetActive(enabled);
    }
}
