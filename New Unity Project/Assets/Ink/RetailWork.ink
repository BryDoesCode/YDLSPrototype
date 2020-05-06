
/*--------------------------------------------------------------------------------

	Retail Work

--------------------------------------------------------------------------------*/

=== retailwork ===

~ location = "Work"
~ background = "retailWorkFront"
~ time = Midday

You made it to work. 

+ [Go Inside]
~ background = "retailWorkRegister"
- {ArriveAtRetailWork()}

+ [Work Hard{statHints: \\n<size={statSize}>(-3 Energy / -2 Health)\\n(+2 Wellness)</size>}]
    You decide to give work your all today. You clean shelves, organize clothing, and help customers. You feel really accomplished and in a lot of pain by the end of the day.
    \-----
    You lost 3 Energy and 2 Health from working hard.
    ~energy -= 3
    ~health -=2
    You gained 2 Wellness from being a hard worker. 
    ~wellness += 2
    
    
+ [Slack Off{statHints: \\n<size={statSize}>(-2 Energy)</size>}]
    It's not really like they pay you enough for this job anyway. You do your work, basically, but don't really put any effort into it. Whatever. 
    \-----
    You lost 2 Energy and 1 Health from working. 
    ~energy -=2
-

+ [Head Home]

-> endofday

+ [Go to Store]
-> store

/*--------------------------------------------------------------------------------

    Variety Functions -- Retail Work

--------------------------------------------------------------------------------*/



=== function ArriveAtRetailWork

~ temp randomNumber = RANDOM(1, 3)
{ randomNumber:
- 1:
You arrived just on time. You clock in on the register before unlocking the front door.
- 2: 
You're a few minutes early. You take a moment to breathe and prepare yourself for the day, before clocking in and opening up the store. 
\-----
You gained 1 Wellness from destressing.
~ wellness += 1
- 3:
You see the clock on the wall and realize that somehow the train was late. It's never late. You rush to the register, and clock in five minutes after your shift was supposed to start. Your manager doesn't seem to notice, thankfully. 
\-----
You lost 1 Wellness from the stress of being late.
~ wellness -= 1
}
 

