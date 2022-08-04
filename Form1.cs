using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.IO;


namespace aysenurkoycu
{
    public partial class FormMainMenu : Form
    {
        
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        

        public void dosyaac()
        {
            StreamWriter sw = new StreamWriter("d:\\kullanicilistesi.txt");
            sw.Close();
        }
        public void dosyayaz()
        {
            StreamWriter writer = File.AppendText("d:\\kullanicilistesi.txt");
            writer.WriteLine("zx.mopafk@gmail.com\n"
                 + "as.mopafk@gmail.com\n" +
                 "qw.mopafk@gmail.com\n" +
                 "rt.mopafk@gmail.com\n" +
                 "ty.mopafk@gmail.com\n" +
                 "yu.mopafk@gmail.com\n" +
                 "uı.mopafk@gmail.com\n" +
                 "bn.mopafk@gmail.com");
            

            



            writer.Close();
        }
        public void dosyalistele()
        {
            StreamReader sr = File.OpenText("d:\\kullanicilistesi.txt");
            List<string> satirlarList = new List<string>();
            string satir = null;

            while ((satir = sr.ReadLine()) != null)
            {

                satirlarList.Add(satir);
                
            }
            foreach (string s in satirlarList)
            {
                kime = s;
            }
            sr.Close();
        }
        public static string kime, baslik, mesaj;

        async public void mailgonderyangin()
        {
            StreamReader sr = File.OpenText("d:\\kullanicilistesi.txt");
            List<string> satirlarList = new List<string>();
            string satir = null;

            while ((satir = sr.ReadLine()) != null)
            {

                satirlarList.Add(satir);
                

            }
            foreach (string s in satirlarList)
            {
                kime = s;
                baslik = "YANGIN ALARMI";
                mesaj = "TESİSTE YANGIN ALARMI VERİLDİ. İTFAİYE VE AMBULANS EKİPLERİNE HABER VERİLDİ.";
                await Task.Run(sender);


            }
            sr.Close();
            
        }
        async private void mailgonderhirsiz()
        {
            StreamReader sr = File.OpenText("d:\\kullanicilistesi.txt");
            List<string> satirlarList = new List<string>();
            string satir = null;

            while ((satir = sr.ReadLine()) != null)
            {

                satirlarList.Add(satir);
                

            }
            foreach (string s in satirlarList)
            {
                kime = s;
                baslik = "HIRSIZ ALARMI";
                mesaj = "TESİSTE HIRSIZ ALARMI VERİLDİ. POLİS EKİPLERİNE HABER VERİLDİ.";
                await Task.Run(sender);


            }
            sr.Close();
            
        }
        public async Task sender()
        {
            MailMessage mesajım = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("aysenurkycdeneme@gmail.com", "123456C#");
            istemci.Port = 587;
            istemci.Host = "smtp.gmail.com";
            mesajım.To.Add(kime);
            mesajım.From = new MailAddress("aysenurkycdeneme@gmail.com");
            mesajım.Subject = baslik;
            mesajım.Body = mesaj;
            istemci.EnableSsl = true;
            istemci.Send(mesajım);
        }
        async public void mailgonderbaglantihatasi()
        {
            
            StreamReader sr = File.OpenText("d:\\kullanicilistesi.txt");
            List<string> satirlarList = new List<string>();
            string satir = null;
           

            while ((satir = sr.ReadLine()) != null)
            {
                satirlarList.Add(satir);



            }
            foreach (string s in satirlarList)
            {
                kime = s;
                baslik = "BAGLANTI HATASI";
                mesaj = "TESİSTE BAĞLANTI HATASI ALARMI VERİLDİ. ARIZA EKİPLERİNE HABER VERİLDİ.";
                await Task.Run(sender);


            }
            sr.Close();
            
        }

        public FormMainMenu()
        {
            InitializeComponent();
            random=new Random();
            dosyaac();
            dosyayaz();
            
            
        }
        
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                }

            }

        }
        
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                }
            }
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            { 
                activeForm.Close(); 
            }
                
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void btnproducts_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormProducts(), sender);
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormOrders(), sender);
            
                    }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormCustomers(), sender);
            FormMainMenu menu = new FormMainMenu();
            menu.Show();
            this.Hide();

            
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormReport(), sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mailgonderhirsiz();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mailgonderbaglantihatasi();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StreamWriter writer = File.AppendText("d:\\kullanicilistesi.txt");
            
            writer.WriteLine(textBox1.Text);
            writer.Close();
            textBox1.Clear();

        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormNatifications(), sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mailgonderyangin();
        }
    }
}
            
            
  
        
