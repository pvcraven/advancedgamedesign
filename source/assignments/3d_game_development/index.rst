Team 3D Game Work
=================

For this project (and the coming weeks) you'll break into groups and develop
a 3D game.
Your goal is to improve this game, week-by-week.

Starting the Project
--------------------

* Start with one of your roll-a-ball games as a working base.
* Invite other team members to that project.
* You must cite any 3d models, textures, sounds that you use from another source.

  * Get this started by creating a section in your readme to hold this info.

* Figure out how you want to stay in contact. Exchange info. (E-mail, slack, discord, etc.)
* Brainstorm Ideas

  * Theme?
  * Color scheme? See `Adobe Kuler <https://color.adobe.com/create/color-wheel>`_ and create a swatch?
  * Create one or more tasks for everyone. Backup tasks are a good idea. See "Some Ideas On Tasks"

Each Week on Thursday
---------------------

* Pick goals/tasks for each person to get done that week.
* Enter each task as an issue in GitHub.
* Assign it to the proper person.
* If you notice bugs, enter them in GitHub and assign to the proper person.

Each Week on Tuesday
--------------------

* Make sure everyone's work has been merged into GitHub.
* Test your application to make sure it is working.
* Help each other with the tasks and bugs.

Some Ideas on Tasks
-------------------

* Object modeling

  * Create an interesting playing field
  * Add more objects, add more detail to objects

* Materials

  * Learn some of the options for materials, and make things shiny, etc.
  * Note: Learn these in Unity, not Blender. Blender to Unity material transfer is limited.

* Textures

  * Map an image onto an item (UV Mapping) Can do in Blender or Unity.
  * Learn to use normal maps
  * Create water

* Shaders

  * Work with shaders to create better looking materials

* Lighting

  * Instead of one generic light, add better lighting. Spot lights, lamps, etc.

* Skybox

  * Learn to add a skybox. **Warning:** Be very careful about
    how hi-res of an image you download. These can be huge and
    blow up your project if you download something too big.

* Sound

  * Add sound for pickups
  * Add sound when bouncing into objects
  * Add sound for movement

* Create level system

  * Go to new level if all items are picked up
  * Go to new level if player gets to a goal point

* Enemies

  * Create items that reset the user to the start if you bump into them
  * Create have player lose a life when hitting enemy
  * Support 'game over' when player loses all lives
  * Have enemy move towards player
  * Investigate path finding to have enemy move around objects

* Particles

  * Create liquids, smoke, clouds, flames, magic effects

* Shooting

  * Be able to shoot things. Enemies, collectables, walls.

* UI

  * Create intro/instruction screens
  * Allow game restart
  * Show lives left
  * Add background/panel to UI
  * Add dialog system (encounter NPC, have popup dialog)

* Multiplayer

  * Add networking

* Animation

  * Animate obstacles
  * Make moving platforms
  * Create switches that trigger events
  * Create a 3d car instead of a ball to move around
  * Create a 3d walking character rather than a rolling ball.
    `Use Mixamo <https://www.youtube.com/watch?v=0QA2O7juuWQ>`_.


* Player

  * Add ability to jump
  * Add ability to run

Important Notes
---------------

* Do not add assets into a folder without using Unity.
  This will lead to merge errors that will lose you a lot of time.
* If working on a challenging item, have a back-up goal.
  You've got to get something done, so you don't want to be stuck if things
  are more complex than expected.
* Everyone must be on the same version of Unity. Do not upgrade your Unity.
  That will force everyone to upgrade, or you'll just end up losing your work.
* Your work must be integrated. For example, if your task is designing a tree,
  don't spend all your time making a beautiful tree in Blender and never
  get it into the game. Create a cylinder in Blender. Get it into the game.
  Fancy it up with some branches. Get that in the game. Add materials. Get
  that into the game. If something isn't in the game, it might as well not
  exist.
* Commit early. Commit often. If you only commit during one day this week,
  it won't look like you've done much work at all.
* The fancy materials and modifiers you use in Blender are not likely
  to show up in Unity. Keep it simple. Make sure things work in Unity before
  sinking a lot of time into them.

Turn In
-------

Turn in a report.

* Summarize what you finished this week.
* Link to the GitHub project.
* Link to the issue that has the item(s) you worked on.
* Link to your commits. It will look something like:
  https://github.com/pythonarcade/arcade/commits?author=pvcraven
* Include an image of what you did, and show it working in the game.

Grading
-------

I'll grade the way I evaluated the work of my employees back when I worked IT.

* Integration with the project. When I hit 'play' on the game, can I see
  what you did? If so, that will help give you a good grade.
  Don't make the mistake of adding a model, sound, material, or some
  other component, but not make it part of gameplay. If I hit 'play' and
  can't see your work, then it serves no purpose. When adding
  items, start with a simple version. For example, a cube, a beep, code that just
  prints "hello world" at the right trigger.
  You have something working. Go back and add detail. Always keep it
  in the playable game.
* Frequency of commits. Do you have commits spread across three or
  more days? This shows ongoing work and integration with the whole project.
  In the workplace, I'd expect commits every day. Or hour or two.
  If you are doing something that might break the project, do it in a
  separate branch, then merge. Ask if you'd like help learning to do this.
* Documentation. Did you include links to your project and your commits?
  Did you detail what you did that works in words? Include
  screenshots? Did you make it so simple to see what you did, I don't even
  need to clone the game? Did you see me in class and show off your work there?
  Did you use the issue tracking? As a manager, I'm looking at that more than
  diving into your code. You don't want managers diving into the code, make
  it easy for them to track progress.
