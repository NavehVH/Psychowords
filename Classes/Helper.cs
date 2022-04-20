using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMKB.Classes
{
    class Helper
    {
        String SAVED_BOTS = @"
Saved Bots Page:
- Here you're able to see all the bots you've created and saved. 
Which you can recognize by the custom bot name you did, the client name and the server version.
- You can create how many bots you want.
- How to choose your saved bot? Double click the saved bot you have.
- There two types of bots, the Regular Bot which you don't need coding skills, and another one named Script Bot that you can code your own bot.
- Want to save a backup before editing again your saved bot? In the bot files, you have a folder named APP_DATA, you can create a .rar file of it as a backup.
Whenever you want to return this data just make it as a folder and replace it with the current APP_DATA folder.
If you want to send your saved bots to another computer, just send the APP_DATA folder to the other computer and replace, or just send all of the bot program folder.
";

        String REGULAR_BOT = @"
Regular Bot Page:
 + Client Details Tab:
    - Here you define a custom name for the bot you're making, name of client (When the client is not on full screen, you can see the client name on the top of the MapleStory window),
and your maple version (For exmaple 83\95\147\216) which is important because each version has a different UI and the programs needs to know which UI to detect.
    - After entering the details save the bot using the Save button, which will save it and allow you to create the bot.

 + Picture Detect Settings Tab:
    - This is a very important tab to understand, this tab is made to tell the program, where on your computer screen the game mini-map is, and the hp\mp bar.
To calculate your character position\hp\mp the program needs to know where those things are positioned on your screen. Which with this logic, if you move your MapleStory window after setting it,
you will need to set it again, because its not the same position on screen you told the program. Thats why I always set the picture detect setting on the default place the game is loading when entering, so I won't need to set it again all the time.
    - What is the program logic behind finding the player position? After you tell the program where your mini-map is and run the bot. The program screenshot all the time that rectangle, and checks where the player is by checking where is the red dot is,
based on the red dot, it calculate a custom position of the player based on the rectangle width(X) and height(Y).
    - If you have set an Image before, you're able to see what the program can see there. To refresh the image, just re-enter the picture detect settings tab.

 + Keys Tab:
    - 
";
    }
}
