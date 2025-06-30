using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
            if (player == null)
                return;
        }

        transform.position = new Vector3(player.transform.position.x, 0, -10);
    }
}
