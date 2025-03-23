using UnityEngine;
using TMPro;

public class sizeTMP : MonoBehaviour
{
    [SerializeField] public TMP_Text moreDominosText;

    StarterAssets.FirstPersonController player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<StarterAssets.FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        moreDominosText.SetText(" Buy MOORE (" + player.sizePrice + ")");
    }
}
