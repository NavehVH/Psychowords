<%@ Page Title="" Language="C#" MasterPageFile="~/master-pages/main.Master" AutoEventWireup="true" CodeFile="self-dictionary.aspx.cs" Inherits="Psychometric.master_pages.WebForm4" %>

<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/website.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid p-0" dir="rtl" lang="he">

        <h1 class="h3 mb-3">מילון אישי בעברית</h1>

        <div class="row">
            <div class="col-md-12 col-xl-6">
                <div class="card">
                    <div class="card-header">
                        <h5 class="card-title mb-0">הגדרות</h5>
                    </div>
                    <div class="card-body">
                        <a class="buttonLinks" href="#" data-toggle="modal" data-target="#addCategory">
                            <div class="col-md-12 col-xl-12 text-center">
                                <div class="card py-2 py-md-1 border">
                                    <div class="card-body">
                                        <strong>הוסף קטגוריה</strong>
                                    </div>
                                </div>
                            </div>
                        </a>
                        <a class="buttonLinks" href="../hebrew/add-word.aspx">
                            <div class="col-md-12 col-xl-12 text-center">
                                <div class="card py-2 py-md-1 border">
                                    <div class="card-body">
                                        <strong>הוסף מילה ופירוש</strong>
                                    </div>
                                </div>
                            </div>
                        </a>
                    </div>
                </div>

                <div class="card">
                    <div class="card-header">
                        <h5 class="card-title mb-0">קטגוריות</h5>
                    </div>
                    <div class="card-body">
                        <div class="col-md-12 col-xl-12 text-center">
                            <%
                                DataTable dt = GetUserCategories();
                                foreach (DataRow row in dt.Rows)
                                {
                            %>
                            <a class="buttonLinks" href="../hebrew/words-content.aspx?category=<%=row[0] %>">
                                <div id="card<%=row[0] %>" class="card py-2 py-md-1 border">
                                    <div class="card-body text-center">
                                        <div class="float-left">
                                            <button onclick="return deleteButton(this.id)" id="deleteButton<%=row[0] %>" class="btn btn-danger category-icons"><i class="fas fa-times"></i></button>
                                        </div>
                                        <strong><%=row[2] %></strong>
                                        <span class="badge bg-primary badge-size"><%=GetCategoryCount(int.Parse(row[0].ToString())) %></span>
                                    </div>
                                </div>
                            </a>
                            <%
                                }
                            %>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-sm-12 col-xl-6">
                <div class="card">
                    <div class="card-header">
                        <h5 class="card-title mb-0">קטגוריות כלליות</h5>
                    </div>
                    <div class="card-body">
                        <div class="col-md-12 col-xl-12">
                            <a class="buttonLinks" href="../hebrew/words-content.aspx?type=4">
                                <div class="card py-2 py-md-1 border">
                                    <div class="card-body text-center">
                                        <strong>כל המילים שלי </strong>
                                        <span id="allWordsSpan" runat="server" class="badge bg-primary badge-size">0</span>
                                    </div>
                                </div>
                            </a>
                        </div>
                        <div class="col-md-12 col-xl-12">
                            <a class="buttonLinks" href="../hebrew/words-content.aspx?type=3">
                                <div class="card py-2 py-md-1 border">
                                    <div class="card-body text-center">
                                        <strong>כל המילים שאני יודע </strong>
                                        <span id="knownWordsSpan" runat="server" class="badge bg-primary badge-size">0</span>
                                    </div>
                                </div>
                            </a>
                        </div>
                        <div class="col-md-12 col-xl-12">
                            <a class="buttonLinks" href="../hebrew/words-content.aspx?type=2">
                                <div class="card py-2 py-md-1 border">
                                    <div class="card-body text-center">
                                        <strong>כל המילים שאני בקושי ידוע </strong>
                                        <span id="almostKnownWordsSpan" runat="server" class="badge bg-primary badge-size">0</span>
                                    </div>
                                </div>
                            </a>
                        </div>
                        <div class="col-md-12 col-xl-12">
                            <a class="buttonLinks" href="../hebrew/words-content.aspx?type=1">
                                <div class="card py-2 py-md-1 border">
                                    <div class="card-body text-center">
                                        <strong>כל המילים שאני לא יודע </strong>
                                        <span id="unknownWordsSpan" runat="server" class="badge bg-primary badge-size">0</span>
                                    </div>
                                </div>
                            </a>
                        </div>
                    </div>
                </div>
                <div class="card">
                    <div class="card-header">
                        <h5 class="card-title mb-0">קטגוריות כלליות</h5>
                    </div>
                    <div class="card-body">
                        <div class="col-md-12 col-xl-12">
                            <a class="buttonLinks" href="../hebrew/words-content.aspx?type=5">
                                <div class="card py-2 py-md-1 border">
                                    <div class="card-body text-center">
                                        <strong>מילים שהוספתי בעצמי </strong>
                                        <span id="selfAddedSpan" runat="server" class="badge bg-primary badge-size">0</span>
                                    </div>
                                </div>
                            </a>
                        </div>
                        <div class="col-md-12 col-xl-12">
                            <a class="buttonLinks" href="../hebrew/words-content.aspx?type=6">
                                <div class="card py-2 py-md-1 border">
                                    <div class="card-body text-center">
                                        <strong>מילים שעשיתי לייק </strong>
                                        <span id="wordsLikedSpan" runat="server" class="badge bg-primary badge-size">0</span>
                                    </div>
                                </div>
                            </a>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>

    <!-- Modal -->
    <div class="modal fade" id="addCategory" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" dir="rtl" lang="he">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close float-left" data-dismiss="modal" aria-label="Close">

                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body" dir="rtl" lang="he">
                    <h4>הוסף קטוריה:</h4>
                    <br />
                    <asp:TextBox class="form-control CategoryTextBoxClass" placeholder="שם הקטגוריה" ID="CategoryTextBox" runat="server"></asp:TextBox>
                    <span id="categorySpan" class="displayNone">xxxx</span>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">סגור</button>
                    <asp:Button ID="CategoryButton" CssClass="btn btn-primary" runat="server" Text="הוסף קטגוריה" OnClick="AddCategoryButton" OnClientClick="return categoryValidation();"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JsHolder" runat="server">
    <script src="../js-hebrew/deleteCategory.js?2"></script>
</asp:Content>
