﻿using NstuOnline.BFF.Domain.Entity;

namespace NstuOnline.BFF.Application.Features.Auth.GetToken
{
    public class GetTokenResponse
    {
        public GetTokenResponse(User user, 
            string role, 
            string token
        )
        {
            Id = user.Id;
           // FullName = user.FullName;
            EmailAddress = user.Email;
            Token = token;
            Role = role;
        }

        public string Id { get; set; }
       // public string FullName { get; set; 
        public string EmailAddress { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}