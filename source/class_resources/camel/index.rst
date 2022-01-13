Camel Code Review
=================

Here are examples of the "Camel" game. Our goal here is to do code reviews
on this code.

Before the code review, think about:

#. First, list what are the goals of the code review.
#. Look for common mistakes. Keep a to-do list.

   #. Can a person drink more water than is in the canteen?
   #. Do we mis-calculate how far back the people are?
   #. Can the chasing people skip past the person and miss seeing them?
   #. Can we both win and lose the game at the same time? Or otherwise get conflicting messages?

#. Quantify effectiveness of your code review. (Bugs found, changes made, etc.)
#. Code reviews often include work on unit-tests. We aren't doing that here but
   keep it in mind.
#. Code reviews should be less than 400 lines and 60 minutes.

Camel Version 1
---------------

.. literalinclude:: camel1.cs
   :language: c#
   :linenos:

Camel Version 2
---------------

.. literalinclude:: camel2.cs
   :language: c#
   :linenos:

Camel Version 3
---------------

.. literalinclude:: camel3.cs
   :language: c#
   :linenos:
