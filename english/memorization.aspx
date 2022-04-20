<%@ Page Title="" Language="C#" MasterPageFile="~/master-pages/main.Master" AutoEventWireup="true" CodeFile="memorization.aspx.cs" Inherits="Psychometric.master_pages.WebForm3x" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/website.css" rel="stylesheet">
    <link href="../css/flip-card.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid p-0" dir="rtl" lang="he">

        <h1 class="h3 mb-3">שינון מילים באנגלית</h1>
        <input type="hidden" id="Interval" value="<%=IntervalDropDownList.SelectedValue.ToString() %>" />

        <div class="row">
            <!--Out box-->
            <div class="col-12">
                <div class="card">
                    <div class="card-body">
                        <div class="words-icons">
                            <button class="btn btn-primary" onclick="return false;" data-toggle="modal" runat="server" id="SettingButton" data-target="#exampleModalCenter"><i class="fas fa-cog"></i></button>
                            <button class="btn btn-primary" id="sessionButton" runat="server" onserverclick="sessionButton_ServerClick">התחל תרגול</button>
                            <button class="btn btn-primary" id="trainButton" runat="server" onserverclick="trainButton_ServerClick">המשך לתרגול שאלות</button>
                        </div>
                        <div id="memorizationDiv" runat="server">
                            <h4>מופיע לך 8 מילים, תשנן אותם ולאחר מכן תענה על השאלות.</h4>
                            <br />
                            <br />
                            <br />
                            <div class="words-icons card-flip-button">
                                <button type='button' onclick="flipCard(true);" class="btn btn-success" runat="server" id="FlipCardButton"><i class="fas fa-redo"></i></button>


                                <a href="#carouselExampleIndicators" onclick="flipCard(false); $('.carousel').carousel('next')" role="button" runat="server" id="NextButton">
                                    <button type='button' class="btn btn-flickr ">
                                        <i class="fas fa-arrow-left"></i>
                                    </button>
                                </a>

                                <a href="#carouselExampleIndicators" onclick="flipCard(false); $('.carousel').carousel('prev')" role="button" runat="server" id="PrevButton">
                                    <button type='button' class="btn btn-flickr ">
                                        <i class="fas fa-arrow-right"></i>
                                    </button>
                                </a>
                            </div>
                            <!--Slide Boxes-->
                            <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel" data-touch="true" data-interval="false">
                                <ol class="carousel-indicators">
                                    <li class="carousel-li active" data-target="#carouselExampleIndicators" data-slide-to="0"></li>
                                    <%
                                        for (int i = 1; i < OptionsNumber; i++)
                                        {
                                    %>
                                    <li class="carousel-li" data-target="#carouselExampleIndicators" data-slide-to="<%=i %>"></li>
                                    <%
                                        }
                                    %>
                                </ol>
                                <div class="carousel-inner">
                                    <%
                                        if (MyData != null)
                                        {
                                    %>
                                    <div class="carousel-item active">
                                        <div class="col-md-12 col-xl-12 mx-auto">
                                            <div class="tab-content">
                                                <div class="card card-word">
                                                    <div class="card- card-flip">
                                                        <div class="card__face card__face--front card-front">
                                                            <div class="borderBox">
                                                                <h1 class="word-name-middle"><%=MyData[1][0] %></h1>
                                                            </div>
                                                        </div>
                                                        <div class="card__face card__face--back card-back displayNone">
                                                            <div class="card-header">
                                                                <h1><%=MyData[1][0] %></h1>
                                                            </div>
                                                            <div class="card-body">
                                                                <h5>פירושים:</h5>
                                                                <%
                                                                    foreach (string s in WordData[0][0])
                                                                    {
                                                                %>
                                                                <div class="card">
                                                                    <div class="card-header">
                                                                        <span><%=s %></span>
                                                                    </div>
                                                                </div>
                                                                <%
                                                                    }
                                                                    if (WordData[1][0].Count != 0)
                                                                    {
                                                                        if (ShowExample.Checked)
                                                                        {
                                                                %>
                                                                <h5>דוגמאות:</h5>
                                                                <%
                                                                    }
                                                                    foreach (string s in WordData[1][0])
                                                                    {
                                                                %>
                                                                <div class="card">
                                                                    <div class="card-header">
                                                                        <span><%=s %></span>
                                                                    </div>
                                                                </div>
                                                                <%
                                                                        }
                                                                    }
                                                                    if (WordData[1][0].Count != 0)
                                                                    {
                                                                        if (ShowAssociation.Checked)
                                                                        {
                                                                %>
                                                                <h5>אסוציאציות:</h5>
                                                                <%
                                                                    }
                                                                    foreach (string s in WordData[2][0])
                                                                    {
                                                                %>
                                                                <div class="card">
                                                                    <div class="card-header">
                                                                        <span><%=s %></span>
                                                                    </div>
                                                                </div>
                                                                <%
                                                                        }
                                                                    }
                                                                %>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <%
                                        }
                                    %>

                                    <%
                                        if (MyData != null)
                                        {
                                            for (int i = 1; i < MyData[0].Length; i++)
                                            {
                                    %>
                                    <div class="carousel-item">
                                        <div class="col-md-12 col-xl-12 mx-auto">
                                            <div class="tab-content">
                                                <div class="card card-word">
                                                    <div class="card- card-flip">
                                                        <div class="card__face card__face--front card-front">
                                                            <div class="borderBox">
                                                                <h1 class="word-name-middle"><%=MyData[1][i] %></h1>
                                                            </div>
                                                        </div>
                                                        <div class="card__face card__face--back card-back displayNone">
                                                            <div class="card-header">
                                                                <h1><%=MyData[1][i] %></h1>
                                                            </div>
                                                            <div class="card-body">
                                                                <h5>פירושים:</h5>
                                                                <%
                                                                    foreach (string s in WordData[0][i])
                                                                    {
                                                                %>
                                                                <div class="card">
                                                                    <div class="card-header">
                                                                        <span><%=s %></span>
                                                                    </div>
                                                                </div>
                                                                <%
                                                                    }
                                                                    if (WordData[1][i].Count != 0)
                                                                    {
                                                                %>
                                                                <h5>דוגמאות:</h5>
                                                                <%
                                                                    }
                                                                    foreach (string s in WordData[1][i])
                                                                    {
                                                                %>
                                                                <div class="card">
                                                                    <div class="card-header">
                                                                        <span><%=s %></span>
                                                                    </div>
                                                                </div>
                                                                <%
                                                                    }
                                                                    if (WordData[2][i].Count != 0)
                                                                    {
                                                                %>
                                                                <h5>אסוציאציות:</h5>
                                                                <%
                                                                    }
                                                                    foreach (string s in WordData[2][i])
                                                                    {
                                                                %>
                                                                <div class="card">
                                                                    <div class="card-header">
                                                                        <span><%=s %></span>
                                                                    </div>
                                                                </div>
                                                                <%
                                                                    }
                                                                %>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <%
                                            }
                                        }
                                    %>
                                </div>
                            </div>
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
                    <span>הכנס את כמות המילים שתרצה לשנן ולתרגל:</span>
                    <asp:DropDownList ID="WordsDropList" runat="server">
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Selected="True" Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="11">11</asp:ListItem>
                        <asp:ListItem Value="12">12</asp:ListItem>
                        <asp:ListItem Value="13">13</asp:ListItem>
                        <asp:ListItem Value="14">14</asp:ListItem>
                        <asp:ListItem Value="15">15</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <span>איזה סוג של קטגוריה תרצה לתרגל?</span>
                    <asp:DropDownList ID="CategoryDropDownList" runat="server">
                        <asp:ListItem Selected="True" Value="o1">כל המילים</asp:ListItem>
                        <asp:ListItem Value="o2">מילים שאני יודע</asp:ListItem>
                        <asp:ListItem Value="o3">מילים שאני בקושי יודע</asp:ListItem>
                        <asp:ListItem Value="o4">מילים שאני לא יודע</asp:ListItem>
                        <asp:ListItem Value="o5">מילים שלא הגדרתי ידע</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <span>כל כמה זמן להעביר כל מילה (שניות)?</span>
                    <asp:DropDownList ID="IntervalDropDownList" runat="server">
                        <asp:ListItem Selected="True" Value="false">ידנית</asp:ListItem>
                        <asp:ListItem Value="2">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                    </asp:DropDownList>
                    <small class="text-danger">בטלפון עובד רק ידני</small>
                    <br />
                    <br />
                    <div class="form-check form-switch">
                        <input class="form-check-input" type="checkbox" id="ShowExample" runat="server" checked>
                        <span>הראה דוגמאות אם יש למילה.</span>
                    </div>
                    <br />
                    <div class="form-check form-switch">
                        <span>הראה אסוציאציות אם יש למילה.</span>
                        <input class="form-check-input" type="checkbox" id="ShowAssociation" runat="server" checked>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">סגור</button>
                    <button type="button" class="btn btn-primary" id="SaveInfoButton" runat="server" onserverclick="SaveInfoButton_ServerClick">שמור</button>
                </div>
            </div>
        </div>
    </div>
    <script src="../js-english/memorization.js?2"></script>

    <script>
        var Interval = document.getElementById('Interval').value;

        if (Interval == "false")
            Interval = false;
        else
            Interval = parseInt(Interval) * 1000;

        $(document).ready(function () {
            $('.carousel').carousel({
                interval: Interval
            })
        });

    </script>
</asp:Content>
