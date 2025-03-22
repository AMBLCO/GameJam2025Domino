using UnityEngine;

public class Shop : MonoBehaviour
{
    GameObject shopMenu;
    GameObject pizza;
    private void Awake()
    {
        shopMenu = GameObject.Find("ShopMenu");
        shopMenu.SetActive(false);
        pizza = GameObject.Find("CustomCursor");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Cursor.lockState = CursorLockMode.None;
            shopMenu.SetActive(true);
            pizza.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Cursor.lockState = CursorLockMode.Locked;
            shopMenu.SetActive(false);
            pizza.SetActive(true);
        }
    }
}
