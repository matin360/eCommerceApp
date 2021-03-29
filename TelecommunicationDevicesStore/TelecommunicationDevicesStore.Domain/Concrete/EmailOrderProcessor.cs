using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TelecommunicationDevicesStore.Domain.Data;

namespace TelecommunicationDevicesStore.Domain.Concrete
{
    //public class EmailSettings
    //{
    //    public string MailToAddress = "orders@example.com";
    //    public string MailFromAddress = "gamestore@example.com";
    //    public bool UseSsl = true;
    //    public string Username = "MySmtpUsername";
    //    public string Password = "MySmtpPassword";
    //    public string ServerName = "smtp.example.com";
    //    public int ServerPort = 587;
    //    public bool WriteAsFile = true;
    //    public string FileLocation = @"c:\telecom_store_emails";
    //}
    //public class EmailOrderProcessor
    //{
    //    private EmailSettings emailSettings;

    //    public EmailOrderProcessor(EmailSettings settings)
    //    {
    //        emailSettings = settings;
    //    }

    //    public void ProcessOrder(Cart cart, ShippingDetails shippingInfo)
    //    {
    //        using (var smtpClient = new SmtpClient())
    //        {
    //            smtpClient.EnableSsl = emailSettings.UseSsl;
    //            smtpClient.Host = emailSettings.ServerName;
    //            smtpClient.Port = emailSettings.ServerPort;
    //            smtpClient.UseDefaultCredentials = false;
    //            smtpClient.Credentials
    //                = new NetworkCredential(emailSettings.Username, emailSettings.Password);

    //            if (emailSettings.WriteAsFile)
    //            {
    //                smtpClient.DeliveryMethod
    //                    = SmtpDeliveryMethod.SpecifiedPickupDirectory;
    //                smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
    //                smtpClient.EnableSsl = false;
    //            }

    //            StringBuilder body = new StringBuilder()
    //                .AppendLine("New order ready")
    //                .AppendLine("---")
    //                .AppendLine("Products:");

    //            foreach (var line in cart.Lines)
    //            {
    //                var subtotal = line.Product.Price * line.Quantity;
    //                body.AppendFormat("{0} x {1} (total: {2:c}",
    //                    line.Quantity, line.Product.Name, subtotal);
    //            }

    //            body.AppendFormat("Total price: {0:c}", cart.ComputeTotalValue())
    //                .AppendLine("---")
    //                .AppendLine("Shipping:")
    //                .AppendLine(shippingInfo.Name)
    //                .AppendLine(shippingInfo.Line1)
    //                .AppendLine(shippingInfo.Line2 ?? "")
    //                .AppendLine(shippingInfo.Line3 ?? "")
    //                .AppendLine(shippingInfo.City)
    //                .AppendLine(shippingInfo.Country)
    //                .AppendLine("---")
    //                .AppendFormat("The gift wrap: {0}",
    //                    shippingInfo.GiftWrap ? "Yes" : "No");

    //            MailMessage mailMessage = new MailMessage(
    //                                   emailSettings.MailFromAddress,
    //                                   emailSettings.MailToAddress,
    //                                   "New order shipped!",
    //                                   body.ToString());

    //            if (emailSettings.WriteAsFile)
    //            {
    //                mailMessage.BodyEncoding = Encoding.UTF8;
    //            }

    //            smtpClient.Send(mailMessage);
    //        }
    //    }
    //}
}
