using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using SmartAgriculture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Identity.Command.ForgotPassword
{
    public class ForgotPasswordCommandHandler(ILogger<ForgotPasswordCommandHandler> logger,
        UserManager<User> _userManager,
        IEmailSender _emailSender) : IRequestHandler<ForgotPasswordCommand,bool>
    {   

        public async Task<bool> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            //if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
            //{
            //    // Don't reveal if user exists or not
            //    return false;
            //}

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

            var resetLink = $"https://yourfrontend.com/reset-password?email={request.Email}&code={encodedToken}";

            var message = $@"
                        <div style='font-family: Arial, sans-serif; padding: 20px; background-color: #f4f4f4;'>
                            <div style='max-width: 600px; margin: auto; background-color: #ffffff; padding: 30px; border-radius: 10px; box-shadow: 0 2px 8px rgba(0,0,0,0.05);'>
                                <h2 style='color: #2c3e50;'>Reset Your Password</h2>
                                <p>Hello,</p>
                                <p>We received a request to reset the password for your account. If you did not request this, please disregard this email.</p>
                                <p>To reset your password, please click the button below:</p>
                                <p style='text-align: center; margin: 30px 0;'>
                                    <a href='{resetLink}' 
                                       style='background-color: #007BFF; color: white; padding: 12px 24px; text-decoration: none; 
                                              border-radius: 5px; font-weight: bold; display: inline-block;'>
                                        Reset Password
                                    </a>
                                </p>
                                <p>If the button above doesn't work, copy and paste the following link into your browser:</p>
                                <p style='word-break: break-all;'><a href='{resetLink}'>{resetLink}</a></p>
                                <hr style='margin-top: 40px;' />
                                <p style='font-size: 12px; color: #888;'>This email was sent from the Online Bus Ticketing System. Please do not reply.</p>
                            </div>
                        </div>
                    ";

            try
            {
                await _emailSender.SendEmailAsync(request.Email, "Password Reset", message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to send reset password email.");
                return false;
            }

            return true;
        }
    }
}
