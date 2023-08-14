# Psychowords
## רקע
היי, אני נגשתי לפסיכומטרי במרץ 21 אחרי 3~4 חודשים של לימודים. עכשיו אחד החלקים החשובים של הפסיכומטרי זה לימוד אוצר מילים, שמצאתי אותו דיי מאתגר. בסופו של דבר אתה צריך לעבור על אלפי מילים שונות שלא נתקלת בהן ביום יום וגם אין שיטה מדויקת ללמוד את המילים אללו, כל אחד מוצא את השיטה שלו.

מצאתי קושי בלהצליח לזכור כל כך הרבה מילים, אז נזכרתי איך למדתי לתיאוריה, בעזרת שאלות אמריקאיות. ניסיתי את QUIZLET אבל לא אהבתי, לא כל כך מתאים ללימוד לפסיכומטרי (לי לא לפחות הרגיש ככה). אז בתור חובב תכנות עשיתי לעצמי אתר קטן שבו הכנסתי לעצמי מאגר מילים מהאינטרנט, ויצרתי קוד לשאלות אמריקאיות. זה דיי עזר לי, והבנתי שגם לאחרים דבר כזה יכול לעזור? מקום שתוכל לתרגל את המילים שהכנסת לאתר, שאתה רוצה הכי באמת לתרגל ולעבור עליהם. לכן החלטתי אחרי הפסיכומטרי לבנות גרסה גדולה של האתר עם רעיונות חדשים.

## הרעיון

![image](https://github.com/NavehVH/Psychowords/assets/94969200/98bc27fb-229c-4104-b32e-e24f539f2cb4)



## פיצ'רים באתר
- אתר שתוכל להכניס מילים שכדאי לתרגל לפסיכומטרי, אבל גם תוכל להכניס דוגמאות למילה ואסוציאציות שתוכל לזכור אותם יותר טוב.
- תוכל להכניס את המילים שלך לקטגוריה מסוימת שיצרת בעצמך, ככה תוכל לתרגל את מילים ספציפיות שהכנסת.
- תוכל להגדיר את רמת הידע שלך למילה. (יודע טוב\יודע חלקית\לא יודע בכלל).
- אופציית תרגול של "שינון מילים" בוא תוכל לבחור כמה מילים לשנן, ולאחר השינון שעברת עליהם תוכל לעבור על שאלות אמריקאיות על המילים שעברת כמה שאתה רוצה בשביל שיכנס לראש.
- לאפשר לאחרים לראות מילים שכבר הכניסו אחרים בעזרת חיפוש, ולהכניס את המילה למאגר שלך בעזרת לחיצה על לייק למילה. החיפוש יראה את התוצאות עם הכי הרבה לייקים, ככה רוב הסיכויים שהפירוש באמת נכון שהכניסו.
- שאתה עובר על המילים שלך, לראות דוגמאות ואסוציאציות שמתאימות למילה שלך שאחרים הכניסו שקיבלו הכי הרבה לייקים, ואם אתה רואה שזה באמת נכון ומתאים, תוכל לעשות לייק שיכנס למאגר של המילה שלך.
- ועוד!
<!--
<details dir="rtl">
  <summary>היי</summary>
  

  ### משהו

</details>
<!-->
## להריץ את האתר
- ניתן לעשות fork או להוריד את הקבצים כרצונכם, אני משתמש בVS19. <br/>
- הוספתי לפרוייקט לreferences שאפשר למצוא בתקיית DLLs.
- באתר אני משתמש בMYSQL לאחסון נתונים, ניתן למצוא את הconnection string ולערוך אותו כרצונכם. הוא נמצא בApp_Data/Connections.cs. אני קראתי למוסד הנתונים בשם psychometry_data.<br/>
(אני רגיל להשתמש בXAMPP בשביל להשיג חיבור לPORT המתאים לחיבור מוצלח לMYSQL)<br/>
לינק לגיבוי של המוסד נתונים: https://mega.nz/file/IhMFCR6J#mMlIF7xp88X7g30Du4lj7NTSJ-rWr1lYR6TZuAOCxhc
<br/><br/>
הגיבוי נקי ורק הוספתי שם משתמש אחד:<br/>
שם משתמש: admin<br/>
סיסמה: 11111111

## האתר
האתר נבנה בASP.NET, בC#, בBOOTSTRAP, בJS ובAJAX בשביל שלא יהיה צורך לרענן את הדף ברוב השימושים.
עם שימוש במוסד נתונים MYSQL.
קרדיט לי על תכנות האתר, השתמשתי בכמה templates של bootstraps וערכתי אותם ממש שיתאימו לסוג האתר + המון תוספות שלי.
