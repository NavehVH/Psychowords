<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Psychometric.index" %>

<%@ Import Namespace="Psychometric.Classes" %>
<!DOCTYPE html>

<!DOCTYPE html>
<html lang="he" dir="rtl">

<head>
    <meta charset="utf-8">
    <meta content="width=device-width, initial-scale=1.0" name="viewport">

    <title>Psychowords</title>
    <meta content="" name="description">
    <meta content="" name="keywords">

    <!-- Favicons -->
    <link href="assets/img/favicon.png" rel="icon">
    <link href="assets/img/apple-touch-icon-box.png" rel="apple-touch-icon">

    <!-- Google Fonts -->
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i|Raleway:300,300i,400,400i,500,500i,600,600i,700,700i|Poppins:300,300i,400,400i,500,500i,600,600i,700,700i" rel="stylesheet">

    <!-- Vendor CSS Files -->
    <link href="../css/app.css" rel="stylesheet" />
    <link href="assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <link href="assets/vendor/icofont/icofont.min.css" rel="stylesheet">
    <link href="assets/vendor/boxicons/css/boxicons.min.css" rel="stylesheet">
    <link href="assets/vendor/remixicon/remixicon.css" rel="stylesheet">
    <link href="assets/vendor/venobox/venobox.css" rel="stylesheet">
    <link href="assets/vendor/owl.carousel/assets/owl.carousel.min.css" rel="stylesheet">
    <link href="assets/vendor/aos/aos.css" rel="stylesheet">

    <!-- Template Main CSS File -->
    <link href="assets/css/style.css" rel="stylesheet">

    <!-- =======================================================
  * Author: BootstrapMade.com
  * License: https://bootstrapmade.com/license/
  ======================================================== -->
</head>

