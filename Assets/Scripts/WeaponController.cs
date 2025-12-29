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
        if(Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out hit, castDistance))
        {
            Debug.Log("I hit : " + hit.transform.name);

            if(hit.transform.name == "Enemy")
            {
              EnemyAIScript enemyAIScript = hit.transform.GetComponent<EnemyAIScript>();
              enemyAIScript.DealDamage(25);
            }
        }
        else
        {
            return;
        }
    }
}
