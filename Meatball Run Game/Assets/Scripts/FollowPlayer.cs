using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
  //  public Vector3 lookBehind;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update(){
        transform.position = player.position + offset;

      //  if (Input.GetKey("c")) //LOOK BEHIND
       // {
       //     transform.position = player.position + lookBehind;
       // }
        
    }

}
