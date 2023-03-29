using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float knockbackForce = 10f;  // La fuerza del knockback

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))  // Si colisiona con un enemigo
        {
            Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();
            if (enemyRB != null)
            {
                Vector3 knockbackDirection = (collision.transform.position - transform.position).normalized;  // La dirección del knockback
                enemyRB.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);  // Aplicamos el knockback al enemigo
            }
        }
    }
}


/*function OnTriggerEnter(collider:Collider){

    if (collider.tag == "Enemy")
    {
        var dir = (collider.transform.position - transform.position).normalized;

        var characterMotor = collider.GetComponent(CharacterMotor);
        var characterController = collider.GetComponent(CharacterController);

        characterMotor.SetVelocity(dir * velBack);
    }
}*/