using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update(){
        transform.position = player.position + offset;
    }
}
