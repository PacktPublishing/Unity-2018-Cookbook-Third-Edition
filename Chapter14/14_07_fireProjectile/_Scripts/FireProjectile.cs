using UnityEngine;

public class FireProjectile : MonoBehaviour 
{
    const float FIRE_DELAY = 0.1f;
    const float PROJECTILE_LIFE = 10.5f;

    public Rigidbody projectilePrefab;
    public float projectileSpeed = 100f;

    private float nextFireTime = 0;

    void Update()
    {
        if (Time.time > nextFireTime)
            CheckFireKey();
    }

    private void CheckFireKey()
    {
        if(Input.GetButton("Fire1")){
            CreateProjectile();
            nextFireTime = Time.time + FIRE_DELAY;
        }
    }

    private void CreateProjectile()
    {
        Vector3 position = transform.position;
        Quaternion rotation = transform.rotation;

        Rigidbody projectileRigidBody = Instantiate(projectilePrefab, position, rotation);
        Vector3 projectileVelocity = transform.TransformDirection(Vector3.forward * projectileSpeed);

        projectileRigidBody.AddForce(projectileVelocity);

        GameObject projectileGO = projectileRigidBody.gameObject;
        Destroy(projectileGO, PROJECTILE_LIFE);
    }

}
