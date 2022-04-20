<%@ Page Title="" Language="C#" MasterPageFile="~/master-pages/main.Master" AutoEventWireup="true" CodeFile="words-content.aspx.cs" Inherits="Psychometric.master_pages.WebForm1x" %>

<%@ Import Namespace="Psychometric.Classes" %>
<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/website.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid p-0" dir="rtl" lang="he">

        <h1 class="h3 mb-3">מילים בעברית</h1>
        <div class="row">
            <div class="col-md-2 col-xl-2">
                <div class="card">
                    <div class="card-header">
                        <h5 class="card-title mb-0"><span>מילים</span> <span id="allWordsSpan" runat="server" class="badge bg-primary badge-size float-left ml-2">0</span></h5>
                    </div>
                    <div class="words-content">
                        <div id="wordsOptions" class="list-group list-group-flush words-scroll" role="tablist" dir="ltr">
                            <%
                                DataTable dt = CurrentWordTable;
                                foreach (DataRow row in dt.Rows)
                                {
                                    switch (int.Parse(row[3].ToString()))
                                    {
                                        case 0:
                            %>
                            <a id="wordOption1<%=row[0] %>" onclick="setWord(this.id);" class="list-group-item list-group-item-action wordsList" data-toggle="list" href="#" role="tab"><%=row[2] %>
                            </a>
                            <%
                                    break;
                                case 1:
                            %>
                            <a id="wordOption2<%=row[0] %>" onclick="setWord(this.id);" class="list-group-item list-group-item-danger wordsList" data-toggle="list" href="#" role="tab"><%=row[2] %>
                            </a>
                            <%
                                    break;
                                case 2:
                            %>
                            <a id="wordOption3<%=row[0] %>" onclick="setWord(this.id);" class="list-group-item list-group-item-warning wordsList" data-toggle="list" href="#" role="tab"><%=row[2] %>
                            </a>
                            <%
                                    break;
                                case 3:
                            %>
                            <a id="wordOption4<%=row[0] %>" onclick="setWord(this.id);" class="list-group-item list-group-item-success wordsList" data-toggle="list" href="#" role="tab"><%=row[2] %>
                            </a>
                            <%
                                        break;
                                    }
                                }
                            %>
                        </div>
                    </div>
                </div>
            </div>
            <div id="wordContent" class="col">
                <div class="col-md-12 col-xl-12">
                    <div class="tab-content">
                        <div class="tab-pane fade show active" id="password" role="tabpanel">
                            <div class="card">
                                <div class="card-body">
                                    <div class="text-center" id="mainCardLoading">
                                        <div class="spinner-border m-7" style="width: 5rem; height: 5rem;" role="status">
                                            <span class="sr-only">Loading...</span>
                                        </div>
                                    </div>
                                    <div id="mainCardContent">
                                        <div class="words-icons">
                                            <button class="btn btn-success" onclick="setKnown(3); return false;"><i class="fas fa-check-double"></i></button>
                                            <button class="btn btn-warning" onclick="setKnown(2); return false;"><i class="fas fa-check"></i></button>
                                            <button class="btn btn-danger" onclick="setKnown(1); return false;"><i class="fas fa-times"></i></button>
                                            <button class="btn btn-primary ml-2" onclick="refreshSettings(); return false;" data-toggle="modal" data-target="#exampleModalCenter2"><i class="fas fa-pen"></i></button>
                                        </div>
                                        <div class="card-header">
                                            <h3 class="card-title"></h3>
                                            <h2 class="card-subtitle text-muted"><span id="knowShow" class="badge bg-success"><i class="fas fa-check-double"></i></span> <span id="wordName" runat="server" class="wordNameClass">מילה</span></h2>
                                            <hr style="border-color: red" />
                                        </div>
                                        <div class="card-body">
                                            <div id="wordBox1">
                                                <h5>פירושים:</h5>
                                                <div class="card wordCard displayNone">
                                                    <div class="card-header">
                                                        <asp:Label CssClass="wordElement" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="card wordCard displayNone">
                                                    <div class="card-header">
                                                        <asp:Label CssClass="wordElement" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="card wordCard displayNone">
                                                    <div class="card-header">
                                                        <asp:Label CssClass="wordElement" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="card wordCard displayNone">
                                                    <div class="card-header">
                                                        <asp:Label CssClass="wordElement" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="card wordCard displayNone">
                                                    <div class="card-header">
                                                        <asp:Label CssClass="wordElement" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="card wordCard displayNone">
                                                    <div class="card-header">
                                                        <asp:Label CssClass="wordElement" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="card wordCard displayNone">
                                                    <div class="card-header">
                                                        <asp:Label CssClass="wordElement" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="card wordCard displayNone">
                                                    <div class="card-header">
                                                        <asp:Label CssClass="wordElement" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="wordBox2">
                                                <h5>דוגמאות:</h5>
                                                <div class="card wordCard displayNone">
                                                    <div class="card-header">
                                                        <asp:Label CssClass="wordElement" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="card wordCard displayNone">
                                                    <div class="card-header">
                                                        <asp:Label CssClass="wordElement" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="card wordCard displayNone">
                                                    <div class="card-header">
                                                        <asp:Label CssClass="wordElement" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="card wordCard displayNone">
                                                    <div class="card-header">
                                                        <asp:Label CssClass="wordElement" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="card wordCard displayNone">
                                                    <div class="card-header">
                                                        <asp:Label CssClass="wordElement" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="card wordCard displayNone">
                                                    <div class="card-header">
                                                        <asp:Label CssClass="wordElement" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="card wordCard displayNone">
                                                    <div class="card-header">
                                                        <asp:Label CssClass="wordElement" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="card wordCard displayNone">
                                                    <div class="card-header">
                                                        <asp:Label CssClass="wordElement" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="wordBox3">
                                                <h5>אסוציאציות:</h5>
                                                <div class="card wordCard displayNone">
                                                    <div class="card-header">
                                                        <asp:Label CssClass="wordElement" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="card wordCard displayNone">
                                                    <div class="card-header">
                                                        <asp:Label CssClass="wordElement" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="card wordCard displayNone">
                                                    <div class="card-header">
                                                        <asp:Label CssClass="wordElement" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="card wordCard displayNone">
                                                    <div class="card-header">
                                                        <asp:Label CssClass="wordElement" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="card wordCard displayNone">
                                                    <div class="card-header">
                                                        <asp:Label CssClass="wordElement" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="card wordCard displayNone">
                                                    <div class="card-header">
                                                        <asp:Label CssClass="wordElement" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="card wordCard displayNone">
                                                    <div class="card-header">
                                                        <asp:Label CssClass="wordElement" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="card wordCard displayNone">
                                                    <div class="card-header">
                                                        <asp:Label CssClass="wordElement" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <asp:UpdatePanel ID="DefinitionsPanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ShowAssButton" EventName="serverclick" />
                        <asp:AsyncPostBackTrigger ControlID="ShowExaButton" EventName="serverclick" />
                        <asp:AsyncPostBackTrigger ControlID="ShowDefButton" EventName="serverclick" />
                    </Triggers>
                    <ContentTemplate>
                        <div class="col-md-12 col-xl-12">
                            <div class="tab-content">
                                <div class="tab-pane fade show active" role="tabpanel">
                                    <div class="card">
                                        <div class="card-header">
                                            <span>מידע של אחרים שקשור למילה הזאת:</span><br /><br />
                                            <button id="ShowAssButton" class="btn btn-primary" runat="server" onserverclick="UpdateAss">אסוציאציות</button>
                                            <button id="ShowExaButton" class="btn btn-primary" runat="server" onserverclick="UpdateExa">דוגמאות</button>
                                            <button id="ShowDefButton" class="btn btn-primary" runat="server" onserverclick="UpdateDef">פירושים</button>
                                        </div>
                                        <div class="card-body" id="tablesDiv">
                                            <div class="tab-content">
                                                <div class="tab-pane fade show active" id="Tab4" runat="server">
                                                    <h5 class="card-title">אסוציאציות של אחרים</h5>
                                                    <div class="words-content-scroll">
                                                        <table class="table table-striped table-sm">
                                                            <thead>
                                                                <tr>
                                                                    <th style="width: 10%;">מילה</th>
                                                                    <th style="width: 78%">אסוציאציה</th>
                                                                    <th style="width: 6%">לייקים</th>
                                                                    <th style="width: 6%">Actions</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <%
                                                                    if (AssociationsTable != null)
                                                                    {
                                                                        DataTable dt = AssociationsTable;
                                                                        foreach (DataRow row in dt.Rows)
                                                                        {
                                                                %>
                                                                <tr>
                                                                    <td id="wordName3<%=row[2] %>"><%=GetWordById(int.Parse(row[2].ToString())).Word %></td>
                                                                    <td><span id="rowData3<%=row[0] %>"><%=row[3] %></span></td>
                                                                    <td><%=GetTypeLikesCount(int.Parse(row[0].ToString()), "associations") %></td>
                                                                    <td class="table-action">
                                                                        <a href="#" data-toggle="modal" onclick="likeWord(this.id, 3, <%=row[2] %>)" data-target="#exampleModalCenter" id="heartAss<%=row[0] %>"><i class="far fa-heart"></i></a>
                                                                    </td>
                                                                </tr>
                                                                <%
                                                                        }
                                                                    }
                                                                %>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                                <div class="tab-pane fade show active" id="Tab5" runat="server">
                                                    <h5 class="card-title">דוגמאות של אחרים</h5>
                                                    <div class="words-content-scroll">
                                                        <table class="table table-striped table-sm">
                                                            <thead>
                                                                <tr>
                                                                    <th style="width: 10%;">מילה</th>
                                                                    <th style="width: 78%">דוגמה</th>
                                                                    <th style="width: 6%">לייקים</th>
                                                                    <th style="width: 6%">Actions</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <%
                                                                    if (ExamplesTable != null)
                                                                    {
                                                                        DataTable dt = ExamplesTable;
                                                                        foreach (DataRow row in dt.Rows)
                                                                        {
                                                                %>
                                                                <tr>
                                                                    <td id="wordName4<%=row[2] %>"><%=GetWordById(int.Parse(row[2].ToString())).Word %></td>
                                                                    <td><span id="rowData4<%=row[0] %>"><%=row[3] %></span></td>
                                                                    <td><%=GetTypeLikesCount(int.Parse(row[0].ToString()), "examples") %></td>
                                                                    <td class="table-action">
                                                                        <a href="#" data-toggle="modal" onclick="likeWord(this.id, 4, <%=row[2] %>)" data-target="#exampleModalCenter" id="heartExa<%=row[0] %>"><i class="far fa-heart"></i></a>
                                                                    </td>
                                                                </tr>
                                                                <%
                                                                        }
                                                                    }
                                                                %>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                                <div class="tab-pane fade show active" id="Tab6" runat="server">
                                                    <h5 class="card-title">פירושים של אחרים</h5>
                                                    <div class="words-content-scroll">
                                                        <table class="table table-striped table-sm">
                                                            <thead>
                                                                <tr>
                                                                    <th style="width: 10%;">מילה</th>
                                                                    <th style="width: 78%">פירוש</th>
                                                                    <th style="width: 6%">לייקים</th>
                                                                    <th style="width: 6%">Actions</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <%
                                                                    if (DefinitionsTable != null)
                                                                    {
                                                                        DataTable dt = DefinitionsTable;
                                                                        foreach (DataRow row in dt.Rows)
                                                                        {
                                                                %>
                                                                <tr>
                                                                    <td id="wordName2<%=row[2] %>"><%=GetWordById(int.Parse(row[2].ToString())).Word %></td>
                                                                    <td><span id="rowData2<%=row[0] %>"><%=row[3] %></span></td>
                                                                    <td><%=GetTypeLikesCount(int.Parse(row[0].ToString()), "definitions") %></td>
                                                                    <td class="table-action">
                                                                        <a href="#" onclick="likeWord(this.id, 2, <%=row[2] %>)" data-toggle="modal" data-target="#exampleModalCenter" id="heartDef<%=row[0] %>"><i class="far fa-heart"></i></a>
                                                                    </td>
                                                                </tr>
                                                                <%
                                                                        }
                                                                    }
                                                                %>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                                <div class="tab-pane fade" id="tab-0" role="tabpanel">
                                                    <div class="card">
                                                        <div class="card-header">

                                                            <h5 class="card-title mb-0">אסוציאציות ודוגמאות של אחרים</h5>
                                                        </div>
                                                        <div class="card-body h-100">
                                                            <div class="d-flex align-items-start">
                                                                <img src="../img/avatars/avatar.png" width="36" height="36" class="rounded-circle mr-2" alt="Charles Hall">
                                                                <div class="flex-grow-1">
                                                                    <small class="float-left text-navy">30m ago</small>
                                                                    <span class="comments-top-header"><strong>נווה</strong> שיתף אסוציאציה שלו</span>
                                                                    <br />
                                                                    <br />
                                                                    <div class="border text-sm text-muted p-3 mt-1">
                                                                        אסוציאציה טובה אחושילינג
                                                                    </div>
                                                                    <small class="float-left text-navy">234 לייקים</small>
                                                                    <a href="#" class="btn btn-sm btn-danger mt-1"><i class="feather-sm" data-feather="heart"></i><strong>לייק </strong></a>
                                                                </div>
                                                            </div>

                                                            <hr />
                                                            <a href="#" class="btn btn-primary btn-block">Load more</a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <!-- Modal -->
    <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLongTitle">מידע על המילה</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body" dir="rtl" lang="he">
                    <span id="wordModalSpan"></span>
                    <span id="modalSpan"></span>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">סגור</button>
                    <button type="button" class="btn btn-primary" id="saveSettings" onclick="saveButton()">שמור</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="exampleModalCenter2" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLongTitle2">עריכה</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body" dir="rtl" lang="he">
                    <span>ערוך איזה קטגוריה תרצה לשייך את המילה:</span>
                    <asp:DropDownList ID="CategoryDropDownList" CssClass="CategoryDropListClass" runat="server">
                        <asp:ListItem Selected="True" Value="0">לא שייך</asp:ListItem>
                    </asp:DropDownList>
                    <br /><br />
                    <input type="checkbox" id="deleteCheckBox" class="form-check-input">
              <span class="form-check-label">מחק את המילה</span>
                    <br /><br /><small><a target="_blank" href="../hebrew/edit-word.aspx?Id=0" id="editWordHref">עריכה מתקדמת</a></small><br />

                    <strong id="savedSpan" class="displayNone"><br /><br />שינויים נשמרו בהצלחה.</strong>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal" id="editSettingsClose">סגור</button>
                    <button type="button" class="btn btn-primary" id="editSettings" onclick="saveEdit()">שמור</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JsHolder" runat="server">
    <script src="../js-english/words-content.js?2"></script>
</asp:Content>