<body>
    <form autocomplete="off" class="php-email-form" runat="server">
        <asp:ScriptManager ID="ScriptManager1"
            EnablePageMethods="true"
            EnablePartialRendering="true" runat="server" />
        <!-- ======= Header ======= -->
        <header id="header" class="fixed-top">
            <div class="container d-flex align-items-center">

                <h1 class="logo mr-auto"><a href="index.html"></a></h1>
                <!-- Uncomment below if you prefer to use an image logo -->
                <!-- <a href="index.html" class="logo mr-auto"><img src="assets/img/logo.png" alt="" class="img-fluid"></a>-->
                <nav class="nav-menu d-none d-lg-block">
                    <ul>
                        <li><a href="#about">עלינו</a></li>
                        <li><a href="#pricing">מחירים</a></li>
                        <%
                            if (Autorization.SessionId != 0)
                            {
                        %>
                        <li><a href="../pages/logout.aspx">התנתק</a></li>
                        <li><a href="../pages/main.aspx">המילון שלי</a></li>
                        <%
                            }
                            else
                            {
                        %>
                        <li><a href="#contact">הירשם</a></li>
                        <li><a href="../pages/login.aspx">התחבר</a></li>
                        <%
                            }
                        %>
                    </ul>
                </nav>
                <!-- .nav-menu -->

                <%
                    if (Autorization.SessionId == 0)
                    {
                %>
                <a href="#contact" class="get-started-btn scrollto">נסה חינם!</a>
                <%
                    }
                %>
            </div>
        </header>
        <!-- End Header -->

        <!-- ======= Hero Section ======= -->
        <section id="hero" class="align-items-center">
            <div class="container position-relative" data-aos="fade-up" data-aos-delay="70">
                <div class="row justify-content-center">
                    <div class="col-xl-7 col-lg-9 text-center">
                        <br />
                        <br />
                        <br />
                        <h1>Psychowords</h1>
                        <br />
                        <br />
                        <br />
                        <h1>אתר אחד לתרגול המילים לפסיכומטרי</h1>

                        <h2></h2>
                    </div>
                </div>
                <div class="text-center">
                    <a href="#services" class="btn-get-started scrollto">מה יש באתר?</a>
                </div>

            </div>
        </section>
        <!-- End Hero -->

        <main id="main">


            <section id="hero" class="counts section-bg" style="background: none; height: initial">
                <div class="container">

                    <div class="section-title col-12">
                        <h1>אז איך זה עובד?</h1>
                    </div>

                    <div class="faq-list" style="text-align: right;">
                        <div class="row icon-boxes">
                            <div class="col-md-6 col-lg-3 d-flex align-items-stretch mb-5 mb-lg-0" data-aos="zoom-in" data-aos-delay="200">
                                <div class="icon-box">
                                    <div class="icon"><i class="fas fa-address-card"></i></div>
                                    <h4 class="title"><a>נרשמים לאתר</a></h4>
                                    <p class="description">יוצרים משתמש משלך שיהיה לך גישה לעמודים שבאתר.</p>
                                </div>
                            </div>

                            <div class="col-md-6 col-lg-3 d-flex align-items-stretch mb-5 mb-lg-0" data-aos="zoom-in" data-aos-delay="300">
                                <div class="icon-box">
                                    <div class="icon"><i class="fas fa-file-signature"></i></div>
                                    <h4 class="title"><a>מכניסים מילים למאגר</a></h4>
                                    <p class="description">מוסיפים מילים שרוצים לתרגל עצמאית או עושים לייק למילים שכבר הכניסו לאתר.</p>
                                </div>
                            </div>

                            <div class="col-md-6 col-lg-3 d-flex align-items-stretch mb-5 mb-lg-0" data-aos="zoom-in" data-aos-delay="400">
                                <div class="icon-box">
                                    <div class="icon"><i class="fas fa-graduation-cap"></i></div>
                                    <h4 class="title"><a>מתרגלים</a></h4>
                                    <p class="description">מתרגלים בעזרת שינון מילים ושאלות אמריקאיות עד שזוכרים!</p>
                                </div>
                            </div>

                            <div class="col-md-6 col-lg-3 d-flex align-items-stretch mb-5 mb-lg-0" data-aos="zoom-in" data-aos-delay="500">
                                <div class="icon-box">
                                    <div class="icon"><i class="fas fa-check-double"></i></div>
                                    <h4 class="title"><a>שולטים במילים!</a></h4>
                                    <p class="description">האתר מאפשר לך לסדר את המילים לפי רמת ידע ולבחור איך ומה לתרגל.</p>
                                </div>
                            </div>

                        </div>
                    </div>



                </div>
            </section>


            <!-- ======= Counts Section ======= -->
            <section id="counts" class="counts section-bg">
                <div class="container">

                    <div class="row justify-content-end align-items-center justify-content-center">


                        <div class="col-lg-2 col-md-5 col-6 d-md-flex align-items-md-stretch">
                            <div class="count-box">
                                <span runat="server" id="hebrewCountSpan" data-toggle="counter-up">0</span>
                                <p>מילים שונות בעברית</p>
                            </div>
                        </div>

                        <div class="col-lg-2 col-md-5 col-6 d-md-flex align-items-md-stretch">
                            <div class="count-box">
                                <span runat="server" id="englishCountSpan" data-toggle="counter-up">0</span>
                                <p>מילים שונות באנגלית</p>
                            </div>
                        </div>

                        <div class="col-lg-2 col-md-5 col-6 d-md-flex align-items-md-stretch">
                            <div class="count-box">
                                <span runat="server" id="associationsCountSpan" data-toggle="counter-up">0</span>
                                <p>אסוציאציות שרשמו</p>
                            </div>
                        </div>

                        <div class="col-lg-2 col-md-5 col-6 d-md-flex align-items-md-stretch">
                            <div class="count-box">
                                <span runat="server" id="examplesCountSpan" data-toggle="counter-up">0</span>
                                <p>דוגמאות שרשמו</p>
                            </div>
                        </div>

                        <div class="col-lg-2 col-md-5 col-6 d-md-flex align-items-md-stretch">
                            <div class="count-box">
                                <span runat="server" id="likesCountSpan" data-toggle="counter-up">0</span>
                                <p>לייקים שעשו</p>
                            </div>
                        </div>

                    </div>

                </div>
            </section>
            <!-- End Counts Section -->




            <!-- ======= Testimonials Section ======= -->
            <section id="testimonials" class="testimonials">
                <div class="container" data-aos="fade-up">

                    <div class="section-title">
                        <h2>עליי</h2>
                        <p style="display: none;">Magnam dolores commodi suscipit. Necessitatibus eius consequatur ex aliquid fuga eum quidem. Sit sint consectetur velit. Quisquam quos quisquam cupiditate. Et nemo qui impedit suscipit alias ea. Quia fugiat sit in iste officiis commodi quidem hic quas.</p>
                    </div>



                    <div class="testimonial-item">
                        <p>
                            <i class="bx bxs-quote-alt-left quote-icon-left"></i>

                            נעים מאוד,<br />
                            אני נווה, בן 21 מאזור המרכז.<br />
                            <br />

                            עשיתי את הפסיכומטרי של מרץ 21 אחרי 3~4 חודשים של לימודים. אחד החלקים הכי חשובים ללמידה הוא האוצר מילים, שמצאתי אותו דיי מאתגר.<br />
                            בסופו של דבר אתה צריך לעבור על אלפי מילים שונות שלא שמעת בחיים וגם ככה אין שיטה מדויקת ללמוד את המילים אללו, כל אחד מוצא את השיטה שלו. אז התחלתי לעבור על מילים, לעבור ולעבור ואכלתי תסביכים.<br />
                            <br />

                            מסתכל על המילון שלי ולא מצליח להכניס את המילים לראש. הייתי חייב לשנות שיטה, נזכרתי שלתיאוריה הצלחתי ללמוד בעזרת שאלות אמריקאיות. אז בתוך אחד שחובב תכנות עשיתי לעצמי
