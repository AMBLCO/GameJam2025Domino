using UnityEngine;
using TMPro;

public class skinPrice : MonoBehaviour
{
	[SerializeField] public TMP_Text skinPriceText;

	StarterAssets.FirstPersonController player;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<StarterAssets.FirstPersonController>();
	}

	// Update is called once per frame
	void Update()
	{
		if (player.skinToAdd < 8)
		{
			skinPriceText.SetText(" Buy Skin (" + player.skinPrice + ")");
		}
		else
		{
			skinPriceText.SetText("Poubelle a cash (pour les riches seulement) prix : " + player.skinPrice);
		}
	}
}
