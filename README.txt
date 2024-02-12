In this project I want to create a combat simulator for Dungeons & Dragons to test the combat encounters I wish to set up for my players.
 
As a beginner DM it is quite difficult to estimate whether an encounter will be too easy or too hard for my players and using the 
Dungeon Master's Guide's section for balancing an encounter only gives you a rough idea for balance. This is why I want to create
a program that simulates a combat encounter and return multiple possible outcomes of the fight.

To start, the user will add any monsters they want to use to the simulation as well as all the player characters. After the setup
is complete the user will start the simulation that will run a number of times (let's say 100 times) and based on all the outcomes
will give the user a difficulty rating. The difficulty ratings (DR) are easy, medium, hard, very hard, and deadly. So we will be
working in percentiles of 20. 

If the party wins between 80% and 100% of the encounters, the encounter will be flagged as deadly
If the party wins between 60% and 80% of the encounters, the encounter will be flagged as very hard
If the party wins between 40% and 60% of the encounters, the encounter will be flagged as hard
If the party wins between 20% and 40% of the encounters, the encounter will be flagged as medium
If the party wins between 0% and 20% of the encounters, the encounter will be flagged as easy


If the part suffered

During a single encounter test, every creature will roll for initiative and be orderd in an array. Then the array will loop through
every creature and perform actions based on certain criteria. The actions are as follows:

1. Attack a random enemy creature
2. Drink a health potion if possible and necessary
3. Heal an ally if possible and necessary
