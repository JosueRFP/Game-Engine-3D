using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SniperMode
{
    Rifle, Sniper,
}
public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] SniperMode sniperMode;
    [SerializeField] float sniperDistance;
    [SerializeField] float rifleDistance;
    [SerializeField] float distance;
    Transform rayCastOrigin;
    IShootable target;
    // Start is called before the first frame update
    void Start()
    {
        rayCastOrigin = Camera.main.transform;
        ChangeSniperMode(SniperMode.Rifle);
    }
    private void Update()
    {
        Debug.DrawRay(rayCastOrigin.position, rayCastOrigin.forward * 10, Color.red);
        if (Input.GetButtonDown("Fire1"))
        {
            target?.Hit();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Physics.Raycast(rayCastOrigin.position, rayCastOrigin.forward, out RaycastHit hit, distance))
        {
            if(hit.collider.TryGetComponent(out IShootable target))
            {
                this.target = target;
            }
            else
            {
                this.target = null;
            }



        }
        else
        {
            this.target = null;
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
    private void ChangeSniperMode(SniperMode mode)
    {
        switch (mode)
        {
            case SniperMode.Rifle:
                distance = rifleDistance;
                GameController.instance.OnRifleMode.Invoke();
                break;
            case SniperMode.Sniper:
                distance = sniperDistance;
                GameController.instance.OnSniperMode.Invoke();
                break;
        }
        sniperMode = mode;
    }


}
