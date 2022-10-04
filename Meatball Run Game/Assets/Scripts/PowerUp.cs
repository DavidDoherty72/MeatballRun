using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]
public class PowerUp : MonoBehaviour 
{
    [SerializeField]
    private float _speedIncreaseAmount = 20;
    [SerializeField]
    private float _powerupDuration = 1
        ;

    [SerializeField]
    private GameObject _artToDisable = null;

    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }


    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement PlayerMovement = 
            other.gameObject.GetComponent<PlayerMovement>();
        if(PlayerMovement != null)
        {
            //powerup sequence 
            StartCoroutine(PowerupSequence(PlayerMovement));
        }
    }
 

    public IEnumerator PowerupSequence(PlayerMovement PlayerMovement)
    {
        //sot disable
        _collider.enabled = false;
        _artToDisable.SetActive(false);
        //activate
        ActivatePowerup(PlayerMovement);
        //wait for some amount of time
        yield return new WaitForSeconds(_powerupDuration);
        //deactivate 
        DeactivatePowerup(PlayerMovement);

        Destroy(gameObject);
    }

    private void ActivatePowerup(PlayerMovement PlayerMovement)
    {
        PlayerMovement.SetforwardForce(_speedIncreaseAmount);
    }

    private void DeactivatePowerup(PlayerMovement PlayerMovement)
    {
        PlayerMovement.SetforwardForce(-_speedIncreaseAmount);
    }


}
