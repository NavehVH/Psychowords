<%@ Page Title="" Language="C#" MasterPageFile="~/master-pages/main.Master" AutoEventWireup="true" CodeFile="add-word.aspx.cs" Inherits="Psychometric.master_pages.WebForm6" %>

<%@ Import Namespace="Psychometric.Classes" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/website.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="WordAddingPanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="container-fluid p-0" dir="rtl" lang="he">
                <h1 class="h3 mb-3">הוספת מילה למילון בעברית</h1>

                <div class="row">
                    <div class="col-12 col-xl-6">
                        <div class="card">
                            <div class="card-body">
                                <button class="btn btn-primary float-left mr-2" onclick="return false;" data-toggle="modal" data-target="#exampleModalCenter"><i class="fas fa-cog"></i></button>
                                <div class="col-3 float-left mb-2">
                                    <asp:DropDownList class="form-control CategoryDropListClass" ID="CategoryDropList" runat="server">
                                        <asp:ListItem Value="0">קטגוריה</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <h5 class="card-title">הוסף מילה:</h5>
                                <div class="mb-3">
                                    <asp:TextBox ID="WordTextBox" AutoPostBack="True" onchange="removeLikes();" OnTextChanged="WordTextBox_TextChanged" CssClass="form-control WordTextClass" runat="server" placeholder="מילה"></asp:TextBox>
                                </div>
                                <small id="wordValidation" class="displayNone">אופס</small> <small class="text-danger displayNone" id="editWordSpan">האם ברצונך לערוך את המילה? <a id="editWordHref" target="_blank" href="#">ערוך את המילה</a></small>
                            </div>
                        </div>

                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title">הוסף פירושים:</h5>
                                <asp:Panel ID="TextboxPanel" runat="server">
                                    <div>
                                        <div class="mb-3">
                                            <asp:TextBox class="form-control textbox-defs1" placeholder="פירוש" ID="FirstBox1" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="mb-3">
                                            <asp:TextBox class="form-control textbox-defs1 textbox-hide" placeholder="פירוש" ID="TextBox2" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="mb-3">
                                            <asp:TextBox class="form-control textbox-defs1 textbox-hide" placeholder="פירוש" ID="TextBox3" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="mb-3">
                                            <asp:TextBox class="form-control textbox-defs1 textbox-hide" placeholder="פירוש" ID="TextBox4" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="mb-3">
                                            <asp:TextBox class="form-control textbox-defs1 textbox-hide" placeholder="פירוש" ID="TextBox5" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="mb-3">
                                            <asp:TextBox class="form-control textbox-defs1 textbox-hide" placeholder="פירוש" ID="TextBox6" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="mb-3">
                                            <asp:TextBox class="form-control textbox-defs1 textbox-hide" placeholder="פירוש" ID="TextBox7" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="mb-3">
                                            <asp:TextBox class="form-control textbox-defs1 textbox-hide" placeholder="פירוש" ID="TextBox8" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <button type="button" onclick="addDefinitionTextBox(1)" class="btn btn-flickr"><i class="fas fa-plus"></i></button>
                                <br />
                                <small class="form-text text-muted">לחץ כאן על מנת להוסיף עוד פירוש למילה</small>
                                <br />
                                <small id="definitionsValidation" class="displayNone">אופס</small>
                                <asp:Button ID="Button1" CssClass="btn btn-primary float-left" runat="server" Text="הוסף" OnClientClick="WordValidationAndData();" />
                            </div>
                        </div>

                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title">הוסף דוגמאות:</h5>
                                <asp:Panel ID="TextboxPanelExamples" runat="server">
                                    <div>
                                        <div class="mb-3">
                                            <asp:TextBox class="form-control textbox-defs2" placeholder="דוגמה" ID="FirstBox2" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="mb-3">
                                            <asp:TextBox class="form-control textbox-defs2 textbox-hide" placeholder="דוגמה" ID="TextBox10" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="mb-3">
                                            <asp:TextBox class="form-control textbox-defs2 textbox-hide" placeholder="דוגמה" ID="TextBox11" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="mb-3">
                                            <asp:TextBox class="form-control textbox-defs2 textbox-hide" placeholder="דוגמה" ID="TextBox12" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="mb-3">
                                            <asp:TextBox class="form-control textbox-defs2 textbox-hide" placeholder="דוגמה" ID="TextBox13" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="mb-3">
                                            <asp:TextBox class="form-control textbox-defs2 textbox-hide" placeholder="דוגמה" ID="TextBox14" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="mb-3">
                                            <asp:TextBox class="form-control textbox-defs2 textbox-hide" placeholder="דוגמה" ID="TextBox15" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="mb-3">
                                            <asp:TextBox class="form-control textbox-defs2 textbox-hide" placeholder="דוגמה" ID="TextBox16" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <button type="button" onclick="addDefinitionTextBox(2)" class="btn btn-flickr"><i class="fas fa-plus"></i></button>
                                <br />
                                <small class="form-text text-muted">לחץ כאן על מנת להוסיף עוד פירוש למילה</small>
                            </div>
                        </div>

                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title">הוסף אסוציאציות:</h5>
                                <asp:Panel ID="TextboxPanelAssociations" runat="server">
                                    <div>
                                        <div class="mb-3">
                                            <asp:TextBox class="form-control textbox-defs3" placeholder="אסוציאציה" ID="FirstBox3" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="mb-3">
                                            <asp:TextBox class="form-control textbox-defs3 textbox-hide" placeholder="אסוציאציה" ID="TextBox18" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="mb-3">
                                            <asp:TextBox class="form-control textbox-defs3 textbox-hide" placeholder="אסוציאציה" ID="TextBox19" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="mb-3">
                                            <asp:TextBox class="form-control textbox-defs3 textbox-hide" placeholder="אסוציאציה" ID="TextBox20" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="mb-3">
                                            <asp:TextBox class="form-control textbox-defs3 textbox-hide" placeholder="אסוציאציה" ID="TextBox21" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="mb-3">
                                            <asp:TextBox class="form-control textbox-defs3 textbox-hide" placeholder="אסוציאציה" ID="TextBox22" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="mb-3">
                                            <asp:TextBox class="form-control textbox-defs3 textbox-hide" placeholder="אסוציאציה" ID="TextBox23" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="mb-3">
                                            <asp:TextBox class="form-control textbox-defs3 textbox-hide" placeholder="אסוציאציה" ID="TextBox24" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <button type="button" onclick="addDefinitionTextBox(3)" class="btn btn-flickr"><i class="fas fa-plus"></i></button>
                                <br />
                                <small class="form-text text-muted">לחץ כאן על מנת להוסיף עוד פירוש למילה</small>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12 col-xl-6">
                        <div class="tab-content">
                            <div class="tab-pane fade show active" role="tabpanel">
                                <div class="card">
                                    <div class="card-header">
                                        <h5>מידע שאולי קשור למילה שהכנסת:
                                            <asp:Label ID="WordLabel" runat="server" Text=""></asp:Label></h5>
                                        <hr />
                                        <ul class="nav nav-pills card-header-pills pull-right" role="tablist">
                                            <li class="nav-item">
                                                <a class="nav-link active" data-toggle="tab" href="#tab-4">פירושים</a>
                                            </li>
                                            <li class="nav-item">
                                                <a class="nav-link" data-toggle="tab" href="#tab-5">דוגמאות</a>
                                            </li>
                                            <li class="nav-item">
                                                <a class="nav-link" data-toggle="tab" href="#tab-6">אסוציאציות</a>
                                            </li>
                                        </ul>
                                    </div>
                                    <div class="card-body">
                                        <div class="tab-content">
                                            <div class="tab-pane fade show active" id="tab-4" role="tabpanel">
                                                <h5 class="card-title">פירושים
                                                    <asp:Label ID="FoundLabel1" runat="server" Text=""></asp:Label></h5>
                                                <div class="words-scroll">
                                                    <table class="table table-striped table-sm">
                                                        <thead>
                                                            <tr>
                                                                <th style="width: 6%"></th>
                                                                <th style="width: 78%">פירוש</th>
                                                                <th style="width: 6%">לייקים</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <%
                                                                DataTable dt = DefenitionsTable;
                                                                foreach (DataRow row in dt.Rows)
                                                                {
                                                            %>
                                                            <tr>
                                                                <td class="table-action">
                                                                    <a href="#" class="likeHearts" id="heart1<%=row[0] %>" onclick="likeOption(1, this.id)"><i class="far fa-heart"></i></a>
                                                                </td>
                                                                <td id="tdHeart1<%=row[0] %>"><%=row[3] %></td>
                                                                <td><%=GetTypeLikesCount(int.Parse(row[0].ToString()), "definitions") %></td>
                                                            </tr>
                                                            <%
                                                                }
                                                            %>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                            <div class="tab-pane fade" id="tab-5" role="tabpanel">
                                                <h5 class="card-title">דוגמאות
                                                    <asp:Label ID="FoundLabel2" runat="server" Text=""></asp:Label></h5>
                                                <div class="words-scroll">
                                                    <table class="table table-striped table-sm">
                                                        <thead>
                                                            <tr>
                                                                <th style="width: 6%"></th>
                                                                <th style="width: 78%">דוגמה</th>
                                                                <th style="width: 6%">לייקים</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <%
                                                                dt = ExamplesTable;
                                                                foreach (DataRow row in dt.Rows)
                                                                {
                                                            %>
                                                            <tr>
                                                                <td class="table-action">
                                                                    <a href="#" class="likeHearts" id="heart2<%=row[0] %>" onclick="likeOption(2, this.id)"><i class="far fa-heart"></i></a>
                                                                </td>
                                                                <td id="tdHeart2<%=row[0] %>"><%=row[3] %></td>
                                                                <td><%=GetTypeLikesCount(int.Parse(row[0].ToString()), "examples") %></td>
                                                            </tr>
                                                            <%
                                                                }
                                                            %>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                            <div class="tab-pane fade" id="tab-6" role="tabpanel">
                                                <h5 class="card-title">אסוציאציות
                                                    <asp:Label ID="FoundLabel3" runat="server" Text=""></asp:Label></h5>
                                                <div class="words-scroll">
                                                    <table class="table table-striped table-sm">
                                                        <thead>
                                                            <tr>
                                                                <th style="width: 6%"></th>
                                                                <th style="width: 78%">אסוציאציה</th>
                                                                <th style="width: 6%">לייקים</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <%
                                                                dt = AssociationsTable;
                                                                foreach (DataRow row in dt.Rows)
                                                                {
                                                            %>
                                                            <tr>
                                                                <td class="table-action">
                                                                    <a href="#" class="likeHearts" id="heart3<%=row[0] %>" onclick="likeOption(3, this.id)"><i class="far fa-heart"></i></a>
                                                                </td>
                                                                <td id="tdHeart3<%=row[0] %>"><%=row[3] %></td>
                                                                <td><%=GetTypeLikesCount(int.Parse(row[0].ToString()), "associations") %></td>
                                                            </tr>
                                                            <%
                                                                }
                                                            %>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="tab-content">
                            <div class="tab-pane fade show active">
                                <div class="card">
                                    <div class="card-header">
                                        <h5>10 מילים אחרונות שהכנסת:</h5>
                                        <hr />
                                    </div>
                                    <div class="card-body">
                                        <div class="tab-content">
                                            <div class="">
                                                <div class="words-scroll">
                                                    <table class="table table-striped table-sm">
                                                        <thead>
                                                            <tr>
                                                                <th style="width: 6%"></th>
                                                                <th style="width: 94%">מילה</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <%
                                                                dt = Last10Words;
                                                                if (dt != null)
                                                                {
                                                                    foreach (DataRow row in dt.Rows)
                                                                    {
                                                            %>
                                                            <tr>
                                                                <td class="table-action">
                                                                    <a href="../hebrew/edit-word.aspx?Id=<%=row[0] %>" class="editWord"><i class="far fa-edit"></i></a>
                                                                </td>
                                                                <td><%=row[2] %></td>
                                                            </tr>
                                                            <%
                                                                    }
                                                                }
                                                            %>
                                                        </tbody>
                                                    </table>
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

            <!-- Modal -->
            <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLongTitle">הגדרות הכנסת מילה</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body" dir="rtl" lang="he">
                            <div class="form-check form-switch">
                                <input class="form-check-input" type="checkbox" id="CategoryAgain" runat="server" checked>
                                <span>השתמש באותה קטגוריה שהשתמשתי פעם אחרונה.</span>
                            </div>
                            <br />
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">סגור</button>
                            <button type="button" class="btn btn-primary" id="SaveSettings" runat="server" onserverclick="SaveSettings_ServerClick">שמור</button>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JsHolder" runat="server">
    <script src="../js-hebrew/add-word.js?2"></script>
</asp:Content>
