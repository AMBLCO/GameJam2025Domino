using UnityEngine;
using TMPro;

public class fasterPrice : MonoBehaviour
{
    [SerializeField] public TMP_Text fasterPriceText;

    StarterAssets.FirstPersonController player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<StarterAssets.FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.numberFaster < 5)
        {
            fasterPriceText.SetText(" Buy Faster (" + player.fasterPrice + ")");
        }
        else
        {
            fasterPriceText.SetText("Poubelle a cash (pour les riches seulement) prix : " + player.fasterPrice);
        }
    }
}
