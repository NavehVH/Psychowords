<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Psychometric.pages.login" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="Responsive Admin &amp; Dashboard Template based on Bootstrap 5">
    <meta name="author" content="AdminKit">
    <meta name="keywords" content="adminkit, bootstrap, bootstrap 5, admin, dashboard, template, responsive, css, sass, html, theme, front-end, ui kit, web">

    <link rel="shortcut icon" href="../img/icons/favicon.png" />

    <title>Blank Page | AdminKit Demo</title>

    <link href="../css/app.css" rel="stylesheet">
</head>

<body>
    <div class="wrapper">

        <div class="main">
            <nav class="navbar navbar-expand navbar-light navbar-bg">
                <a class="sidebar-toggle d-flex" href="../index.aspx">
                    <i class="fas fa-chevron-left align-middle align-self-center"></i>
                </a>
            </nav>

            <main class="content">
                <form id="form1" runat="server">
                    <asp:ScriptManager ID="ScriptManager1"
                        EnablePageMethods="true"
                        EnablePartialRendering="true" runat="server" />
                    <div>
                        <div class="container-fluid p-0" dir="rtl" lang="he">
                            <div class="col-12 col-xl-6 mx-auto">
                                <div class="card">
                                    <div class="card-header">
                                        <h5 class="card-title mb-0">התחבר למשתמש</h5>
                                    </div>
                                    <div class="card-body">
                                        <h5>שם משתמש:</h5>
                                        <div class="mb-3">
                                            <asp:TextBox ID="UsernameTextBox" class="form-control textbox-defs textbox-hide" placeholder="שם משתמש" runat="server"></asp:TextBox>
                                        </div>
                                        <h5>סיסמה:</h5>
                                        <div class="mb-3">
                                            <asp:TextBox ID="PasswordTextBox" TextMode="Password" class="form-control textbox-defs textbox-hide" placeholder="סיסמה" runat="server"></asp:TextBox>
                                        </div>
                                        <small><a onclick="sendEmailQuestion();" runat="server" id="ForgotPass">שכחת סיסמה?</a></small><br />
                                        <button type="submit" onserverclick="ClickLogin" runat="server" class="btn btn-primary float-left">התחבר</button>
                                        <br />
                                        <asp:Label ID="LabelError" CssClass="text-danger" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </form>
            </main>

            <footer class="footer">
                <div class="container-fluid">
                    <div class="row text-muted">
                        <div class="col-6 text-left">
                            <p class="mb-0">
                                <a href="#" class="text-muted"><strong>Coded by Naveh </strong>. Designed by Paul Laros and his team.</a>&copy;
                           
                            </p>
                        </div>
                        <div class="col-6 text-right">
                            <ul class="list-inline">
                                <li class="list-inline-item">
                                    <a class="text-muted" href="#">Support</a>
                                </li>
                                <li class="list-inline-item">
                                    <a class="text-muted" href="#">Help Center</a>
                                </li>
                                <li class="list-inline-item">
                                    <a class="text-muted" href="#">Privacy</a>
                                </li>
                                <li class="list-inline-item">
                                    <a class="text-muted" href="#">Terms</a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </footer>
        </div>
    </div>
    <script>
        function sendEmailQuestion() {

            var username = prompt("הכנס את שם המשתמש שלך", "");
            var email = prompt("הכנס את כתובת האימייל של המשתמש שלך", "");

            if (email == null || email == "" || username == null || username == "") {
                txt = "לא הכנסת מידע.";
                alert(txt);
            } else {
                forgotPass_ServerClickAjax(username, email, function (result) {
                    if (result == true) {
                        alert("אימייל נשלח בהצלחה עם סיסמה חדשה למשתמש.");
                    }
                    else {
                        alert("משהו השתבש, או שהנתונים שהכנסת אינם נכונים למשתמש, או שהמערכת כבר שלחה לך אימייל ב5 דקות האחרונות או שהתחברת למשתמש ב5 דקות האחרונות. בדיקה זו מונעת ספאם, חכה 5 דקות ונסה שוב.")
                    }
                });
            }
        }

        function forgotPass_ServerClickAjax(username, email, callback) {

            try {
                PageMethods.ForgotPass_ServerClick(username, email, onSucess, onError);
                function onSucess(result) {
                    callback(result);
                }
                function onError(result) {
                    //Nothing
                }
            } catch (e) {
                //Nothing
            }
            return false;
        }
    </script>
    <script src="../js/app.js"></script>
</body>
</html>
