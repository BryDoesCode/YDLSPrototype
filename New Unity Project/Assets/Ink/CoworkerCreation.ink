
/*--------------------------------------------------------------------------------

	Appearance
	
--------------------------------------------------------------------------------*/

// Face

VAR coworkerFaceShape = 1
VAR coworkerSkinColor = 1
VAR coworkerEyeShape = 1
VAR coworkerEyeColor = 1 
VAR coworkerNoseShape = 1
VAR coworkerMouthShape = 1
VAR coworkerEarShape = 1


//  Hair

VAR coworkerBangShape = 1
VAR coworkerHairShape = 1
VAR coworkerHairColor = 1


// Facial Hair

VAR coworkerMustache = 1
VAR coworkerBeard = 1


// Details

VAR coworkerPiercings = 1
VAR coworkerFreckles = 1
VAR coworkerMoles = 1


/*--------------------------------------------------------------------------------

	Character Information
	
--------------------------------------------------------------------------------*/


// Name Lists

LIST masculineFirstNames = (John), (Brian), (Josh)
LIST feminineFirstNames = (Jane), (Karen), (Mary)
LIST neutralFirstNames = (Cassidy), (Lee), (Riley)

LIST lastNames = (Smith), (Johnson), (McClellan)

// Basic Info

VAR coworkerFirstName = John
VAR coworkerLastName =  Smith


// Pronouns

VAR coworkerSubjectPronoun = they
VAR coworkerObjectPronoun = them
VAR coworkerPosessivePronoun = theirs


// Personality

VAR coworkerExtroversion = neutral
VAR coworkerNeatness = neutral
VAR coworkerActiveness = neutral

VAR relationshipWithPlayer = 0



/*--------------------------------------------------------------------------------

	Character Generation
	
--------------------------------------------------------------------------------*/

=== function GenerateCoworker

// Face

~ coworkerFaceShape = RANDOM(0, 3)
~ coworkerSkinColor = RANDOM(0, 7)
~ coworkerEyeShape = RANDOM(0, 3)
~ coworkerEyeColor = RANDOM(0, 7) 
~ coworkerNoseShape = RANDOM(0, 5)
~ coworkerMouthShape = RANDOM(0, 3)
~ coworkerEarShape = RANDOM(0, 5)


//  Hair

~ coworkerBangShape = RANDOM(0, 5)
~ coworkerHairShape = RANDOM(0, 4)
~ coworkerHairColor = RANDOM(0, 7)


// Facial Hair

~ coworkerMustache = RANDOM(0, 5)
~ coworkerBeard = RANDOM(0, 5)


// Details

~ coworkerPiercings = RANDOM(0, 5)
~ coworkerFreckles = RANDOM(0, 5)
~ coworkerMoles = RANDOM(0, 5)


// Basic Info

~ coworkerFirstName = LIST_RANDOM(neutralFirstNames)
~ coworkerLastName = LIST_RANDOM(lastNames)


// Personality

~ coworkerExtroversion = LIST_RANDOM(personality)
~ coworkerNeatness = LIST_RANDOM(personality)
~ coworkerActiveness = LIST_RANDOM(personality)


/*--------------------------------------------------------------------------------

	Character Conversations
	
--------------------------------------------------------------------------------*/

=== coworkerConversation
~ conversationActive = true

"Hey {firstName}! It's almost the end of your shift, right?"

+ ["Not soon enough." {statHints: \\n<size={statSize}>(+1 Relationship)</size>}]
    "Yeah, I feel you."
    Your relationship with {coworkerFirstName} increased by 1. 
    ~ relationshipWithPlayer += 1

+ ["Yeah and yours is just starting. Ha." {statHints: \\n<size={statSize}>(-1 Relationship)</size>}]
    "No need to rub it in."
    Your relationship with {coworkerFirstName} decreased by 1. 
    ~ relationshipWithPlayer -= 1

+ ["Your point?" {statHints: \\n<size={statSize}>(-2 Relationship)</size>}]    "Nothing, really. Just making conversation. Jeez."
    Your relationship with {coworkerFirstName} decreased by 2. 
    ~ relationshipWithPlayer -= 2
-

+ ["I have to get back to work." {statHints: \\n<size={statSize}>(+1 Relationship)</size>}]
    "Have a good one."
    Your relationship with {coworkerFirstName} increased by 1. 
    ~ relationshipWithPlayer += 1

+ ["My break is over. Nice talking to you. {statHints: \\n<size={statSize}>(+2 Relationship)</size>}]
    "You too! Hang in there."
    Your relationship with {coworkerFirstName} increased by 2. 
    ~ relationshipWithPlayer += 2
    
+ [Just Leave. {statHints: \\n<size={statSize}>(-2 Relationship)</size>}]
    "Wow. Nice talking to you too, jerk."
    Your relationship with {coworkerFirstName} decreased by 2. 
    ~ relationshipWithPlayer -= 2
    
-

+ [Close]
~ conversationActive = false
->->