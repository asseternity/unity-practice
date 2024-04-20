using UnityEngine;

public class gemparticlescript : MonoBehaviour
{
    public GameObject gem;
    public ParticleSystem particles;
    public float seconds = 0.3f;
    public bool gemDestroyed = false;
    public AudioSource src;
    void Update()
    {
        if (gem == null && !gemDestroyed) {
            particles.Play();
            src.Play();

            gemDestroyed = true;
            Invoke("StopParticles", seconds);
        }
    }
    void StopParticles()
    {
        particles.Stop();
    }
}
