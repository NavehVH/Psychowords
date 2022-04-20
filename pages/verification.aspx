<%@ Page Language="C#" AutoEventWireup="true" CodeFile="verification.aspx.cs" Inherits="Psychometric.pages.verification" %>

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
                                        <h5 class="card-title mb-0">עלייך להכניס קוד אימות שנשלח לאימייל שלך ולאחר מכן להתחבר שוב.</h5>
                                    </div>
                                    <div class="card-body">
                                        <h5>שם משתמש:</h5>
                                        <div class="mb-3">
                                            <asp:TextBox ID="UsernameTextBox" class="form-control textbox-defs textbox-hide" placeholder="שם משתמש" runat="server"></asp:TextBox>
                                        </div>
                                        <h5>קוד אימות:</h5>
                                        <div class="mb-3">
                                            <asp:TextBox ID="CodeTextBox" class="form-control textbox-defs textbox-hide" placeholder="סיסמה" runat="server"></asp:TextBox>
                                        </div>
                                        <button type="submit" onserverclick="ClickLogin" runat="server" class="btn btn-primary float-left">התחבר</button>
                                        <br />
                                        <asp:Label ID="LabelError" CssClass="text-danger" runat="server" Text=""></asp:Label>

                                        <br />
                                        <br />
                                        <asp:Button ID="EmailButton" runat="server" CssClass="btn btn-primary" Text="שלח אימייל שוב" OnClick="EmailButton_Click" />
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
                                <a href="#" class="text-muted"><strong>Coded by Naveh </strong></a>&copy;
                           
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
    <script src="../js/app.js"></script>
</body>
</html>

