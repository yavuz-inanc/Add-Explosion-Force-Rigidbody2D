using UnityEngine;

public static class Explosion2D
{
    public static void AddExplosionForce(this Rigidbody2D rb, float explosionForce, Vector2 explosionPosition, float radius) 
    {
        Vector2 explosionDir = rb.position - explosionPosition;
        float explosionDistance = explosionDir.magnitude;
        explosionDir.Normalize();
        float lerpPower = 1 - (explosionDistance / radius);
        float force = Mathf.Lerp(0, explosionForce, lerpPower);
        rb.AddForce(explosionDir * force, ForceMode2D.Force);
        if (explosionDir.x > 0)
        {
            rb.AddTorque(-force);
        }
        else
        {
            rb.AddTorque(force);
        }
    }
}
