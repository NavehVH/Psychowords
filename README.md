# Psychowords  
A smart, feature-rich web app for mastering vocabulary for the Israeli Psychometric exam — designed to help you memorize words in the most effective way possible.

![gif](assets/chome_ibwsAlujSB.gif)

## Motivation  
I took the psychometric exam in March 2021. I had enrolled in one of the big-name prep courses in Israel, but their vocabulary practice tool was disappointing — just a basic four-choice random quiz with no real learning strategy.

So instead of studying (oops), I decided to build my own tool — one that actually helps. As I progressed, new ideas came to mind, and I kept improving the site along the way. What started as a quick side project became a tool I wish I had from day one.

## How It Works

After registering to the site, you can start building your own personal vocabulary collection. For each word, you can add a definition, an example sentence, and even a personal association to help you remember it better.

All the words you enter go into your **personal dictionary**, which you can later organize into custom groups. But you’re not limited to just your own words — you can also explore words added by other users, see their examples and associations, and "like" any entry to add it to your own list.

Once your dictionary is populated, you can start training. The site offers multiple practice modes and customization options to help you focus on exactly the words you want, in the way that works best for you.

All of this is presented through a clean, modern, and well-organized interface — with smooth navigation and no unnecessary page reloads. It’s designed to feel fast, professional, and distraction-free.

The next sections break down each feature in detail.

## Inserting a New Word to the Dictionary

This feature allows you to add new words to your personal dictionary, along with rich information to help with memorization.

For each word, you can provide:
- A definition
- An example sentence
- A personal association or memory aid

You can also explore the most liked definitions, examples, and associations added by other users for the same word — and easily adopt any of them into your own entry.

Words can be organized into custom categories to match your study style. For example, you might create a group like “Words I don’t even know how to pronounce” to revisit later. You’re free to create any categories that help you organize your learning.

At the bottom of the page, you can also view and edit the last 10 words you added, making it easy to refine or update entries on the fly.

![new word](https://i.imgur.com/pvO6LhT.png)

## Personal Dictionary

The Personal Dictionary is where all the words you've added are displayed in a clean, easy-to-navigate interface. Each word entry includes your custom definition, example, and personal association — all visible at a glance.

You can also see public content that others have contributed for the same word. If you find a definition, example, or association you like, you can simply "like" it to add it to your own version.

Each word in your dictionary can be assigned a **familiarity level**:
- **Green** – I know this word well  
- **Orange** – I barely know this word  
- **Red** – I don’t know this word  

These labels help you prioritize your study sessions.

You can filter and view your words in various ways:
- All words  
- Words I know  
- Words I barely know  
- Words I don’t know  
- Words from a specific category  
- Words I added  
- Words I liked  

This flexibility gives you full control over what to focus on next.

![personal](https://i.imgur.com/r6xlv7y.png)

## Global Dictionary

The Global Dictionary gives you access to the entire collection of words added by all users — no page reloads required. It's designed to be fast, searchable, and highly interactive.

You can:
- Browse the most popular words  
- Filter words alphabetically (A, B, C, ...)  
- Search across definitions, associations, and examples  
- View content added by other users, ordered by number of likes  

Found something useful? With one click, you can add any public word — or parts of it — to your own dictionary.

This shared space makes it easy to discover new vocabulary, see how others think about words, and expand your knowledge beyond your own list.

![global](https://i.imgur.com/2eA2HPX.png)

## Practice Words

Once you've added words, assigned their familiarity status, and organized them into categories, you can start practicing through a flexible multiple-choice quiz system.

In the settings, you can customize your quiz to match your learning goals:
- Choose how many answer options to include (from 1 to 10) to adjust the difficulty
- Select specific word groups to focus your practice

Available filters include:
- All words  
- Words I know  
- Words I barely know  
- Words I don’t know  
- Words from a specific category  

This makes it easy to run highly targeted practice sessions, focusing only on the words you need to reinforce.

![image](https://github.com/user-attachments/assets/0e443cde-1650-4ea0-917a-a638ddc50d6d)

## Memorization of Words

This feature is similar to the multiple-choice quiz, but with a more memory-focused approach.

You begin with a set of flashcards (5–15 words) that you can flip to reveal definitions. Take your time reviewing the cards until you feel confident. Once you're ready, you'll move on to the next stage — a multiple-choice quiz based on the same words — to reinforce what you've just memorized.

The goal is to improve retention by combining passive review with active recall.

Additional settings let you customize the experience:
- Choose how many words to review at once
- Enable auto-flip and timed transitions between cards
- Show example sentences or personal associations when flipping, if desired

![settings](https://i.imgur.com/jgwLw4I.png)

This method is especially effective for building long-term memory in a focused and efficient way — especially when you can choose exactly which words to practice.

![memory](https://i.imgur.com/XE5KSAy.png)

## Settings

The Settings page allows you to manage your personal account details.

You can:
- View your current user information
- Change your password
- Update your email address

These options give you full control over your account and allow you to keep your information up to date as needed.

## Technologies Used

- **C# and ASP.NET** – Used for building the backend logic and server-side functionality  
- **AJAX** – Enables smooth interaction with the backend without requiring full page reloads  
- **MySQL** – Serves as the relational database for storing user data, words, definitions, and progress  
- **HTML, CSS, Bootstrap, JavaScript** – Used for building a responsive and user-friendly frontend

## How to Use / Run

You can either fork this repository or download the files directly. The project was developed using **Visual Studio 2019**.

### Project Setup
The project includes several `.DLL` files required for compilation, which are already referenced and located in the `DLLs` folder.

### Database Configuration
This project uses **MySQL** to store all application data.  
You can find and update the connection string in the following file:  
`App_Data/Connections.cs`

The default database name used is: `psychometry_data`

> Note: I personally use **XAMPP** to run a local MySQL server on the correct port (usually 3306), which allows a successful connection between the app and the database.

### Database Backup

A clean backup of the database is available here:  
[Download MySQL Backup (MEGA link)](https://mega.nz/file/IhMFCR6J#mMlIF7xp88X7g30Du4lj7NTSJ-rWr1lYR6TZuAOCxhc)

This backup includes one default test user:
- **Username:** `admin`  
- **Password:** `11111111`

Once your database is restored and the connection string is configured, simply run the project in Visual Studio.

The site should now be fully functional and connected to your local MySQL instance.


