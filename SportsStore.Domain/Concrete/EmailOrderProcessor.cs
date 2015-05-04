using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SportsStore.Domain.Abstract;
using System.Net.Mail;
using System.Net;

namespace SportsStore.Domain.Concrete
{
	public class EmailOrderProcessor : IOrderProcessor
	{
		private EmailSettings _emailSettings;

		public EmailOrderProcessor(EmailSettings settings)
		{
			_emailSettings = settings;
		}

		public void ProcessOrder(Entities.Cart cart, Entities.ShippingDetails shippingDetails)
		{
			using (var smtp = new SmtpClient())
			{
				smtp.EnableSsl = _emailSettings.UseSsl;
				smtp.Host = _emailSettings.ServerName;
				smtp.Port = _emailSettings.ServerPort;
				smtp.UseDefaultCredentials = false;
				smtp.Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password);

				if (_emailSettings.WriteAsFile)
				{
					smtp.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
					smtp.PickupDirectoryLocation = _emailSettings.FileLocation;
					smtp.EnableSsl = false;
				}

				StringBuilder body = new StringBuilder()
				.AppendLine("A new order has been submitted")
				.AppendLine("---")
				.AppendLine("Items:");

				foreach (var line in cart.Lines)
				{
					var subtotal = line.Product.Price * line.Quantity;
					body.AppendFormat("{0} x {1} (subtotal: {2:c}", line.Quantity, line.Product.Name, subtotal);
				}

				body.AppendFormat("Total order value: {0:c}", cart.ComputeTotalValue())
					.AppendLine("---")
					.AppendLine("Ship to:")
					.AppendLine(shippingDetails.Name)
					.AppendLine(shippingDetails.Line1 ?? "")
					.AppendLine(shippingDetails.Line2 ?? "")
					.AppendLine(shippingDetails.Line3 ?? "")
					.AppendLine(shippingDetails.City)
					.AppendLine(shippingDetails.State ?? "")
					.AppendLine(shippingDetails.Country)
					.AppendLine(shippingDetails.Zip)
					.AppendLine("---")
					.AppendFormat("Gift wrap: {0}", shippingDetails.GiftWrap ? "Yes" : "No");

				MailMessage msg = new MailMessage(_emailSettings.MailFromAddress, _emailSettings.MailToAddress, "New order submitted!", body.ToString());

				if (_emailSettings.WriteAsFile)
				{
					msg.BodyEncoding = Encoding.ASCII;
				}

				smtp.Send(msg);
			}
		}
	}
}
