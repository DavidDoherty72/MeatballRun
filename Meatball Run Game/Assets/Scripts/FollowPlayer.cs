using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    


    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;



        if (Input.GetKey("c"))
        {
            transform.Rotate(0, 180, 0);
        }

        if (Input.GetKey("j"))
        {
            transform.position = player.position + offset;
            transform.Rotate(0, 90, 0);
        }


    }
}
      