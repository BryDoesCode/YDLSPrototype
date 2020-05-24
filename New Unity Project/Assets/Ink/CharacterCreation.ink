
/*--------------------------------------------------------------------------------

	Appearance
	
--------------------------------------------------------------------------------*/

// Face

VAR faceShape = 1
VAR skinColor = 1
VAR eyeShape = 1
VAR eyeColor = 1
VAR noseShape = 1
VAR mouthShape = 1
VAR earShape = 1


//  Hair

VAR bangShape = 1
VAR hairShape = 1
VAR hairColor = 1


// Facial Hair

VAR mustache = 1
VAR beard = 1


// Details

VAR piercings = 1
VAR freckles = 1
VAR moles = 1


/*--------------------------------------------------------------------------------

	Character Information
	
--------------------------------------------------------------------------------*/

// Basic Info

VAR firstName = "First"
VAR lastName = "Last"


// Pronouns

LIST shePronouns = she, her, hers
LIST hePronouns = he, him, his
LIST theyPronouns = they, them, theirs

VAR subjectPronoun = they
VAR objectPronoun = them
VAR posessivePronoun = theirs

// Personality

LIST personality = low, neutral, high

VAR extroversion = neutral
VAR neatness = neutral
VAR activeness = neutral

=== function CreatePlayerCharacter(firstString, lastString)
firstName = firstString
lastName = lastString
