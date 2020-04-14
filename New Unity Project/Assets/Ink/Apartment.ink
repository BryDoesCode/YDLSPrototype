/*--------------------------------------------------------------------------------

   Apartment -- Morning

--------------------------------------------------------------------------------*/

=== morning ===
{AdvanceWeekday()}
~ date ++
~ time = Morning
~ fullDate = month + " " + date
~ energy = RANDOM(7, 9)
~ location = "Apartment"
~ background = "apartmentMorning"

It's morning!

You've started with {energy} Energy today. Make it count!
+ [Wake Up]
-
{MorningWakeUp()}
+ [Get Out of Bed]
    You push yourself up out of bed. {MorningCondition()}
-
+ [Get Ready]
    You brush your teeth and take your medicine like normal, then turn your attention to food. 
    \-----
    You lost 1 Energy from getting ready.
    ~ energy -= 1
-
+ [Eat] -> breakfast


= breakfast

What would you like to eat for breakfast?

+ [Prepacked Meal]
	     {~You settled on cereal this morning. It’s quick and it’s easy. | It's a toast kind of morning. {~This time with butter.| A quick swipe of peanut butter makes all the difference. | Some jelly on top adds just enough sweetness.} | Just a container of yogurt should be fine.} 
	     \-----
	     You gained 1 Health from eating.
	     ~ health += 1
	     
	     
+ [Recipe]
	    
	    {~Today was a pancake morning. Sure, you’re a bit tired now but nothing beats the smell of freshly cooked pancakes. | You're exhausted already, but that omlette sure was worth it.}
	    \-----
	    You lost 2 Energy from cooking.
	    ~ energy -= 2
	    You gained 2 Health from eating.
	    ~ health += 2
	    You gained 1 Wellness from the homecooked meal.
	    ~ wellness += 1
	    


- 
+ [Continue Getting Ready] -> shower


= shower

- You still have some time this morning. 
Would you like to take a shower? 
+ [Yes]
    
    Ah, that was a wonderful shower. You feel a bit more tired, but you’re clean and ready to face the day. It felt great. Now it’s time to get dressed and head out.
    \-----
    You lost 2 Energy from taking a shower.
    You lost 1 Energy from getting dressed. 
    ~ energy -= 3
    You gained 1 Health and 1 Wellness from taking a shower. 
    ~ health += 1
    ~ wellness += 1
    
    #showerSFX
    
+ [No]
    No time for a shower this morning. You’d rather just get to work. You get dressed as normal and head to work. 
    \-----
    
    You lost 1 Health and 1 Wellness from not taking a shower.
    You lost 1 Energy from getting dressed.
   
    ~ health -= 1
    ~ wellness -= 1
    ~ energy -= 1

- 
+ [Leave for Work]

-> retailwork


/*--------------------------------------------------------------------------------

    Apartment -- Evening

--------------------------------------------------------------------------------*/


=== endofday ===

~ location = "Apartment"
~ background = "apartmentEvening"
~ time = Evening

Looks like you made it home for the day. 

+ [Check in with Yourself]
- 
{
    - energy <= 0:
        Yeah, you have no energy left. None. How are you even standing?
    - energy <= 2:
        You're exhausted. You only have {energy} Energy left. Better just head to bed.
    - energy <= 5:
        You only have {energy} Energy left, but at least you finished everything you needed to. Right?
    - energy > 5:
        Well, you have {energy} Energy right now. You can actually do something productive tonight. 
}
-
* [Sleep]
    -> morning
+ [Restart]
    {ResetStats()}
    -> morning
    + [End]
    {EndGame()}
    -> DONE

-> END


/*--------------------------------------------------------------------------------

    Variety Functions -- Morning

--------------------------------------------------------------------------------*/

=== function MorningWakeUp
~ temp randomNumber = RANDOM(1, 3)
{ randomNumber:
    - 1:
        You wake up to your alarm blaring.
    - 2: 
        You wake up before your alarm, looking over just in time to see it start beeping.
    - 3:
        You woke up to your alarm, sort of. Actually, you smashed the snooze button once. Just enough for some extra sleep but not enough to change your morning routine.
        \-----
        You gained 1 Energy from a little extra sleep.
        ~ energy += 1
}
 

=== function MorningCondition
~ temp randomNumber = RANDOM(1, 3)
{ randomNumber:
    - 1:
        Your muscles ache, but nothing more than usual. 
    - 2: 
        You actually feel pretty good this morning, for once.
        \-----
        You gained 1 Wellness from feeling good. 
        ~ wellness += 1
    - 3:
        You feel really groggy, must not have slept well. 
        \-----
        You lost 2 Energy from not sleeping well.
        ~ energy -= 2
}
