using UnityEngine;
using System.Collections;

public class SSAutoAddUICamera : MonoBehaviour 
{
    [System.Obsolete]
    private void Awake()
	{
        _ = UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(gameObject, "Assets/SSSystem/Scripts/Compatibility/nGUI/SSAutoAddUICamera.cs (8,3)", "UICamera");
	}
}
