2D Attacks
==========

This section based off: https://www.youtube.com/watch?v=1QfxdUpVh5I

Add time-limited trigger for attacks
------------------------------------

.. code-block:: c#
   :linenos:

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CravenAttackScript : MonoBehaviour
    {
        // How frequently can we attack?
        public float attackTimeLimit = 0.5f;

        // Countdown timer for attacks
        private float attackCountdownTimer = 0;

        void Update()
        {
            // See if we can attack, via timer.
            if (attackCountdownTimer <= 0)
            {
                // We can attack. See if user hit space bar.
                if (Input.GetKey(KeyCode.Space))
                {
                    Debug.Log("Attack");
                    attackCountdownTimer = attackTimeLimit;
                }
            }
            else
            {
                // Attack timer needs count-down
                attackCountdownTimer -= Time.deltaTime;
            }
        }
    }

Do damage
---------

.. code-block:: c#
   :linenos:

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CravenAttackScript : MonoBehaviour
    {
        // How frequently can we attack?
        public float attackTimeLimit = 0.5f;

        // Countdown timer for attacks
        private float attackCountdownTimer = 0;

        // An empty parented that says where to attack
        public Transform attackPos;
        // Radius of attack circle
        public float attackRange;
        // What layer will the enemies be on?
        public LayerMask enemyLayer;
        // How much damage to deal
        public int damage = 3;

        void Update()
        {
            // See if we can attack, via timer.
            if (attackCountdownTimer <= 0)
            {
                // We can attack. See if user hit space bar.
                if (Input.GetKey(KeyCode.Space))
                {
                    Debug.Log("Attack");
                    // Reset the countdown timer
                    attackCountdownTimer = attackTimeLimit;
                    // What enemies did we hit?
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyLayer);
                    // Loop through each enemy we hit
                    for(int i=0; i < enemiesToDamage.Length; i++)
                    {
                        // Get the enemy script attached to this object
                        CravenEnemyScript enemyScript = enemiesToDamage[i].GetComponent<CravenEnemyScript>();
                        // If there is an enemy script
                        if (enemyScript)
                        {
                            // Damage
                            enemiesToDamage[i].GetComponent<CravenEnemyScript>().health -= damage;
                            // Print health levels
                            Debug.Log(enemiesToDamage[i].GetComponent<CravenEnemyScript>().health);

                            // --- ToDo: destroy enemy here when health <= 0
                        }
                        else
                        {
                            // We hit an enemy, but there's no script attached to it.
                            Debug.Log("Enemy Script not present");
                        }
                    }
                }
            }
            else
            {
                // Attack timer needs count-down
                attackCountdownTimer -= Time.deltaTime;
            }
        }
        // Used to draw a circle when we are selecting the player in the scene view
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPos.position, attackRange);
        }
    }

.. note::

   You'll need:
   * An enemy script
   * Turn on gizmos in the scene view
   * An enemy layer
   * Program a change to the attackPos when user changes direction.