using MySql.Data.MySqlClient;
using Psychometric.App_Data;
using Psychometric.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Psychometric.master_pages
{
    public partial class EditWord : System.Web.UI.Page
    {

        public DataTable DefenitionsTable;
        public DataTable AssociationsTable;
        public DataTable ExamplesTable;

        public static Words WordUsed = null;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (!Autorization.CheckAutorization())
                {
                    Response.Redirect("../pages/logout.aspx");
                }

                DataTable Categories = SetAllCategories();
                foreach (DataRow r in Categories.Rows)
                {
                    CategoryDropList.Items.Add(new ListItem { Text = r[2].ToString(), Value = r[0].ToString() });
                }

                if (Request.QueryString["Id"] != null)
                {
                    int temp;
                    int get = 0;
                    if (int.TryParse(Request.QueryString["Id"], out temp))
                    {
                        get = int.Parse(Request.QueryString["Id"]);
                    }
                    WordUsed = new Words(get);
                    if (WordUsed.Id == 0 || WordUsed.Username_id != Autorization.SessionId)
                        Response.Redirect("../hebrew/self-dictionary.aspx");

                    WordTextBox.Text = WordUsed.Word;
                    WordNameLabel.Text = WordUsed.Word;
                    CategoryDropList.SelectedValue = WordUsed.Category_id.ToString();
                    ShowTextBoxData();

                }
                else
                {
                    Response.Redirect("../hebrew/self-dictionary.aspx");
                }

                DefenitionsTable = GetTableByTextBox("definitions");
                AssociationsTable = GetTableByTextBox("associations");
                ExamplesTable = GetTableByTextBox("examples");


            }
        }

        private void ShowTextBoxPanel(Control mainPanel, object[] type, object[] typeLike, TextBox firstBox)
        {
            TextBox box;
            Panel panel;
            bool visible = false;
            int index = 0;
            int indexLikes = 0;
            bool showPanel = false;

            string text = "";

            foreach (Control ctrPanels in mainPanel.Controls)
            {
                foreach (Control ctr in ctrPanels.Controls)
                {
                    if (ctr is TextBox)
                    {
                        box = (TextBox)ctr;

                        if (type.Length > index)
                        {
                            if (type[index].GetType() == typeof(Definitions))
                                text = ((Definitions)type[index]).Definition;
                            if (type[index].GetType() == typeof(Examples))
                                text = ((Examples)type[index]).Example;
                            if (type[index].GetType() == typeof(Associations))
                                text = ((Associations)type[index]).Association;

                            showPanel = true;
                            visible = true;
                            box.Style.Add(HtmlTextWriterStyle.Display, "block");
                            box.ReadOnly = true;
                            box.Text = text;
                            index++;
                        }
                        else if (typeLike.Length > indexLikes)
                        {
                            if (typeLike[indexLikes].GetType() == typeof(Definitions))
                                text = ((Definitions)typeLike[indexLikes]).Definition;
                            if (typeLike[indexLikes].GetType() == typeof(Examples))
                                text = ((Examples)typeLike[indexLikes]).Example;
                            if (typeLike[indexLikes].GetType() == typeof(Associations))
                                text = ((Associations)typeLike[indexLikes]).Association;

                            showPanel = true;
                            visible = true;
                            box.ReadOnly = true;
                            box.Style.Add(HtmlTextWriterStyle.Display, "block");
                            box.Text = text;
                            indexLikes++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (ctrPanels is Panel)
                {
                    panel = (Panel)ctrPanels;
                    if (showPanel)
                    {
                        panel.Style.Add(HtmlTextWriterStyle.Display, "flex");
                        showPanel = false;
                    }
                }
            }
            if (!visible)
                firstBox.Style.Add(HtmlTextWriterStyle.Display, "block");
            visible = false;
        }

        private void ShowTextBoxData()
        {
            WordUsed.GetFullInfo();

            ShowTextBoxPanel(TextboxPanel, WordUsed.DefinitionsList.ToArray(), WordUsed.DefinitionsLikesList.ToArray(), FirstBox1);
            ShowTextBoxPanel(TextboxPanelExamples, WordUsed.ExamplesList.ToArray(), WordUsed.ExamplesLikesList.ToArray(), FirstBox2);
            ShowTextBoxPanel(TextboxPanelAssociations, WordUsed.AssociationsList.ToArray(), WordUsed.AssociationsLikesList.ToArray(), FirstBox3);
        }

        private DataTable SetAllCategories()
        {
            DataTable dt;
            Connection c = new Connection();
            try
            {
                c.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM `categories` WHERE username_id = @username_id;", c.Con);
                msc.Parameters.AddWithValue("@username_id", Session["Id"]);
                DataSet ds = c.getDataSet(msc, "categories");
                dt = ds.Tables["categories"];
            }
            finally
            {
                c.conClose();
            }
            return dt;
        }

        [WebMethod]
        public static void AddAllLikes(int id, int type)
        {
            if (type == 1)
            {
                Definitions liked = new Definitions(id);

                Definitions newD = new Definitions();
                newD.Username_id = Autorization.SessionId;
                newD.Word_id = WordUsed.Id;
                newD.Definition = liked.Definition;
                newD.Registration_date = DateTime.UtcNow;
                newD.Ghosted = false;
                newD.Liked_id = liked.Id;
                newD.AddDefinition();
            }
            if (type == 2)
            {
                Examples liked = new Examples(id);

                Examples newE = new Examples();
                newE.Username_id = Autorization.SessionId;
                newE.Word_id = WordUsed.Id;
                newE.Example = liked.Example;
                newE.Registration_date = DateTime.UtcNow;
                newE.Ghosted = false;
                newE.Liked_id = liked.Id;
                newE.AddExample();
            }
            if (type == 3)
            {
                Associations liked = new Associations(id);

                Associations ass = new Associations();
                ass.Username_id = Autorization.SessionId;
                ass.Word_id = WordUsed.Id;
                ass.Association = liked.Association;
                ass.Registration_date = DateTime.UtcNow;
                ass.Ghosted = false;
                ass.Liked_id = liked.id;
                ass.AddAssociation();
            }
        }

        //ריראיראירא
        protected void WordTextBox_TextChanged(object sender, EventArgs e)
        {
            WordLabel.Text = WordTextBox.Text;
            HideTextBoxText();
            FoundLabel1.Text = "";
            FoundLabel2.Text = "";
            FoundLabel3.Text = "";

            if (WordTextBox.Text == "")
                return;

            Words w = new Words(WordTextBox.Text);
            if (!w.Exists())
            {
                DefenitionsTable = GetTableByTextBox("definitions");
                AssociationsTable = GetTableByTextBox("associations");
                ExamplesTable = GetTableByTextBox("examples");
                FoundLabel1.Text = "(לא נמצאו פירושים)";
                FoundLabel2.Text = "(לא נמצאו דוגמאות)";
                FoundLabel3.Text = "(לא נמצאו אסוציאציות)";
                WordAddingPanel.Update();
            }
            else
            {
                DefenitionsTable = GetTableByTextBox("definitions");
                if (DefenitionsTable.Rows.Count == 0)
                    FoundLabel1.Text = "(לא נמצאו פירושים)";
                ExamplesTable = GetTableByTextBox("examples");
                if (ExamplesTable.Rows.Count == 0)
                    FoundLabel2.Text = "(לא נמצאו דוגמאות)";
                AssociationsTable = GetTableByTextBox("associations");
                if (AssociationsTable.Rows.Count == 0)
                    FoundLabel3.Text = "(לא נמצאו אסוציאציות)";
                WordAddingPanel.Update();
            }
        }

        public DataTable GetTableByTextBox(string table)
        {
            DataTable dt;
            Connection c = new Connection();
            try
            {
                c.conOpen();
                MySqlCommand msc = new MySqlCommand(@"
SELECT ass.*, a.total, w.`language`
FROM " + table + @" ass
INNER JOIN words w
        ON ass.word_id = w.id AND w.`language` = 'hebrew'
    LEFT JOIN (
                SELECT liked_id, COUNT(liked_id) as total
                FROM " + table + @" a1
                GROUP BY liked_id
               ) a
        ON ass.id = a.liked_id
WHERE w.word = @type AND ass.liked_Id = 0 ORDER BY a.liked_id DESC LIMIT 0, 50",
    c.Con);
                msc.Parameters.AddWithValue("@type", WordTextBox.Text);
                DataSet ds = c.getDataSet(msc, table);
                dt = ds.Tables[table];
            }
            finally
            {
                c.conClose();
            }
            return dt;
        }

        private void HideTextBoxText()
        {
            HideTextBoxTextInPanel(TextboxPanel);
            HideTextBoxTextInPanel(TextboxPanelExamples);
            HideTextBoxTextInPanel(TextboxPanelAssociations);
        }

        private void HideTextBoxTextInPanel(Panel p)
        {
            TextBox box;
            Panel panel;
            bool visible = false;
            bool show = false;
            foreach (Control ctrPanel in p.Controls)
            {
                if (ctrPanel is Panel)
                {
                    foreach (Control ctr in ctrPanel.Controls)
                    {
                        if (ctr is TextBox)
                        {
                            box = (TextBox)ctr;
                            if (box.Text != "")
                            {
                                visible = true;
                                box.Style.Add(HtmlTextWriterStyle.Display, "block");
                                show = true;
                            }
                            else
                            {
                                box.Style.Add(HtmlTextWriterStyle.Display, "none");
                                show = false;
                            }
                        }
                    }

                    panel = (Panel)ctrPanel;
                    if (show)
                        panel.Style.Add(HtmlTextWriterStyle.Display, "flex");
                    else
                        panel.Style.Add(HtmlTextWriterStyle.Display, "none");
                    show = false;

                }
            }
            if (!visible)
            {
                FirstBox1.Style.Add(HtmlTextWriterStyle.Display, "block");
                FirstPanel1.Style.Add(HtmlTextWriterStyle.Display, "flex");
            }
            visible = false;
        }

        public int GetTypeLikesCount(int id, string table)
        {
            int count = 0;
            Connection con = new Connection();
            try
            {
                con.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT COUNT(*) FROM " + table + " WHERE liked_id = @liked_id");
                msc.Connection = con.Con;
                msc.Parameters.AddWithValue("@liked_id", id);
                MySqlDataReader r = msc.ExecuteReader();
                if (r.Read())
                {
                    count = r.GetInt32(0);
                }
                r.Close();
            }
            finally
            {
                con.conClose();
            }
            return count;
        }

        [WebMethod]
        public static void EditWordAjax(string WordTextBox, int lastCategoryIndex, string[] definitions, string[] examples, string[] associations, int[] defDeleteIndex, int[] exaDeleteIndex, int[] assDeleteIndex)
        {
            //Add word
            WordUsed.Category_id = lastCategoryIndex;
            Debug.WriteLine(WordUsed.Id);
            //Add definitions
            foreach (string def in definitions)
            {
                Definitions definition = new Definitions();
                definition.Username_id = Autorization.SessionId;
                definition.Word_id = WordUsed.Id;
                definition.Definition = def;
                definition.Ghosted = false;
                definition.Registration_date = DateTime.UtcNow;
                definition.AddDefinition();
            }

            //Add examples
            foreach (string exa in examples)
            {
                Examples example = new Examples();
                example.Username_id = Autorization.SessionId;
                example.Word_id = WordUsed.Id;
                example.Example = exa;
                example.Ghosted = false;
                example.Registration_date = DateTime.UtcNow;
                example.AddExample();
            }

            //Add association
            foreach (string ass in associations)
            {
                Associations association = new Associations();
                association.Username_id = Autorization.SessionId;
                association.Word_id = WordUsed.Id;
                association.Association = ass;
                association.Ghosted = false;
                association.Registration_date = DateTime.UtcNow;
                association.AddAssociation();
            }

            foreach (int defIndex in defDeleteIndex)
            {
                var combained = (WordUsed.DefinitionsList.Concat(WordUsed.DefinitionsLikesList)).ToArray();
                combained[defIndex].DeleteDefinition();
            }

            foreach (int exaIndex in exaDeleteIndex)
            {
                var combained = (WordUsed.ExamplesList.Concat(WordUsed.ExamplesLikesList)).ToArray();
                combained[exaIndex].DeleteExample();
            }

            foreach (int assIndex in assDeleteIndex)
            {
                var combained = (WordUsed.AssociationsList.Concat(WordUsed.AssociationsLikesList)).ToArray();
                combained[assIndex].DeleteAssociation();
            }
        }

        [WebMethod]
        public static int GetWordIdByNameAjax(string word)
        {
            Accounts acc = (Accounts)HttpContext.Current.Session["Account"];
            return acc.GetWordIdByName(word);
        }

        protected void DeleteSettings_ServerClick(object sender, EventArgs e)
        {
            Words w = WordUsed;
            foreach (Definitions d in w.DefinitionsList)
                d.DeleteDefinition();
            foreach (Definitions d in w.DefinitionsLikesList)
                d.DeleteDefinition();
            foreach (Examples ex in w.ExamplesList)
                ex.DeleteExample();
            foreach (Examples ex in w.ExamplesLikesList)
                ex.DeleteExample();
            foreach (Associations a in w.AssociationsList)
                a.DeleteAssociation();
            foreach (Associations a in w.AssociationsLikesList)
                a.DeleteAssociation();

            w.DeleteWord();
            Response.Redirect("../hebrew/self-dictionary.aspx");
        }
    }
}