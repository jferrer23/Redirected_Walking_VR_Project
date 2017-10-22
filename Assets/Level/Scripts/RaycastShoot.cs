using UnityEngine;
using System.Collections;

public class RaycastShoot : MonoBehaviour {
    public int gunDamage = 1;                                     
    public float fireRate = 0.3f;    
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Transform gunEnd;

    private Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(.3f);
    private AudioSource gunAudio;
    private Animation gunEffect;
    private LineRenderer laserLine;
    private float nextFire;
    public ParticleSystem gunshot;


    // Use this for initialization
    void Start () {
        gunEffect = GetComponent<Animation>();
        laserLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        fpsCam = GetComponentInParent<Camera>();

    }


    // Update is called once per frame
    void Update () {
	
        if(Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            StartCoroutine(ShotEffect());

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            laserLine.SetPosition(0, gunEnd.position);
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point);

                DamageScript health = hit.collider.GetComponent<DamageScript>();

                if(health != null)
                {
                    health.Damage(gunDamage);
                }

                if(hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }
        }
	}

    private IEnumerator ShotEffect()
    {
        gunshot.Play();
        gunAudio.Play();
        gunEffect.Play();
        laserLine.enabled = false;
        yield return shotDuration;
        laserLine.enabled = false;

    }
}
