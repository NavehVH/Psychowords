<%@ Page Title="" Language="C#" MasterPageFile="~/master-pages/main.Master" AutoEventWireup="true" CodeFile="settings.aspx.cs" Inherits="Psychometric.master_pages.WebForm11" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid p-0" dir="rtl">

        <h1 class="h3 mb-3">הגדרות</h1>

        <div class="row">
            <div class="col-md-3 col-xl-2">

                <!-- setting options -->
                <div class="card">
                    <div class="card-header">
                        <h5 class="card-title mb-0">הגדרות משתמש</h5>
                    </div>

                    <div class="list-group list-group-flush" role="tablist">
                        <a class="list-group-item list-group-item-action active" data-toggle="list" href="#account" role="tab">משתמש
                        </a>
                        <a class="list-group-item list-group-item-action" data-toggle="list" href="#password" role="tab">סיסמה
                        </a>
                        <a class="list-group-item list-group-item-action" data-toggle="list" href="#email" role="tab">אימייל
                        </a>
                    </div>
                </div>
            </div>


            <div class="col-md-9 col-xl-10">
                <div class="tab-content">
                    <div class="tab-pane fade show active" id="account" role="tabpanel">


                        <!-- user info -->
                        <div class="card">
                            <div class="card-header">

                                <h5 class="card-title mb-0">מידע על המשתמש</h5>
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-8">
                                        <div class="mb-3">
                                            <span>שם משתמש:</span> <strong id="Username" runat="server">Naveh</strong>
                                        </div>
                                        <div class="mb-3">
                                            <span class="col-3">שם פרטי:</span> <strong id="FirstName" runat="server">נווה</strong>
                                        </div>
                                        <div class="mb-3">
                                            <span class="col-3">שם משפחה:</span> <strong id="LastName" runat="server">הדס</strong>
                                        </div>
                                        <div class="mb-3">
                                            <span class="col-3">אימייל:</span> <strong id="Email" runat="server">naveh10@gmail.com</strong>
                                        </div>
                                        <div class="mb-3">
                                            <span class="col-3">תאריך הרשמה:</span> <strong id="RegistrationDate" runat="server">2020-12-20</strong>
                                        </div>
                                        <div class="mb-3">
                                            <span class="col-3">תאריך תחילת מנוי:</span> <strong runat="server" id="DatePurchase">2020-12-21</strong>
                                        </div>
                                        <div class="mb-3">
                                            <span class="col-3">זמן מנוי:</span> <strong runat="server" id="PurchasedFor">30 יום</strong>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>


                    </div>

                    <!-- change password -->
                    <div class="tab-pane fade" id="password" role="tabpanel">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title">שינוי סיסמה</h5>

                                <div class="mb-3">
                                    <label class="form-label" for="inputPasswordCurrent">סיסמה כרגע:</label>
                                    <input type="password" class="form-control passwordInputs" id="inputPasswordCurrent">
                                    <small><a onclick="sendEmailQuestion();" runat="server" id="ForgotPass">שכחת סיסמה?</a></small><br />
                                    <small id="inputPasswordCurrentV" class="displayNone">היי מה קורה</small>
                                </div>
                                <div class="mb-3">
                                    <label class="form-label" for="inputPasswordNew">סיסמה חדשה:</label>
                                    <input type="password" class="form-control passwordInputs" id="inputPasswordNew">
                                    <small id="inputPasswordNewV" class="displayNone">היי מה קורה</small>
                                </div>
                                <div class="mb-3">
                                    <label class="form-label" for="inputPasswordNew2">חזור על סיסמה חדשה:</label>
                                    <input type="password" class="form-control passwordInputs" id="inputPasswordNew2">
                                    <small id="inputPasswordNew2V" class="displayNone">היי מה קורה</small>
                                </div>
                                <button type="button" class="btn btn-primary" id="passwordButton" onclick="return validPasswordCheck();">שמור שינויים</button>
                                <br />
                                <br />
                                <small id="passwordButtonV" class="displayNone"></small>

                            </div>
                        </div>
                    </div>

                    <!-- change email -->
                    <div class="tab-pane fade" id="email" role="tabpanel">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title">שינוי אימייל</h5>

                                <div class="mb-3">
                                    <label class="form-label" for="inputPasswordCurrent">אימייל כרגע:</label>
                                    <input type="text" class="form-control emailInputs" id="inputEmailCurrent">
                                    <small id="inputEmailCurrentV" class="displayNone">היי מה קורה</small>
                                </div>
                                <div class="mb-3">
                                    <label class="form-label" for="inputPasswordNew">אימייל חדש:</label>
                                    <input type="text" class="form-control emailInputs" id="inputEmailNew">
                                    <small id="inputEmailNewV" class="displayNone">היי מה קורה</small>
                                </div>
                                <div class="mb-3">
                                    <label class="form-label" for="inputEmailNew2">חזור על אימייל חדש:</label>
                                    <input type="text" class="form-control emailInputs" id="inputEmailNew2">
                                    <small id="inputEmailNew2V" class="displayNone">היי מה קורה</small>
                                </div>
                                <button type="button" class="btn btn-primary" id="emailButton" onclick="return validEmailCheck();">שמור שינויים</button>
                                <br />
                                <br />
                                <small id="emailButtonV" class="displayNone"></small>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JsHolder" runat="server">
    <script src="../js-pages/settings.js?2"></script>
</asp:Content>
