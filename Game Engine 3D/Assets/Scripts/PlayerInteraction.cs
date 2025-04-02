using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SniperMode
{
    Rifle, Sniper
}
public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] SniperMode sniperMode;
    [SerializeField] float rifleDst;
    [SerializeField] float sniperDst;
    
    float distance;
    Transform rayCastOrigin;
    IShotable target;
    // Start is called before the first frame update
    void Start()
    {
        rayCastOrigin = Camera.main.transform;
        ChangeSniperMode(SniperMode.Rifle);
    }

    private void Update()
    {
        Debug.DrawRay(rayCastOrigin.position, rayCastOrigin.forward, Color.cyan);
        if (Input.GetButtonDown("Fire1"))
        {
            target.Hit();
        }
        
        if (Input.GetButtonDown("Fire2"))
        {
            ChangeSniperMode(SniperMode.Sniper);
        }
        
        if (Input.GetButtonUp("Fire2"))
        {
            ChangeSniperMode(SniperMode.Rifle);         
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Physics.Raycast(rayCastOrigin.position, rayCastOrigin.forward, out RaycastHit hit, distance))
        {
            if(hit.collider.TryGetComponent(out IShotable target))
            {
               // this.target = target;
            }
        }
        else
        {
            //this.target = null;
        }
    }
    void ChangeSniperMode(SniperMode mode)
    {
        switch (mode) 
        {
            case SniperMode.Rifle:
                distance = rifleDst;
                GameController.instance.OnRifleMode.Invoke();
                 break;
            case SniperMode.Sniper:
                distance = sniperDst;
                GameController.instance.OnSniperMode.Invoke();
                break;
        }
        sniperMode = mode;
    }
}