אתר קטן שעושה לי שאלות אמריקאיות רנדומליות וראיתי שזה עזר לי, הבנתי שגם לאחרים זה יכול לעזור ועם הזמן עלה לי עוד ועוד רעיונות איך אפשר ליצור מערכת שלמה שמתאימה ללמידת מילים לפסיכומטרי 
                            והחלטתי לקחת על עצמי פרויקט ולעשות את האתר הזה שגם יוכל לעזור לאחרים שמחפשים דרכים לתרגל אוצר מילים לפסיכומטרי.

              <i class="bx bxs-quote-alt-right quote-icon-right"></i>
                        </p>
                        <img src="assets/img/testimonials/naveh-pic.jpeg" class="testimonial-img" alt="">
                        <h3>Naveh</h3>
                        <h4>Developer</h4>
                    </div>



                </div>
            </section>
            <!-- End Testimonials Section -->






            <!-- ======= About Section ======= -->
            <section id="about" class="about" style="display: none;">
                <div class="container" data-aos="fade-up">

                    <div class="section-title">
                        <h2>עלינו</h2>
                        <p>מחפשים מקום לתרגל את המילים שלכם לפסיכומטרי שאתם מתקשים? הגעתם למקום הנכון!</p>
                    </div>

                    <div class="row content">
                        <div class="col-lg-6">
                            <p style="text-align: right;">
                                למי מתאים האתר?<br />
                                <span><i class="ri-check-double-line"></i>בעל מילון ורוצה להכניס את המילים שלך ולתרגל</span><br />
                                <span><i class="ri-check-double-line"></i>אנשים שרוצים דרך נוספת לתרגל מילים שהם מתקשים בהם</span>
                            </p>
                        </div>
                        <div class="col-lg-6">
                            <p style="text-align: right;">
                                מה הרעיון? כמו סוג של רשת חברתית, רק שבמקום פוסטים אנשים יכולים לעלות מילים ואת ההגדרות שלהם, לראות מילים\פירושים\אסוציאציות\דוגמאות שאחרים הכניסו. אפשרות של לעשות לייקים לדברים שאתה רוצה להוסיף למאגר שלך. זה גם כמו מחברת עם יתרונות, האתר נועד שתוכל להכניס מילים שאתה מתקשה בהם, עם הפירוש שלהם לתוך האתר. להוסיף דוגמאות ואסוציאציות. אחר כך תוכל לתרגל אותם כמה שתרצה בעזרת שאלות אמריקאיות בנושא מסויים או בשיטת שינון מילים והתרגול שלהם אחר כך.
                            </p>
                        </div>
                    </div>

                </div>
            </section>
            <!-- End About Section -->
            <!-- ======= About Video Section ======= -->
            <section id="about-video" class="about-video" style="display: none;">
                <div class="container" data-aos="fade-up">

                    <div class="row">

                        <div class="col-lg-6 video-box align-self-baseline" data-aos="fade-right" data-aos-delay="100">
                            <img src="https://www.solidbackgrounds.com/images/1680x1050/1680x1050-dodger-blue-solid-color-background.jpg" class="img-fluid" alt="">
                            <a href="https://www.youtube.com/embed/dQw4w9WgXcQ" class="venobox play-btn mb-4" data-vbtype="video" data-autoplay="true"></a>
                        </div>

                        <div class="col-lg-6 pt-3 pt-lg-0 content" data-aos="fade-left" data-aos-delay="100">
                            <h3 class="text-md-right">בואו תראו דוגמה איך זה עובד</h3>
                            <p class="font-italic text-md-right">
                                דוגמה שלמה בסרטון אחד
                            </p>
                            <p class="text-md-right">
                                עוד איזה פסקה נחמדה לחפור לכם
                            </p>
                        </div>

                    </div>

                </div>
            </section>
            <!-- End About Video Section -->



            <!-- ======= Services Section ======= -->
            <section id="services" class="services section-bg">
                <div class="container" data-aos="fade-up">

                    <div class="section-title">
                        <h2>מה מיוחד באתר?</h2>
                        <p></p>
                    </div>

                    <div class="row">
                        <div class="col-lg-4 col-md-6 d-flex align-items-stretch" data-aos="zoom-in" data-aos-delay="100">
                            <div class="icon-box iconbox-blue">
                                <div class="icon">
                                    <svg width="100" height="100" viewBox="0 0 600 600" xmlns="http://www.w3.org/2000/svg">
                                        <path stroke="none" stroke-width="0" fill="#f5f5f5" d="M300,521.0016835830174C376.1290562159157,517.8887921683347,466.0731472004068,529.7835943286574,510.70327084640275,468.03025145048787C554.3714126377745,407.6079735673963,508.03601936045806,328.9844924480964,491.2728898941984,256.3432110539036C474.5976632858925,184.082847569629,479.9380746630129,96.60480741107993,416.23090153303,58.64404602377083C348.86323505073057,18.502131276798302,261.93793281208167,40.57373210992963,193.5410806939664,78.93577620505333C130.42746243093433,114.334589627462,98.30271207620316,179.96522072025542,76.75703585869454,249.04625023123273C51.97151888228291,328.5150500222984,13.704378332031375,421.85034740162234,66.52175969318436,486.19268352777647C119.04800174914682,550.1803526380478,217.28368757567262,524.383925680826,300,521.0016835830174"></path>
                                    </svg>
                                    <i class="fas fa-book-open"></i>
                                </div>
                                <h4><a>מתאים במיוחד לפסיכומטרי</a></h4>
                                <p>אפשר להכניס למילה דוגמאות שיכולות לעזור לך לזכור אותה וגם אסוציאציות.</p>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-6 d-flex align-items-stretch mt-4 mt-md-0" data-aos="zoom-in" data-aos-delay="200">
                            <div class="icon-box iconbox-orange ">
                                <div class="icon">
                                    <svg width="100" height="100" viewBox="0 0 600 600" xmlns="http://www.w3.org/2000/svg">
                                        <path stroke="none" stroke-width="0" fill="#f5f5f5" d="M300,582.0697525312426C382.5290701553225,586.8405444964366,449.9789794690241,525.3245884688669,502.5850820975895,461.55621195738473C556.606425686781,396.0723002908107,615.8543463187945,314.28637112970534,586.6730223649479,234.56875336149918C558.9533121215079,158.8439757836574,454.9685369536778,164.00468322053177,381.49747125262974,130.76875717737553C312.15926192815925,99.40240125094834,248.97055460311594,18.661163978235184,179.8680185752513,50.54337015887873C110.5421016452524,82.52863877960104,119.82277516462835,180.83849132639028,109.12597500060166,256.43424936330496C100.08760227029461,320.3096726198365,92.17705696193138,384.0621239912766,124.79988738764834,439.7174275375508C164.83382741302287,508.01625554203684,220.96474134820875,577.5009287672846,300,582.0697525312426"></path>
                                    </svg>
                                    <i class="fas fa-mobile-alt"></i>
                                </div>
                                <h4><a>מתאים לשימוש גם במחשב וגם בטלפון</a></h4>
                                <p>אתר מאוד גמיש שמתאים לשימוש בכל מכשיר.</p>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-6 d-flex align-items-stretch mt-4 mt-lg-0" data-aos="zoom-in" data-aos-delay="300">
                            <div class="icon-box iconbox-pink">
                                <div class="icon">
                                    <svg width="100" height="100" viewBox="0 0 600 600" xmlns="http://www.w3.org/2000/svg">
                                        <path stroke="none" stroke-width="0" fill="#f5f5f5" d="M300,541.5067337569781C382.14930387511276,545.0595476570109,479.8736841581634,548.3450877840088,526.4010558755058,480.5488172755941C571.5218469581645,414.80211281144784,517.5187510058486,332.0715597781072,496.52539010469104,255.14436215662573C477.37192572678356,184.95920475031193,473.57363656557914,105.61284051026155,413.0603344069578,65.22779650032875C343.27470386102294,18.654635553484475,251.2091493199835,5.337323636656869,175.0934190732945,40.62881213300186C97.87086631185822,76.43348514350839,51.98124368387456,156.15599469081315,36.44837278890362,239.84606092416172C21.716077023791087,319.22268207091537,43.775223500013084,401.1760424656574,96.891909868211,461.97329694683043C147.22146801428983,519.5804099606455,223.5754009179313,538.201503339737,300,541.5067337569781"></path>
                                    </svg>
                                    <i class="fas fa-search"></i>
                                </div>
                                <h4><a href="">גלובלי</a></h4>
                                <p>ניתן לראות מילים שאחרים הכניסו לאתר בעזרת חיפוש מתקדם.</p>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-6 d-flex align-items-stretch mt-4" data-aos="zoom-in" data-aos-delay="100">
                            <div class="icon-box iconbox-yellow">
                                <div class="icon">
                                    <svg width="100" height="100" viewBox="0 0 600 600" xmlns="http://www.w3.org/2000/svg">
                                        <path stroke="none" stroke-width="0" fill="#f5f5f5" d="M300,503.46388370962813C374.79870501325706,506.71871716319447,464.8034551963731,527.1746412648533,510.4981551193396,467.86667711651364C555.9287308511215,408.9015244558933,512.6030010748507,327.5744911775523,490.211057578863,256.5855673507754C471.097692560561,195.9906835881958,447.69079081568157,138.11976852964426,395.19560036434837,102.3242989838813C329.3053358748298,57.3949838291264,248.02791733380457,8.279543830951368,175.87071277845988,42.242879143198664C103.41431057327972,76.34704239035025,93.79494320519305,170.9812938413882,81.28167332365135,250.07896920659033C70.17666984294237,320.27484674793965,64.84698225790005,396.69656628748305,111.28512138212992,450.4950937839243C156.20124167950087,502.5303643271138,231.32542653798444,500.4755392045468,300,503.46388370962813"></path>
                                    </svg>
                                    <i class="fas fa-heart"></i>
                                </div>
                                <h4><a href="">לייקים</a></h4>
                                <p>אפשר לעשות לייקים למילים של אחרים, דוגמאות ואסוציאציות שתרצה להכניס למאגר שלך!</p>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-6 d-flex align-items-stretch mt-4" data-aos="zoom-in" data-aos-delay="200">
                            <div class="icon-box iconbox-red">
                                <div class="icon">
                                    <svg width="100" height="100" viewBox="0 0 600 600" xmlns="http://www.w3.org/2000/svg">
                                        <path stroke="none" stroke-width="0" fill="#f5f5f5" d="M300,532.3542879108572C369.38199826031484,532.3153073249985,429.10787420159085,491.63046689027357,474.5244479745417,439.17860296908856C522.8885846962883,383.3225815378663,569.1668002868075,314.3205725914397,550.7432151929288,242.7694973846089C532.6665558377875,172.5657663291529,456.2379748765914,142.6223662098291,390.3689995646985,112.34683881706744C326.66090330228417,83.06452184765237,258.84405631176094,53.51806209861945,193.32584062364296,78.48882559362697C121.61183558270385,105.82097193414197,62.805066853699245,167.19869350419734,48.57481801355237,242.6138429142374C34.843463184063346,315.3850353017275,76.69343916112496,383.4422959591041,125.22947124332185,439.3748458443577C170.7312796277747,491.8107796887764,230.57421082200815,532.3932930995766,300,532.3542879108572"></path>
                                    </svg>
                                    <i class="fas fa-check-double"></i>
                                </div>
                                <h4><a>להגדיר רמת ידע של מילה</a></h4>
                                <p>לכל מילה אפשר להגדיר את רמת הידע שלך בה. (יודע\בקושי יודע\לא יודע בכלל)</p>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-6 d-flex align-items-stretch mt-4" data-aos="zoom-in" data-aos-delay="300">
                            <div class="icon-box iconbox-teal">
                                <div class="icon">
                                    <svg width="100" height="100" viewBox="0 0 600 600" xmlns="http://www.w3.org/2000/svg">
                                        <path stroke="none" stroke-width="0" fill="#f5f5f5" d="M300,566.797414625762C385.7384707136149,576.1784315230908,478.7894351017131,552.8928747891023,531.9192734346935,484.94944893311C584.6109503024035,417.5663521118492,582.489472248146,322.67544863468447,553.9536738515405,242.03673114598146C529.1557734026468,171.96086150256528,465.24506316201064,127.66468636344209,395.9583748389544,100.7403814666027C334.2173773831606,76.7482773500951,269.4350130405921,84.62216499799875,207.1952322260088,107.2889140133804C132.92018162631612,134.33871894543012,41.79353780512637,160.00259165414826,22.644507872594943,236.69541883565114C3.319112789854554,314.0945973066697,72.72355303640163,379.243833228382,124.04198916343866,440.3218312028393C172.9286146004772,498.5055451809895,224.45579914871206,558.5317968840102,300,566.797414625762"></path>
                                    </svg>
                                    <i class="fas fa-file-import"></i>
                                </div>
                                <h4><a>לסדר לפי קטגוריות</a></h4>
                                <p>יכול ליצור קטגוריות מותאמות אישית בשם שאתה בוחר ולבחור איזה מילים להכניס לבפנים.</p>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-6 d-flex align-items-stretch mt-4" data-aos="zoom-in" data-aos-delay="300">
                            <div class="icon-box iconbox-teal">
                                <div class="icon">
                                    <svg width="100" height="100" viewBox="0 0 600 600" xmlns="http://www.w3.org/2000/svg">
                                        <path stroke="none" stroke-width="0" fill="#f5f5f5" d="M300,566.797414625762C385.7384707136149,576.1784315230908,478.7894351017131,552.8928747891023,531.9192734346935,484.94944893311C584.6109503024035,417.5663521118492,582.489472248146,322.67544863468447,553.9536738515405,242.03673114598146C529.1557734026468,171.96086150256528,465.24506316201064,127.66468636344209,395.9583748389544,100.7403814666027C334.2173773831606,76.7482773500951,269.4350130405921,84.62216499799875,207.1952322260088,107.2889140133804C132.92018162631612,134.33871894543012,41.79353780512637,160.00259165414826,22.644507872594943,236.69541883565114C3.319112789854554,314.0945973066697,72.72355303640163,379.243833228382,124.04198916343866,440.3218312028393C172.9286146004772,498.5055451809895,224.45579914871206,558.5317968840102,300,566.797414625762"></path>
                                    </svg>
                                    <i class="fas fa-question-circle"></i>
                                </div>
                                <h4><a>שאלות אמריקאיות</a></h4>
                                <p>יכול לבחור איזה קבוצת מילים תרצה לתרגל בשאלות אמריקאיות</p>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-6 d-flex align-items-stretch mt-4" data-aos="zoom-in" data-aos-delay="300">
                            <div class="icon-box iconbox-teal">
                                <div class="icon">
                                    <svg width="100" height="100" viewBox="0 0 600 600" xmlns="http://www.w3.org/2000/svg">
                                        <path stroke="none" stroke-width="0" fill="#f5f5f5" d="M300,566.797414625762C385.7384707136149,576.1784315230908,478.7894351017131,552.8928747891023,531.9192734346935,484.94944893311C584.6109503024035,417.5663521118492,582.489472248146,322.67544863468447,553.9536738515405,242.03673114598146C529.1557734026468,171.96086150256528,465.24506316201064,127.66468636344209,395.9583748389544,100.7403814666027C334.2173773831606,76.7482773500951,269.4350130405921,84.62216499799875,207.1952322260088,107.2889140133804C132.92018162631612,134.33871894543012,41.79353780512637,160.00259165414826,22.644507872594943,236.69541883565114C3.319112789854554,314.0945973066697,72.72355303640163,379.243833228382,124.04198916343866,440.3218312028393C172.9286146004772,498.5055451809895,224.45579914871206,558.5317968840102,300,566.797414625762"></path>
                                    </svg>
                                    <i class="fas fa-file-contract"></i>
                                </div>
                                <h4><a>שינון מילים</a></h4>
                                <p>צורת תרגול בה תוכל לעבור על כמות מילים מסויימת כמה שתרצה ולאחר מכן לענות שאלות עלייה.</p>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-6 d-flex align-items-stretch mt-4" data-aos="zoom-in" data-aos-delay="300">
                            <div class="icon-box iconbox-teal">
                                <div class="icon">
                                    <svg width="100" height="100" viewBox="0 0 600 600" xmlns="http://www.w3.org/2000/svg">
                                        <path stroke="none" stroke-width="0" fill="#f5f5f5" d="M300,566.797414625762C385.7384707136149,576.1784315230908,478.7894351017131,552.8928747891023,531.9192734346935,484.94944893311C584.6109503024035,417.5663521118492,582.489472248146,322.67544863468447,553.9536738515405,242.03673114598146C529.1557734026468,171.96086150256528,465.24506316201064,127.66468636344209,395.9583748389544,100.7403814666027C334.2173773831606,76.7482773500951,269.4350130405921,84.62216499799875,207.1952322260088,107.2889140133804C132.92018162631612,134.33871894543012,41.79353780512637,160.00259165414826,22.644507872594943,236.69541883565114C3.319112789854554,314.0945973066697,72.72355303640163,379.243833228382,124.04198916343866,440.3218312028393C172.9286146004772,498.5055451809895,224.45579914871206,558.5317968840102,300,566.797414625762"></path>
                                    </svg>
                                    <i class="fas fa-cogs"></i>
                                </div>
                                <h4><a>הגדרות תרגול</a></h4>
                                <p>יכול לשנות בהגדרות של התרגול כל מיני אופציות שיהיה לך יותר קל\קשה\נוח בתרגול.</p>
                            </div>
                        </div>

                    </div>

                </div>
            </section>
            <!-- End Sevices Section -->


            <!-- ======= Frequently Asked Questions Section ======= -->
            <section id="faq" class="faq section-bg" dir="rtl">
                <div class="container" data-aos="fade-up">

                    <div class="section-title">
                        <h2>שאלות נפוצות</h2>
                        <p>שאלות ששואלים אנשים בדרך כלל.</p>
                    </div>

                    <div class="faq-list" style="text-align: right;">
                        <ul>
                            <li data-aos="fade-up">
                                <i class="bx bx-help-circle icon-help"></i><a data-toggle="collapse" class="collapse" href="#faq-list-1">האתר עולה כסף? <i class="bx bx-chevron-down icon-show"></i><i class="bx bx-chevron-up icon-close"></i></a>
                                <div id="faq-list-1" class="collapse show" data-parent=".faq-list">
                                    <p>
                                       האתר כרגע בחינם, הוא בתקופת בטא שמטרתה לתקן את כל הבאגים שיש.<br />
                                        כנראה בעוד כמה חודשים אם האתר יהיה פופולרי אעשה מחיר זול לשימוש באתר.<br />
                                        - תחזוקת האתר עולה לי הרבה וצריך לממן את האחזקה שלו<br />
                                        - תכנות האתר לוקח זמן רב מזמני וגם בדיקה שתוכן באתר תקין שצריך לעשות בזמן היותי סטודנט.<br />
                                        - מטרת המנוי גם שאנשים שרציניים ללמוד יכניסו מילים נכונות כמה שיותר
                                        
                                    </p>
                                </div>
                            </li>

                            <li data-aos="fade-up" data-aos-delay="100">
                                <i class="bx bx-help-circle icon-help"></i><a data-toggle="collapse" href="#faq-list-2" class="collapsed">אנשים יכולים להכניס נתונים שאינם נכונים למילה, מה ההיגיון? <i class="bx bx-chevron-down icon-show"></i><i class="bx bx-chevron-up icon-close"></i></a>
                                <div id="faq-list-2" class="collapse" data-parent=".faq-list">
                                    <p>
                                        נכון, אנשים יכולים להכניס מילים שהפירוש\דוגמה שלהם אינו נכון.
                                        <br />
                                        <strong>זו אחריות המשתמש, לבדוק האם המילה\פירוש\דוגמה שהוא מכניס נכונה בעזרת מילונים\אינטרנט וכדומה.
                                            <br />
                                            האתר נועד ליצור כלי שיעזור ללמידה של המילים ואינו לקוח אחריות על נתונים לא נכונים שמתמשים אחרים הכניסו.<br />
                                            זוהי אחריות המשתמש בלבד לשים לב שהנתונים שלו נכונים.
                                        </strong>
                                    </p>
                                </div>
                            </li>

                            <!--
                      <li data-aos="fade-up" data-aos-delay="100" >
                          <i class="bx bx-help-circle icon-help"></i> <a data-toggle="collapse" href="#faq-list-3" class="collapsed">ריק <i class="bx bx-chevron-down icon-show"></i><i class="bx bx-chevron-up icon-close"></i></a>
                          <div id="faq-list-3" class="collapse" data-parent=".faq-list">
                              <p>
                                  ריק
                              </p>
                          </div>
                      </li>
                      -->
                        </ul>
                    </div>

                </div>
            </section>
            <!-- End Frequently Asked Questions Section -->
            <!-- ======= Contact Section ======= -->
            <%
                if (Autorization.SessionId == 0)
                {
            %>

            <section id="contact" class="contact" style="text-align: right;">
                <div class="container" data-aos="fade-up">

                    <div class="section-title">
                        <h2>הירשם</h2>
                        <p>הירשם לאתר על מנת שתוכל לבצע רכישה.</p>
                    </div>

                    <div class="row mt-5">

                        <div class="col-lg-12 mt-5 mt-lg-0">

                            <div class="form-row">
                                <div class="col-md-6 form-group">
                                    <input type="text" class="form-control registrationInputs" id="firstName" placeholder="שם פרטי" />
                                    <span class="text-danger" id="firstNameV"></span>
                                </div>
                                <div class="col-md-6 form-group">
                                    <input type="text" class="form-control registrationInputs" id="lastName" placeholder="שם משפחה" />
                                    <span class="text-danger" id="lastNameV"></span>
                                </div>
                            </div>
                            <div class="form-group">
                                <input type="text" class="form-control registrationInputs" id="username" placeholder="שם משתמש" />
                                <span class="text-danger" id="usernameV"></span>
                            </div>
                            <div class="form-row">
                                <div class="col-md-6 form-group">
                                    <input type="password" autocomplete="off" class="form-control registrationInputs" id="password" placeholder="סיסמה" />
                                    <span class="text-danger" id="passwordV"></span>
                                </div>
                                <div class="col-md-6 form-group">
                                    <input type="password" autocomplete="off" class="form-control registrationInputs" id="passwordRepeat" placeholder="סיסמה שוב" />
                                    <span class="text-danger" id="passwordRepeatV"></span>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="col-md-6 form-group">
                                    <input type="email" class="form-control registrationInputs" id="email" placeholder="אימייל" />
                                    <span class="text-danger" id="emailV"></span>
                                </div>
                                <div class="col-md-6 form-group">
                                    <input type="email" class="form-control registrationInputs" id="emailRepeat" placeholder="אימייל שוב" />
                                    <span class="text-danger" id="emailRepeatV"></span>
                                </div>
                            </div>
                            <div class="text-center">
                                <button type="submit" class="btn btn-primary" onclick="validateRegistration();">הירשם</button>
                            </div>
                            <span class="text-success text-center" id="accountAddedSpan"></span>

                        </div>

                    </div>

                </div>
            </section>
            <!-- End Contact Section -->

            <%
                }
            %>


            <!-- ======= Pricing Section ======= -->
            <section id="pricing" class="pricing">
                <div class="container" data-aos="fade-up">

                    <div class="section-title">
                        <h2>מחירים</h2>
                        <p><strong>כרגע האתר בתקופת בטא, אפשר להשתמש בו בחינם עד להודעה חדשה.</strong></p>
                        <p style="display: none;">האתר מאפשר מנוי חודשי במחירים זולים לאנשים שרוצים להשתמש, אפשר לנסות בחינם ב-3 ימים הראשונים!</p>
                    </div>

                    <div class="row">

                        <div class="col-lg-4 col-md-6" data-aos="zoom-im" data-aos-delay="100">
                            <div class="box">
                                <h3>מנוי</h3>
                                <h4><sup>₪</sup><del>18</del><span> / חודש</span></h4>
                                <ul>
                                    <li>גישה להכניס מילים למאגר</li>
                                    <li>גישה לעשות לייקים למילים של אחרים</li>
                                    <li>גישה לתרגול המילים</li>
                                </ul>
                                <div class="btn-wrap">
                                    <a href="#" class="btn-buy"><del>הירשם כמנוי</del></a>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-6 mt-4 mt-md-0" data-aos="zoom-in" data-aos-delay="100">
                            <div class="box featured">
                                <h3>מנוי</h3>
                                <h4><sup>₪</sup><del>26</del><span> / חודשיים</span></h4>
                                <ul>
                                    <li>גישה להכניס מילים למאגר</li>
                                    <li>גישה לעשות לייקים למילים של אחרים</li>
                                    <li>גישה לתרגול המילים</li>
                                </ul>
                                <div class="btn-wrap">
                                    <a href="#" class="btn-buy"><del>הירשם כמנוי</del></a>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-6 mt-4 mt-lg-0" data-aos="zoom-in" data-aos-delay="100">
                            <div class="box">
                                <h3>מנוי</h3>
                                <h4><sup>₪</sup><del>37</del><span> / 3 חודשים</span></h4>
                                <ul>
                                    <li>גישה להכניס מילים למאגר</li>
                                    <li>גישה לעשות לייקים למילים של אחרים</li>
                                    <li>גישה לתרגול המילים</li>
                                </ul>
                                <div class="btn-wrap">
                                    <a href="#" class="btn-buy"><del>הירשם כמנוי</del></a>
                                </div>
                            </div>
                        </div>

                    </div>

                </div>
            </section>
            <!-- End Pricing Section -->

        </main><!-- End #main -->

        <!-- ======= Footer ======= -->
        <footer id="footer" style="text-align: right;">

            <div class="footer-top">
                <div class="container">
                    <div class="row">

                        <div class="col-lg-3 col-md-6 footer-contact">
                            <h3>Psychowords</h3>
                            <p>
                                <strong>אימייל ליצור קשר:</strong> support@psychowords.com<br>
                            </p>
                        </div>

                        <div class="col-lg-2 col-md-6 footer-links">
                            <h4>לינקיים שימושיים</h4>
                            <ul>
                                <li><i class="bx bx-chevron-left"></i><a href="../index.aspx">דף הבית</a></li>
                            </ul>
                        </div>

                    </div>
                </div>
            </div>

            <div class="container d-md-flex py-4">

                <div class="mr-md-auto text-center text-md-left">
                    <div class="copyright">
                        &copy; Coded by Naveh. Designed by <strong><span>OnePage</span></strong> Copyright. All Rights Reserved
                    </div>
                    <div class="credits">
                        <!-- All the links in the footer should remain intact. -->
                        <!-- You can delete the links only if you purchased the pro version. -->
                        <!-- Licensing information: https://bootstrapmade.com/license/ -->
                        <!-- Purchase the pro version with working PHP/AJAX contact form: https://bootstrapmade.com/onepage-multipurpose-bootstrap-template/ -->
                    </div>
                </div>
            </div>
        </footer>
        <!-- End Footer -->

        <a href="#" class="back-to-top"><i class="ri-arrow-up-line"></i></a>
        <div id="preloader"></div>

        <!-- Vendor JS Files -->
        <script src="assets/vendor/jquery/jquery.min.js"></script>
        <script src="assets/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
        <script src="assets/vendor/jquery.easing/jquery.easing.min.js"></script>
        <script src="assets/vendor/php-email-form/validate.js"></script>
        <script src="assets/vendor/waypoints/jquery.waypoints.min.js"></script>
        <script src="assets/vendor/counterup/counterup.min.js"></script>
        <script src="assets/vendor/venobox/venobox.min.js"></script>
        <script src="assets/vendor/owl.carousel/owl.carousel.min.js"></script>
        <script src="assets/vendor/isotope-layout/isotope.pkgd.min.js"></script>
        <script src="assets/vendor/aos/aos.js"></script>

        <script src="js-pages/index.js?2"></script>

        <!-- Template Main JS File -->
        <script src="assets/js/main.js"></script>
    </form>
</body>

</html>
