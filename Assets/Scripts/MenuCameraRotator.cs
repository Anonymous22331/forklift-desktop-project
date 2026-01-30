using Unity.Cinemachine;
using UnityEngine;

public class MenuCameraRotator : MonoBehaviour
{
    [SerializeField] private CinemachineOrbitalFollow _orbitalFollow;
    [SerializeField] private float _rotationSpeed = 10f;

    private void Update()
    {
        _orbitalFollow.HorizontalAxis.Value += _rotationSpeed * Time.deltaTime;
    }
    
}
