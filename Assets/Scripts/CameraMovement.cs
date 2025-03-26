using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public Vector2 Offset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + Offset.x, player.transform.position.y + Offset.y, -1);
    }
    
}
