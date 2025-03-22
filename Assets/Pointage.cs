using UnityEngine;

public class Pointage : MonoBehaviour
{
    public int score = 0;

    private bool pointAvailable = true;

    StarterAssets.FirstPersonController player;

	private void Start()
	{
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<StarterAssets.FirstPersonController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Contains("Domino"))
        {
            if (pointAvailable)
            {
                player.Score++;
                pointAvailable = false;
            }
        }
    }
}
