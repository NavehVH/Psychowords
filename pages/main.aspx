<%@ Page Title="" Language="C#" MasterPageFile="~/master-pages/main.Master" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="Psychometric.master_pages.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/website.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid p-0" dir="rtl" lang="he">

        <!-- home page with user satistics -->
        <h1 class="h3 mb-3">עמוד בית</h1>

        <div class="row">
            <div class="col-xl-12 col-xxl-12 d-flex">
                <div class="w-100">
                    <div class="row">
                        <div class="col-sm-3">
                            <div class="card">
                                <div class="card-body">
                                    <h5 class="card-title mb-4">כל המילים שלי</h5>
                                    <h1 class="mt-1 mb-3" id="allWordsSpan" runat="server">1,433</h1>
                                    <div class="mb-1">
                                        <span class="text-muted displayNone">מאז שבוע שעבר</span>
                                        <span class="text-success displayNone"><i class="mdi mdi-arrow-bottom-right"></i>5.25% </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="card">
                                <div class="card-body">
                                    <h5 class="card-title mb-4">מילים שאני יודע</h5>
                                    <h1 class="mt-1 mb-3" id="knownWordsSpan" runat="server">1,433</h1>
                                    <div class="mb-1">
                                        <span class="text-muted displayNone">מאז שבוע שעבר</span>
                                        <span class="text-danger displayNone"><i class="mdi mdi-arrow-bottom-right"></i>3.65%- </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="card">
                                <div class="card-body">
                                    <h5 class="card-title mb-4">מילים שאני בקושי יודע</h5>
                                    <h1 class="mt-1 mb-3" id="almostKnownWordsSpan" runat="server">1,433</h1>
                                    <div class="mb-1">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="card">
                                <div class="card-body">
                                    <h5 class="card-title mb-4">מילים שאני לא יודע</h5>
                                    <h1 class="mt-1 mb-3" id="unknownWordsSpan" runat="server">1,433</h1>
                                    <div class="mb-1">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
						
                </div>
            </div>

            <div class="col-12 col-lg-12 displayNone">
							<div class="card flex-fill w-100">
								<div class="card-header">
									<h5 class="card-title">גרף התקדמות</h5>
									<h6 class="card-subtitle text-muted">גרך המראה את ההתקדמות שלך ב30 הימים האחרונים</h6>
								</div>
								<div class="card-body">
									<div class="chart">
										<canvas id="chartjs-line"></canvas>
									</div>
								</div>
							</div>
						</div>
        </div>

    </div>

    <script src="../js-pages/line-chart.js"></script>
</asp:Content>
