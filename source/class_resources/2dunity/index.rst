2D Unity
========

Get some sample sprites in Unity
--------------------------------

#. Clone the base Unity project: https://github.com/pvcraven/2022_Class_2D_Project
#. Create sprites in Aesprite.

   * Use NES palette
   * Create a 16x16 character.

   .. image:: paul_character.png
      :width: 20%

   * Create a 16x32 tree. (Or some other size, keeping in mind 16x16 is the character size.)

   .. image:: paul_tree.png
      :width: 20%

   * Save to ``Assets/Sprites/Trees`` or ``Assets/Sprites/Characters`` folder.
   * Call your character ``tree_name`` or ``character_name``. Obviously, use your first and/or last name, not "name".
   * Export your sprite as a ``.png`` in that same folder.

#. Open in Unity, confirm the assets are there.
#. Do a git add, commit, push and pull to sync with the whole class.

.. warning:: Be careful of .meta files

   Unity adds a ``.meta`` file that tags a GUID for each file. If you create
   or move a file into a Unity project, let unity create a ``.meta`` for it
   before check in! This includes the exported ``.png``. Failure to do this
   will cause a lot of merge headaches.

Move and collide with sprites
-----------------------------

#. Create your own scene. Call it ``scene_name``.
#. Drag character onto the screen.
#. Way too small. Unity defaults to 100 pixels to one 'unit' which is 1 meter.
   Change from 100 to 16.
#. Great. Now the character is blurry. Change the filtering to 'point'.
#. Character might be blotchy. Turn off compression.
#. Should be able to run and see character.
#. Add rigid body 2d. Character should now fall.
#. Take out gravity.
#. Add in character controller script that is already in the project.
#. Should be able to move character with WSAD. Can adjust speed as needed.
#. Add your tree, adjusting PPU and filter as before.
#. Add capsule 2d collider. Adjust so you collide on the bottom half.

   .. image:: tree_collider.png
      :width: 70%

#. Try running. No collision.
#. Add collider on character. (Circle?)
#. Try running. But character spins!
#. Freeze rotation.

   .. image:: freeze_rotation.png
      :width: 40%

#. Character may or may not appear behind/ahead of the tree properly. You can use sort mode in project settings
   to fix:

   .. image:: sort_order.png
      :width: 40%