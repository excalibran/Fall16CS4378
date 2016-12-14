Final 4378Z Project for group 7, William Winters (w_w26) and Jay Villegas(jav96).

Directory fall16cs4378 is the project itself, made in Unity Personal Edition version 5.4.2f2 64-bit
Directory WintersVillegasFinalDemo is a version compiled for Windows x86. If moved, please move the exe AND the data folder.

When playing the demo, either the arrow keys or W, A, S, and D can be used for movement, and spacebar will fire. Holding down spacebar for a moment will charge a shot with wider range. To the top is your score, to the lower right is the player's lives, and to the left is a visualizer for the EnemyProduction class's current priorities (first the region it sees the player in, second by the region it sees the player moving through the most).

Classes are contained in assets/scripts, and are divided into 'player', 'enemy', and 'world'. For seeing the work on moving entities, you may wish to focus on MoveByWaypoints, DodgeDetection, and FollowPlayer under 'enemy'. Overall AI is done with EnemyProduction, RegionData, Strategies, and Spawner under 'world'. I apologize for the inconsistant naming convention for classes, many are behaviors while others are treated as objects.

Setting strategies for EnemyProduction to follow is done by attaching additional Strategy components to EnemyProduction and giving it spawners to use.