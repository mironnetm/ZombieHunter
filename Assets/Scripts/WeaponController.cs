using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Camera fpCamera;
    [SerializeField] private float castDistance;
    [SerializeField] private ParticleSystem muzzleFlash;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out hit, castDistance);
        Debug.Log("I hit : " + hit.transform.name);
    }
}
