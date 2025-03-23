using UnityEngine;

public class Pointage : MonoBehaviour
{
    private bool pointAvailable = true;

    StarterAssets.FirstPersonController player;

    private void Start()
	{
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<StarterAssets.FirstPersonController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
		if (collision.gameObject.tag == "Domino")
        {
            if (pointAvailable)
            {
                player.Score++;
                pointAvailable = false;
            }
        }
    }
}
