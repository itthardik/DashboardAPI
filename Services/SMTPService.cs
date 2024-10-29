using Dashboard.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace Dashboard.Services
{
    /// <summary>
    /// Email Sender class for Papercut SMTP
    /// </summary>
       
    public class SMTPService
    {
        private readonly string _Host;
        private readonly int _Port;

        /// <summary>
        /// Email sender constructor
        /// </summary>
        public SMTPService()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            _Host = configuration.GetValue<string>("AppConstraint:Host")!;
            _Port = configuration.GetValue<int>("AppConstraint:Port");
        }

        /// <summary>
        /// Send Email message
        /// </summary>
        private void SendEmail(string senderEmail, string reciverEmail, string subject, string body)
        {
            var client = new SmtpClient(_Host, _Port)
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                EnableSsl = false
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(senderEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(reciverEmail);
            client.Send(mailMessage);
        }
        /// <summary>
        /// Request Supplier for stocks
        /// </summary>
        /// <param name="reciver"></param>
        /// <param name="product"></param>
        /// <param name="stockRequire"></param>
        /// <param name="user"></param>
        public void SendInventoryRequest(Supplier reciver, Product product, int stockRequire, User user) {
            string subject = $"Urgent Restock Needed for {product.Name} (ID: {product.Id})";
            string body = $@"<!DOCTYPE html>
                            <html>
                            <head>
                                <title>Restock Notification</title>
                                <style>
                                    body{{
                                        font-family: Arial, sans-serif;
                                        font-size: 16px;
                                        color: #333;
                                        line-height: 1.6;
                                    }}
                                    p {{
                                        margin: 0 0 15px;
                                    }}
                                    ul {{
                                        margin: 0 0 15px;
                                        padding-left: 20px;
                                    }}
                                    li {{
                                        margin-bottom: 10px;
                                    }}
                                    strong {{
                                        color: #000;
                                    }}
                                </style>
                            </head>
                            <body>
                                <p>Dear {reciver.Name},</p>

                                <p>I’ve updated the stock for <strong>{product.Name}</strong> (ID: <strong>{product.Id}</strong>) on our website, and it is now running low. We require an urgent restock to maintain availability.</p>

                                <ul>
                                    <li><strong>Current Stock</strong>: {product.CurrentStock}</li>
                                    <li><strong>Quantity Needed</strong>: {stockRequire}</li>
                                </ul>

                                <p>Please confirm the delivery date at your earliest convenience.</p>

                                <p>Thank you for your prompt attention.</p>

                                <p>Best regards,<br>{user.Username}<br>{user.Email}</p>
                            </body>
                            </html";

            SendEmail("inventory@hm.com", reciver.ContactInfo, subject, body);
        }
    }
}

