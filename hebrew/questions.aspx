<%@ Page Title="" Language="C#" MasterPageFile="~/master-pages/main.Master" AutoEventWireup="true" CodeFile="questions.aspx.cs" Inherits="Psychometric.master_pages.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/website.css" rel="stylesheet">
    <link href="../css/flip-card.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid p-0" dir="rtl" lang="he">

        <h1 class="h3 mb-3" runat="server" id="TitlePage">תרגול מילים בעברית</h1>

        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-body">
                        <div class="words-icons">
                            <button class="btn btn-primary" onclick="return false;" data-toggle="modal" data-target="#exampleModalCenter"><i class="fas fa-cog"></i></button>
                            <button class="btn btn-primary" id="sessionButton" onclick="startSession(); return false;">התחל תרגול</button>
                        </div>
                        <div id="questionDiv" class="displayNone">
                            <small class="float-left text-navy displayNone">רמת קושי: 100%</small>
                            <h1>איזו מילה פירושה:
                                <br />
                                <br />

                                <strong id="questionText"></strong>?</h1>
                            <br />
                            <br />
                            <br />

                            <div class="row">
                                <div class="col-md-4 col-xl-3 text-center optionsButtonsDiv displayNone">
                                    <div class="card bg-light border">
                                        <button onclick="return tryToAnswer(this.id, 0)" runat="server" class="btn btn-primary py-2 py-md-3 optionsButtons">בדיקה</button>
                                    </div>
                                </div>
                                <div class="col-md-4 col-xl-3 text-center optionsButtonsDiv displayNone">
                                    <div class="card bg-light border">
                                        <button onclick="return tryToAnswer(this.id, 1)" runat="server" class="btn btn-primary py-2 py-md-3 optionsButtons">בדיקה</button>
                                    </div>
                                </div>
                                <div class="col-md-4 col-xl-3 text-center optionsButtonsDiv displayNone">
                                    <div class="card bg-light border">
                                        <button onclick="return tryToAnswer(this.id, 2)" runat="server" class="btn btn-primary py-2 py-md-3 optionsButtons">בדיקה</button>
                                    </div>
                                </div>
                                <div class="col-md-4 col-xl-3 text-center optionsButtonsDiv displayNone">
                                    <div class="card bg-light border">
                                        <button onclick="return tryToAnswer(this.id, 3)" runat="server" class="btn btn-primary py-2 py-md-3 optionsButtons">בדיקה</button>
                                    </div>
                                </div>
                                <div class="col-md-4 col-xl-3 text-center optionsButtonsDiv displayNone">
                                    <div class="card bg-light border">
                                        <button onclick="return tryToAnswer(this.id, 4)" runat="server" class="btn btn-primary py-2 py-md-3 optionsButtons">בדיקה</button>
                                    </div>
                                </div>
                                <div class="col-md-4 col-xl-3 text-center optionsButtonsDiv displayNone">
                                    <div class="card bg-light border">
                                        <button onclick="return tryToAnswer(this.id, 5)" runat="server" class="btn btn-primary py-2 py-md-3 optionsButtons">בדיקה</button>
                                    </div>
                                </div>
                                <div class="col-md-4 col-xl-3 text-center optionsButtonsDiv displayNone">
                                    <div class="card bg-light border">
                                        <button onclick="return tryToAnswer(this.id, 6)" runat="server" class="btn btn-primary py-2 py-md-3 optionsButtons">בדיקה</button>
                                    </div>
                                </div>
                                <div class="col-md-4 col-xl-3 text-center optionsButtonsDiv displayNone">
                                    <div class="card bg-light border">
                                        <button onclick="return tryToAnswer(this.id, 7)" runat="server" class="btn btn-primary py-2 py-md-3 optionsButtons">בדיקה</button>
                                    </div>
                                </div>
                                <div class="col-md-4 col-xl-3 text-center optionsButtonsDiv displayNone">
                                    <div class="card bg-light border">
                                        <button onclick="return tryToAnswer(this.id, 8)" runat="server" class="btn btn-primary py-2 py-md-3 optionsButtons">בדיקה</button>
                                    </div>
                                </div>
                                <div class="col-md-4 col-xl-3 text-center optionsButtonsDiv displayNone">
                                    <div class="card bg-light border">
                                        <button onclick="return tryToAnswer(this.id, 9)" runat="server" class="btn btn-primary py-2 py-md-3 optionsButtons">בדיקה</button>
                                    </div>
                                </div>
                            </div>
                            <span>מספר שאלות שענית נכון: <strong id="questionsAmountSpan">0</strong>/<strong id="answeredSpan">0</strong>. אחוזי הצלחה: <strong><strong id="percentSpan">100</strong>%</strong></span>
                            <span class="float-left">
                                <span>זמן התרגול: </span>
                                <span id="minutes"></span>:<span id="seconds"></span>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>


    <!-- Modal -->
    <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLongTitle">הגדרות תרגול</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body" dir="rtl" lang="he">
                    <span>הכנס את כמות האופציות שאתה מעוניין שיהיה לתשובות:</span>
                    <asp:DropDownList ID="AnswersDropDownList" runat="server" CssClass="DropDownListClass">
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Selected="True" Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <span>איזה סוג של קטגוריה תרצה לתרגל?</span>
                    <asp:DropDownList ID="CategoryDropDownList" runat="server" CssClass="CategoryDropDownListClass">
                        <asp:ListItem Selected="True" Value="o1">כל המילים</asp:ListItem>
                        <asp:ListItem Value="o2">מילים שאני יודע</asp:ListItem>
                        <asp:ListItem Value="o3">מילים שאני בקושי יודע</asp:ListItem>
                        <asp:ListItem Value="o4">מילים שאני לא יודע</asp:ListItem>
                        <asp:ListItem Value="o5">מילים שלא הגדרתי ידע</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">סגור</button>
                    <button type="button" class="btn btn-primary" id="SaveInfoButton" runat="server" onserverclick="SaveInfoButton_ServerClick">שמור</button>
                </div>
            </div>
        </div>
    </div>

    <input type="hidden" id="MemorySession" runat="server" value="false" class="MemorySessionClass" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JsHolder" runat="server">
    <script src="../js-hebrew/questions.js?2"></script>
</asp:Content>
