using Unity.Cinemachine;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public CinemachineCamera cinemachineCam;
    private Transform player;

    void Start()
    {
        player = GameObject.Find("Player").transform;
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

