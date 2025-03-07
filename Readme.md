
# New Mechanic Assignment Changes

My chosen mechanic was shooting mechanic that when you hit a certain key on your keyboard you would shoot a bullet forwards which can be used to damage anything with a healthScript attached to it.

## Scripts Added or edited
For the most part all my scripts used were new ones but I did have to make a slight addition to the HealthController Script as I was using onTriggerEnter for the collsions which wasn't in the script already so I had to add it.
The first new script is the Bullet script which is used for anything bullet-related such as how much damage the bullets do and how long they last in the scene before disappearing(so they don't go on forever) as well as detecting when the bullet hit an object with the HealthController attached.
The Second script is the PlayerShooting script which handles the main aspect of the mechanic, shooting. It searches for a FirePoint in the scene and if one isn't found it creates one on the player so that your bullets shoot from them. And then the Shhot method which when your shoot key ius pressed a bullet appears and goes forwards from the player using velocity and the bullets speed.

## Extra Script
I also created a SpeechBubble script that would allow me to have text appear above NPC's when the player got close to them. The script would hide the speechbubble at first and then enable them in the scene when the player was within a set range of them and then disable again when the player left that zone.

## Prefabs
On the note of new additions I also added 2 prefabs to the game. One being the bullets the player shot and the other being a speech bubble. It just made it easier for me to make them prefabs and reuse them instead of creating several instances of the objects.
