using MetroFramework.Forms;
using Newtonsoft.Json.Linq;
using RESTUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace pr3
{
    public partial class Form2 : MetroForm
    {
        Rest rj = new Rest("http://ist.rit.edu/api");
        Rest rjGoogle = new Rest("http://info.google.com/api");
        Employment emp;
        Graduate grad;
        private People people;
        Undergrad undergrad;
        minor minor;
        Footer footer;
        Research Research;
        resources resource;
        News istnews;
        public Form2()
        {
            InitializeComponent();
            Populate();

        }

        private void Populate()
        {
            // get About information
            string jsonAbout = rj.getRestData("/about/");
            // need a way to get the JSON form into an About object
            About about = JToken.Parse(jsonAbout).ToObject<About>();
            // start displaying the About object information on the screen

            /*About*/
            metroTextBox1.Text = "\t\t\t" + about.title.ToUpper() + "\r\n\r\n" + about.description;
            quote.Text = about.quote + "\r\n\r\n" + "- " + about.quoteAuthor;


            /*Employment*/
            string jsonEmp = rj.getRestData("/employment/");
            emp = JToken.Parse(jsonEmp).ToObject<Employment>();


            /*Graduate*/
            string jsonGrad = rj.getRestData("/degrees/graduate/");
            grad = JToken.Parse(jsonGrad).ToObject<Graduate>();


            /*Undergraduate*/
            string jsonUnderGrad = rj.getRestData("/degrees/undergraduate/");
            undergrad = JToken.Parse(jsonUnderGrad).ToObject<Undergrad>();


            /*Minors*/
            string jsonMinor = rj.getRestData("/minors/");
            minor = JToken.Parse(jsonMinor).ToObject<minor>();


            /*People*/
            string jsonPeople = rj.getRestData("/people/");
            people = JToken.Parse(jsonPeople).ToObject<People>();


            /*Footer*/
            string jsonFooter = rj.getRestData("/footer");
            footer = JToken.Parse(jsonFooter).ToObject<Footer>();

            /*Research*/
            string jsonReseach = rj.getRestData("/research");
            Research = JToken.Parse(jsonReseach).ToObject<Research>();

            /*Resource*/
            string jsonResource = rj.getRestData("/resources");
            resource = JToken.Parse(jsonResource).ToObject<resources>();

            /*News*/
            string jsonNews = rj.getRestData("/news");
            istnews = JToken.Parse(jsonNews).ToObject<News>();

            //creating list view for co-op table
            metroListView1.View = View.Details;
            metroListView1.GridLines = true;
            metroListView1.FullRowSelect = true;

            metroListView1.Columns.Add("Employer", 150);
            metroListView1.Columns.Add("Degree", 100);
            metroListView1.Columns.Add("City", 125);
            metroListView1.Columns.Add("Term", 75);

            //creating list view for professional table
            metroListView2.View = View.Details;
            metroListView2.GridLines = true;
            metroListView2.FullRowSelect = true;

            metroListView2.Columns.Add("Employer", 150);
            metroListView2.Columns.Add("Degree", 100);
            metroListView2.Columns.Add("City", 120);
            metroListView2.Columns.Add("title", 125);
            metroListView2.Columns.Add("startDate", 75);

            //tweets
            htmlPanel2.Text = footer.social.tweet.ToString();
            htmlPanel2.Text += "\r\n\r\n" + footer.social.by.ToString() + "\r\n\r\n";
            //copyright
            htmlPanel1.Text = footer.copyright.html.ToString().Replace("&nbsp;", " ");


            //displaying emp content
            for (int i = 0; i < emp.introduction.content.Count; i++)
            {
                employmentcontent.Text = emp.introduction.content[i].description.ToString() + "\r\n";
                i++;
                cooperativecontent.Text = emp.introduction.content[i].description.ToString() + "\r\n";
            }

            //textboxes for degree statistics
            for (int i = 0; i < emp.degreeStatistics.statistics.Count; i++)
            {
                metroTextBox2.Text = emp.degreeStatistics.statistics[i].value + "\r\n\r\n";
                metroTextBox2.Text += emp.degreeStatistics.statistics[i].description.ToString() + "\r\n\r\n";
                i++;

                metroTextBox3.Text = emp.degreeStatistics.statistics[i].value + "\r\n\r\n";
                metroTextBox3.Text += emp.degreeStatistics.statistics[i].description.ToString() + "\r\n\r\n";
                i++;

                metroTextBox4.Text = emp.degreeStatistics.statistics[i].value + "\r\n\r\n";
                metroTextBox4.Text += emp.degreeStatistics.statistics[i].description.ToString() + "\r\n\r\n";
                i++;

                metroTextBox5.Text = emp.degreeStatistics.statistics[i].value + "\r\n\r\n";
                metroTextBox5.Text += emp.degreeStatistics.statistics[i].description.ToString() + "\r\n\r\n";
                i++;

            }

            //text box for all grad degrees
            for (var i = 0; i < grad.graduate.Count - 1; i++)
            {
                degreename1.Text = "\t" + grad.graduate[i].degreeName.ToUpper().ToString() + "\r\n\r\n";
                degreename1.Text += grad.graduate[i].title.ToString() + "\r\n\r\n";
                degreename1.Text += grad.graduate[i].description.ToString() + "\r\n\r\n";
                i++;

                degreename2.Text = "\t" + grad.graduate[i].degreeName.ToUpper().ToString() + "\r\n\r\n";
                degreename2.Text += grad.graduate[i].title.ToString() + "\r\n\r\n";
                degreename2.Text += grad.graduate[i].description.ToString() + "\r\n\r\n";
                i++;

                degreename3.Text = "\t" + grad.graduate[i].degreeName.ToUpper().ToString() + "\r\n\r\n";
                degreename3.Text += grad.graduate[i].title.ToString() + "\r\n\r\n";
                degreename3.Text += grad.graduate[i].description.ToString() + "\r\n\r\n";
                i++;
            }

            //text box for all undergrad degrees
            for (var i = 0; i < undergrad.undergraduate.Count; i++)
            {

                udegree1.Text = "\t" + undergrad.undergraduate[i].degreeName.ToUpper().ToString() + "\r\n\r\n";
                udegree1.Text += undergrad.undergraduate[i].title.ToString() + "\r\n\r\n";
                udegree1.Text += undergrad.undergraduate[i].description.ToString() + "\r\n\r\n";
                i++;

                udegree2.Text = "\t" + undergrad.undergraduate[i].degreeName.ToUpper().ToString() + "\r\n\r\n";
                udegree2.Text += undergrad.undergraduate[i].title.ToString() + "\r\n\r\n";
                udegree2.Text += undergrad.undergraduate[i].description.ToString() + "\r\n\r\n";
                i++;

                udegree3.Text = "\t" + undergrad.undergraduate[i].degreeName.ToUpper().ToString() + "\r\n\r\n";
                udegree3.Text += undergrad.undergraduate[i].title.ToString() + "\r\n\r\n";
                udegree3.Text += undergrad.undergraduate[i].description.ToString() + "\r\n\r\n";

            }
            //text box for all minor degrees
            for (var i = 0; i < minor.UgMinors.Count; i++)
            {
                minor1.Text = "\t" + minor.UgMinors[i].name.ToUpper().ToString() + "\r\n\r\n";
                minor1.Text += minor.UgMinors[i].title.ToString() + "\r\n\r\n";
                minor1.Text += minor.UgMinors[i].description.ToString() + "\r\n\r\n";
                minor1.Text += "Courses :" + "\r\n";
                foreach (string j in minor.UgMinors[i].courses)
                {
                    minor1.Text += j + "\r\n\r\n";
                }
                minor1.Text += "Note :" + minor.UgMinors[i].note.ToString() + "\r\n";
                i++;

                minor2.Text = "\t" + minor.UgMinors[i].name.ToUpper().ToString() + "\r\n\r\n";
                minor2.Text += minor.UgMinors[i].title.ToString() + "\r\n\r\n";
                minor2.Text += minor.UgMinors[i].description.ToString() + "\r\n\r\n";
                minor2.Text += "Courses :" + "\r\n";
                foreach (string j in minor.UgMinors[i].courses)
                {
                    minor2.Text += j + "\r\n\r\n";
                }
                minor2.Text += "Note :" + minor.UgMinors[i].note.ToString() + "\r\n";
                i++;

                minor3.Text = "\t" + minor.UgMinors[i].name.ToUpper().ToString() + "\r\n\r\n";
                minor3.Text += minor.UgMinors[i].title.ToString() + "\r\n\r\n";
                minor3.Text += minor.UgMinors[i].description.ToString() + "\r\n\r\n";
                minor3.Text += "Courses :" + "\r\n";
                foreach (string j in minor.UgMinors[i].courses)
                {
                    minor3.Text += j + "\r\n\r\n";
                }
                minor3.Text += "Note :" + minor.UgMinors[i].note.ToString() + "\r\n";
                i++;

                minor4.Text = "\t" + minor.UgMinors[i].name.ToUpper().ToString() + "\r\n\r\n";
                minor4.Text += minor.UgMinors[i].title.ToString() + "\r\n\r\n";
                minor4.Text += minor.UgMinors[i].description.ToString() + "\r\n\r\n";
                minor4.Text += "Courses :" + "\r\n";
                foreach (string j in minor.UgMinors[i].courses)
                {
                    minor4.Text += j + "\r\n\r\n";
                }
                minor4.Text += "Note :" + minor.UgMinors[i].note.ToString() + "\r\n";
                i++;

                minor5.Text = "\t" + minor.UgMinors[i].name.ToUpper().ToString() + "\r\n\r\n";
                minor5.Text += minor.UgMinors[i].title.ToString() + "\r\n\r\n";
                minor5.Text += minor.UgMinors[i].description.ToString() + "\r\n\r\n";
                minor5.Text += "Courses :" + "\r\n";
                foreach (string j in minor.UgMinors[i].courses)
                {
                    minor5.Text += j + "\r\n\r\n";
                }
                minor5.Text += "Note :" + minor.UgMinors[i].note.ToString() + "\r\n";
                i++;

                minor6.Text = "\t" + minor.UgMinors[i].name.ToUpper().ToString() + "\r\n\r\n";
                minor6.Text += minor.UgMinors[i].title.ToString() + "\r\n\r\n";
                minor6.Text += minor.UgMinors[i].description.ToString() + "\r\n\r\n";
                minor6.Text += "Courses :" + "\r\n";
                foreach (string j in minor.UgMinors[i].courses)
                {
                    minor6.Text += j + "\r\n\r\n";
                }
                minor6.Text += "Note :" + minor.UgMinors[i].note.ToString() + "\r\n";
                i++;

                minor7.Text = "\t" + minor.UgMinors[i].name.ToUpper().ToString() + "\r\n\r\n";
                minor7.Text += minor.UgMinors[i].title.ToString() + "\r\n\r\n";
                minor7.Text += minor.UgMinors[i].description.ToString() + "\r\n\r\n";
                minor7.Text += "Courses :" + "\r\n";
                foreach (string j in minor.UgMinors[i].courses)
                {
                    minor7.Text += j + "\r\n\r\n";
                }
                minor7.Text += "Note :" + minor.UgMinors[i].note.ToString() + "\r\n";
                i++;

                minor8.Text = "\t" + minor.UgMinors[i].name.ToUpper().ToString() + "\r\n\r\n";
                minor8.Text += minor.UgMinors[i].title.ToString() + "\r\n\r\n";
                minor8.Text += minor.UgMinors[i].description.ToString() + "\r\n\r\n";
                minor8.Text += "Courses :" + "\r\n";
                foreach (string j in minor.UgMinors[i].courses)
                {
                    minor8.Text += j + "\r\n\r\n";
                }
                minor8.Text += "Note :" + minor.UgMinors[i].note.ToString() + "\r\n";

            }

            /*Dynamically creating People-Faculty tab*/
            int n = people.faculty.Count();
            Label la = new Label();
            la.BackColor = Color.Transparent;
            la.ForeColor = Color.Bisque;
            la.Size = new Size(250, 30);
            la.Location = new Point(10, 20);
            la.Text = "Click on the picture to know more";
            Faculty.Controls.Add(la);
            PictureBox[] pictureBox = new PictureBox[n];
            for (int i = 0; i < people.faculty.Count; i++)
            {

                pictureBox[i] = new PictureBox();
                //designig picture box
                pictureBox[i].Size = new Size(250, 220);
                System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
                gp.AddEllipse(0, 0, pictureBox[i].Width - 1, pictureBox[i].Height - 1);
                Region rg = new Region(gp);
                pictureBox[i].Region = rg;
                pictureBox[i].SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox[i].Location = new Point(i * 316, 50);
                pictureBox[i].ImageLocation = people.faculty[i].imagePath;
                pictureBox[i].Text = people.faculty[i].name;
                pictureBox[i].MouseClick += buttonclick;//triggers function
                Faculty.Controls.Add(pictureBox[i]);
                Faculty.AutoScroll = true;
            }

            /*Dynamically creating People-Staff tab*/
            int num = people.staff.Count();
            Label lb = new Label();
            lb.BackColor = Color.Transparent;
            lb.ForeColor = Color.Bisque;
            lb.Size = new Size(250, 30);
            lb.Location = new Point(10, 20);
            lb.Text = "Click on the picture to know more";
            staff.Controls.Add(lb);
            PictureBox[] staffpictureBox = new PictureBox[num];
            for (int i = 0; i < people.staff.Count; i++)
            {

                staffpictureBox[i] = new PictureBox();
                //designig picture box
                staffpictureBox[i].Size = new Size(250, 220);
                System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
                gp.AddEllipse(0, 0, staffpictureBox[i].Width - 1, staffpictureBox[i].Height - 1);
                Region rg = new Region(gp);
                staffpictureBox[i].Region = rg;
                staffpictureBox[i].SizeMode = PictureBoxSizeMode.StretchImage;
                staffpictureBox[i].Location = new Point(i * 316, 50);
                staffpictureBox[i].ImageLocation = people.staff[i].imagePath;
                staffpictureBox[i].Text = people.staff[i].name;
                staffpictureBox[i].MouseClick += staffbuttonclick;//triggers function
                staff.Controls.Add(staffpictureBox[i]);
                staff.AutoScroll = true;
            }
        }/*Populate ends here*/

        /// <summary>
        /// Displays Staff details
        /// </summary>
        /// <param name="name"></param>
        private void getStaffInfo(string name)
        {
            for (int i = 0; i < people.staff.Count; i++)
            {
                if (people.staff[i].name == name)
                {
                    MessageBox.Show("Name is :" + people.staff[i].name + "\r\n" +
                                    "Email is :" + people.staff[i].email + "\r\n" +
                                    "website is :" + people.staff[i].website + "\r\n" +
                                    "office is :" + people.staff[i].office + "\r\n" +
                                    "tagline is :" + people.staff[i].tagline + "\r\n" +
                                    "title is :" + people.staff[i].title);
                                    
                }
            }
        }
        /// <summary>
        /// get called when user clicks on button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void staffbuttonclick(object sender, MouseEventArgs e)
        {
            var btn = (PictureBox)sender;
            Console.WriteLine("btn that got here is " + btn.Text);
            getStaffInfo(btn.Text);
        }

        /// <summary>
        /// Displays Faculty info
        /// </summary>
        /// <param name="name"></param>
        private void getInfo(string name)
        {
            for (int i = 0; i < people.faculty.Count; i++)
            {
                if (people.faculty[i].name == name)
                {
                    MessageBox.Show("Name is :" + people.faculty[i].name + "\r\n" +
                                    "Email is :" + people.faculty[i].email + "\r\n" +
                                    "website is :" + people.faculty[i].website + "\r\n" +
                                    "office is :" + people.faculty[i].office + "\r\n" +
                                    "tagline is :" + people.faculty[i].tagline +"\r\n"+
                                    "interestArea :"+people.faculty[i].interestArea +"\r\n"+
                                    "title is :"+ people.faculty[i].title);
                }
            }
        }
        /// <summary>
        /// get called when button clicked on people-faculty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonclick(object sender, MouseEventArgs e)
        {
            var btn = (PictureBox)sender;
            Console.WriteLine("btn that got here is " + btn.Text);
            getInfo(btn.Text);
        }

        /*Resources page starts*/
        
        /// <summary>
        ////coop enrollment displays
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void coopenrollment_Click(object sender, EventArgs e)
        {
            Form coopform = new Form();
            coopform.StartPosition = FormStartPosition.CenterScreen;
            coopform.AutoScroll = true;

            TextBox tx = new TextBox();
            tx.Text = resource.coopEnrollment.title;
            foreach (EnrollmentInformationContent i in resource.coopEnrollment.enrollmentInformationContent)
            {
                tx.Text += i.title + "\r\n\r\n";
                tx.Text += i.description + "\r\n\r\n";
            }
            tx.Multiline = true;
            tx.Size = new Size(500, 500);
            tx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            tx.BackColor = Color.Gray;
            coopform.Size = new Size(500, 600);
            coopform.Controls.Add(tx);
            coopform.Show();
        }
        
        /// <summary>
        /// displays tutor info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tutor_Click(object sender, EventArgs e)
        {
            Form tutorForm = new Form();
            tutorForm.StartPosition = FormStartPosition.CenterScreen;
            tutorForm.AutoScroll = true;
            TextBox tx = new TextBox();
            tx.Text = resource.tutorsAndLabInformation.title + "\r\n\r\n" + resource.tutorsAndLabInformation.description + "\r\n\r\n" + resource.tutorsAndLabInformation.tutoringLabHoursLink;
            tx.Multiline = true;
            tx.Size = new Size(500, 600);
            tx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            tx.BackColor = Color.Gray;
            tutorForm.Size = new Size(500, 600);
            tutorForm.Controls.Add(tx);
            tutorForm.Show();
        }

        /// <summary>
        /// displays student advising
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advise_Click(object sender, EventArgs e)
        {
            Form adviseForm = new Form();
            adviseForm.StartPosition = FormStartPosition.CenterScreen;
            adviseForm.AutoScroll = true;
            TextBox tx = new TextBox();
            tx.Text = resource.studentServices.title + "\r\n\r\n" + resource.studentServices.academicAdvisors.title + "\r\n\r\n" +
            resource.studentServices.academicAdvisors.description + "\r\n\r\n";

            LinkLabel linklable = new LinkLabel();
            linklable.Text = resource.studentServices.academicAdvisors.faq.title + "\r\n\r\n";
            linklable.Location = new Point(140, 173);
            linklable.Click += new System.EventHandler(this.linklable_LinkClicked);
            tx.Controls.Add(linklable);

            tx.Text += resource.studentServices.professonalAdvisors.title + "\r\n\r\n";
            foreach (var i in resource.studentServices.professonalAdvisors.advisorInformation)
            {
                tx.Text += i.name + "\r\n";
                tx.Text += i.department + "\r\n";
                tx.Text += i.email + "\r\n\r\n";
            }
            tx.Text += resource.studentServices.facultyAdvisors.title + "\r\n\r\n" +
            resource.studentServices.facultyAdvisors.description + "\r\n\r\n";
            tx.Text += resource.studentServices.istMinorAdvising.title + "\r\n\r\n";
            foreach (var a in resource.studentServices.istMinorAdvising.minorAdvisorInformation)
            {
                tx.Text += a.title + "\r\n\r\n" + a.advisor + "\r\n" + a.email;
            }

            tx.Multiline = true;
            tx.Size = new Size(500, 1100);
            tx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            tx.BackColor = Color.Gray;
            adviseForm.Size = new Size(500, 600);
            adviseForm.Controls.Add(tx);
            adviseForm.Show();

        }
        private void linklable_LinkClicked(object sender, EventArgs e)

        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://ist.rit.edu/assets/includes/resources/calls.php?area=advising");
            Process.Start(sInfo);
        }
        /// <summary>
        /// disaplys student ambassadors
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroTile8_Click(object sender, EventArgs e)
        {
            Form ambForm = new Form();
            ambForm.StartPosition = FormStartPosition.CenterScreen;
            ambForm.AutoScroll = true;
            TextBox tx = new TextBox();
            tx.Text = resource.studentAmbassadors.title + "\r\n\r\n\r\n\r\n\r\n\r\n";
            PictureBox p = new PictureBox();
            p.ImageLocation = "http://ist.rit.edu/assets/img/resources/Ambassadors.jpg";
            p.Location = new Point(100, 20);
            p.SizeMode = PictureBoxSizeMode.StretchImage;
            p.Visible = true;

            tx.Controls.Add(p);
            foreach (var i in resource.studentAmbassadors.subSectionContent)
            {
                tx.Text += i.title + "\r\n" + i.description + "\r\n\r\n";
            }

            LinkLabel lb = new LinkLabel();

            lb.Text = "applicationForm";
            lb.Location = new Point(100, 690);
            lb.Click += new System.EventHandler(this.lb_LinkClicked);
            tx.Controls.Add(lb);
            tx.Text += resource.studentAmbassadors.note;
            tx.Multiline = true;
            tx.Size = new Size(500, 900);
            tx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            ambForm.Size = new Size(500, 600);
            ambForm.Controls.Add(tx);
            ambForm.Show();
        }
        private void lb_LinkClicked(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://goo.gl/forms/PIL1T1JGdm");
            Process.Start(sInfo);
        }

        /// <summary>
        /// disaplys study abroad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void studyAbroad_Click(object sender, EventArgs e)
        {

            Form studyForm = new Form();
            studyForm.StartPosition = FormStartPosition.CenterScreen;
            studyForm.AutoScroll = true;
            TextBox tx = new TextBox();
            tx.Text = resource.studyAbroad.title + "\r\n\r\n" + resource.studyAbroad.description + "\r\n\r\n";
            foreach (var i in resource.studyAbroad.places)
            {
                tx.Text += i.nameOfPlace + "\r\n" + i.description + "\r\n\r\n";
            }
            tx.Multiline = true;
            tx.Size = new Size(500, 600);
            tx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            tx.BackColor = Color.Gray;
            studyForm.Size = new Size(500, 600);
            studyForm.Controls.Add(tx);
            studyForm.Show();
        }
        /// <summary>
        /// displays map in web as well as on screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void map_Click(object sender, EventArgs e)
        {
            Form f = new Form();
            WebBrowser web = new WebBrowser();
            web.ScriptErrorsSuppressed = true;
            web.Size = new Size(650, 500);
            web.Navigate("http://ist.rit.edu/api/map");
            f.Size = new Size(700, 500);
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Controls.Add(web);
            global::System.Diagnostics.Process.Start("http://ist.rit.edu/api/map");
            f.ShowDialog();

        }
        /// <summary>
        /// sets value for co-op table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showlistview_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < emp.coopTable.coopInformation.Count; i++)
            {
                // create an object to add information into the List View
                ListViewItem item = new ListViewItem(new String[]
                {
                    emp.coopTable.coopInformation[i].employer,
                    emp.coopTable.coopInformation[i].degree,
                    emp.coopTable.coopInformation[i].city,
                    emp.coopTable.coopInformation[i].term
                });
                metroListView1.Items.Add(item);
            }
        }
        /// <summary>
        /// sets value for professsional employment table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButton2_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < emp.employmentTable.professionalEmploymentInformation.Count; i++)
            {
                // create an object to add information into the List View
                ListViewItem item = new ListViewItem(new String[]
                {
                    emp.employmentTable.professionalEmploymentInformation[i].employer,
                    emp.employmentTable.professionalEmploymentInformation[i].degree,
                    emp.employmentTable.professionalEmploymentInformation[i].city,
                    emp.employmentTable.professionalEmploymentInformation[i].title,
                    emp.employmentTable.professionalEmploymentInformation[i].startDate

                });
                metroListView2.Items.Add(item);
            }
        }
        /// <summary>
        /// grad concentrations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroLink1_Click(object sender, EventArgs e)
        {
            TextBox txtrun = new TextBox(); //dynamically creating a text box to hold concentrations
            txtrun.Name = "textDynamic";
            for (var i = 0; i < grad.graduate[0].concentrations.Count; i++)
            {
                txtrun.AppendText("> " + grad.graduate[0].concentrations[i] + "\r\n");
              
            }
            txtrun.Location = new Point(24, 367);
            txtrun.Size = new Size(150, 100);
            txtrun.Multiline = true;
            Graduate.Controls.Add(txtrun);
        }
        /// <summary>
        /// grad concentrations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroLink2_Click(object sender, EventArgs e)
        {
            TextBox txtrun = new TextBox(); //dynamically creating a text box to hold concentrations
            txtrun.Name = "textDynamic";
            for (var i = 0; i < grad.graduate[1].concentrations.Count; i++)
            {

                txtrun.AppendText("> " + grad.graduate[1].concentrations[i] + "\r\n");
            }
            txtrun.Location = new Point(320, 367);
            txtrun.Size = new Size(150, 100);
            txtrun.ReadOnly = true;
            txtrun.Multiline = true;
            Graduate.Controls.Add(txtrun);

        }
        /// <summary>
        /// grad concentrations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroLink3_Click(object sender, EventArgs e)
        {
            TextBox txtrun = new TextBox(); //dynamically creating a text box to hold concentrations
            txtrun.Name = "textDynamic";
            for (var i = 0; i < grad.graduate[2].concentrations.Count; i++)
            {
                txtrun.AppendText("> " + grad.graduate[2].concentrations[i] + "\r\n");

            }
            txtrun.Location = new Point(557, 367);
            txtrun.Size = new Size(150, 100);
            txtrun.ReadOnly = true;
            txtrun.Multiline = true;
            Graduate.Controls.Add(txtrun);
        }
        /// <summary>
        /// undergrad concentrations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroLink4_Click(object sender, EventArgs e)
        {
            TextBox txtrun = new TextBox(); //dynamically creating a text box to hold concentrations
            txtrun.Name = "textDynamic";
            for (var i = 0; i < undergrad.undergraduate[0].concentrations.Count; i++)
            {
                txtrun.AppendText("> " + undergrad.undergraduate[0].concentrations[i] + "\r\n");

            }
            txtrun.Location = new Point(63, 366);
            txtrun.Size = new Size(150, 100);
            txtrun.Multiline = true;
            txtrun.ReadOnly = true;
            UnderGraduate.Controls.Add(txtrun);
        }
        /// <summary>
        /// undergrad concentrations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroLink5_Click(object sender, EventArgs e)
        {
            TextBox txtrun = new TextBox(); //dynamically creating a text box to hold concentrations
            txtrun.Name = "textDynamic";
            for (var i = 0; i < undergrad.undergraduate[1].concentrations.Count; i++)
            {
                txtrun.AppendText("> " + undergrad.undergraduate[1].concentrations[i] + "\r\n");

            }
            txtrun.Location = new Point(333, 366);
            txtrun.Size = new Size(150, 100);
            txtrun.Multiline = true;
            UnderGraduate.Controls.Add(txtrun);
        }
        /// <summary>
        /// undergrad concentrations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroLink6_Click(object sender, EventArgs e)
        {
            TextBox txtrun = new TextBox(); //dynamically creating a text box to hold concentrations
            txtrun.Name = "textDynamic";
            for (var i = 0; i < undergrad.undergraduate[2].concentrations.Count; i++)
            {
                txtrun.AppendText("> " + undergrad.undergraduate[2].concentrations[i] + "\r\n");

            }
            txtrun.Location = new Point(588, 366);
            txtrun.Size = new Size(150, 100);
            txtrun.ReadOnly = true;
            txtrun.Multiline = true;
            UnderGraduate.Controls.Add(txtrun);
        }
        /// <summary>
        /// minor concentrations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButton1_Click(object sender, EventArgs e)
        {
            Form minorForm1 = new Form();
            minorForm1.StartPosition = FormStartPosition.CenterScreen;
            TextBox minorText1 = new TextBox();
            minorText1.Multiline = true;
            minorText1.Size = new Size(500, 500);
            minorText1.ScrollBars = ScrollBars.Both;
            minorText1.ReadOnly = true;
            minorText1.BackColor = Color.Beige;
            for (var i = 0; i < minor.UgMinors[0].courses.Count; i++)
            {
                minorText1.Text += minor.UgMinors[0].courses[i] + "\r\n";

            }
            minorForm1.Controls.Add(minorText1);
            minorForm1.ShowDialog();
        }
        /// <summary>
        /// minor concentrations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void interest1_Click(object sender, EventArgs e)
        {
            Form hciForm = new Form();
            hciForm.Text = "Details";
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            tx.ReadOnly = true;
            hciForm.StartPosition = FormStartPosition.CenterParent;
            tx.BackColor = Color.BlanchedAlmond;
            hciForm.AutoScroll = true;
            tx.Text = Research.byInterestArea[0].areaName + "\r\n\r\n";
            foreach (string i in Research.byInterestArea[0].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            hciForm.Controls.Add(tx);
            hciForm.ShowDialog();
        }
        /// <summary>
        /// minor concentrations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void interest2_Click(object sender, EventArgs e)
        {
            Form geoForm = new Form();
            geoForm.Text = "Details";
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            tx.ReadOnly = true;
            geoForm.StartPosition = FormStartPosition.CenterParent;
            tx.BackColor = Color.BlanchedAlmond;
            geoForm.AutoScroll = true;
            tx.Text = Research.byInterestArea[2].areaName + "\r\n\r\n";
            foreach (string i in Research.byInterestArea[2].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            geoForm.Controls.Add(tx);
            geoForm.ShowDialog();
        }
        /// <summary>
        /// interst by area - Research
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void interest3_Click(object sender, EventArgs e)
        {
            Form analyticsForm = new Form();
            analyticsForm.Text = "Details";
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            tx.ReadOnly = true;
            tx.BackColor = Color.BlanchedAlmond;
            analyticsForm.StartPosition = FormStartPosition.CenterParent;
            analyticsForm.BackColor = Color.LightBlue;
            analyticsForm.AutoScroll = true;
            tx.Text = Research.byInterestArea[4].areaName + "\r\n\r\n";
            foreach (string i in Research.byInterestArea[4].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            analyticsForm.Controls.Add(tx);
            analyticsForm.ShowDialog();
        }

        private void interest4_Click(object sender, EventArgs e)
        {
            Form healthForm = new Form();
            healthForm.Text = "Details";
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            tx.ReadOnly = true;
            healthForm.StartPosition = FormStartPosition.CenterParent;
            tx.BackColor = Color.BlanchedAlmond;
            healthForm.AutoScroll = true;
            tx.Text = Research.byInterestArea[8].areaName + "\r\n\r\n";
            foreach (string i in Research.byInterestArea[8].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            healthForm.Controls.Add(tx);
            healthForm.ShowDialog();
        }

        private void interest5_Click(object sender, EventArgs e)
        {
            Form eduForm = new Form();
            eduForm.Text = "Details";
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            tx.ReadOnly = true;
            eduForm.StartPosition = FormStartPosition.CenterParent;
            tx.BackColor = Color.BlanchedAlmond;
            eduForm.AutoScroll = true;
            tx.Text = Research.byInterestArea[1].areaName + "\r\n\r\n";
            foreach (string i in Research.byInterestArea[1].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            eduForm.Controls.Add(tx);
            eduForm.ShowDialog();
        }

        private void interest6_Click(object sender, EventArgs e)
        {
            Form dbForm = new Form();
            dbForm.Text = "Details";
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            tx.ReadOnly = true;
            dbForm.StartPosition = FormStartPosition.CenterParent;
            tx.BackColor = Color.BlanchedAlmond;
            dbForm.AutoScroll = true;
            tx.Text = Research.byInterestArea[3].areaName + "\r\n\r\n";
            foreach (string i in Research.byInterestArea[3].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            dbForm.Controls.Add(tx);
            dbForm.ShowDialog();
        }

        private void interest7_Click(object sender, EventArgs e)
        {
            Form mobForm = new Form();
            mobForm.Text = "Details";
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            tx.ReadOnly = true;
            mobForm.StartPosition = FormStartPosition.CenterParent;
            tx.BackColor = Color.BlanchedAlmond;
            mobForm.AutoScroll = true;
            tx.Text = Research.byInterestArea[7].areaName + "\r\n\r\n";
            foreach (string i in Research.byInterestArea[7].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            mobForm.Controls.Add(tx);
            mobForm.ShowDialog();
        }

        private void interest8_Click(object sender, EventArgs e)
        {
            Form netForm = new Form();
            netForm.Text = "Details";
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            netForm.StartPosition = FormStartPosition.CenterParent;
            tx.BackColor = Color.BlanchedAlmond;
            tx.ReadOnly = true;
            netForm.AutoScroll = true;
            tx.Text = Research.byInterestArea[6].areaName + "\r\n\r\n";
            foreach (string i in Research.byInterestArea[6].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            netForm.Controls.Add(tx);
            netForm.ShowDialog();
        }

        private void interest9_Click(object sender, EventArgs e)
        {
            Form progForm = new Form();
            progForm.Text = "Details";
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            tx.ReadOnly = true;
            progForm.StartPosition = FormStartPosition.CenterParent;
            progForm.BackColor = Color.LightBlue;
            tx.ScrollBars = ScrollBars.Both;
            tx.Text = Research.byInterestArea[9].areaName + "\r\n\r\n";
            foreach (string i in Research.byInterestArea[9].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            progForm.Controls.Add(tx);
            progForm.ShowDialog();
        }

        private void interest10_Click(object sender, EventArgs e)
        {
            Form Form = new Form();
            Form.Text = "Details";
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            tx.ReadOnly = true;
            Form.StartPosition = FormStartPosition.CenterParent;
            tx.BackColor = Color.BlanchedAlmond;
            tx.ScrollBars = ScrollBars.Both;
            tx.Text = Research.byInterestArea[11].areaName + "\r\n\r\n";
            foreach (string i in Research.byInterestArea[11].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            Form.Controls.Add(tx);
            Form.ShowDialog();
        }

        private void interest11_Click(object sender, EventArgs e)
        {
            Form webForm = new Form();
            webForm.Text = "Details";
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            tx.ReadOnly = true;
            webForm.StartPosition = FormStartPosition.CenterParent;
            webForm.BackColor = Color.LightBlue;
            tx.ScrollBars = ScrollBars.Both;
            tx.Text = Research.byInterestArea[5].areaName + "\r\n\r\n";
            foreach (string i in Research.byInterestArea[5].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            webForm.Controls.Add(tx);
            webForm.ShowDialog();
        }

        private void interest12_Click(object sender, EventArgs e)
        {
            Form sysForm = new Form();
            sysForm.Text = "Details";
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            tx.ReadOnly = true;
            sysForm.StartPosition = FormStartPosition.CenterParent;
            tx.BackColor = Color.BlanchedAlmond;
            tx.ScrollBars = ScrollBars.Both;
            tx.Text = Research.byInterestArea[10].areaName + "\r\n\r\n";
            foreach (string i in Research.byInterestArea[10].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            sysForm.Controls.Add(tx);
            sysForm.ShowDialog();
        }
        /// <summary>
        /// dispalys contact form in web page as well as on screen 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contact_Click(object sender, EventArgs e)
        {
            Form contactForm = new Form();
            WebBrowser web = new WebBrowser();
            web.Size = new Size(500, 500);
            web.ScriptErrorsSuppressed = true;
            web.Navigate("http://ist.rit.edu/api/contactForm/");
            contactForm.Size = new Size(500, 500);
            contactForm.StartPosition = FormStartPosition.CenterScreen;
            contactForm.Controls.Add(web);
            global::System.Diagnostics.Process.Start("http://ist.rit.edu/api/contactForm/");
            contactForm.ShowDialog();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            global::System.Diagnostics.Process.Start("http://www.rit.edu/admission.html");

        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            global::System.Diagnostics.Process.Start("http://ist.rit.edu/assets/includes/resources/calls.php?area=tutors");


        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            global::System.Diagnostics.Process.Start("http://ist.rit.edu/assets/includes/calls/calls.php?area=supportIST");

        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            global::System.Diagnostics.Process.Start("http://ist.rit.edu/assets/includes/calls/calls.php?area=aboutSite");

        }
        /// <summary>
        /// research by faculty starts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form pic1 = new Form();
            pic1.Text = "Details";
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            tx.ReadOnly = true;
            pic1.StartPosition = FormStartPosition.CenterParent;
            pic1.BackColor = Color.LightBlue;
            pic1.AutoScroll = true;
            tx.Text = Research.byFaculty[0].facultyName + "\r\n\r\n";
            foreach (string i in Research.byFaculty[0].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            pic1.Controls.Add(tx);
            pic1.ShowDialog();
        }

        private void fac2_Click(object sender, EventArgs e)
        {
            Form pi2 = new Form();
            pi2.Text = "Details";
            TextBox tx = new TextBox();
            tx.ReadOnly = true;
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            pi2.StartPosition = FormStartPosition.CenterParent;
            pi2.BackColor = Color.LightBlue;
            pi2.AutoScroll = true;
            tx.Text = Research.byFaculty[1].facultyName + "\r\n\r\n";
            foreach (string i in Research.byFaculty[1].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            pi2.Controls.Add(tx);
            pi2.ShowDialog();
        }

        private void fac3_Click(object sender, EventArgs e)
        {
            Form pic3 = new Form();
            pic3.Text = "Details";
            TextBox tx = new TextBox();
            tx.ReadOnly = true;
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            pic3.StartPosition = FormStartPosition.CenterParent;
            pic3.BackColor = Color.LightBlue;
            pic3.AutoScroll = true;
            tx.Text = Research.byFaculty[2].facultyName + "\r\n\r\n";
            foreach (string i in Research.byFaculty[2].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            pic3.Controls.Add(tx);
            pic3.ShowDialog();
        }

        private void fac4_Click(object sender, EventArgs e)
        {
            Form pic4 = new Form();
            pic4.Text = "Details";
            TextBox tx = new TextBox();
            tx.ReadOnly = true;
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            pic4.StartPosition = FormStartPosition.CenterParent;
            pic4.BackColor = Color.LightBlue;
            pic4.AutoScroll = true;
            tx.Text = Research.byFaculty[3].facultyName + "\r\n\r\n";
            foreach (string i in Research.byFaculty[3].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            pic4.Controls.Add(tx);
            pic4.ShowDialog();
        }

        private void fac5_Click(object sender, EventArgs e)
        {
            Form pic5 = new Form();
            pic5.Text = "Details";
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.ReadOnly = true;
            tx.Size = new Size(800, 800);
            pic5.StartPosition = FormStartPosition.CenterParent;
            pic5.BackColor = Color.LightBlue;
            pic5.AutoScroll = true;
            tx.Text = Research.byFaculty[4].facultyName + "\r\n\r\n";
            foreach (string i in Research.byFaculty[4].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            pic5.Controls.Add(tx);
            pic5.ShowDialog();
        }

        private void fac6_Click(object sender, EventArgs e)
        {
            Form pic6 = new Form();
            pic6.Text = "Details";
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            tx.ReadOnly = true;
            pic6.StartPosition = FormStartPosition.CenterParent;
            pic6.BackColor = Color.LightBlue;
            pic6.AutoScroll = true;
            tx.Text = Research.byFaculty[5].facultyName + "\r\n\r\n";
            foreach (string i in Research.byFaculty[5].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            pic6.Controls.Add(tx);
            pic6.ShowDialog();
        }

        private void fac7_Click(object sender, EventArgs e)
        {
            Form pic7 = new Form();
            pic7.Text = "Details";
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            tx.ReadOnly = true;
            pic7.StartPosition = FormStartPosition.CenterParent;
            pic7.BackColor = Color.LightBlue;
            pic7.AutoScroll = true;
            tx.Text = Research.byFaculty[6].facultyName + "\r\n\r\n";
            foreach (string i in Research.byFaculty[6].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            pic7.Controls.Add(tx);
            pic7.ShowDialog();
        }

        private void fac8_Click(object sender, EventArgs e)
        {
            Form pic8 = new Form();
            pic8.Text = "Details";
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            tx.ReadOnly = true;
            pic8.StartPosition = FormStartPosition.CenterParent;
            pic8.BackColor = Color.LightBlue;
            pic8.AutoScroll = true;
            tx.Text = Research.byFaculty[7].facultyName + "\r\n\r\n";
            foreach (string i in Research.byFaculty[7].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            pic8.Controls.Add(tx);
            pic8.ShowDialog();
        }

        private void fac9_Click(object sender, EventArgs e)
        {
            Form pic9 = new Form();
            pic9.Text = "Details";
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            tx.ReadOnly = true;
            pic9.StartPosition = FormStartPosition.CenterParent;
            pic9.BackColor = Color.LightBlue;
            pic9.AutoScroll = true;
            tx.Text = Research.byFaculty[8].facultyName + "\r\n\r\n";
            foreach (string i in Research.byFaculty[8].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            pic9.Controls.Add(tx);
            pic9.ShowDialog();
        }

        private void fac10_Click(object sender, EventArgs e)
        {
            Form pic10 = new Form();
            pic10.Text = "Details";
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            tx.ReadOnly = true;
            pic10.StartPosition = FormStartPosition.CenterParent;
            pic10.BackColor = Color.LightBlue;
            pic10.AutoScroll = true;
            tx.Text = Research.byFaculty[9].facultyName + "\r\n\r\n";
            foreach (string i in Research.byFaculty[9].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            pic10.Controls.Add(tx);
            pic10.ShowDialog();
        }

        private void fac11_Click(object sender, EventArgs e)
        {
            Form pic11 = new Form();
            pic11.Text = "Details";
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            tx.ReadOnly = true;
            pic11.StartPosition = FormStartPosition.CenterParent;
            pic11.BackColor = Color.LightBlue;
            pic11.AutoScroll = true;
            tx.Text = Research.byFaculty[10].facultyName + "\r\n\r\n";
            foreach (string i in Research.byFaculty[10].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            pic11.Controls.Add(tx);
            pic11.ShowDialog();
        }

        private void fac12_Click(object sender, EventArgs e)
        {
            Form pic12 = new Form();
            pic12.Text = "Details";
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            tx.ReadOnly = true;
            pic12.StartPosition = FormStartPosition.CenterParent;
            pic12.BackColor = Color.LightBlue;
            pic12.AutoScroll = true;
            tx.Text = Research.byFaculty[11].facultyName + "\r\n\r\n";
            foreach (string i in Research.byFaculty[11].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            pic12.Controls.Add(tx);
            pic12.ShowDialog();
        }

        private void fac13_Click(object sender, EventArgs e)
        {
            Form pic13 = new Form();
            pic13.Text = "Details";
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            tx.ReadOnly = true;
            pic13.StartPosition = FormStartPosition.CenterParent;
            pic13.BackColor = Color.LightBlue;
            pic13.AutoScroll = true;
            tx.Text = Research.byFaculty[12].facultyName + "\r\n\r\n";
            foreach (string i in Research.byFaculty[12].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            pic13.Controls.Add(tx);
            pic13.ShowDialog();
        }

        private void fac14_Click(object sender, EventArgs e)
        {
            Form pic14 = new Form();
            pic14.Text = "Details";
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            tx.ReadOnly = true;
            pic14.StartPosition = FormStartPosition.CenterParent;
            pic14.BackColor = Color.LightBlue;
            pic14.AutoScroll = true;
            tx.Text = Research.byFaculty[13].facultyName + "\r\n\r\n";
            foreach (string i in Research.byFaculty[13].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            pic14.Controls.Add(tx);
            pic14.ShowDialog();
        }

        private void fac15_Click(object sender, EventArgs e)
        {
            Form pic15 = new Form();
            pic15.Text = "Details";
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            tx.ReadOnly = true;
            pic15.StartPosition = FormStartPosition.CenterParent;
            pic15.BackColor = Color.LightBlue;
            pic15.AutoScroll = true;
            tx.Text = Research.byFaculty[14].facultyName + "\r\n\r\n";
            foreach (string i in Research.byFaculty[14].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            pic15.Controls.Add(tx);
            pic15.ShowDialog();
        }

        private void fac16_Click(object sender, EventArgs e)
        {
            Form pic16 = new Form();
            pic16.Text = "Details";
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            pic16.StartPosition = FormStartPosition.CenterParent;
            pic16.BackColor = Color.LightBlue;
            pic16.AutoScroll = true;
            tx.Text = Research.byFaculty[15].facultyName + "\r\n\r\n";
            foreach (string i in Research.byFaculty[15].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            pic16.Controls.Add(tx);
            pic16.ShowDialog();
        }

        private void fac17_Click(object sender, EventArgs e)
        {
            Form pic17 = new Form();
            pic17.Text = "Details";
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            tx.ReadOnly = true;
            pic17.StartPosition = FormStartPosition.CenterParent;
            pic17.BackColor = Color.LightBlue;
            pic17.AutoScroll = true;
            tx.Text = Research.byFaculty[16].facultyName + "\r\n\r\n";
            foreach (string i in Research.byFaculty[16].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            pic17.Controls.Add(tx);
            pic17.ShowDialog();
        }

        private void fac18_Click(object sender, EventArgs e)
        {
            Form pic18 = new Form();
            pic18.Text = "Details";
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            tx.ReadOnly = true;
            pic18.StartPosition = FormStartPosition.CenterParent;
            pic18.BackColor = Color.LightBlue;
            pic18.AutoScroll = true;
            tx.Text = Research.byFaculty[17].facultyName + "\r\n\r\n";
            foreach (string i in Research.byFaculty[17].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            pic18.Controls.Add(tx);
            pic18.ShowDialog();
        }

        private void fac19_Click(object sender, EventArgs e)
        {
            Form pic19 = new Form();
            pic19.Text = "Details";
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            tx.ReadOnly = true;
            pic19.StartPosition = FormStartPosition.CenterParent;
            pic19.BackColor = Color.LightBlue;
            pic19.AutoScroll = true;
            tx.Text = Research.byFaculty[18].facultyName + "\r\n\r\n";
            foreach (string i in Research.byFaculty[18].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            pic19.Controls.Add(tx);
            pic19.ShowDialog();
        }

        private void fac20_Click(object sender, EventArgs e)
        {
            Form pic20 = new Form();
            pic20.Text = "Details";
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            tx.ReadOnly = true;
            pic20.StartPosition = FormStartPosition.CenterParent;
            pic20.BackColor = Color.LightBlue;
            pic20.AutoScroll = true;
            tx.Text = Research.byFaculty[19].facultyName + "\r\n\r\n";
            foreach (string i in Research.byFaculty[19].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            pic20.Controls.Add(tx);
            pic20.ShowDialog();
        }

        private void fac21_Click(object sender, EventArgs e)
        {
            Form pic21 = new Form();
            pic21.Text = "Details";
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.Size = new Size(800, 800);
            tx.ReadOnly = true;
            pic21.StartPosition = FormStartPosition.CenterParent;
            pic21.BackColor = Color.LightBlue;
            pic21.AutoScroll = true;
            tx.Text = Research.byFaculty[20].facultyName + "\r\n\r\n";
            foreach (string i in Research.byFaculty[20].citations)
            {
                tx.Text += i + "\r\n\r\n";
            }
            pic21.Controls.Add(tx);
            pic21.ShowDialog();
        }
        /// <summary>
        /// displays form for news data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void news_Click_1(object sender, EventArgs e)
        {
            Form news = new Form();
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.Size = new Size(800, 1800);
            tx.ForeColor = Color.Snow;
            tx.ReadOnly = true;
            news.AutoScroll = true;
            news.StartPosition = FormStartPosition.CenterParent;
            tx.BackColor = Color.DarkSlateGray;
            foreach (var i in istnews.year)
            {
                tx.Text += i.date + "\r\n\r\n";
                tx.Text += i.title + "\r\n\r\n";
                tx.Text += i.description + "\r\n\r\n";
            }
            news.Controls.Add(tx);
            news.ShowDialog();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            global::System.Diagnostics.Process.Start("https://twitter.com/istatrit");

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            global::System.Diagnostics.Process.Start("https://www.facebook.com/ISTatRIT");
        }
    }
}
