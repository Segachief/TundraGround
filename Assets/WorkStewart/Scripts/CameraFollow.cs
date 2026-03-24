using Unity.Cinemachine;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public CinemachineCamera cinemachineCam;
    public Transform player;

    void Start()
    {
        if (cinemachineCam != null && player != null)
        {
            cinemachineCam.Follow = player;
            cinemachineCam.LookAt = player;
        }
        else
        {
            Debug.LogWarning("Cinemachine camera or player not assigned.");
        }
    }
}
