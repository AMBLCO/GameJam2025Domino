using UnityEngine;
using System;
using UnityEngine.Rendering.HighDefinition;
using Unity.VisualScripting;
using System.Collections.Generic;

public class DominoCreater : MonoBehaviour
{
    [SerializeField] List<GameObject> myDominos;

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

	public void AddDominoSkin(int i)
	{
		if (i < 8)
			myDominos.Add(Resources.Load<GameObject>("Prefabs/Viennoiserie" + i));
	}

    public void CreateDomino(Vector2Int size)
    {
		Vector3 forward = _mainCamera.transform.TransformDirection(Vector3.forward);
		Vector3 right = _mainCamera.transform.TransformDirection(Vector3.right);

		LayerMask layerMask = LayerMask.GetMask("Default");
		RaycastHit hit;
		if (Physics.Raycast(_mainCamera.transform.position, forward, out hit, 10, layerMask))
		{
			if (hit.distance < 2)
				return;

			Vector3 cameraRotation = _mainCamera.transform.rotation.eulerAngles;
			cameraRotation.z = 0;
			cameraRotation.x = 0;
			cameraRotation.y += 90;
			Vector3 spawnPos = hit.point + -0.5f * forward;

			int yCount = (int)Math.Ceiling(size.y / 2.0f);
			for (int i = 0; i < size.x; i++)
			{
				for (int j = -yCount + 1; j < yCount; j++)
				{
					Vector3 pos = spawnPos + i * -forward + j * right * 1.2f;

					if (Physics.Raycast(pos, Vector3.down, out hit, 10, layerMask))
					{
						pos = hit.point;
					}
					pos.y += 1;

					System.Random random = new System.Random();
					int randomNumber = random.Next(0, myDominos.Count);
					GameObject newDomino = Instantiate(myDominos[randomNumber], pos, Quaternion.Euler(cameraRotation));
					newDomino.transform.parent = this.gameObject.transform;
				}
			}
		}
    }
}
