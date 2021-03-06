﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsStore.Domain.Concrete
{
	public class EmailSettings
	{
		public EmailSettings()
		{
			MailToAddress = "orders@example.com";
			MailFromAddress = "sportsstore@example.com";
			UseSsl = true;
			Username = "MySmtpUsername";
			Password = "MySmtpPassword";
			ServerName = "smtp.example.com";
			ServerPort = 587;
			WriteAsFile = false;
			FileLocation = @"c:\sport_store_emails";
		}

		public string MailToAddress { get; set; }
		public string MailFromAddress { get; set; }
		public bool UseSsl { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string ServerName { get; set; }
		public int ServerPort { get; set; }
		public bool WriteAsFile { get; set; }
		public string FileLocation { get; set; }
	}
}
