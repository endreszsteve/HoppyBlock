using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class mono_gmail : MonoBehaviour 
{
    private MailMessage mail = new MailMessage();

    [SerializeField]
    private string email;
    [SerializeField]
    private string password;

    [SerializeField]
    private Text fromEmail;
    [SerializeField]
    private Text subject;
    [SerializeField]
    private Text feedback;

    [SerializeField]
    private Image errorBox;
    private bool formIncomplete = false;
    private float errorTime = 3;
    private float timer = 0;

    public void Submit()
    {
        if (fromEmail.text.Length > 1 && subject.text.Length > 1 && feedback.text.Length > 1)
        {
            mail.From = new MailAddress(email);
            mail.To.Add(email);
            mail.Subject = subject.text;
            mail.IsBodyHtml = true;
            mail.Body = "From: " + fromEmail.text + "<br/><br/><h2>" + subject.text + "<h2/><br/><br/><p>Feedback:<p> " + feedback.text;

            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            smtpServer.Port = 587;
            smtpServer.Credentials = new System.Net.NetworkCredential(email, password) as ICredentialsByHost;
            smtpServer.EnableSsl = true;
            ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            smtpServer.Send(mail);
            Sent();
        }
        else
        {
            formIncomplete = true;
            errorBox.gameObject.SetActive(true);
            timer = 0;
        }
    }

    private void Sent()
    {
        subject.text = " ";
        feedback.text = " ";
        Debug.Log("Mail Sent");
    }

    void Update()
    {
        if(formIncomplete == true)
        {
            timer += Time.deltaTime;
            if(timer >= errorTime)
            {
                timer = 0;
                formIncomplete = false;
                errorBox.gameObject.SetActive(false);
            }
        }
    }
}
