VAR JEAN_met = true
VAR JEAN_affection = 0

The bell on the door rings. The sound of clinking metal and heavy steps carry their owner to you. #Prose

A young knight stands before the counter, shoulders taut with an austere formality. It seems almost... <i>forced</i>. #Prose

<b>KNIGHT</b>: "Greetings. Are you the proprietor of this establishment?" #JEAN_neutral
* [Hm, I don't see anyone else here?] -> Proprietor
* [And if I am?] -> Proprietor



== Proprietor ==
Whatever mask she seemed to don a moment ago falters. You sense she's not used to being teased. #Prose

There's a semblance of a frown on her lips now but she pushes forward. #Prose

<b>KNIGHT</b>: "On behalf of The Order, I'd like to personally welcome you to Mondstadt. We look forward to establishing a fruitful partnership." #JEAN_neutral
* [I can't say I'm interested in the Knights' interference.] -> Proprietor_left
* [I'd be open to it if it meant seeing you more often.] -> Proprietor_right

    == Proprietor_left ==
    ~ JEAN_affection = JEAN_affection - 1
    <b>KNIGHT</b>: "That's... understandable, but I do hope you'll reconsider." #JEAN_sad
    -> Magic_lately
    
    == Proprietor_right ==
    ~ JEAN_affection = JEAN_affection + 1
    <b>KNIGHT</b>: "I... suppose that is a possibility." #JEAN_blush
    -> Magic_lately



== Magic_lately ==
The knight shifts with uncertainty, as her eyes survey the room. It seems she has more to say, so you beckon her on. #Prose

<b>KNIGHT</b>: "There have been reports of magic usage in this area lately." #JEAN_neutral
* [<i>Magic?</i> How curious.] -> Magic_lately_left
* [<i>Mm...</i>] -> Magic_lately_right
    
    == Magic_lately_left ==
    <b>KNIGHT</b>: "Yes... The Order is rather concerned." #JEAN_frown 
    -> Magic_lately2
    
    == Magic_lately_right ==
    -> Magic_lately2



== Magic_lately2 ==
<b>KNIGHT</b>: "You wouldn't happen to have heard anything, would you?" #JEAN_neutral

You think of the flames you've just managed to put out from Klee's little incident yesterday. But, <i>surely</i>, news hadn't traveled that quickly? #Prose

<b>KNIGHT</b>: "You wouldn't happen to have heard anything, would you?" #JEAN_neutral
* [I can't say that I have, darling.] -> Magic_lately2_left
* [I've barely settled in, darling.] -> Magic_lately2_right

    == Magic_lately2_left ==
    <b>KNIGHT</b>: "That's understandable. You've only just settled in." #JEAN_blush
    -> Introductions
    
    == Magic_lately2_right ==
    <b>KNIGHT</b>: "Right. My apologies, I didn't mean to assume." #JEAN_blush
    -> Introductions
    


== Introductions ==
You watch each other curiously, letting silence take space in the room. Moments pass. You think little of the quiet, but the knight grows restless. #Prose

She lowers her gaze, seemingly struggling to find anything else to say, and you don't bother suppressing a laugh. She looks up startled, then <i>embarrassed</i>. But it's your smile that allows her shoulders to relax and coaxes one of her own onto her lips. #Prose

<b>JEAN GUNNHILDR</b>: "I believe I've forgotten to introduce myself. I'm Jean Gunnhildr, Master of Knights with the Order of Favonius." #JEAN_smile
* [Lisa Minci. Newly settled Mondstadian.] -> Introductions_left
* [Lisa Minci. Humble apothecary... <i>proprietor</i>.] -> Introductions_right
    
    == Introductions_left ==
    -> Introductions_done
    
    == Introductions_right ==
    ~ JEAN_affection = JEAN_affection + 1
    -> Introductions_done



== Introductions_done ==
YOU'VE REACHED THE END. Swipe to restart. #Prose

-> END