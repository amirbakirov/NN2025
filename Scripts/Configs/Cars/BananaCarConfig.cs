using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BananaCarConfig", menuName = "Scriptable Objects/BananaCarConfig")]
[Serializable]
public class BananaCarConfig : ScriptableObject
{
    public Vector3 BackWheelsPosition = new Vector3(-0.75f, 0.1f, 0);
    public Vector3 ForwardWheelsPosition = new Vector3(0.75f, 0.1f, 0);
    public Vector3 PropellerPosition = new Vector3(-1.5f, 1, 0);
    public Vector3 WingsAndRocketPosition = new Vector3(0, 0.9f, 0);
}
