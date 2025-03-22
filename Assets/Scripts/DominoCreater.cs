using UnityEngine;
using System;

public class DominoCreater : MonoBehaviour
{
    [SerializeField] GameObject myDomino;

    //Camera
    private GameObject _mainCamera;

    private void Awake()
    {
        // get a reference to our main camera
        if (_mainCamera == null)
        {
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }
    }

    public void CreateDomino()
    {
        if (Math.Abs(_mainCamera.transform.forward.y) > 0.98)
        {
            return;
        }

        Vector3 currentPos = _mainCamera.transform.position;
        Vector3 spawnPos = currentPos + _mainCamera.transform.forward * 3;
        spawnPos.y = 1;

        Vector3 cameraRotation = _mainCamera.transform.rotation.eulerAngles;
        cameraRotation.z = 0;
        cameraRotation.x = 0;
        cameraRotation.y += 90;

        Instantiate(myDomino, spawnPos, Quaternion.Euler(cameraRotation));
    }
}
