using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;

namespace ITGateWorkDesk.Business
{
    public class Email
    {
        #region private_members
        private string _userName;
        private string _password;
        private string _host;
        private string _from;
        private List<string> _to;
        private List<string> _cc;
        private List<string> _bc;
        private string _subject;
        private bool _isBodyHtml;
        private List<string> _attatchments;
        private MailMessage _eMail;
        private String _emailBody;
        private int _port;
        private bool _enableSSl;

        #endregion

        #region public_Setters_getters
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Host
        {
            get { return _host; }
            set { _host = value; }
        }

        public string From
        {
            get { return _from; }
            set { _from = value; }
        }



        public List<string> To
        {
            get { return _to ?? (_to = new List<string>()); }
            set { _to = value; }
        }

        public List<string> Cc
        {
            get { return _cc ?? (_cc = new List<string>()); }
            set { _cc = value; }
        }

        public List<string> Bc
        {
            get { return _bc ?? (_bc = new List<string>()); }
            set { _bc = value; }
        }

        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public bool IsBodyHtml
        {
            get { return _isBodyHtml; }
            set { _isBodyHtml = value; }
        }

        public List<string> Attatchments
        {
            get { return _attatchments ?? (_attatchments = new List<string>()); }
            set { _attatchments = value; }
        }

        public String EmailBody
        {
            get { return _emailBody; }
            set { _emailBody = value; }
        }

        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }

        public bool EnableSSl
        {
            get { return _enableSSl; }
            set { _enableSSl = value; }
        }
        #endregion

        #region Constructors
        public Email() { }

        public Email(string userName, string password, string host, int port, string from,
            List<string> to, List<string> cc, List<string> bc,
            string subject, string emailBody, bool enableSSl = true, bool isBodyHtml = true)
        {
            this._userName = userName;
            this._password = password;
            this._host = host;
            this._from = from;
            this._to = to;
            this._cc = cc;
            this._bc = bc;
            this._subject = subject;
            this._isBodyHtml = isBodyHtml;
            this._emailBody = emailBody;
            this._port = port;
            this._enableSSl = enableSSl;
        }
        #endregion
        public void Send()
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = this._host;

            NetworkCredential creditial = new NetworkCredential(_userName, _password);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Port = _port;
            smtpClient.Credentials = creditial;
            smtpClient.EnableSsl = _enableSSl;

            _eMail = new MailMessage();
            MailAddress addres = new MailAddress(_from);
            _eMail.From = addres;
            _eMail.Subject = _subject;
            _eMail.Body = _emailBody;
            _eMail.IsBodyHtml = _isBodyHtml;
            AddToToEmail();
            AddCcToEmail();
            AddbcToEmail();
            AddAttatchmentsToEmail();
            if (EmailChecked())
            {
                smtpClient.Send(_eMail);
            }
        }

        private bool EmailChecked()
        {
            bool result = false;
            if (_from.Length > 0 && _to != null && _to.Count > 0)
                result = true;
            return result;
        }

        private void AddAttatchmentsToEmail()
        {

            if (this._attatchments != null && this._attatchments.Count > 0)
            {
                for (int i = 0; i < _attatchments.Count; i++)
                {
                    Attachment attatchment = new Attachment(this._attatchments.ElementAt(i));
                    _eMail.Attachments.Add(attatchment);
                }
            }


        }
        private void AddbcToEmail()
        {
            if (this._bc != null && this._bc.Count > 0)
            {
                for (int i = 0; i < _bc.Count; i++)
                {
                    MailAddress address = new MailAddress(this._bc.ElementAt(i));
                    _eMail.Bcc.Add(address);
                }
            }
        }
        private void AddCcToEmail()
        {
            if (this._cc != null && this._cc.Count > 0)
            {
                for (int i = 0; i < _cc.Count; i++)
                {
                    MailAddress address = new MailAddress(this._bc.ElementAt(i));
                    _eMail.CC.Add(address);
                }
            }
        }
        private void AddToToEmail()
        {
            if (this._to != null && this._to.Count > 0)
            {
                for (int i = 0; i < _to.Count; i++)
                {
                    MailAddress address = new MailAddress(this._to.ElementAt(i));
                    _eMail.To.Add(address);
                }
            }
        }
    }
}