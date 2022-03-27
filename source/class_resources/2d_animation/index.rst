.. _2d_shooting:

2D Shooting
===========

.. contents::

Make a sprites in Aseprite
--------------------------

* Make a bullet, laser, heart, whatever you want to shoot.
* Make a target to hit.
* Export, and import into Unity changing the normal three things.

Detect mouse down events
------------------------

In our ``Update`` method on cour controller, we can detect a mouse-down event with ``Input.GetMouseButtonDown(0)``.
The 0 is for our left mouse button. An implementation might look like:

.. code-block::
   :language: c#

    // Has the mouse been pressed?
    if (Input.GetMouseButtonDown(0))
    {
        Debug.Log("Mouse down");
    }

Create a bullet
---------------

Create a bullet prefab. Add a box collider and rigidbody to it. Set the collider to be a trigger.

Add a public variable for the prefab. Then drag the prefab in.

.. code-block::
   :language: c#

    public GameObject bulletPrefab;

Update code to fire the bullet:

.. code-block::
   :language: c#c

    if (Input.GetMouseButtonDown(0))
    {
        // Fire a bullet
        Debug.Log("Mouse down ");
        var bullet = Instantiate(bulletPrefab, body.position, Quaternion.identity);
        var bulletbody = bullet.GetComponent<Rigidbody2D>();
        bulletbody.velocity = new Vector2(4, 0);
    }

Create targets
--------------

Create targets. Add a collider. Add a tag for "Destroyable".

Add a bullet script
-------------------

.. code-block::
   :language: c#

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class BulletScript : MonoBehaviour
    {

        public void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("Trigger");
            if (collision.tag == "Destroyable")
            {

                Debug.Log("Destroyable");
                Destroy(collision.gameObject);
            }
        }

    }


Calculate angles
----------------

Next, if we want to fire in a particular direction, we...