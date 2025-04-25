using System;
using System.Windows.Forms;
using DTO;
using BLL;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace GUI
{
    public partial class Form_ForgotPassword : Form
    {
        private AccountBLL accountBLL = new AccountBLL();
        private string otpCode = "";
        private string userEmail = "";
        private DateTime otpGeneratedTime;
        private int otpAttempts = 0;
        private const int MAX_OTP_ATTEMPTS = 3;
        private const int OTP_EXPIRY_MINUTES = 10;
        private System.Windows.Forms.Timer countdownTimer;
        private bool isPasswordValid = false;

        public Form_ForgotPassword()
        {
            InitializeComponent();
            loadLanguage();

            // Initialize countdown timer
            countdownTimer = new System.Windows.Forms.Timer();
            countdownTimer.Interval = 1000; // 1 second
            countdownTimer.Tick += CountdownTimer_Tick;
            btnVerify.Enabled = false;

            // Set initial form size for step 1
            //this.Size = new System.Drawing.Size(395, 299); // Height includes title bar
        }

        private void loadLanguage()
        {
            string selectedLanguage = Language.GetCurrentLanguage();
            foreach (KeyValuePair<string, string> kvp in Language.languages)
            {
                switch (kvp.Key)
                {
                    case "Enter_Email":
                        labelEmail.Text = kvp.Value;
                        break;
                    case "Send_OTP":
                        btnSendOTP.Text = kvp.Value;
                        break;
                    case "Enter_OTP":
                        labelOTP.Text = kvp.Value;
                        break;
                    case "Verify":
                        btnVerify.Text = kvp.Value;
                        break;
                    case "New_Password":
                        labelNewPassword.Text = kvp.Value;
                        break;
                    case "Confirm_Password":
                        labelConfirmPassword.Text = kvp.Value;
                        break;
                    case "Reset_Password":
                        btnResetPassword.Text = kvp.Value;
                        break;
                }
            }
            btnSendOTP.Text = Language.GetCurrentLanguage() == "Vietnamese" ? "Gửi mã" : "Send OTP";
            txtEmail.PlaceholderText = Language.GetCurrentLanguage() == "Vietnamese" ? "Nhập email của bạn..." : "Enter your email...";
            btnVerify.Text = Language.GetCurrentLanguage() == "Vietnamese" ? "Xác nhận" : "Verify";
            txtOTP.PlaceholderText = Language.GetCurrentLanguage() == "Vietnamese" ? "Nhập mã OTP..." : "Enter OTP code...";
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan remainingTime = otpGeneratedTime.AddMinutes(OTP_EXPIRY_MINUTES) - DateTime.Now;
            if (remainingTime.TotalSeconds <= 0)
            {
                countdownTimer.Stop();
                lblCountdown.Text = Language.GetCurrentLanguage() == "Vietnamese" ? "Mã OTP đã hết hạn" : "OTP has expired";
                btnSendOTP.Enabled = true;
                btnSendOTP.Text = Language.GetCurrentLanguage() == "Vietnamese" ? "Gửi lại mã" : "Resend OTP";
                txtOTP.Enabled = false;
                btnVerify.Enabled = false;
                return;
            }

            lblCountdown.Text = Language.GetCurrentLanguage() == "Vietnamese" ?
                $"Thời gian còn lại: {remainingTime.Minutes:D2}:{remainingTime.Seconds:D2}" :
                $"Time remaining: {remainingTime.Minutes:D2}:{remainingTime.Seconds:D2}";
        }

        private void SendOTPEmail(string email, string otp)
        {
            try
            {
                // Email configuration
                string senderEmail = "hoaianduong214@gmail.com";
                string senderPassword = "yeek fkcz dhiu bkcb";
                string smtpServer = "smtp.gmail.com";
                int smtpPort = 587;

                // Create email message
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderEmail, "RentEase Support");
                mail.To.Add(email);
                mail.Subject = Language.GetCurrentLanguage() == "Vietnamese" ? "Đặt lại mật khẩu RentEase" : "RentEase Password Reset";

                // Create HTML body with exact styling match
                string htmlBody = $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <style>
        body {{ 
            font-family: Arial, sans-serif;
            line-height: 1.6;
            color: #333333;
            margin: 0;
            padding: 0;
        }}
        .container {{
            max-width: 600px;
            margin: 0 auto;
        }}
        .header {{
            background-color: #4CAF50;
            color: white;
            padding: 20px;
            text-align: center;
        }}
        .header h1 {{
            margin: 0;
            font-size: 24px;
            font-weight: normal;
        }}
        .content {{
            padding: 20px;
            background-color: #ffffff;
        }}
        .greeting {{
            color: #333;
            margin-bottom: 15px;
        }}
        .message {{
            color: #333;
            margin-bottom: 20px;
        }}
        .otp-container {{
            border: 2px dashed #4CAF50;
            padding: 20px;
            margin: 20px 0;
            text-align: center;
        }}
        .otp-code {{
            font-size: 36px;
            color: #4CAF50;
            font-weight: normal;
            margin: 0;
        }}
        .expiry {{
            color: #333;
            margin: 15px 0;
        }}
        .warning {{
            background-color: #fff2f2;
            color: #ff0000;
            padding: 15px;
            margin: 15px 0;
            border-radius: 4px;
        }}
        .signature {{
            color: #333;
            margin-top: 20px;
        }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>{(Language.GetCurrentLanguage() == "Vietnamese" ? "Đặt lại mật khẩu RentEase" : "RentEase Password Reset")}</h1>
        </div>
        <div class='content'>
            <div class='greeting'>
                {(Language.GetCurrentLanguage() == "Vietnamese" ? "Kính gửi Người dùng," : "Dear User,")}
            </div>
            
            <div class='message'>
                {(Language.GetCurrentLanguage() == "Vietnamese"
                    ? "Chúng tôi đã nhận được yêu cầu đặt lại mật khẩu cho tài khoản RentEase của bạn. Để tiến hành đặt lại mật khẩu, vui lòng sử dụng mã OTP (Mật khẩu dùng một lần) sau:"
                    : "We received a request to reset your password for your RentEase account. To proceed with the password reset, please use the following OTP (One-Time Password) code:")}
            </div>

            <div class='otp-container'>
                <div class='otp-code'>{otp}</div>
            </div>

            <div class='expiry'>
                {(Language.GetCurrentLanguage() == "Vietnamese"
                    ? $"Mã này sẽ hết hạn sau {OTP_EXPIRY_MINUTES} phút vì lý do bảo mật."
                    : $"This code will expire in {OTP_EXPIRY_MINUTES} minutes for security reasons.")}
            </div>

            <div class='warning'>
                {(Language.GetCurrentLanguage() == "Vietnamese"
                    ? "Nếu bạn không yêu cầu đặt lại mật khẩu, vui lòng bỏ qua email này hoặc liên hệ với nhóm hỗ trợ của chúng tôi nếu bạn có thắc mắc."
                    : "If you did not request this password reset, please ignore this email or contact our support team if you have concerns.")}
            </div>

            <div class='signature'>
                {(Language.GetCurrentLanguage() == "Vietnamese" ? "Trân trọng," : "Best regards,")}<br>
                {(Language.GetCurrentLanguage() == "Vietnamese" ? "Nhóm hỗ trợ RentEase" : "RentEase Support Team")}
            </div>
        </div>
    </div>
</body>
</html>";

                mail.Body = htmlBody;
                mail.IsBodyHtml = true;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.SubjectEncoding = System.Text.Encoding.UTF8;

                // Configure SMTP client
                SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

                // Send email
                smtpClient.Send(mail);
                MessageBox.Show(Language.GetCurrentLanguage() == "Vietnamese" ?
                    "Mã OTP đã được gửi đến email của bạn!" :
                    "OTP has been sent to your email!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.GetCurrentLanguage() == "Vietnamese" ?
                    $"Lỗi khi gửi email: {ex.Message}" :
                    $"Error sending email: {ex.Message}");
            }
        }

        private bool IsOTPExpired()
        {
            return (DateTime.Now - otpGeneratedTime).TotalMinutes > OTP_EXPIRY_MINUTES;
        }

        private bool ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return false;

            bool hasMinLength = password.Length >= 8;
            bool hasNumber = Regex.IsMatch(password, @"\d");
            bool hasSpecialChar = Regex.IsMatch(password, @"[!@#$%^&*(),.?""':{}|<>]");

            return hasMinLength && hasNumber && hasSpecialChar;
        }

        private void btnSendOTP_Click(object sender, EventArgs e)
        {
            btnSendOTP.Enabled = false;
            btnSendOTP.Text = Language.GetCurrentLanguage() == "Vietnamese" ? "Đang gửi..." : "Sending...";

            string userEmail = AccountBLL.CheckEmail(txtEmail.Text.Trim());
            switch (userEmail)
            {
                case "required_email":
                    MessageBox.Show(Language.GetCurrentLanguage() == "Vietnamese" ? "Vui lòng nhập email" : "Please enter your email");
                    btnSendOTP.Enabled = true;
                    btnSendOTP.Focus();
                    return;
                case "Invalid":
                    MessageBox.Show(Language.GetCurrentLanguage() == "Vietnamese" ? "Email không hợp lệ" : "Invalid email");
                    btnSendOTP.Enabled = true;
                    btnSendOTP.Focus();
                    return;
                case "Valid":
                    btnVerify.Enabled = true;
                    Random random = new Random();
                    otpCode = random.Next(100000, 999999).ToString();
                    otpGeneratedTime = DateTime.Now;
                    otpAttempts = 0;
                    SendOTPEmail(txtEmail.Text.Trim(), otpCode);

                    txtOTP.Enabled = true;
                    btnVerify.Enabled = true;
                    countdownTimer.Start();
                    break;
            }

            btnSendOTP.Enabled = true;
            btnSendOTP.Text = Language.GetCurrentLanguage() == "Vietnamese" ? "Gửi lại mã" : "Resend OTP";
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (IsOTPExpired())
            {
                MessageBox.Show(Language.GetCurrentLanguage() == "Vietnamese" ?
                    "Mã OTP đã hết hạn. Vui lòng yêu cầu mã mới." :
                    "OTP has expired. Please request a new one.");
                txtOTP.Enabled = false;
                btnVerify.Enabled = false;
                btnSendOTP.Enabled = true;
                btnSendOTP.Text = Language.GetCurrentLanguage() == "Vietnamese" ? "Gửi lại mã" : "Resend OTP";
                return;
            }

            string enteredOTP = txtOTP.Text.Trim();
            if (string.IsNullOrEmpty(enteredOTP))
            {
                MessageBox.Show(Language.GetCurrentLanguage() == "Vietnamese" ?
                    "Vui lòng nhập mã OTP!" :
                    "Please enter the OTP code!");
                return;
            }

            otpAttempts++;
            if (enteredOTP == otpCode)
            {
                countdownTimer.Stop();
                lblCountdown.Text = Language.GetCurrentLanguage() == "Vietnamese" ?
                    "Xác thực thành công!" :
                    "OTP verified successfully!";

                // Switch to password reset panel
                panelStep1.Visible = false;
                panelStep2.Visible = true;
                this.Size = new System.Drawing.Size(395, 299);

                MessageBox.Show(Language.GetCurrentLanguage() == "Vietnamese" ?
                    "Xác thực thành công! Bạn có thể đặt lại mật khẩu." :
                    "OTP verified successfully! You can now reset your password.");
            }
            else
            {
                if (otpAttempts >= MAX_OTP_ATTEMPTS)
                {
                    MessageBox.Show(Language.GetCurrentLanguage() == "Vietnamese" ?
                        $"Bạn đã vượt quá số lần thử tối đa ({MAX_OTP_ATTEMPTS}). Vui lòng yêu cầu mã OTP mới." :
                        $"You have exceeded the maximum number of attempts ({MAX_OTP_ATTEMPTS}). Please request a new OTP.");
                    txtOTP.Enabled = false;
                    btnVerify.Enabled = false;
                    btnSendOTP.Enabled = true;
                    btnSendOTP.Text = Language.GetCurrentLanguage() == "Vietnamese" ? "Gửi lại mã" : "Resend OTP";
                }
                else
                {
                    MessageBox.Show(Language.GetCurrentLanguage() == "Vietnamese" ?
                        $"Mã OTP không đúng! Bạn còn {MAX_OTP_ATTEMPTS - otpAttempts} lần thử." :
                        $"Invalid OTP code! You have {MAX_OTP_ATTEMPTS - otpAttempts} attempts remaining.");
                }
            }
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            isPasswordValid = ValidatePassword(txtNewPassword.Text);
            btnResetPassword.Enabled = isPasswordValid && !string.IsNullOrEmpty(txtConfirmPassword.Text) &&
                                     txtNewPassword.Text == txtConfirmPassword.Text;
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            btnResetPassword.Enabled = isPasswordValid && !string.IsNullOrEmpty(txtConfirmPassword.Text) &&
                                     txtNewPassword.Text == txtConfirmPassword.Text;
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            btnResetPassword.Enabled = false;
            btnResetPassword.Text = Language.GetCurrentLanguage() == "Vietnamese" ? "Đang đặt lại..." : "Resetting...";

            string result = AccountBLL.UpdatePassword(
                txtEmail.Text.Trim(),
                txtNewPassword.Text.Trim(),
                txtConfirmPassword.Text.Trim());

            if (result.StartsWith("Database error:"))
            {
                MessageBox.Show(Language.GetCurrentLanguage() == "Vietnamese" ?
                    $"Lỗi cơ sở dữ liệu: {result.Substring(15)}" :
                    $"Database problem: {result.Substring(15)}");
            }
            else if (result == "Success")
            {
                MessageBox.Show(Language.GetCurrentLanguage() == "Vietnamese" ?
                    "Đặt lại mật khẩu thành công!" :
                    "Password updated successfully!");
                this.Close();
            }
            else
            {
                MessageBox.Show(result);
            }

            btnResetPassword.Enabled = true;
            btnResetPassword.Text = Language.GetCurrentLanguage() == "Vietnamese" ? "Đặt lại mật khẩu" : "Reset Password";
        }

        private void Form_ForgotPassword_Load(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}