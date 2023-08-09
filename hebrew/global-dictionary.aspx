<%@ Page Title="" Language="C#" MasterPageFile="~/master-pages/main.Master" AutoEventWireup="true" CodeFile="global-dictionary.aspx.cs" Inherits="Psychometric.master_pages.WebForm7" %>

<%@ Import Namespace="Psychometric.Classes" %>
<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- css -->
    <link href="../css/website.css" rel="stylesheet">
    <!--
    <meta http-equiv="Content-Security-Policy" content="upgrade-insecure-requests"> 
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" type="text/javascript"></script>
    -->
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <!-- 
        page to search globally words in HEBREW
        -->

    <asp:UpdatePanel ID="GlobalDictionaryPanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="SearchButton" EventName="serverclick" />
        </Triggers>
        <ContentTemplate>
            <div class="container-fluid p-0" dir="rtl" lang="he">

                <h1 class="h3 mb-3">חיפוש בעברית</h1>

                <div class="row">
                    <div class="col-12 col-xl-3">
                        <div class="card">
                            <div class="card-header">
                                <h5 class="card-title mb-0">הגדרות חיפוש</h5>
                            </div>
                            <div class="card-body">
                                <h5>חיפוש</h5>

                                <!-- search bar -->
                                <div class="input-group input-group-navbar">
                                    <input type="text" class="form-control SearchTextBoxClass" placeholder="חיפוש" aria-label="Search" id="SearchTextBox" runat="server">
                                    <button id="SearchButton" runat="server" class="btn" type="button" onserverclick="SearchClick" onclientclick="return searchValidation(); __doPostBack('SearchButton',''">
                                        <span><i class="fas fa-search"></i></span>
                                    </button>
                                </div>
                                <small id="SearchValidation" class="displayNone">אופס</small>
                                <div>
                                    <hr />
                                    <br />
                                    <!-- search words by subject -->
                                    <h5>נושא:</h5>
                                    <select multiple class="form-control" runat="server" id="SelectList">
                                        <option>מילים הכי פופולריות</option>
                                        <option>א</option>
                                        <option>ב</option>
                                        <option>ג</option>
                                        <option>ד</option>
                                        <option>ה</option>
                                        <option>ו</option>
                                        <option>ז</option>
                                        <option>ח</option>
                                        <option>ט</option>
                                        <option>י</option>
                                        <option>כ</option>
                                        <option>ל</option>
                                        <option>מ</option>
                                        <option>נ</option>
                                        <option>ס</option>
                                        <option>ע</option>
                                        <option>פ</option>
                                        <option>צ</option>
                                        <option>ק</option>
                                        <option>ר</option>
                                        <option>ש</option>
                                        <option>ת</option>
                                    </select>
                                    <br />
                                    <h5>חיפוש לפי נושא
                                        <asp:Button ID="SubjectButton" runat="server" CssClass="btn btn-primary" Text="חיפוש נושא" OnClick="SubjectButton_Click" /></h5>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- main -->
                    <div id="SearchPanel" class="col-md-12 col-xl-9" runat="server">
                        <div class="tab-content">
                            <div class="tab-pane fade show active" role="tabpanel">
                                <div class="card">
                                    <!-- choose by what to search -->
                                    <div class="card-header">
                                        <ul class="nav nav-pills card-header-pills pull-right" role="tablist">
                                            <li class="nav-item">
                                                <a class="nav-link active" data-toggle="tab" href="#tab-4">חיפוש מילים</a>
                                            </li>
                                            <li class="nav-item">
                                                <a class="nav-link" data-toggle="tab" href="#tab-5">חיפוש פירושים</a>
                                            </li>
                                            <li class="nav-item">
                                                <a class="nav-link" data-toggle="tab" href="#tab-6">חיפוש אסוציאציות</a>
                                            </li>
                                            <li class="nav-item">
                                                <a class="nav-link" data-toggle="tab" href="#tab-7">חיפוש דוגמאות</a>
                                            </li>
                                        </ul>
                                    </div>
                                    <!-- show search by words -->
                                    <div class="card-body">
                                        <div class="tab-content">
                                            <div class="tab-pane fade show active" id="tab-4" role="tabpanel">
                                                <h5 class="card-title">מילים</h5>
                                                <h6 class="card-subtitle text-muted">חיפוש לפי מילים <strong runat="server" id="WordsEmptySpan">(לא נמצא מידע לחיפוש שלך)</strong></h6>
                                                <br />
                                                <div class="words-scroll">
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
                                                                if (WordsTable != null)
                                                                {
                                                                    DataTable dtWords = WordsTable;
                                                                    foreach (DataRow rowWords in dtWords.Rows)
                                                                    {
                                                            %>
                                                            <tr>
                                                                <td id="wordName1<%=rowWords[0] %>"><%=rowWords[2] %></td>
                                                                <td>
                                                                    <table>
                                                                        <%
                                                                            List<string> dtDef = GetInfoByWord(int.Parse(rowWords[0].ToString()), "definitions");
                                                                            foreach (string stringDef in dtDef)
                                                                            {
                                                                        %>
                                                                        <tr>
                                                                            <td><span>+</span> <span><%=stringDef %></span></td>
                                                                        </tr>
                                                                        <%
                                                                            }
                                                                        %>
                                                                    </table>
                                                                </td>
                                                                <td>
                                                                    <%=CheckLikes(rowWords[9].ToString()) %>
                                                                </td>
                                                                <td class="table-action">
                                                                    <a href="#" data-toggle="modal" onclick="likeWord(this.id, 1, <%=rowWords[0] %>)" data-target="#exampleModalCenter" id="heartWor<%=rowWords[0] %>"><i class="far fa-heart"></i></a>
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


                                            <!-- show search by definitions -->
                                            <div class="tab-pane fade" id="tab-5" role="tabpanel">
                                                <h5 class="card-title">מילים</h5>
                                                <h6 class="card-subtitle text-muted">חיפוש לפי פירושים <strong runat="server" id="DefsEmptySpan">(לא נמצא מידע לחיפוש שלך)</strong></h6>
                                                <br />
                                                <div class="words-scroll">
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
                                                                    <a href="#" data-toggle="modal" onclick="likeWord(this.id, 2, <%=row[2] %>)" data-target="#exampleModalCenter" id="heartDef<%=row[0] %>"><i class="far fa-heart"></i></a>
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

                                            <!-- show ass' search by words -->
                                            <div class="tab-pane fade" id="tab-6" role="tabpanel">
                                                <h5 class="card-title">מילים</h5>
                                                <h6 class="card-subtitle text-muted">חיפוש אסוציאציות לפי מילים <strong runat="server" id="AssEmptySpan">(לא נמצא מידע לחיפוש שלך)</strong></h6>
                                                <br />
                                                <div class="words-scroll">
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
                                            <!-- show search of exmaples by words -->
                                            <div class="tab-pane fade" id="tab-7" role="tabpanel">
                                                <h5 class="card-title">מילים</h5>
                                                <h6 class="card-subtitle text-muted">חיפוש דוגמאות לפי מילים <strong runat="server" id="ExaEmptySpan">(לא נמצא מידע לחיפוש שלך)</strong></h6>
                                                <br />
                                                <div class="words-scroll">
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

    <!-- not used -->
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
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JsHolder" runat="server">
    <script src="../js-hebrew/global-dictionary.js?2"></script>
</asp:Content>
