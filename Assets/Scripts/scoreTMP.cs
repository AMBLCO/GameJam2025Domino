using UnityEngine;
using TMPro;

public class scoreTMP : MonoBehaviour
{
    [SerializeField] public TMP_Text scoreText;

    StarterAssets.FirstPersonController player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<StarterAssets.FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText(" Cash : " + player.Score);
    }
}
