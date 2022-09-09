# Greg Sheerin Emydex Code Assigment

In this readme I'll go over a few points, mainly so whoever is reviewing this assigment can get a better understanding of my though process. This is just a (slighly) organsiged version of the notes Ive been keeping to help explain some of my descion making.

## Git
[Repo link](https://github.com/GregSheerin/ETL-Repo)
As a note before we get into any techical details. I am using the git repo mainly as a way to view the progress I have been making. Normaly I would follow a more structured process than just commiting to master.Normally i'd branch off, do my work while, make commits, rebase onto master if anything got added in the mean time. Finally squash it into one commit to reflect the user story and raise a pull request. Ill be sending this off as a zip file aswell. 
Bascily I just forked the repo, cloned it locally and started work on the assigments, as this test is not related to git useage.

##Apporach to tackling the exercises
My apporach was fairly simple, firstly I did a run over each on the first day(Wednesday) and got a basic implentation going. My reasoning being that I would like to make sure I understand everything correctly and I am matching the expected outputs.

Next step was to make a unit test project(see below). While not technically a part of the assigment, I do beleive having a unit test project in place significanlty speeds up refactoring work.

Once I got the unit test project in place,running,and covering most of the code. I set about doing some refactoring here and there.

Finally I made a few refactoring runs, general goals of each can be found below.

### Approach to Animal Classes
I wanted to refactor use to reuse as much code as possible, and be as resuable as possible. In my first run I made the Animal abstract class, which would handle any of the common functionalty the animals shared. Few reworks were in order. 
I wanted to reduce any repeat code, so rather than just having the sound be a string being printed to the console via the actual class(EG cow says moo in the cow class),
I added a enum in order to assign the sound an animal makes, and this is passed via their classes(so from hen to animal, or cow to milkable animal). And then Animal handles the acutal
returning of the value(so that all the children have that functionaly, but dont have to repeat it in each of their own classes).
This way I was able to implement another virutal method on the base class, that used the name of the class(well name of the type to be accurate) to say the sound, thus reducing repeat code.
I did this in the first run for the running and walking methods(more on this later), and I reasoned that using the type names would reduce reapting code. Similarly, I used the same logic for the milkable animal class.
Also wanted to follow the open closed princple here, that being its possible to extend out animal to milkableable(and to new classes in the future), but ideally the functionaly in each one is not up for modication(EG rather than trying to account milking into animal, a milkable animal can be its own enity). Following this each of the non abstract models is sealed(I was debating if you could extend logcily here, eg cow could be used as a base for a breed of cow, but hard to jusifty since I have to assume we are tracking breed specfic traits of cows).

Final note here, the chain of inheritance here allows me to treat everything as animal in the FarmSystem class, generaly just makes it easier to work with the collection of animals that may be different, but can behave in the same way doing certain things(EG they all enter the farm the same way)

I also changed the animal classes to return strings rather than directly printing to the console. My reasoning here is that the models themself should be reasonsable for themselfs,and not for any actual work outside of their remit(EG the cow just moos, it would be the job of the consuming code to do what is wanted with that info). Sticking to the single responabilty princlpe here.

#### Abstract classes
Overall there are two abstract classes used, Animal and Milkable Animal(see below). General idea being that I could rip out any common fucntionalty/properies and put them into the abstract
class. Most of it is self explaitory(or I explain it better via comments per line). The Animal class then servers as a base for Milkable Animal( see below), and the hen(only animal not falling into the mammal category)

##### Milkable Animals
I made an extra abstract class for a milkable animal, the orginal output to follow didnt have horse and sheep down, but I added it in just so completness sake. The idea was very simliar to the common fucntioanly in the Animal class. Output only needed to say X was Milked, therefore it made a lot more sense to get rid of Produce Milk methods in each, and have them inherit the virual implenation from the Milkable Animal(which in turns gets all the common animal fucntionaly via the Animal class). As a note I marked all the abstract class's implenations as virtual. In the event this would need to be extented.

### Interfaces
Nothing too off the walk. I use IAnimal to enforce the common fucntioanly across animal, same with IMilkable animal and IEmydexFarmSystem. In the case of Animal, it purely to define the common methods. In the case of ImilkableAnimal, this is used both for the same reason as animal, and to server as a way to extract out any "milkable" animal in the farm system.
Finally, IEmydexFarmSystem is used for the same as IAnimal/IMilkableAnimal, but also to allow for extenabilty(EG a new farm system, does the same things in general but the logic is changed).

###### Quick note on Walk and Run methods in the Animal class
This methods are complety unsed bar my units tests. Normally id cut these methods out the second I figured they were not doing anything, but I am unuse if these were placed in the repo
to test my abilty to regonise the common functiaonlty(and thus use inheritance to incoperate these methods into their children), or to regonise that these methods are infact unsed and thus should be got rid of.
I did ask early on about these methods(IE can all of the animals do this, not about their usage) and it was to be left up to me to decide. Upon realising this I figured it would be better
to just note this here, and explain that I would normally get rid of them. As I exaplined above, not use what their purpose is in regards to the actual test itself.


If you want it to the end of this, thanks for reading though my thoughts on this. As I said, just a general overview of my thoughts tackling this project. I would also take this time
to aplogise for any spelling/gramatic errors, as I am dyslexic its not my fortey. 



