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
		LayerMask layerMask = LayerMask.GetMask("Default");
		RaycastHit hit;
		if (Physics.Raycast(_mainCamera.transform.position, _mainCamera.transform.TransformDirection(Vector3.forward), out hit, 10, layerMask))
		{
			if (hit.distance < 2)
				return;

			Vector3 spawnPos = hit.point + -_mainCamera.transform.TransformDirection(Vector3.forward) * 0.5f;

			if (Physics.Raycast(spawnPos, Vector3.down, out hit, 10, layerMask))
			{
				spawnPos = hit.point;
			}
			spawnPos.y += 1;

			Vector3 cameraRotation = _mainCamera.transform.rotation.eulerAngles;
			cameraRotation.z = 0;
			cameraRotation.x = 0;
			cameraRotation.y += 90;

			GameObject newDomino = Instantiate(myDomino, spawnPos, Quaternion.Euler(cameraRotation));
			newDomino.transform.parent = this.gameObject.transform;
		}
    }
}
