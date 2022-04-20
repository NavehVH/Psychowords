<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="termofservice.aspx.cs" Inherits="Psychometric.termofservice" %>

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
        <main>

            <!-- ======= Frequently Asked Questions Section ======= -->
            <section id="faq" class="faq section-bg mt-7" dir="rtl">
                <div class="container" data-aos="fade-up">

                    <div class="section-title">
                        <h2>מידע</h2>
                        <p></p>
                    </div>

                    <div class="faq-list" style="text-align: right;">
                        <ul>
                            <li data-aos="fade-up">
                                <i class="bx bx-info-circle icon-help"></i><a data-toggle="collapse" class="collapse" href="#faq-list-1">יצירת קשר <i class="bx bx-chevron-down icon-show"></i><i class="bx bx-chevron-up icon-close"></i></a>
                                <div id="faq-list-1" class="collapse show" data-parent=".faq-list">
                                    <p>
                                       ניתן ליצור קשר בלכתוב לנו לכתובת האימייל: support@psychowords.com
                                        
                                    </p>
                                </div>
                            </li>

                            <li data-aos="fade-up" data-aos-delay="100">
                                <i class="bx bx-info-circle icon-help"></i><a data-toggle="collapse" href="#faq-list-2" class="collapsed">תנאי השימוש <i class="bx bx-chevron-down icon-show"></i><i class="bx bx-chevron-up icon-close"></i></a>
                                <div id="faq-list-2" class="collapse" data-parent=".faq-list">
                                    </p>
<h1>תנאי שימוש באתר "Psychowords"</h1>
<h3>תקנון השימוש באתר הנ"ל נכתב בלשון זכר אך האמור בו מתייחס לנשים וגברים כאחד.</h3>
<p></p>
<ol>
<li>
<h4>קדימון</h4>
<p>אתר "Psychowords" (להלן "האתר") הוא אתר המשתמש כאתר ("נועד לתרגול מילים לפסיכומטרי") ייצוגי עבור "Psychowords" והנך מוזמן לקחת בו חלק בכפוף להסכמתך לתנאי השימוש אשר יפורטו להלן</p>
<p>בנוסף השימוש באתר זה על כל תכניו והשירותים המוצעים בו, הורדות של קבצים, מדיה כגון תמונות וסרטונים והתכנים השונים המוצעים לקהל המבקרים עשויים להשתנות מעת לעת או בהתאם לסוג התוכן.</p>
<p>הנהלת האתר שומרת לעצמה הזכות לעדכן את תנאי השימוש המוצגים להלן מעת לעת וללא התראה או אזכור מיוחד בערוצי האתר השונים.</p>
</li>
<li>
<h4>קניין רוחני</h4>
<p>האתר כמו גם כל המידע שבו לרבות קוד צד שרת באתר, קבצי מדיה, סרטונים, תמונות, טקסטים, קבצים המוצעים להורדה וכל חומר אחר אשר מוצג באתר שייכים במלואם לאתר הנ"ל ומהווים קניין רוחני בלעדי של אתר "שם האתר שלכם" ואין לעשות בהם שימוש ללא אישור כתוב מראש מאתר "Psychowords".</p>
<p>בנוסף אין להפיץ, להעתיק, לשכפל, לפרסם, לחקות או לעבד פיסות קוד, סרטונים, סימנים מסחריים או כל מדיה ותוכן אחר מבלי שיש ברשותכם אישור כתוב מראש.</p>
</li>
<li>
<h4>תוכן האתר</h4>
<p>אנו שואפים לספק לכם את המידע המוצג באתר ללא הפרעות אך יתכנו בשל שיקולים טכניים, תקלות צד ג או אחרים, הפרעות בזמינות האתר. ולכן איננו יכולים להתחייב כי האתר יהיה זמין לכם בכל עת ולא יינתן כל פיצוי כספי או אחר בשל הפסקת השירות / הורדת האתר.</p>
<p>קישורים לאתר חיצוניים אינם מהווים ערובה כי מדובר באתרים בטוחים, איכותיים או אמינים וביקור בהם נעשה על דעתכם האישית בלבד ונמצאים בתחום האחריות הבלעדי של המשתמש באתר.</p>
<p>התכנים המוצעים באתר הינם בבעלותם הבלעדית של "Psychowords" ואין לעשות בהם שימוש אשר נועד את האמור בתקנון זה (ראה סעיף 3) למעט במקרים בהם צוין אחרת או במקרים בהם צוין כי זכויות היוצרים שייכים לגוף חיצוני. במקרים אלו יש לבדוק מהם תנאי השימוש בקישור המצורף ולפעול על פי המצוין באתר החיצוני לו שייכים התכנים.</p>
</li>
<li>
<h4>ניהול משתמשים ומבקרים באתר</h4>
<p>הנהלת האתר שומרת לעצמה את הזכות לחסום כל משתמש ובין אם על ידי חסימת כתובת הIP  של המחשב שלו, כתובת הMACID  של המחשב שלו או אפילו בהתאם למדינת המוצא אם עבר על חוקי האתר.</p>
<p>צוות האתר / הנהלת האתר יעשה כל שביכולתו להגן על פרטי המשתמשים הרשומים באתר / מנויים הרשומים באתר. במקרים בהם יעלה בידיו של צד שלישי להשיג גישה למידע מוסכם בזאת כי לגולשים, משתמשים וחברים באתר לה תהה כל תביעה, טענה או דרישה כלפי צוות האתר "Psychowords".</p>
</li>
<li>
<h4>גילוי נאות</h4>
<p>באתר זה עשוי לעשות שימוש בקבצי קוקיז (במיוחד עבור משתמשים רשומים ומנויים) שנועדו לאפשר כניסה אוטומטית לאתר ושמירת הגדרות שהמשתמש הכניס בשימוש באתר.</p>
<p>בכל העת ולבד מאשר גולשים המחוברים לאתר המידע הנשמר הוא אנונימי לחלוטין ואין בו את שם הגולש או כל פרט מזהה אחר.</p>
</li>
<li>
<h4>איזור שיפוט</h4>
<p>בעת שאתם עושים שימוש באתר ובמקרה בו התגלעה כל מחולקת אתם מסכימים להלן כי האמור לעיל נמצא תחת סמכות השיפוט הבלעדי של החוק הישראלי תוך שימוש במערכת בתי המשפט הישראליים בלבד במחוז תל אביב.</p>
</li>
</ol>
<p>	
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

        </main>

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
